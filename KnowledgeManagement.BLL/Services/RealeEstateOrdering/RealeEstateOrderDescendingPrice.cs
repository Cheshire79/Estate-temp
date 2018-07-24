using KnowledgeManagement.BLL.Interface.Date;
using System.Linq;

namespace KnowledgeManagement.BLL.Services.RealeEstateOrdering
{
	public class RealeEstateOrderDescendingPrice : RealeEstateOrder
	{
		public override IQueryable<RealEstateForRealtor> Order(IQueryable<RealEstateForRealtor> realEstates)
		{
			return realEstates.OrderByDescending(x => x.Price);
		}
	}
}
