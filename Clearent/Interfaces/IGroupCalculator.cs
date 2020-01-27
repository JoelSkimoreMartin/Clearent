using Clearent.Groupers;
using Clearent.Models;
using Clearent.Models.TestData;
using System.Collections.Generic;

namespace Clearent.Interfaces
{
	public interface IGroupCalculator
	{
		IEnumerable<GroupCalculation> Calculate(Grouping grouping, IEnumerable<Person> people);
	}
}