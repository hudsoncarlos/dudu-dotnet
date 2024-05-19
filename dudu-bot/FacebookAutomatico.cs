using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;
using System.Threading;

namespace FaceboolLoginAutomation
{
    public class FacebookAutomation
    {
        private readonly IWebDriver webDriver;
        private readonly IConfiguration _configuration;

        public FacebookAutomation(IWebDriver webDriver, IConfiguration configuration)
        {
            this.webDriver = webDriver;
            this._configuration = configuration;
        }

        public void Login(string username, string password, string nomePerfil)
        {
            // Navigate to Facebook
            webDriver.Url = _configuration["Facebook:URL"];

            // Procura o campo email pelo id email e seta o email do usuario 
            var inputIdEmail = webDriver.FindElements(By.Id(_configuration["Facebook:ID_EMAIL"]));
            if (inputIdEmail.Count == 0)
            {
                Console.WriteLine("O id do campo EMAIL mudou! DEU RUIM!");
                return;
            }
            var input = webDriver.FindElement(By.Id(_configuration["Facebook:ID_EMAIL"]));
            input.SendKeys(username);

            // Procura o campo senha pelo id pass e seta a senha
            if (webDriver.FindElements(By.Id(_configuration["Facebook:ID_SENHA"])).Count == 0)
            {
                Console.WriteLine("O id do campo SENHA mudou! DEU RUIM!");
                return;
            }
            input = webDriver.FindElement(By.Id(_configuration["Facebook:ID_SENHA"]));
            input.SendKeys(password);

            // Click no botão de Entrar para fazer login
            if (webDriver.FindElements(By.Name(_configuration["Facebook:NAME_BTN_ENTRAR"])).Count == 0)
            {
                Console.WriteLine("O name do botão ENTRAR mudou! DEU RUIM!");
                return;
            }
            //ClickAndWaitForPageToLoad(webDriver, By.Name(_configuration["Facebook:NAME_BTN_ENTRAR"]));
            input = webDriver.FindElement(By.Name(_configuration["Facebook:NAME_BTN_ENTRAR"]));
            input.Click();
            //var teste = WebDriverExtensions.FindElement(webDriver, By.Name(_configuration["Facebook:XPATH_CRIAR_PUBLICACAO"]), 5);

            // Procura o campo de pesquisa pelo name global_typeahead e seta o nome do usuario a ser seguido
            //input = webDriver.FindElement(By.Name("global_typeahead"));
            //input.SendKeys("Guilher Costa Ferreira");

            // Acessar URL do perfil direto pela url
            webDriver.Url = "https://www.facebook.com/" + nomePerfil;

            Thread.Sleep(1000);

            // Click no botão de Adicionar
            if (webDriver.FindElements(By.XPath(_configuration["Facebook:XPATH_BTN_ADICIONAR"])).Count == 0)
            {
                Console.WriteLine("O XPath do botão adicionar mudou! DEU RUIM!");
                return;
            }
            //ClickAndWaitForPageToLoad(webDriver, By.XPath(_configuration["Facebook:XPATH_BTN_ADICIONAR"]));
            input = webDriver.FindElement(By.Name(_configuration["Facebook:NAME_BTN_ENTRAR"]));
            input.Click();
            //teste = WebDriverExtensions.FindElement(webDriver, By.XPath(_configuration["Facebook:XPATH_BTN_ADICIONAR"]), 5);

            TirarPrint(webDriver, username);
        }

        private void ClickAndWaitForPageToLoad(IWebDriver driver, By elementLocator, int timeout = 10)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
                var elements = driver.FindElements(elementLocator);
                if (elements.Count == 0)
                    throw new NoSuchElementException("No elements " + elementLocator + " ClickAndWaitForPageToLoad");

                var element = elements.FirstOrDefault(e => e.Displayed);
                element.Click();
                wait.Until(ExpectedConditions.StalenessOf(element));
            }
            catch (NoSuchElementException ex)
            {
                Console.WriteLine("Element with locator: '" + elementLocator + "' was not found.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error em ClickAndWaitForPageToLoad " + ex.Message + " - " + ex.StackTrace + ex.ToString());
            }
        }

        private void TirarPrint(IWebDriver driver, string username)
        {
            try
            {
                Screenshot screenshot = (driver as ITakesScreenshot).GetScreenshot();
                screenshot.SaveAsFile(@"Prints\" + username + ".png"); // Format values are Bmp, Gif, Jpeg, Png, Tiff
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro " + ex.Message + " - " + ex.StackTrace);
            }
        }
    }

    public static class WebDriverExtensions
    {
        public static IWebElement FindElement(this IWebDriver driver, By by, int timeoutInSeconds)
        {
            try
            {
                if (timeoutInSeconds > 0)
                {
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                    return wait.Until(drv => drv.FindElement(by));
                }
                return driver.FindElement(by);
            }
            catch (NoSuchElementException ex)
            {
                Console.WriteLine("Element with locator: '" + by + "' was not found.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error em ClickAndWaitForPageToLoad " + ex.Message + " - " + ex.StackTrace + ex.ToString());
            }

            return driver.FindElement(by);
        }
    }
}