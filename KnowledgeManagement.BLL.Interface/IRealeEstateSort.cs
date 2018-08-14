using System.Collections.Generic;
using System.Linq;
using KnowledgeManagement.BLL.Interface.Date;

namespace KnowledgeManagement.BLL.Interface
{
    public delegate IQueryable<RealEstateForRealtorDTO> Sorting(IQueryable<RealEstateForRealtorDTO> realEstates);
    public interface IRealeEstateSort
    {
        List<SortOrderDropDownDTO> GetSortingOptionsName();
        Sorting Sort(SortOrder sortOrder);
    }
}
