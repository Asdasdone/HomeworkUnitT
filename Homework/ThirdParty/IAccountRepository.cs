using System.Collections.Generic;

namespace Homework.ThirdParty
{
	public interface IAccountRepository
	{
		/// <summary>
		/// Adds an account to the repository.
		/// </summary>
		/// <param name="account">The account to be added.</param>
		/// <returns>True if the account was successfully stored. False otherwise.</returns>
		bool Add(Account account);

		/// <summary>
		/// Removes an account by its Id from the repository.
		/// </summary>
		/// <param name="accountId">The Id of the account to be removed.</param>
		/// <returns>True if the account was successfully removed. False otherwise.</returns>
		bool Remove(int accountId);

		/// <summary>
		/// Checks if the account by the given Id exists in the repository.
		/// </summary>
		/// <param name="accountId">The Id of the account.</param>
		/// <returns>True if the account exists. False otherwise.</returns>
		bool Exists(int accountId);

		/// <summary>
		/// Gets an account by its Id from the repository.
		/// </summary>
		/// <param name="accountId">The Id of the account to be retrieved.</param>
		/// <returns>The account instance if found, null otherwise.</returns>
		Account Get(int accountId);

		/// <summary>
		/// Gets all the accounts stored in the repository.
		/// </summary>
		/// <returns>All the account instances stored in the repository.</returns>
		IEnumerable<Account> GetAll();
	}
}