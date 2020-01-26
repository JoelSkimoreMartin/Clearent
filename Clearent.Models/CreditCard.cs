using Clearent.Models.Interfaces;
using System.Collections.Generic;

namespace Clearent.Models
{
	public class CreditCard : ICardResolver
	{
		public int Id { get; set; } = 1;

		public CreditCardType Type { get; set; }

		public decimal Balance { get; set; }

		public IEnumerable<CreditCard> Cards { get; }

		public string Name => $"{Type} {Id}";

		public CreditCard()
		{
			Cards = new[] { this };
		}

		public override string ToString() => Name;

		public static implicit operator CreditCard(CreditCardType type) => new CreditCard { Type = type };

		public static implicit operator CreditCardType(CreditCard card) => card?.Type ?? CreditCardType.Unknown;
	}
}