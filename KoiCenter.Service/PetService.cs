using KoiCenter.Common;
using KoiCenter.Data;
using KoiCenter.Data.Models;
using KoiCenter.Service.Base;

namespace KoiCenter.Service
{
    public interface IPetService
    {
        Task<BusinessResult> GetAll();
        Task<BusinessResult> GetById(int id);
        Task<BusinessResult> Save(Pet pet);

        Task<BusinessResult> DeleteById(int id);
    }
    public class PetService : IPetService
    {
        private readonly UnitOfWork _unitOfWork;
        public PetService() => _unitOfWork ??= new UnitOfWork();

        public async Task<BusinessResult> GetAll()
        {
            #region Business Rule

            #endregion Business Rule

            var pets = await _unitOfWork.PetRepository.GetAllAsync();

            if (pets == null)
            {
                return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG);
            }
            else
            {
                return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, pets);
            }
        }

        public async Task<BusinessResult> GetById(int id)
        {
            #region Business Rule

            #endregion Business Rule

            var pets = _unitOfWork.PetRepository.GetByIdAsync(id);
            if (pets == null)
            {
                return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG);
            }
            else
            {
                return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, pets);
            }
        }

        public async Task<BusinessResult> Save(Pet pet)
        {
            try
            {
                int result = -1;

                var petTemp = this.GetById(pet.Id);

                if (petTemp.Result.Status == Const.SUCCESS_READ_CODE)
                {

                    result = await _unitOfWork.PetRepository.UpdateAsync(pet);

                    if (result > 0)
                    {
                        return new BusinessResult(Const.SUCCESS_UPDATE_CODE, Const.SUCCESS_UPDATE_MSG, pet);
                    }
                    else
                    {
                        return new BusinessResult(Const.FAIL_UPDATE_CODE, Const.FAIL_UPDATE_MSG);
                    }
                }
                else
                {
                    result = await _unitOfWork.PetRepository.CreateAsync(pet);

                    if (result > 0)
                    {
                        return new BusinessResult(Const.SUCCESS_CREATE_CODE, Const.SUCCESS_CREATE_MSG, pet);
                    }
                    else
                    {
                        return new BusinessResult(Const.FAIL_CREATE_CODE, Const.FAIL_CREATE_MSG, pet);
                    }
                }
            }
            catch (Exception ex)
            {

                return new BusinessResult(Const.ERROR_EXCEPTION, ex.Message);
            }
        }

        public async Task<BusinessResult> DeleteById(int id)
        {
            try
            {
                var result = false;
                var petResult = this.GetById(id);

                if (petResult != null && petResult.Result.Status == Const.SUCCESS_READ_CODE)
                {
                    result = await _unitOfWork.PetRepository.RemoveAsync((Pet)petResult.Result.Data);

                    if (result)
                    {
                        return new BusinessResult(Const.SUCCESS_DELETE_CODE, Const.SUCCESS_DELETE_MSG, result);
                    }
                    else
                    {
                        return new BusinessResult(Const.FAIL_CREATE_CODE, Const.FAIL_CREATE_MSG, petResult.Result.Data);
                    }
                }
                else
                {
                    return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG);
                }
            }
            catch (Exception ex)
            {
                return new BusinessResult(Const.ERROR_EXCEPTION, ex.Message);
            }
        }

    }
}
