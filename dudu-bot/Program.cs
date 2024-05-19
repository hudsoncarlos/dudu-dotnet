using FacebookLoginAutomatico.Model;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace FaceboolLoginAutomation
{
    public class Program
    {
        static void Main(string[] args)
        {    
            var _configuration = SetObjetoConfiguration();
            IWebDriver webDriver = null;
            
            var listaContaEscavos = new List<PerfilEscravo>() 
            {
                new PerfilEscravo() { Id = 1, Login = "poker10ao@gmail.com", Senha = "Ztqk4MVv87835R9d835CgvGsc%jS", NomePerfilPatrao = "tisuvax" },
                new PerfilEscravo() { Id = 2, Login = "poker10ao@gmail.com", Senha = "Ztqk4MVv87835R9d835CgvGsc%jS", NomePerfilPatrao = "tisuvax" },
                new PerfilEscravo() { Id = 3, Login = "poker10ao@gmail.com", Senha = "Ztqk4MVv87835R9d835CgvGsc%jS", NomePerfilPatrao = "tisuvax" }
            };

            foreach (var item in listaContaEscavos)
            {
                try
                {
                    webDriver = LaunchBrowser();
                    webDriver.Manage().Window.Position = new Point();
                    webDriver.Manage().Window.Size = new Size(1280, 1050);

                    var facebookAutomation = new FacebookAutomation(webDriver, _configuration);
                    facebookAutomation.Login(item.Login, item.Senha, item.NomePerfilPatrao);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error while executing automation");
                    Console.WriteLine(ex.ToString());
                }
                finally
                {
                    webDriver.Quit();
                }
            }

            Console.ReadKey();
        }

        private static IConfiguration SetObjetoConfiguration() =>
            new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true).Build();

        static IWebDriver LaunchBrowser()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            options.AddArgument("--disable-notifications");

            var driver = new ChromeDriver(Environment.CurrentDirectory, options);
            return driver;
        }
    }
}