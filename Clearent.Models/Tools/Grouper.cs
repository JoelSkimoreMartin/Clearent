using System.Collections.Generic;
using System.Linq;

namespace Clearent.Models.Tools
{
	public class Grouper
	{
		public IEnumerable<Group> Group(Grouping grouping, IEnumerable<Person> people) =>
			people?
				.Where(p => p != null)
				.Select(p => new Group(p, grouping))
			??
			Enumerable.Empty<Group>();
	}
}