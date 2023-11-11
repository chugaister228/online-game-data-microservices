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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Donations.BLL.Services
{
    public class ProductService : IProductService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        private IDistributedCache _cache;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper, IDistributedCache cache)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _cache = cache;
        }

        public async Task<IBaseResponse<ProductDTO>> GetById(Guid id)
        {
            var baseResponse = new BaseResponse<ProductDTO>();
            Product? model = null;

            try
            {
                var modelString = await _cache.GetStringAsync(id.ToString());

                if (modelString != null) model = System.Text.Json.JsonSerializer.Deserialize<Product>(modelString);

                if (model == null)
                {
                    model = await _unitOfWork.ProductRepository.GetByIdAsync(id);

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
                        return new BaseResponse<ProductDTO>()
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

                baseResponse.Data = _mapper.Map<ProductDTO>(model);
                baseResponse.StatusCode = StatusCode.OK;

                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<ProductDTO>()
                {
                    Description = $"{ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<IEnumerable<ProductDTO>>> GetAll()
        {
            var baseResponse = new BaseResponse<IEnumerable<ProductDTO>>();
            var modelDtoList = new List<ProductDTO>();

            string serializedModels;
            var cacheKey = "productList";
            var redisModels = await _cache.GetAsync(cacheKey);

            try
            {
                if (redisModels != null)
                {
                    serializedModels = Encoding.UTF8.GetString(redisModels);
                    var models = JsonConvert.DeserializeObject<List<Product>>(serializedModels);

                    if (models != null)
                        foreach (var model in models)
                        {
                            modelDtoList.Add(_mapper.Map<ProductDTO>(model));
                        }

                    baseResponse.ResultsCount = modelDtoList.Count;
                    baseResponse.Description = "Data extracted from cache";
                    baseResponse.StatusCode = StatusCode.OK;
                }
                else
                {
                    var models = await _unitOfWork.ProductRepository.GetAsync();

                    serializedModels = JsonConvert.SerializeObject(models);
                    redisModels = Encoding.UTF8.GetBytes(serializedModels);

                    var options = new DistributedCacheEntryOptions()
                        .SetAbsoluteExpiration(DateTime.Now.AddMinutes(10))
                        .SetSlidingExpiration(TimeSpan.FromMinutes(2));
                    await _cache.SetAsync(cacheKey, redisModels, options);

                    foreach (var model in models)
                    {
                        modelDtoList.Add(_mapper.Map<ProductDTO>(model));
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
                return new BaseResponse<IEnumerable<ProductDTO>>()
                {
                    Description = $"{ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<string>> Insert(ProductDTO modelDto)
        {
            try
            {
                if (modelDto is not null)
                {
                    modelDto.ID = Guid.NewGuid();

                    var model = _mapper.Map<Product>(modelDto);

                    await _unitOfWork.ProductRepository.InsertAsync(model);
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
                var model = await _unitOfWork.ProductRepository.GetByIdAsync(id);

                if (model is not null)
                {
                    await _unitOfWork.ProductRepository.DeleteAsync(id);
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
