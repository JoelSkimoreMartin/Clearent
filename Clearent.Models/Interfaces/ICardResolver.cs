using System.Collections.Generic;

namespace Clearent.Models.Interfaces
{
	public interface ICardResolver
	{
		int Id { get; set; }

		string Name { get; }

		IEnumerable<CreditCard> Cards { get; }
	}
}