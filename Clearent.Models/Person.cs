using Clearent.Models.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Clearent.Models
{
	public class Person : ICardResolver
	{
		public int Id { get; set; } = 1;

		public IEnumerable<Wallet> Wallets { get; set; } = new List<Wallet>();

		public IEnumerable<CreditCard> Cards => Wallets?.SelectMany(w => w.Cards);

		public string Name => $"Person {Id}";

		public override string ToString() => Name;
	}
}