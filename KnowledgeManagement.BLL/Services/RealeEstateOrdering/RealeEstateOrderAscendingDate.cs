﻿using KnowledgeManagement.BLL.Interface.Date;
using System.Linq;

namespace KnowledgeManagement.BLL.Services.RealeEstateOrdering
{
	public class RealeEstateOrderAscendingDate : RealeEstateOrder
	{
		public override IQueryable<RealEstateForRealtor> Order(IQueryable<RealEstateForRealtor> realEstates)
		{
			return realEstates.OrderBy(x => x.CreationDate);
		}
	}
}