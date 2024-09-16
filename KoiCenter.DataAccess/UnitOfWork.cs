using KoiCenter.Data.Models;
using KoiCenter.Data.Repository;

namespace KoiCenter.Data
{
    public class UnitOfWork
    {
        private FA24_SE1702_PRN221_G3_KoiVeterinaryServiceCenterContext _context;
        private PetRepository _petRepository;

        public UnitOfWork(PetRepository petRepository, FA24_SE1702_PRN221_G3_KoiVeterinaryServiceCenterContext context)
        {

            _petRepository = petRepository;
            _context = context;
        }

        public PetRepository PetRepository
        {
            get { return _petRepository; }
        }




    }
}
