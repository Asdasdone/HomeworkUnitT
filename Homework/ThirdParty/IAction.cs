namespace Homework.ThirdParty
{
	public interface IAction
	{
		/// <summary>
		/// Performs the steps, defined by the action.
		/// </summary>
		/// <returns>True if all the steps of the action has been performed successfully. False otherwise.</returns>
		bool Execute();
	}
}