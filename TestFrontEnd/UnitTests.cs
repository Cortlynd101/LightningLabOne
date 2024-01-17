using Bunit;
using FluentAssertions;
using FrontEnd.Pages;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FrontEndTests
{
    public class FrontEndTestContext : TestContext
    {
        public FrontEndTestContext()
        {
            //register services here:

            //var mockService = new Mock<IService>();
            //mockService.Setup(m=>m.DoSomething()).Returns(5);
            //Services.AddScoped<IService>(_ => mockService.Object);
        }
    }

    public class CounterTests : FrontEndTestContext
    {
        /*[Fact]
        public async Task CanCount()
        {
            var cut = RenderComponent<Counter>();
            cut.Find("button").Click();
            cut.Find("p").InnerHtml.Should().Be("Current count: 1");
        }

        [Fact]
        public async Task LotsOfClicks()
        {
            var cut = RenderComponent<Counter>();
            cut.Find("button").Click();
            cut.Find("button").Click();
            cut.Find("button").Click();
            cut.Find("button").Click();
            cut.Find("p").InnerHtml.Should().Be("Current count: 4");
        }

        [Fact]
        public async Task CanCountBy5()
        {
            var cut = RenderComponent<Counter>(parameters => parameters.Add(c => c.IncrementBy, 5));
            cut.Find("button").Click();
            cut.Find("p").InnerHtml.Should().Be("Current count: 5");
        }

        [Fact]
        public async Task CanCountBy5StartingAt2()
        {
            var cut = RenderComponent<Counter>(parameters => parameters
                .Add(c => c.IncrementBy, 5)
                .Add(c => c.StartingValue, 2)
            );
            cut.Find("button").Click();
            cut.Find("p").InnerHtml.Should().Be("Current count: 7");
        }*/
    }
    /*public class AdminTests : BlazorUnitTestContext
    {
        [Fact]
        public async Task AdminRecognized()
        {
            var authContext = this.AddTestAuthorization();
            authContext.SetRoles(Constants.AdminRole);

            var cut = RenderComponent<PageWithAuthState>();
            cut.Find(".authorizedGreeting").InnerHtml.Should().Be("You're an admin!");
        }

        [Fact]
        public async Task UnauthorizedUserDoesNotSeeAnyContent()
        {
            this.AddTestAuthorization();
            var cut = RenderComponent<PageWithAuthState>();
            cut.Find(".notAuthorizedGreeting").InnerHtml.Should().Be("Go away.");
        }
    }*/
}
