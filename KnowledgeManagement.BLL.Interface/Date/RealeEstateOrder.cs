using System.Linq;

namespace KnowledgeManagement.BLL.Interface.Date
{
    public abstract class RealeEstateOrder
    {
        public abstract IQueryable<RealEstateForRealtorDTO> Order(IQueryable<RealEstateForRealtorDTO> realEstates);
    }
}

