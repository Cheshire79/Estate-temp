using System.Collections.Generic;
using KnowledgeManagement.BLL.Interface.Date.ForManipulate;

namespace KnowledgeManagement.BLL.Interface.Date
{
    public class DataForSearchParametersDTO
    {
        public List<CityDistrictDropDownItemDTO> Districts;
        public List<RoomNumberDownItemDTO> RoomNumbers;
        public List<SortOrderDropDownDTO> SortOrders;
    }
}

