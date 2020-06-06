using System;
using Moq;
using Xunit;

namespace TestConsoleApp
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Assert.False(false);
        }
        [Fact]
        public void NewlyCreatedSystem_hasNoLoggedInUsers()
        {
            var authorizerMock = new Mock<IAuthorizer>();

            //Setup with general arguments
            authorizerMock.Setup(p => p.Authorize(It.IsAny<string>(), It.IsAny<string>())).Returns(true);
            
            //Setup with exact arguments
            authorizerMock.Setup(p => p.Authorize("bob", "secret")).Returns(true);
            
            //We expect that Authorize has been called exactely one time with parameters bob and secret
            authorizerMock.Verify(s => s.Authorize("bob","secret"), Times.Once);

            
        }
        // [Fact]
        // public void NewlyCreatedSystem_hasNoLoggedInUsers()
        // {
        //     System system = new System(new DummyAuthorizer());
        //     Assert.Equal(0, system.LoginCount());
        // }
    }

    // public class AcceptingAuthorizerVerificationMock : IAuthorizer
    // {
    //     public bool AuthorizeWasCalled = false;
    //
    //     public bool Verify()
    //     {
    //         return AuthorizeWasCalled;
    //     }
    //
    //     public bool Authorize(string username, string password)
    //     {
    //         AuthorizeWasCalled = true;
    //         return true;
    //     }
    // }
    //
    // public class AcceptingAuthorizerSpy : IAuthorizer
    // {
    //     public bool authorizeWasCalled = false;
    //
    //     public bool Authorize(string username, string password)
    //     {
    //         authorizeWasCalled = true;
    //         return true;
    //     }
    // }
    //
    // public class AcceptingAuthorizerFake : IAuthorizer
    // {
    //     public bool Authorize(string username, string password)
    //     {
    //         return username.Equals("Bob");
    //     }
    // }
    //
    // public class AcceptingAuthorizerStub : IAuthorizer
    // {
    //     public bool Authorize(string username, string password)
    //     {
    //         return true;
    //     }
    // }
    //
    // public class System
    // {
    //     private IAuthorizer authorizer;
    //
    //     public System(IAuthorizer authorizer)
    //     {
    //         this.authorizer = authorizer;
    //     }
    //
    //     public int LoginCount()
    //     {
    //         //returns number of logged in users.
    //     }
    // }
    //
    //
    // public class DummyAuthorizer : IAuthorizer
    // {
    //     public bool Authorize(string username, string password)
    //     {
    //         throw new NotImplementedException();
    //     }
    // }
}