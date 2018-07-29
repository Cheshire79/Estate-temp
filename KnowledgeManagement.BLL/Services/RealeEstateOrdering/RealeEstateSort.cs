using System;
using System.Collections.Generic;
using System.Linq;
using KnowledgeManagement.BLL.Interface;
using KnowledgeManagement.BLL.Interface.Date;

namespace KnowledgeManagement.BLL.Services.RealeEstateOrdering
{

    public class RealeEstateSort : IRealeEstateSort
    {
        private Dictionary<SortOrder, Tuple<string, Sorting>> _textAndFunctions = new Dictionary<SortOrder, Tuple<string, Sorting>>()
        {
            {SortOrder.ByDateNewOld, new Tuple<string, Sorting>("By date listed (new – old)", l => l.OrderByDescending(x => x.CreationDate))},
            {SortOrder.ByDateOldNew, new Tuple<string, Sorting>("By date listed (old – new)", l => l.OrderBy(x => x.CreationDate))},
            {SortOrder.ByPriceMinMax, new Tuple<string, Sorting>("By price (min – max)", l => l.OrderBy(x => x.Price))},
            {SortOrder.ByPriceMaxMin, new Tuple<string, Sorting>("By price (max – min)", l => l.OrderByDescending(x => x.Price))},
            {SortOrder.ByTotalAreaMinMax, new Tuple<string, Sorting>("Total area (min – max)", l => l.OrderBy(x => x.Area))},
            {SortOrder.ByTotalAreaMaxMin, new Tuple<string, Sorting>("Total area (max – min)", l => l.OrderByDescending(x => x.Area))}
        };

        public List<SortOrderDTO> GetSortingOptionsName()
        {
            List<SortOrderDTO> result = new List<SortOrderDTO>();
            foreach (var item in _textAndFunctions)
            {
                result.Add(new SortOrderDTO() { Id = item.Key, Name = item.Value.Item1 });
            }
            return result;
        }

        public Sorting Sort(SortOrder sortOrder)
        {
            return _textAndFunctions[sortOrder].Item2;
        }
    }
}
