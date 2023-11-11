using AutoMapper;
using Donations.BLL.Services.Interfaces;
using Donations.DAL.Repositories.Interfaces;
using Donations.Data.Dtos;
using Donations.Data.Enums;
using Donations.Data.Interfaces;
using Donations.Data.Models;
using Donations.Data.Responses;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json;

namespace Donations.BLL.Services
{
    public class DonationService : IDonationService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        private IDistributedCache _cache;

        public DonationService(IUnitOfWork unitOfWork, IMapper mapper, IDistributedCache cache)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _cache = cache;
        }

        public async Task<IBaseResponse<DonationDTO>> GetById(Guid id)
        {
            var baseResponse = new BaseResponse<DonationDTO>();
            Donation? model = null;

            try
            {
                var modelString = await _cache.GetStringAsync(id.ToString());

                if (modelString != null) model = System.Text.Json.JsonSerializer.Deserialize<Donation>(modelString);

                if (model == null)
                {
                    model = await _unitOfWork.DonationRepository.GetByIdAsync(id);

                    if (model != null)
                    {
                        baseResponse.Description = "Data extracted from database";

                        modelString = System.Text.Json.JsonSerializer.Serialize(model);

                        await _cache.SetStringAsync(model.ID.ToString(), modelString, new DistributedCacheEntryOptions
                        {
                            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(2)
                        });
                    }
                    else
                    {
                        return new BaseResponse<DonationDTO>()
                        {
                            Description = $"0 objects with {id} ID found in database",
                            StatusCode = StatusCode.NotFound
                        };
                    }
                }
                else
                {
                    baseResponse.Description = "Data extracted from cache";
                }

                baseResponse.Data = _mapper.Map<DonationDTO>(model);
                baseResponse.StatusCode = StatusCode.OK;

                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<DonationDTO>()
                {
                    Description = $"{ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<IEnumerable<DonationDTO>>> GetAll()
        {
            var baseResponse = new BaseResponse<IEnumerable<DonationDTO>>();
            var modelDtoList = new List<DonationDTO>();

            string serializedModels;
            var cacheKey = "donationList";
            var redisModels = await _cache.GetAsync(cacheKey);

            try
            {
                if (redisModels != null)
                {
                    serializedModels = Encoding.UTF8.GetString(redisModels);
                    var models = JsonConvert.DeserializeObject<List<Donation>>(serializedModels);

                    if (models != null)
                    foreach (var model in models)
                    {
                        modelDtoList.Add(_mapper.Map<DonationDTO>(model));
                    }

                    baseResponse.ResultsCount = modelDtoList.Count;
                    baseResponse.Description = "Data extracted from cache";
                    baseResponse.StatusCode = StatusCode.OK;
                }
                else
                {
                    var models = await _unitOfWork.DonationRepository.GetAsync();

                    serializedModels = JsonConvert.SerializeObject(models);
                    redisModels = Encoding.UTF8.GetBytes(serializedModels);

                    var options = new DistributedCacheEntryOptions()
                        .SetAbsoluteExpiration(DateTime.Now.AddMinutes(10))
                        .SetSlidingExpiration(TimeSpan.FromMinutes(2));
                    await _cache.SetAsync(cacheKey, redisModels, options);

                    foreach (var model in models)
                    {
                        modelDtoList.Add(_mapper.Map<DonationDTO>(model));
                    }

                    if (modelDtoList.Count is 0)
                    {
                        baseResponse.Description = "0 objects found";
                        baseResponse.StatusCode = StatusCode.NotFound;
                        return baseResponse;
                    }

                    baseResponse.ResultsCount = modelDtoList.Count;
                    baseResponse.Description = "Data extracted from database";
                    baseResponse.StatusCode = StatusCode.OK;
                }

                baseResponse.Data = modelDtoList;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<DonationDTO>>()
                {
                    Description = $"{ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<string>> Insert(DonationDTO modelDto)
        {
            try
            {
                if (modelDto is not null)
                {
                    modelDto.ID = Guid.NewGuid();

                    var model = _mapper.Map<Donation>(modelDto);

                    await _unitOfWork.DonationRepository.InsertAsync(model);
                    await _unitOfWork.SaveChangesAsync();

                    return new BaseResponse<string>()
                    {
                        Description = $"Object inserted!",
                        StatusCode = StatusCode.OK
                    };
                }
                else
                {
                    return new BaseResponse<string>()
                    {
                        Description = $"Object can`t be empty...",
                        StatusCode = StatusCode.NotFound
                    };
                }
            }
            catch (Exception e)
            {
                return new BaseResponse<string>()
                {
                    Description = $"{e.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<string>> DeleteById(Guid id)
        {
            try
            {
                var model = await _unitOfWork.DonationRepository.GetByIdAsync(id);

                if (model is not null)
                {
                    await _unitOfWork.DonationRepository.DeleteAsync(id);
                    await _unitOfWork.SaveChangesAsync();

                    return new BaseResponse<string>()
                    {
                        Description = $"Object deleted!",
                        StatusCode = StatusCode.OK
                    };
                }
                else
                {
                    return new BaseResponse<string>()
                    {
                        Description = $"No object with this id...",
                        StatusCode = StatusCode.NotFound
                    };
                }
            }
            catch (Exception e)
            {
                return new BaseResponse<string>()
                {
                    Description = $"{e.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }
    }
}
