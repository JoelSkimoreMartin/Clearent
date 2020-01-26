using Clearent.Models.Interfaces;

namespace Clearent.Interfaces
{
	/// <summary>
	/// Performs simple credit card calculations
	/// </summary>
	public interface ISimpleInterestCalculator
	{
		/// <summary>
		/// Performs simple interest calculation for supplied credit cards
		/// </summary>
		/// <param name="resolvers">POCO objects that resolve to credit cards</param>
		/// <returns>money value of simple interest rate calculation</returns>
		decimal Calculate(params ICardResolver[] resolvers);
	}
}