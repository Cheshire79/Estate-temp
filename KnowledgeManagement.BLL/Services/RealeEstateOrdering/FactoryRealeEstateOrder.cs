
using KnowledgeManagement.BLL.Interface;
using KnowledgeManagement.BLL.Interface.Date;

namespace KnowledgeManagement.BLL.Services.RealeEstateOrdering
{
	public class FactoryRealeEstateOrder: IFactoryRealeEstateOrder
	{
		//new SortOrderView() { Id = 1,Name = "By date listed (new – old)"},
		//			new SortOrderView() { Id = 2,Name = "By date listed (old – new)"},
		//			new SortOrderView() { Id = 3,Name = "By price (min – max)"},
		//			new SortOrderView() { Id = 4,Name = "By price (max – min)"},
		//			new SortOrderView() { Id = 5,Name = "Total area (min – max)"},
		//			new SortOrderView() { Id = 6,Name = "Total area (max – min)"}
		public	RealeEstateOrder Create(int id)
		{
			switch (id)
			{
				case 1:
					return new RealeEstateOrderDescendingDate();
				case 2:					
					return new RealeEstateOrderAscendingDate();
				case 3:
					return new RealeEstateOrderAscendingPrice();					
				case 4:
					return new RealeEstateOrderDescendingPrice();
				case 5:
					return new RealeEstateOrderAscendingArea();
				case 6:					
					return new RealeEstateOrderDescendingArea();
				default:
					return new RealeEstateOrderAscendingDate();			
			}
		}			
	}
}
