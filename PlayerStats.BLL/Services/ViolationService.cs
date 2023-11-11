using AutoMapper;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using PlayerStats.BLL.Services.Interfaces;
using PlayerStats.DAL.Repositories.Interfaces;
using PlayerStats.Data.Dtos;
using PlayerStats.Data.Enums;
using PlayerStats.Data.Interfaces;
using PlayerStats.Data.Models;
using PlayerStats.Data.Responses;
using System.Text;
using System.Text.Json;

namespace PlayerStats.BLL.Services
{
    public class ViolationService : IViolationService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        private IDistributedCache _cache;

        public ViolationService(IUnitOfWork unitOfWork, IMapper mapper, IDistributedCache cache)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _cache = cache;
        }

        public async Task<IBaseResponse<ViolationDTO>> GetById(Guid id)
        {
            var baseResponse = new BaseResponse<ViolationDTO>();
            Violation? model = null;

            try
            {
                var modelString = await _cache.GetStringAsync(id.ToString());

                if (modelString != null) model = System.Text.Json.JsonSerializer.Deserialize<Violation>(modelString);

                if (model == null)
                {
                    model = await _unitOfWork.ViolationRepository.GetByIdAsync(id);

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
                        return new BaseResponse<ViolationDTO>()
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

                baseResponse.Data = _mapper.Map<ViolationDTO>(model);
                baseResponse.StatusCode = StatusCode.OK;

                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<ViolationDTO>()
                {
                    Description = $"{ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<IEnumerable<ViolationDTO>>> GetAll()
        {
            var baseResponse = new BaseResponse<IEnumerable<ViolationDTO>>();
            var modelDtoList = new List<ViolationDTO>();

            string serializedModels;
            var cacheKey = "violationList";
            var redisModels = await _cache.GetAsync(cacheKey);

            try
            {
                if (redisModels != null)
                {
                    serializedModels = Encoding.UTF8.GetString(redisModels);
                    var models = JsonConvert.DeserializeObject<List<Violation>>(serializedModels);

                    if (models != null)
                        foreach (var model in models)
                        {
                            modelDtoList.Add(_mapper.Map<ViolationDTO>(model));
                        }

                    baseResponse.ResultsCount = modelDtoList.Count;
                    baseResponse.Description = "Data extracted from cache";
                    baseResponse.StatusCode = StatusCode.OK;
                }
                else
                {
                    var models = await _unitOfWork.ViolationRepository.GetAsync();

                    serializedModels = JsonConvert.SerializeObject(models);
                    redisModels = Encoding.UTF8.GetBytes(serializedModels);

                    var options = new DistributedCacheEntryOptions()
                        .SetAbsoluteExpiration(DateTime.Now.AddMinutes(10))
                        .SetSlidingExpiration(TimeSpan.FromMinutes(2));
                    await _cache.SetAsync(cacheKey, redisModels, options);

                    foreach (var model in models)
                    {
                        modelDtoList.Add(_mapper.Map<ViolationDTO>(model));
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
                return new BaseResponse<IEnumerable<ViolationDTO>>()
                {
                    Description = $"{ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<string>> Insert(ViolationDTO modelDto)
        {
            try
            {
                if (modelDto is not null)
                {
                    modelDto.ID = Guid.NewGuid();

                    var model = _mapper.Map<Violation>(modelDto);

                    await _unitOfWork.ViolationRepository.InsertAsync(model);
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
                var model = await _unitOfWork.ViolationRepository.GetByIdAsync(id);

                if (model is not null)
                {
                    await _unitOfWork.ViolationRepository.DeleteAsync(id);
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
