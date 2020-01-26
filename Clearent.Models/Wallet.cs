using System.Collections.Generic;
using Clearent.Models.Interfaces;

namespace Clearent.Models
{
	public class Wallet : ICardResolver
	{
		public int Id { get; set; } = 1;

		public IEnumerable<CreditCard> Cards { get; set; } = new List<CreditCard>();

		public string Name => $"Wallet {Id}";

		public override string ToString() => Name;
	}
}