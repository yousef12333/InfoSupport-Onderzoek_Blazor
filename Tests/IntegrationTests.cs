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
using Microsoft.JSInterop;
using Blazor_Project.Classes;
using Moq;
using System.Reactive.Linq;

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
        [Fact]
        public void TemplateFormShouldRenderCorrectly()
        {
            var component = RenderComponent<TemplateFormsExample>();
            var formData = new FormData
            {
                FirstName = "Youssef",
                Password = "Password",
                Gender = "m",
                ShouldUseCity = true,
                City = 1
            };

            component.SetParametersAndRender(parameters => parameters
                .Add(p => p.FormData, formData)
            );

            Assert.NotNull(component.Find("h2"));
            Assert.NotNull(component.Find("form"));
            Assert.NotNull(component.Find("button[type='submit']"));
        }

        [Fact]
        public void ReactiveFormShouldRenderCorrectly()
        {
       
            var component = RenderComponent<ReactiveFormsExample>();
            var formData = new FormData
            {
                FirstName = "Youssef",
                Password = "Password",
                Gender = "m",
                ShouldUseCity = true,
                City = 1
            };

         
            component.SetParametersAndRender(parameters => parameters
                .Add(p => p.FormModel, formData)
            );

            Assert.NotNull(component.Find("h2"));
            Assert.NotNull(component.Find("form"));
            Assert.NotNull(component.Find("button[type='submit']"));
        }

        [Fact]
        public void TemplateFormSubmitShouldWorkCorrectly()
        {
            JSInterop.SetupVoid("alert", _ => true);
            var component = RenderComponent<TemplateFormsExample>();
            var formData = new FormData
            {
                FirstName = "Youssef",
                Password = "Password",
                Gender = "m",
                ShouldUseCity = true,
                City = 1
            };


            component.SetParametersAndRender(parameters => parameters
                .Add(p => p.FormData, formData)
            );
            var form = component.Find("form");
            form.Submit();

            Assert.Contains("Youssef", component.Markup);
            Assert.Contains("Password", component.Markup);
         
        }

        [Fact]
        public void ReactiveFormSubmitShouldWorkCorrectly()
        {
            JSInterop.SetupVoid("alert", _ => true);
            var component = RenderComponent<ReactiveFormsExample>();
            var formData = new FormData
            {
                FirstName = "Youssef",
                Password = "Password",
                Gender = "m",
                ShouldUseCity = true,
                City = 1
            };

            component.SetParametersAndRender(parameters => parameters
                .Add(p => p.FormModel, formData)
            );
            var form = component.Find("form");
            form.Submit();

            Assert.Contains("Youssef", component.Markup);
            Assert.Contains("Password", component.Markup);
        }
        [Fact]
        public async Task SearchMovies_WithEmptySearchTerm_ClearsSearchResults()
        {
            var cut = RenderComponent<MoviesSearch>();
            var inputElement = cut.Find(".MoviesSearch__input");
            inputElement.Change(""); 
            await Task.Delay(1000);
            var listItems = cut.FindAll(".MoviesSearch__list-group-item");
            Assert.Empty(listItems);
        }
        [Fact]
        public async Task SearchMovies_WithInvalidSearchTerm_DoesNotFetchData()
        {
            var cut = RenderComponent<MoviesSearch>();
            var inputElement = cut.Find(".MoviesSearch__input");
            inputElement.Change("A"); 
            await Task.Delay(1000); 
            var listItems = cut.FindAll(".MoviesSearch__list-group-item");
            Assert.Empty(listItems);
        }
        
    }
}