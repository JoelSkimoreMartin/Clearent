using Clearent.Interfaces;
using Clearent.Models.Interfaces;
using Clearent.Repo.Interfaces;
using System;
using System.Linq;

namespace Clearent
{
	/// <summary>
	/// Performs simple credit card calculations
	/// </summary>
	public class SimpleInterestCalculator : ISimpleInterestCalculator
	{
		private ICardRepo CardRepo { get; }

		public SimpleInterestCalculator(ICardRepo cardRepo)
		{
			CardRepo = cardRepo;
		}

		/// <summary>
		/// Performs simple interest calculation for supplied credit cards
		/// </summary>
		/// <param name="resolvers">POCO objects that resolve to credit cards</param>
		/// <returns>money value of simple interest rate calculation</returns>
		/// <exception cref="System.ArgumentNullException">Thrown when resolvers parameter is null</exception>
		/// <exception cref="System.ArgumentException">Thrown when any null CreditCard classes supplied</exception>
		/// <exception cref="System.ArgumentException">Thrown when a credit card type supplied and a matching interest rate does not exist</exception>
		public decimal Calculate(params ICardResolver[] resolvers)
		{
			// verify parameters
			if (resolvers == null)
				throw new ArgumentNullException(nameof(resolvers));

			var cards = resolvers.SelectMany(r => r.Cards).ToList();

			// verify no null cards
			if (cards.Any(c => c == null))
				throw new ArgumentException("Cannot have null credit cards");

			// Load interest rates
			var interestRates = CardRepo.LoadInterestRates();

			// verify interest rates exist
			var missingInterestRates = cards.Select(c => c.Type).Distinct().Where(t => interestRates.ContainsKey(t) == false).Select(t => $"{t}").ToList();
			if (missingInterestRates.Any())
				throw new ArgumentException($"Interest rates do not exist for: {string.Join(",", missingInterestRates)}");

			// Calculate simple interest
			return cards.Sum(c => c.Balance * interestRates[c.Type]);
		}
	}
}