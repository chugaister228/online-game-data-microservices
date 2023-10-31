using AutoMapper;
using PlayerStats.BLL.Services.Interfaces;
using PlayerStats.DAL.Repositories.Interfaces;
using PlayerStats.Data.Dtos;
using PlayerStats.Data.Enums;
using PlayerStats.Data.Interfaces;
using PlayerStats.Data.Models;
using PlayerStats.Data.Responses;

namespace PlayerStats.BLL.Services
{
    public class FriendService : IFriendService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public FriendService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IBaseResponse<IEnumerable<FriendDTO>>> GetAll()
        {
            var baseResponse = new BaseResponse<IEnumerable<FriendDTO>>();
            var modelDtoList = new List<FriendDTO>();

            try
            {
                var models = await _unitOfWork.FriendRepository.GetAsync();

                foreach (var model in models)
                {
                    var modelDto = _mapper.Map<FriendDTO>(model);
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
                return new BaseResponse<IEnumerable<FriendDTO>>()
                {
                    Description = $"{ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<string>> Insert(FriendDTO modelDto)
        {
            try
            {
                if (modelDto is not null)
                {
                    modelDto.ID = Guid.NewGuid();

                    var model = _mapper.Map<Friend>(modelDto);

                    await _unitOfWork.FriendRepository.InsertAsync(model);
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
                var model = await _unitOfWork.FriendRepository.GetByIdAsync(id);

                if (model is not null)
                {
                    await _unitOfWork.FriendRepository.DeleteAsync(id);
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
