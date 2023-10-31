using AutoMapper;
using PlayerStats.BLL.Services.Interfaces;
using PlayerStats.DAL.Repositories.Interfaces;
using PlayerStats.Data.Dtos;
using PlayerStats.Data.Enums;
using PlayerStats.Data.Interfaces;
using PlayerStats.Data.Models;
using PlayerStats.Data.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerStats.BLL.Services
{
    public class ViolationService : IViolationService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public ViolationService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IBaseResponse<IEnumerable<ViolationDTO>>> GetAll()
        {
            var baseResponse = new BaseResponse<IEnumerable<ViolationDTO>>();
            var modelDtoList = new List<ViolationDTO>();

            try
            {
                var models = await _unitOfWork.ViolationRepository.GetAsync();

                foreach (var model in models)
                {
                    var modelDto = _mapper.Map<ViolationDTO>(model);
                    modelDtoList.Add(modelDto);
                }

                if (modelDtoList.Count is 0)
                {
                    baseResponse.Description = "0 objects found";
                    baseResponse.StatusCode = StatusCode.NotFound;
                    return baseResponse;
                }

                baseResponse.ResultsCount = modelDtoList.Count;
                baseResponse.Description = "Success!";
                baseResponse.Data = modelDtoList;
                baseResponse.StatusCode = StatusCode.OK;

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
