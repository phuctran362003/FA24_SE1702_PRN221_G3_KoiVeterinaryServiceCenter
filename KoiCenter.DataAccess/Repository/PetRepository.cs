using KoiCenter.Data.Base;
using KoiCenter.Data.Models;

namespace KoiCenter.Data.Repository
{
    public class PetRepository : GenericRepository<Pet>
    {
        public PetRepository()
        {

        }

        public PetRepository(FA24_SE1702_PRN221_G3_KoiVeterinaryServiceCenterContext context)
        {
            _context = context;
        }

    }
}
