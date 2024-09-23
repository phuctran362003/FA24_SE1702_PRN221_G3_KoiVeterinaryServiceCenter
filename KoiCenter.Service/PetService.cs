using KoiCenter.Common;
using KoiCenter.Data;
using KoiCenter.Data.Models;
using KoiCenter.Service.Base;

namespace KoiCenter.Service
{
    public interface IPetService
    {
        Task<IBusinessResult> GetAll();
        Task<IBusinessResult> GetById(int id);
        Task<IBusinessResult> Save(Pet pet);

        Task<IBusinessResult> DeleteById(int id);
    }
    public class PetService : IPetService
    {
        private readonly UnitOfWork _unitOfWork;
        public PetService() => _unitOfWork ??= new UnitOfWork();

        public async Task<IBusinessResult> GetAll()
        {
            #region Business Rule

            #endregion Business Rule

            var pets = await _unitOfWork.PetRepository.GetAllAsync();

            if (pets == null)
            {
                return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG, new List<Pet>());
            }
            else
            {
                return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, pets);
            }
        }

        public async Task<IBusinessResult> GetById(int id)
        {
            //lay 1 con petResult

            var pet = _unitOfWork.PetRepository.GetByIdAsync(id);
            if (pet == null)
            {
                return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG, new Pet());
            }
            else
            {
                return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, pet);
            }
        }

        public async Task<IBusinessResult> Save(Pet pet)
        {
            try
            {
                int result = -1;

                var petTemp = _unitOfWork.PetRepository.GetById(pet.Id);

                if (petTemp != null)
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

                return new BusinessResult(Const.ERROR_EXCEPTION, ex.Message.ToString());
            }
        }

        public async Task<IBusinessResult> DeleteById(int id)
        {
            try
            {
                var petResult = await _unitOfWork.PetRepository.GetByIdAsync(id);

                if (petResult == null)
                {
                    return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG, new Pet());
                }

                else
                {
                    var result = await _unitOfWork.PetRepository.RemoveAsync(petResult);
                    if (result)
                    {
                        return new BusinessResult(Const.SUCCESS_DELETE_CODE, Const.SUCCESS_DELETE_MSG, petResult);
                    }
                    else
                    {
                        return new BusinessResult(Const.FAIL_DELETE_CODE, Const.FAIL_DELETE_MSG, petResult);

                    }
                }
            }
            catch (Exception ex)
            {
                return new BusinessResult(Const.ERROR_EXCEPTION, ex.Message);
            }
        }

    }
}
