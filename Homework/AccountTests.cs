using Homework;
using Homework.ThirdParty;
using Moq;
using NUnit.Framework;

[TestFixture]
public class AccountTests
{
    private Mock<IAction> _actionMock;
    private Account _account;

    [SetUp]
    public void SetUp()
    {
        _actionMock = new Mock<IAction>();
        _account = new Account(1);
    }

    [Test]
    public void Register_AccountNotRegistered_SetsIsRegisteredToTrue()
    {
        _account.Register();

        Assert.That(_account.IsRegistered, Is.True);
    }

    [Test]
    public void Activate_AccountNotConfirmed_SetsIsConfirmedToTrue()
    {
        _account.Activate();

        Assert.That(_account.IsConfirmed, Is.True);
    }

    [Test]
    public void TakeAction_AccountActive_ActionExecutedSuccessfully_IncrementsActionsSuccessfullyPerformed()
    {
        _actionMock.Setup(a => a.Execute()).Returns(true);
        _account.Register();
        _account.Activate();

        bool result = _account.TakeAction(_actionMock.Object);

        Assert.That(result, Is.True);
        Assert.That(_account.ActionsSuccessfullyPerformed, Is.EqualTo(1));
    }

    [Test]
    public void TakeAction_AccountInactive_ThrowsException()
    {
        _actionMock.Setup(a => a.Execute()).Returns(true);

        Assert.Throws<InactiveUserException>(() => _account.TakeAction(_actionMock.Object));
    }
}