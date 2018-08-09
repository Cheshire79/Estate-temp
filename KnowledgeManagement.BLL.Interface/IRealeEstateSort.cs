using System.Collections.Generic;
using System.Linq;
using KnowledgeManagement.BLL.Interface.Date;

namespace KnowledgeManagement.BLL.Interface
{
    public delegate IQueryable<RealEstateForRealtor> Sorting(IQueryable<RealEstateForRealtor> realEstates);
    public interface IRealeEstateSort
    {
        List<SortOrderDropDownDTO> GetSortingOptionsName();
        Sorting Sort(SortOrder sortOrder);
    }
}
