using System.Linq;

namespace KnowledgeManagement.BLL.Interface.Date
{
    public abstract class RealeEstateOrder
    {
        public abstract IQueryable<RealEstateForRealtor> Order(IQueryable<RealEstateForRealtor> realEstates);
    }
}

