using AutoMapper;
using Skins.BLL.Services.Interfaces;
using Skins.DAL.Repositories.Interfaces;
using Skins.Data.Dtos;
using Skins.Data.Enums;
using Skins.Data.Interfaces;
using Skins.Data.Models;
using Skins.Data.Responses;

namespace Skins.BLL.Services
{
    public class CharacterService : ICharacterService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public CharacterService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IBaseResponse<IEnumerable<CharacterDTO>>> GetAll()
        {
            var baseResponse = new BaseResponse<IEnumerable<CharacterDTO>>();
            var modelDtoList = new List<CharacterDTO>();

            try
            {
                var models = await _unitOfWork.CharacterRepository.GetAsync();

                foreach (var model in models)
                {
                    var modelDto = _mapper.Map<CharacterDTO>(model);
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
