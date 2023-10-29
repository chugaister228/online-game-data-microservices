using AutoMapper;
using Donations.BLL.Services.Interfaces;
using Donations.DAL.Repositories.Interfaces;
using Donations.Data.Dtos;
using Donations.Data.Enums;
using Donations.Data.Interfaces;
using Donations.Data.Models;
using Donations.Data.Responses;

namespace Donations.BLL.Services
{
    public class DonationService : IDonationService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public DonationService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IBaseResponse<IEnumerable<DonationDTO>>> GetAll()
        {
            var baseResponse = new BaseResponse<IEnumerable<DonationDTO>>();
            var modelDtoList = new List<DonationDTO>();

            try
            {
                var models = await _unitOfWork.DonationRepository.GetAsync();

                foreach (var model in models)
                {
                    var modelDto = _mapper.Map<DonationDTO>(model);
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
