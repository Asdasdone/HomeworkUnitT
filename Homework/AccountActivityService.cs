using Homework.ThirdParty;

namespace Homework
{
	public class AccountActivityService : IAccountActivityService
	{
		private readonly IAccountRepository _accountRepository;

		public AccountActivityService(IAccountRepository accountRepository)
		{
			_accountRepository = accountRepository;
		}

		public ActivityLevel GetActivity(int accountId)
		{
			Account account = _accountRepository.Get(accountId);
			if (account == null)
			{
				throw new AccountNotExistsException(accountId);
			}

			ActivityLevel activity;
			if (account.ActionsSuccessfullyPerformed == 0)
			{
				activity = ActivityLevel.None;
			}
			else if (account.ActionsSuccessfullyPerformed < 20)
			{
				activity = ActivityLevel.Low;
			}
			else if (account.ActionsSuccessfullyPerformed < 40)
			{
				activity = ActivityLevel.Medium;
			}
			else
			{
				activity = ActivityLevel.High;
			}

			return activity;
		}

		public int GetAmountForActivity(ActivityLevel activityLevel)
		{
			int amount = 0;
			foreach (Account account in _accountRepository.GetAll())
			{
				if (GetActivity(account.Id) == activityLevel)
				{
					amount++;
				}
			}
			return amount;
		}
	}
}