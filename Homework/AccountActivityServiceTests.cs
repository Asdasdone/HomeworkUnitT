using Homework;
using Homework.ThirdParty;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

[TestFixture]
public class AccountActivityServiceTests
{
    private Mock<IAccountRepository> _accountRepositoryMock;
    private AccountActivityService _service;

    [SetUp]
    public void SetUp()
    {
        _accountRepositoryMock = new Mock<IAccountRepository>();
        _service = new AccountActivityService(_accountRepositoryMock.Object);
    }

    [Test]
    public void GetActivity_AccountExists_ReturnsCorrectActivityLevel()
    {
        var account = new Account(1, 25);
        _accountRepositoryMock.Setup(r => r.Get(It.IsAny<int>())).Returns(account);

        ActivityLevel result = _service.GetActivity(1);

        Assert.That(result, Is.EqualTo(ActivityLevel.Medium));
    }

    [Test]
    public void GetActivity_AccountDoesNotExist_ThrowsException()
    {
        _accountRepositoryMock.Setup(r => r.Get(It.IsAny<int>())).Returns<Account>(null);

        Assert.Throws<AccountNotExistsException>(() => _service.GetActivity(1));
    }

    [Test]
    public void GetAmountForActivity_ActivityLevelLow_ReturnsCorrectCount()
    {

        var accounts = new List<Account>
    {
        new Account(1,15),
        new Account(2,30),
        new Account(3,5) 
    };

        _accountRepositoryMock.Setup(r => r.GetAll()).Returns(accounts.AsQueryable());

        foreach (var account in accounts)
        {
            _accountRepositoryMock.Setup(r => r.Get(account.Id)).Returns(account);
        }

        int result = _service.GetAmountForActivity(ActivityLevel.Low);

        Assert.That(result, Is.EqualTo(2));
    }
}