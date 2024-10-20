namespace Homework.ThirdParty
{
	public interface IAccountActivityService
	{
		/// <summary>
		/// Gets the activity level for an account, given by its Id.
		/// </summary>
		/// <param name="accountId">The Id of the account.</param>
		/// <returns>The activity level of the account.</returns>
		ActivityLevel GetActivity(int accountId);

		/// <summary>
		/// Returns the amount of accounts associated with the given activity level.
		/// </summary>
		/// <param name="activityLevel">The activity level to count the accounts for.</param>
		/// <returns>The amount of accounts associated with the given activity level.</returns>
		int GetAmountForActivity(ActivityLevel activityLevel);
	}
}