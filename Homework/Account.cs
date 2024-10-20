using Homework.ThirdParty;

namespace Homework
{
	public class Account
	{
		public int Id { get; }

		public bool IsRegistered { get; private set; }
		public bool IsConfirmed { get; private set; }

		public int ActionsSuccessfullyPerformed { get; private set; }

        public Account(int id, int actionsSuccessfullyPerformed = 0)
        {
            Id = id;
            ActionsSuccessfullyPerformed = actionsSuccessfullyPerformed;
        }

        public void Register()
		{
			IsRegistered = true;
		}

		public void Activate()
		{
			IsConfirmed = true;
		}

		public bool TakeAction(IAction action)
		{
			ValidateAccount();
			return PerformAction(action);
		}

		private void ValidateAccount()
		{
			if (IsInactiveAccount())
			{
				throw new InactiveUserException();
			}
		}

		private bool IsInactiveAccount()
		{
			return IsNotRegistered() && IsNotConfirmed();
		}

		private bool IsNotRegistered()
		{
			return !IsRegistered;
		}

		private bool IsNotConfirmed()
		{
			return !IsConfirmed;
		}

		private bool PerformAction(IAction action)
		{
			bool success = action.Execute();
			if (success)
			{
				ActionsSuccessfullyPerformed++;
			}
			return success;
		}
	}
}