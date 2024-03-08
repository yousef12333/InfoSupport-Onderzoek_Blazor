using System;
using Blazor_Project;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blazor_Project.Pages;
using Blazor_Project.Services;
using Bunit;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Tests
{
    public class IntegrationTests : TestContext
    {
        [Fact]
        public void AppComponentShouldRenderCorrectly()
        {
            Services.AddScoped<PasswordStrengthService>();
            var component = RenderComponent<FormChecker>();
            Assert.NotNull(component.Find(".pass-title"));
            Assert.NotNull(component.Find(".pass-label"));
            Assert.NotNull(component.Find(".pass-input"));
            Assert.NotNull(component.Find(".pass-marker"));
            Assert.Contains("Password strength", component.Markup);
        }

        [Fact]
        public void PasswordStrengthServiceShouldBeInjected()
        {
            Services.AddScoped<PasswordStrengthService>();
            var component = RenderComponent<FormChecker>();
            var passwordStrengthService = Services.GetRequiredService<PasswordStrengthService>();
            Assert.NotNull(passwordStrengthService);
        }
        [Fact]
        public void PasswordStrengthCssClassesAreApplied()
        {
            Services.AddScoped<PasswordStrengthService>();
            var component = RenderComponent<FormChecker>();

            component.Find(".pass-input").Change("");
            var span0Class = component.Find(".pass-marker span:nth-child(1)").ClassName;
            Assert.Contains("spanColors invalid", span0Class);

            component.Find(".pass-input").Change("HelloWorld"); 
            var span1Class = component.Find(".pass-marker span:nth-child(1)").ClassName;
            Assert.Contains("spanColors easy", span1Class);

            component.Find(".pass-input").Change("HelloWorld12");
            var span2Class = component.Find(".pass-marker span:nth-child(2)").ClassName;
            Assert.Contains("spanColors medium", span2Class);


            component.Find(".pass-input").Change("HelloHelloWorld12./"); 
            var span3Class = component.Find(".pass-marker span:nth-child(3)").ClassName;
            Assert.Contains("spanColors strong", span3Class);
        }
    }
}