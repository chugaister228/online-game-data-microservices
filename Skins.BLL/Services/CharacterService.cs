using AutoMapper;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using Skins.BLL.Services.Interfaces;
using Skins.DAL.Repositories.Interfaces;
using Skins.Data.Dtos;
using Skins.Data.Enums;
using Skins.Data.Interfaces;
using Skins.Data.Models;
using Skins.Data.Responses;
using System.Text;
using System.Text.Json;

namespace Skins.BLL.Services
{
    public class CharacterService : ICharacterService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        private IDistributedCache _cache;

        public CharacterService(IUnitOfWork unitOfWork, IMapper mapper, IDistributedCache cache)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _cache = cache;
        }

        public async Task<IBaseResponse<CharacterDTO>> GetById(Guid id)
        {
            var baseResponse = new BaseResponse<CharacterDTO>();
            Character? model = null;

            try
            {
                var modelString = await _cache.GetStringAsync(id.ToString());

                if (modelString != null) model = System.Text.Json.JsonSerializer.Deserialize<Character>(modelString);

                if (model == null)
                {
                    model = await _unitOfWork.CharacterRepository.GetByIdAsync(id);

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
                        return new BaseResponse<CharacterDTO>()
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

                baseResponse.Data = _mapper.Map<CharacterDTO>(model);
                baseResponse.StatusCode = StatusCode.OK;

                return baseResponse;
            }
            catch(Exception ex)
            {
                return new BaseResponse<CharacterDTO>()
                {
                    Description = $"{ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<IEnumerable<CharacterDTO>>> GetAll()
        {
            var baseResponse = new BaseResponse<IEnumerable<CharacterDTO>>();
            var modelDtoList = new List<CharacterDTO>();

            string serializedModels;
            var cacheKey = "characterList";
            var redisModels = await _cache.GetAsync(cacheKey);

            try
            {
                if (redisModels != null)
                {
                    serializedModels = Encoding.UTF8.GetString(redisModels);
                    var models = JsonConvert.DeserializeObject<List<Character>>(serializedModels);

                    if (models != null)
                        foreach (var model in models)
                        {
                            modelDtoList.Add(_mapper.Map<CharacterDTO>(model));
                        }

                    baseResponse.ResultsCount = modelDtoList.Count;
                    baseResponse.Description = "Data extracted from cache";
                    baseResponse.StatusCode = StatusCode.OK;
                }
                else
                {
                    var models = await _unitOfWork.CharacterRepository.GetAsync();

                    serializedModels = JsonConvert.SerializeObject(models);
                    redisModels = Encoding.UTF8.GetBytes(serializedModels);

                    var options = new DistributedCacheEntryOptions()
                        .SetAbsoluteExpiration(DateTime.Now.AddMinutes(10))
                        .SetSlidingExpiration(TimeSpan.FromMinutes(2));
                    await _cache.SetAsync(cacheKey, redisModels, options);

                    foreach (var model in models)
                    {
                        modelDtoList.Add(_mapper.Map<CharacterDTO>(model));
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
                return new BaseResponse<IEnumerable<CharacterDTO>>()
                {
                    Description = $"{ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<string>> Insert(CharacterDTO modelDto)
        {
            try
            {
                if (modelDto is not null)
                {
                    modelDto.ID = Guid.NewGuid();

                    var model = _mapper.Map<Character>(modelDto);

                    await _unitOfWork.CharacterRepository.InsertAsync(model);
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
                var model = await _unitOfWork.CharacterRepository.GetByIdAsync(id);

                if (model is not null)
                {
                    await _unitOfWork.CharacterRepository.DeleteAsync(id);
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
