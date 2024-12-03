// Create a Nunit project
// Install Nuget Packages - NUnit, Nunit 3 test adapter, Selenium.WebDriver, Selenium.Support, Selenium.WebDriver.ChromeDriver.
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions; 
using System;
using System.Collections.ObjectModel;
using System.Threading;

namespace CheatSheet
{
    [TestFixture]
    //[Parallelizable(ParallelScope.All)] //to check Order annotation comment this line.

    public class SeleniumCommands
    {
        IWebDriver driver;

        [SetUp]
        public void StartBrowser()
        {
            driver = new ChromeDriver();
            /*
            ChromeOptions options = new ChromeOptions();
            options.AddArguments ("--disable-notifications"); // to disable notification
            driver new ChromeDriver (options);
            */
        }

        [Test, Order(1)]
        public void WebDrivrCmds()
        {
            driver.Navigate().GoToUrl("https://demoga.com/checkbox");
            string DemoQA_Url = "https://demoqa.com/alerts"; 
            driver.Navigate().GoToUrl(DemoQA_Url);
            driver.Navigate().Back();
            driver.Navigate().Forward();
            driver.Navigate().Refresh();

            string Current_WindowHandle = driver.CurrentWindowHandle;
            string Page_Source = driver.PageSource; 
            string Title_webpge = driver.Title;
            string Url_webpge = driver.Url;
            ReadOnlyCollection<string> winHandles = driver.WindowHandles;

            Cookie cook1 = new Cookie("welmsg", "goodmorning"); 
            Cookie cook2 = new Cookie("exitmsg", "goodbye");
            driver.Manage().Cookies.AddCookie(cook1);
            driver.Manage().Cookies.AddCookie(cook2);
            ReadOnlyCollection<Cookie> Cooks = driver.Manage().Cookies.AllCookies;
            string Cook_Domain = driver.Manage().Cookies.GetCookieNamed("welmsg").Domain;
            DateTime? Cook_Expiry = driver.Manage().Cookies.GetCookieNamed("welmsg").Expiry; 
            bool Cook_CheckHTTP = driver.Manage().Cookies.GetCookieNamed("welmsg").IsHttpOnly;
            string Cook_Name = driver.Manage().Cookies.GetCookieNamed("welmsg").Name;
            string Cook_Path = driver.Manage().Cookies.GetCookieNamed("welmsg").Path;
            string Cook_SameSite = driver.Manage().Cookies.GetCookieNamed("welmsg").SameSite;
            bool Cook_CheckIsSecure = driver.Manage().Cookies.GetCookieNamed("welmsg").Secure;
            string Cook_Value = driver.Manage().Cookies.GetCookieNamed("welmsg").Value; 
            driver.Manage().Cookies.DeleteCookie(cook1);
            driver.Manage().Cookies.DeleteCookieNamed("welmsg"); 
            driver.Manage().Cookies.DeleteAllCookies();

            ReadOnlyCollection<string> Logs = driver.Manage().Logs.AvailableLogTypes;
            ReadOnlyCollection<LogEntry> Get_Log1 = driver.Manage().Logs.GetLog(LogType.Browser);
            ReadOnlyCollection<LogEntry> Get_Log2 = driver.Manage().Logs.GetLog(LogType.Client); 
            ReadOnlyCollection<LogEntry> Get_Log3 = driver.Manage().Logs.GetLog(LogType.Driver);
            ReadOnlyCollection<LogEntry> Get_Log4 = driver.Manage().Logs.GetLog(LogType.Profiler);
            ReadOnlyCollection<LogEntry> Get_Log5 = driver.Manage().Logs.GetLog(LogType.Server);

            /*
            driver.Manage().Network. AddAuthenticationHandler();
            driver.Manage().Network. AddRequestHanaler (); 
            driver.Manage().Network. AddResponseHandler();
            driver.Manage().Network.ClearAuthenticationHandlers();
            driver.Manage().Network.ClearRequestHandlers();
            driver. Manage().Network.ClearResponseHandlers();
            EventHandler <NetworkResponseReceived EventArgs> networkResponseSent = driver.Manage().Network.NetworkRequestSent; 
            EventHandler<Network ResponseReceivedEventArgs> networkResponseReceived = driver. Manage().Network.NetworkResponseReceived; 
            driver.Manage().Network.StartMonitoring();
            driver.Manage().Network. StopMonitoring();
            */

            driver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(500);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(58); 
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(500);

            driver.Manage().Window.FullScreen();
            driver.Manage().Window.Minimize();
            driver.Manage().Window.Maximize();
            var Post = driver.Manage().Window.Position;
            var size = driver.Manage().Window.Size;

            driver.SwitchTo().ActiveElement();

            driver.SwitchTo().Alert().Accept();
            driver.SwitchTo().Alert().Dismiss(); 
            driver.SwitchTo().Alert().SendKeys("helo"); 
            driver.SwitchTo().Alert().Accept(); 
            driver.SwitchTo().Alert().SetAuthenticationCredentials("user1", "****"); 
            driver.SwitchTo().Alert().Accept(); 
            string Alert_Txt = driver.SwitchTo().Alert().Text;

            driver.SwitchTo().DefaultContent();

            driver.SwitchTo().Frame(1);
            driver.SwitchTo().Frame("framel"); 
            IWebElement Frm = driver.FindElement(By.TagName("iframe")); 
            driver.SwitchTo().Frame(Frm);

            driver.SwitchTo().NewWindow(WindowType.Window); 
            driver.SwitchTo().NewWindow(WindowType.Tab);

            driver.SwitchTo().ParentFrame();

            driver.SwitchTo().Window(driver.WindowHandles[0]); 
            driver.SwitchTo().Window(Current_WindowHandle);
            
            driver.Close();
            driver.Dispose();
            driver.Quit();

        }



        [Test, Order(5)]
        public void WebEleCmds()
        {
            driver.Navigate().GoToUrl("https://demoga.com/links");
            driver.Manage().Window.Maximize();

            driver.FindElement(By.ClassName("col-12 mt-4 col-md-6"));

            driver.FindElement(By.CssSelector("input[name='first_name']")); //by attribute syntax; tag[attribute='value"]
            driver.FindElement(By.CssSelector("#no-content")); //by id syntax: #id_value or syntax: tag#id_value
            driver.FindElement(By.CssSelector(".myform")); //by class syntax: .class_value or syntax: tag.class value
            driver.FindElement(By.CssSelector("input#Passwd[name='Pass']")); //by startswith syntax: tag [attribute= 'prefix of the string"]
            driver.FindElement(By.CssSelector("input#Passwd[names='wd']")); //by endswith syntax: tag[attributes= 'prefix of the string"]
            driver.FindElement(By.CssSelector("input #Passwd[name='wd']")); //by contains syntax: tag [attribute*='text']
            driver.FindElement(By.CssSelector("input:contains('wd')")); //by inner text contains syntax: tag: contains("text")
            driver.FindElement(By.CssSelector("div[class='calendar-day-']:not([class='unavailable'])")); //not
            driver.FindElement(By.CssSelector("ul#fruit li:last-child")); //Locating Multiple Child Element last child
            driver.FindElement(By.CssSelector("div#logo img")); //Locating Child Element
            driver.FindElement(By.CssSelector("ul#fruit li:nth-of-type (2)")); //Locating Multiple Child Element nth child

            driver.FindElement(By.Id("linkwrapper"));
            driver.FindElement(By.LinkText("Home"));
            driver.FindElement(By.PartialLinkText("Home"));
            driver.FindElement(By.Name("aswift_0"));
            driver.FindElement(By.TagName("strong"));

            driver.FindElement(By.XPath("//input(@id='firstName']")); //tag[@attribute= 'value']
            driver.FindElement(By.XPath("//*[@class='btn']")); //*[@attribute="value"]
            driver.FindElement(By.XPath("//strong[text()='Following']")); //text match //tag[text()= 'text value']
            driver.FindElement(By.XPath("//div[starts-with(@class,'react')]")); //partial text match starts with //tag[starts-with(@attribute,'text value')]
            driver.FindElement(By.XPath("//div[ends-with(@class,'class')]")); //partial text match ends with //tag[ends-with(@attribute, 'text value')]
            driver.FindElement(By.XPath("//p[contains(text(),'This text has random Id')]")); //contains //tag[ contains (text(), 'text )]
            driver.FindElement(By.XPath("(//div[@class='card-body'])[1]")); //multiple match (//tag[@attribute= value'])[n]
            driver.FindElement(By.XPath("//table[@class='dataTaple']/thead/tr/th")); //table
            driver.FindElement(By.XPath("//table[@class='dataTable']/tbody/tr/td[4]"));

            string i = "6";
            string j = "4";
            string Xpath_SpecificcellData = "//table[@class='dataTable']/tbody/tr[" + i + "]/td[" + j + "]";
            IWebElement Output_SpecificcellData = driver.FindElement(By.XPath(Xpath_SpecificcellData));

            ReadOnlyCollection<IWebElement> ListofMenu = driver.FindElements(By.ClassName("header-text"));

            driver.FindElement(By.XPath("//input[@id='firstName']")).Clear();
            driver.FindElement(By.XPath("//input[@id='firstName']")).Click();
            bool WebEl_Disp = driver.FindElement(By.XPath("//input[@id='firstName']")).Displayed;
            bool WebEl_Enab = driver.FindElement(By.XPath("//input[@id='firstName']")).Enabled;
            driver.FindElement(By.XPath("//input[@id='firstName']")).GetAttribute("value");
            driver.FindElement(By.XPath("//input[@id='firstName']")).GetCssValue("color");
            driver.FindElement(By.XPath("//input[@id='firstName'J")).GetDomAttribute("attr");
            driver.FindElement(By.XPath("//input[@id='firstName']")).GetDomProperty("prop");
            var WebEl_Loc = driver.FindElement(By.XPath("//input[@id='firstName']")).Location;
            var WebEl_Loc1 = driver.FindElement(By.XPath("//input[@id='firstName']")).Location.X;
            var WebEl_Loc2 = driver.FindElement(By.XPath("//input[@id= 'firstName' ]")).Location.Y;
            bool WebEl_Loc3 = driver.FindElement(By.XPath("//input[@id='firstName']")).Location.IsEmpty;
            bool WebEl_Sel = driver.FindElement(By.XPath("//input[@id='firstName']")).Selected;
            driver.FindElement(By.XPath("//input[@id='firstName']")).SendKeys("Marzooq");
            var WebEl_Size = driver.FindElement(By.XPath("//input[@id=' firstName']")).Size;
            var WebEl_Size1 = driver.FindElement(By.XPath("//input[@id='firstName']")).Size.Height;
            var WebEl_Size2 = driver.FindElement(By.XPath("//input[@ida' firstName']")).Size.Width;
            bool WebEl_Sizes = driver.FindElement(By.XPath("//input[@id='firstName']")).Size.IsEmpty;
            driver.FindElement(By.XPath("//input[@id='firstName']")).Submit();
            var WebEl_Txt = driver.FindElement(By.XPath("//input (@id=' firstName']")).Text;
            var WebEl_Tag = driver.FindElement(By.XPath("//input[@id='firstName']")).TagName;

            driver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(50);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(58);

            Thread.Sleep(5000);

            new WebDriverWait(driver, TimeSpan.FromSeconds(18)).Until(d => d.FindElement(By.Id("item-0")));
            //new WebDriverWait(ariver, TimeSpan. FromSeconds (10)). until (ExpectedConditions. ElementIsVisible (By.Id("item-0")));

            //HTML Tag <select><option value="red">Red</option>...</select>
            SelectElement Sdd = new SelectElement(driver.FindElement(By.Id("oldSelectMenu")));
            Sdd.SelectByValue("red"); //It takes a parameter of String which is on of the value (red) of option html tag.
            Sdd.SelectByIndex(4); //index starts from e //It takes a parameter of int, the index number of the option.
            Sdd.SelectByText("Red"); //It takes a parameter of String which is text (Red) of html tag.

            IWebElement Button = driver.FindElement(By.XPath("//button[@id='rigntClickBtn']"));
            IWebElement Source = driver.FindElement(By.XPath("//button[@id='rightClickBtn']"));
            IWebElement Destination = driver.FindElement(By.XPath("//button[@id='rightClickBtn']"));

            Actions act = new Actions(driver);
            act.Click(Button);
            act.ClickAndHold(Button);
            act.ContextClick(Button).Build().Perform();
            act.DoubleClick(Button).Build().Perform();
            act.DragAndDrop(Source, Destination).Build().Perform();
            act.DragAndDropToOffset(Source, Destination.Location.X, Destination.Location.Y).Build().Perform();
            act.KeyDown(Source, Keys.ArrowRight).Build().Perform(); //KeyDown for pressing
            act.KeyUp(Source, Keys.ArrowRight).Build().Perform(); //KeyUp for releasing
            act.MoveByOffset(Source.Location.X, Source.Location.Y).ClickAndHold()
                .MoveByOffset(Destination.Location.X, Destination.Location.Y).Release().Build().Perform();
            act.MoveToElement(Source).Build().Perform();
            act.Reset();
            act.SendKeys("jarvis");

            Assert.IsTrue(WebEl_Disp);
            Assert.IsFalse(WebEl_Disp);
            Assert.AreEqual(WebEl_Txt, WebEl_Tag);

            ITakesScreenshot screenshot = driver as ITakesScreenshot;
            Screenshot ss = screenshot.GetScreenshot(); ss.SaveAsFile(@"C:\Users\jarvis\Documents\ss1.png", ScreenshotImageFormat.Png); //formats Bmp Gif Png Jpeg Tiff

            IJavaScriptExecutor jsd = (IJavaScriptExecutor)driver;
            jsd.ExecuteScript("window. scrollTo(e, document.body.scrollHeight)");


        }
        

        [Test]
        public void BrokenLink()
        {
            ReadOnlyCollection<IWebElement> Links = driver.FindElements(By.PartialLinkText("Click Here for"));
            foreach (IWebElement link in Links)
            {
                string urls = link.GetAttribute("href"); 
                CheckLink(urls);
            }
        }
        private static void CheckLink(string urls)
        {

            System.Net.HttpWebRequest req = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(urls); 
            req.AllowAutoRedirect = true;
            try
            {
                System.Net.HttpWebResponse response = (System.Net.HttpWebResponse)req.GetResponse();

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    response.Close();
                }
                else
                {
                    Console.WriteLine(response.StatusCode);
                }
            }
            catch (System.Net.WebException ex)
            {
                var Exc = ex.Message;
                Console.WriteLine(Exc);
            }
        }

        [Test]
        [Ignore("Ignored Donately intentionally to understand how Ignore Annotation works")]
        public void Ignored()
        {
            driver.Navigate().GoToUrl("https://www.e-learningforkids.org/"); 
            driver.Manage().Window.Maximize();
            driver.Quit();
        }

        [Test, Order(3)]
        [TestCase("Apple")]
        [TestCase("Blackberry")]
        [TestCase("Canava")]
        public void Source1(string Name)
        {
            driver.Navigate().GoToUrl("https://www.freelogodesign.org/");
            driver.Manage().Window.Maximize(); 
            IWebElement TextBox = driver.FindElement(By.XPath("//input[@id='txtCompanyName']"));
            TextBox.SendKeys(Name); 
            IWebElement Get_Btn = driver.FindElement(By.XPath("//button[@class='startAll fld-btn fld-btn-full-width']"));
            Get_Btn.Click();
            driver.Quit();
        }

        [Test, Order(4), TestCaseSource("DataSource")] 
        //[Ignore("Server Error")]
        public void Source2(string txt, string tag)
        {
            driver.Navigate().GoToUrl("https://www.designimo.com/");
            driver.Manage().Window.Maximize();
            IWebElement TextBox = driver.FindElement(By.XPath("//input[@id='company_name']"));
            TextBox.Click();
            TextBox.SendKeys(txt);
            IWebElement Create_Btn = driver.FindElement(By.XPath("//input[@value='Create Logo Now']"));
            Create_Btn.Click();
            IWebElement TagBox = driver.FindElement(By.XPath("//input[@id='tagline']"));
            TagBox.Click();
            TagBox.SendKeys(tag);
            driver.Quit();
        }

        public static object[] DataSource()
        {
            object[][] obj = new object[3][];

            obj[0] = new object[2];
            obj[0][0] = "heisenberg";
            obj[0][1] = "SayMyName";

            obj[1] = new object[2];
            obj[1][0] = "ironman"; obj[1][1] = "AmericanCheeseburger";
            obj[2] = new object[2]; obj[2][1] = "WinterIsComing";
            obj[2][0] = "jonsnow";
            return obj;
        }

        [TearDown]
        public void CloseBroswer()
        {
            driver.Close();
        }

    }
}
