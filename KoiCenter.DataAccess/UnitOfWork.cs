using KoiCenter.Data.Models;
using KoiCenter.Data.Repository;

namespace KoiCenter.Data
{
    public class UnitOfWork
    {
        private FA24_SE1702_PRN221_G3_KoiVeterinaryServiceCenterContext _unitOfWorkContext;
        public PetRepository _petRepository;

        public UnitOfWork()
        {
            _unitOfWorkContext ??= new FA24_SE1702_PRN221_G3_KoiVeterinaryServiceCenterContext();
        }

        public PetRepository PetRepository
        {
            get
            {
                return _petRepository ??= new Repository.PetRepository(_unitOfWorkContext);
            }
        }
    }
}
