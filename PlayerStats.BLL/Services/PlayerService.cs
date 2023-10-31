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
    public class PlayerService : IPlayerService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public PlayerService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IBaseResponse<IEnumerable<PlayerDTO>>> GetAll()
        {
            var baseResponse = new BaseResponse<IEnumerable<PlayerDTO>>();
            var modelDtoList = new List<PlayerDTO>();

            try
            {
                var models = await _unitOfWork.PlayerRepository.GetAsync();

                foreach (var model in models)
                {
                    var modelDto = _mapper.Map<PlayerDTO>(model);
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
                return new BaseResponse<IEnumerable<PlayerDTO>>()
                {
                    Description = $"{ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<string>> Insert(PlayerDTO modelDto)
        {
            try
            {
                if (modelDto is not null)
                {
                    modelDto.ID = Guid.NewGuid();

                    var model = _mapper.Map<Player>(modelDto);

                    await _unitOfWork.PlayerRepository.InsertAsync(model);
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
                var model = await _unitOfWork.PlayerRepository.GetByIdAsync(id);

                if (model is not null)
                {
                    await _unitOfWork.PlayerRepository.DeleteAsync(id);
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
