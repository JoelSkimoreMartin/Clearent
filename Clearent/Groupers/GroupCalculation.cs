using Clearent.Models;
using Clearent.Models.Interfaces;
using Clearent.Models.TestData;
using System.Collections.Generic;

namespace Clearent.Groupers
{
	public class GroupCalculation
	{
		public Grouping Grouping { get; internal set; }
		public Person Person { get; internal set; }
		public decimal PersonInterest { get; internal set; }
		public List<(ICardResolver resolver, decimal resolverInterest)> Resolvers { get; internal set; }
	}
}