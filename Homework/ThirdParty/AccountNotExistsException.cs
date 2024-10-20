using System;

namespace Homework.ThirdParty
{
	public class AccountNotExistsException : Exception
	{
		public int AccountId { get; }

		public AccountNotExistsException(int accountId)
		{
			AccountId = accountId;
		}
	}
}