using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;
using System.Collections;
using System.IO;
using System.Drawing;
using System.Text.RegularExpressions;
using ShoppingCart.Models;
using Bots;


/*
 Course: ACST 3540
Section 01
Name: Noel Rhymer
Professor: Shaw
Assignment: HW8
*/



namespace ShoppingCart.Controllers
{
    public class HomeController : Controller
    {

        // Text for Site Heading
        string siteHeading = "The Game Store";

        // Text for Order View Heading
        string orderHeading = "Video Games ";

        // Text for View Heading for each Tab
        string[] tabHeadings = { "Home", "Open World", "Fighting",
                                   "Shooting", "Console",
                                   "Check-Out", "Admin", "About","Help Desk" };

        // View method name for each Tab
        string[] tabViews = { "Index", "Tab1Orders", "Tab2Orders", "Tab3Orders","Tab4Orders",
                                   "CheckOut", "Admin", "About", "HelpDesk" };

        // View label displayed on each Tab
        string[] tabLabels = { "Home", "Open World Games", "Fighting Games", "Shooting Games", "Video Games Consoles",
                                   "Check-Out", "Admin", "About", "Help Desk" };

        // Text for View Heading of any Options columns
        string[] optionsColumnHeading = { "", "Open World Games",
                                              "", "", "", "", "" };

        // The tax rate is 5%
        decimal taxRate = 0.05M;

        // Email address of the company that will be in the "From" box
        //  of the confirmation message sent
        string websiteEmail = "order@videogamestore.com";


        public ActionResult Index()
        {
            Session["PageHeading"] = siteHeading;
            ViewBag.Title = "Home Page for " + siteHeading;
            ViewBag.Message = "<b>Welcome to " + siteHeading + "!</b>";
            ViewBag.Message += "<br /><img src=\"/Images/logo.jpg\">";
            ViewBag.Message += "<br /><b><span style=\"color: black;\">";
            ViewBag.Message += "This is the Game Store of your Dreams!</span></b>";

            return View();
        }

        public ActionResult About()
        {
            Session["PageHeading"] = siteHeading;
            ViewBag.Title = "About " + siteHeading;
            ViewBag.Message = "The Webmaster of this site is: ";
            ViewBag.Message += "<br /> Prof. Shaw";
            ViewBag.Message += "<br /> <img src='/Images/aboutus.jpg'>";

            return View();
        }

        // Action Method for First Product View
        public ActionResult Tab1Orders()
        {
            int tabNum = 1;
            Session["PageHeading"] = orderHeading;
            Session["ProductType"] = tabViews[tabNum];
            ViewBag.Message = Session["Message"] = tabHeadings[tabNum] + " Orders:";
            return View(LoadViewTableData(Session["ProductType"].ToString(), tabNum));
        }

        // Action Method for First Product View
        [HttpPost]
        public ActionResult Tab1Orders(string button, FormCollection collection)
        {
            int tabNum = 1;
            string pType = Session["ProductType"].ToString();
            int amount = Int32.Parse(Session[pType + "ItemAmount"].ToString());

            LoadSubmission(pType, amount, collection);

            for (int i = 1; i <= amount; i++)
            {
                int value;
                if (!Int32.TryParse(collection[i - 1], out value) || value < 0)
                {
                    ViewBag.Message = "<div style=\"color:#800\">" +
                                       "Error: Invalid entry in Item #" + i +
                                        "</div><br />" + Session["Message"].ToString();
                    return View(pType, LoadViewTableData(pType, tabNum));
                }
            }

            if (button == "Save And Go To Checkout")
            {
                return RedirectToAction("CheckOut");
            }
            else
            {
                // This is the View for the next product page
                return RedirectToAction(tabViews[tabNum + 1]);
            }
        }

        // Action Method for Second Product View
        public ActionResult Tab2Orders()
        {
            int tabNum = 2;
            Session["PageHeading"] = orderHeading;
            Session["ProductType"] = tabViews[tabNum];
            ViewBag.Message = Session["Message"] = tabHeadings[tabNum] + " Orders:";
            return View(LoadViewTableData(Session["ProductType"].ToString(), tabNum));
        }

        // Action Method for Second Product View
        [HttpPost]
        public ActionResult Tab2Orders(string button, FormCollection collection)
        {
            int tabNum = 2;
            string pType = Session["ProductType"].ToString();
            int amount = Int32.Parse(Session[pType + "ItemAmount"].ToString());

            LoadSubmission(pType, amount, collection);

            for (int i = 1; i <= amount; i++)
            {
                int value;
                if (!Int32.TryParse(collection[i - 1], out value) || value < 0)
                {
                    ViewBag.Message = "<div style=\"color:#800\">" +
                                       "Error: Invalid entry in Item #" + i +
                                        "</div><br />" + Session["Message"].ToString();
                    return View(pType, LoadViewTableData(pType, tabNum));
                }
            }

            if (button == "Save And Go To Checkout")
            {
                return RedirectToAction("CheckOut");
            }
            else
            {
                // This is the View for the next product page
                return RedirectToAction(tabViews[tabNum + 1]);
            }
        }

        // Action Method for Second Product View
        public ActionResult Tab3Orders()
        {
            int tabNum = 3;
            Session["PageHeading"] = orderHeading;
            Session["ProductType"] = tabViews[tabNum];
            ViewBag.Message = Session["Message"] = tabHeadings[tabNum] + " Orders:";
            return View(LoadViewTableData(Session["ProductType"].ToString(), tabNum));
        }

        // Action Method for Second Product View
        [HttpPost]
        public ActionResult Tab3Orders(string button, FormCollection collection)
        {
            int tabNum = 3;
            string pType = Session["ProductType"].ToString();
            int amount = Int32.Parse(Session[pType + "ItemAmount"].ToString());

            LoadSubmission(pType, amount, collection);

            for (int i = 1; i <= amount; i++)
            {
                int value;
                if (!Int32.TryParse(collection[i - 1], out value) || value < 0)
                {
                    ViewBag.Message = "<div style=\"color:#800\">" +
                                       "Error: Invalid entry in Item #" + i +
                                        "</div><br />" + Session["Message"].ToString();
                    return View(pType, LoadViewTableData(pType, tabNum));
                }
            }

            if (button == "Save And Go To Checkout")
            {
                return RedirectToAction("CheckOut");
            }
            else
            {
                // This is the View for the next product page
                return RedirectToAction(tabViews[tabNum + 1]);
            }
        }

        // Action Method for Second Product View
        public ActionResult Tab4Orders()
        {
            int tabNum = 4;
            Session["PageHeading"] = orderHeading;
            Session["ProductType"] = tabViews[tabNum];
            ViewBag.Message = Session["Message"] = tabHeadings[tabNum] + " Orders:";
            return View(LoadViewTableData(Session["ProductType"].ToString(), tabNum));
        }

        // Action Method for Second Product View
        [HttpPost]
        public ActionResult Tab4Orders(string button, FormCollection collection)
        {
            int tabNum = 4;
            string pType = Session["ProductType"].ToString();
            int amount = Int32.Parse(Session[pType + "ItemAmount"].ToString());

            LoadSubmission(pType, amount, collection);

            for (int i = 1; i <= amount; i++)
            {
                int value;
                if (!Int32.TryParse(collection[i - 1], out value) || value < 0)
                {
                    ViewBag.Message = "<div style=\"color:#800\">" +
                                       "Error: Invalid entry in Item #" + i +
                                        "</div><br />" + Session["Message"].ToString();
                    return View(pType, LoadViewTableData(pType, tabNum));
                }
            }

            if (button == "Save And Go To Checkout")
            {
                return RedirectToAction("CheckOut");
            }
            else
            {
                // This is the View for the next product page
                return RedirectToAction(tabViews[tabNum + 1]);
            }
        }

        // Gets the list of tabs and the Site heading label
        public ActionResult GetTabs(string id)
        {
            string headStr = "";
            if (Session["PageHeading"] != null)
            {
                headStr += "<ul id=\"head\"><li>";
                if (tabViews.Length > 0)
                    headStr += "<a href=\"/Home/" + tabViews[0] + "\">";
                headStr += Session["PageHeading"].ToString();
                headStr = headStr.Replace(":", "");
                if (tabViews.Length > 0)
                    headStr += "</a>";
                headStr += "</li></ul>:";
            }
            int tabNum = -1;
            for (int i = 0; i < tabViews.Length && tabNum < 0; ++i)
                if (tabViews[i].ToLower() == id.ToLower())
                    tabNum = i;
            string tabStr = "<ul id=\"menu\">" + Environment.NewLine;
            for (int i = 0; i < tabViews.Length; ++i)
            {
                tabStr += "<li>";
                if (i != tabNum)
                    tabStr += "<a href=\"/Home/" + tabViews[i] + "\">";
                tabStr += tabLabels[i];
                if (i != tabNum)
                    tabStr += "</a>";
                tabStr += "</li>" + Environment.NewLine;
            }
            tabStr += "</ul>";

            return Content(headStr + tabStr);
        }

        // Loads the submission details into session variables for each tab
        public void LoadSubmission(string name, int amount, FormCollection collection)
        {
            for (int i = 1; i <= amount; i++)
            {
                int value;
                if (!Int32.TryParse(collection[i - 1], out value))
                    continue;
                Session[String.Format("{0}Amount{1}", name, i)] = collection[i - 1];
                Session[String.Format("{0}Price{1}", name, i)] =
                    Double.Parse(Session[String.Format("{0}UnitPrice{1}",
                      name, i)].ToString()) * value;
            }
        }

        // Converts table entries for a particular product type into a list of products for the website
        private List<Product> LoadViewTableData(string pType, int viewIndex)
        {
            using (ShoppingCartDBEntities1Entities1 db1 = new ShoppingCartDBEntities1Entities1())
            {
                var productItems = from wp in db1.Products where (wp.ProductType == pType) select wp;
                int index = 1;
                foreach (var p in productItems)
                {
                    string pathlabel = "";
                    Session[pType + "ProductName" + index] = "";
                    if (String.IsNullOrWhiteSpace(p.ProductName) && String.IsNullOrWhiteSpace(p.ImageFile))
                        pathlabel = "[No Image]";
                    else
                    {
                        if (!String.IsNullOrWhiteSpace(p.ProductName))
                        {
                            pathlabel = p.ProductName.Trim();
                            Session[pType + "ProductName" + index] = pathlabel;
                            if (!String.IsNullOrWhiteSpace(p.ImageFile))
                                pathlabel += ":<br />";
                        }
                        if (!String.IsNullOrWhiteSpace(p.ImageFile))
                            pathlabel += "<img src=\"/Images/" + p.ImageFile.Trim() + "\" alt=\"Store Product Image\" />";
                    }
                    Session[pType + "Path" + index] = pathlabel;
                    Session[pType + "UnitPrice" + index] = p.UnitPrice;
                    int amount;
                    if (Session[pType + "Amount" + index] == null)
                        amount = (p.DefaultAmount >= 0) ? p.DefaultAmount : 0;
                    else
                        amount = Int32.Parse(Session[pType + "Amount" + index].ToString());
                    ViewData["DefaultChoice" + index] = Convert.ToString(amount);
                    ++index;
                }
                Session[pType + "ItemAmount"] = productItems.Count();
                return productItems.ToList();
            }
        }

        // Builds a string that is an HTML lists of all of the products purchased
        private string GetSessionItemString(string name, string title, int amount, ref decimal total)
        {
            string ItemStr = "", OptionStr;
            for (int i = 1; i <= amount; i++)
                if (!string.IsNullOrEmpty((string)Session[String.Format("{0}Amount{1}", name, i)]) &&
                              (string)Session[String.Format("{0}Amount{1}", name, i)] != "0")
                {
                    ItemStr += "<tr><td align=\"center\"><b>" +
                                      String.Format("{0} {1}", Session[name + "Amount" + i], title);
                    if ((string)Session[String.Format("{0}Amount{1}", name, i)] != "1" &&
                              ItemStr.ToLower().Substring(ItemStr.Length - 1) != "s")
                        ItemStr += "s";

                    if (Session[String.Format("{0}ProductName{1}", name, i)] != null &&
                           !string.IsNullOrEmpty((string)Session[String.Format("{0}ProductName{1}", name, i)]))
                        ItemStr += String.Format(":<br /><span style=\"color: #8A2BE2;\" color=\"#8A2BE2\"><i>{0}</i></span>",
                                                 (string)Session[String.Format("{0}ProductName{1}", name, i)]);
                    else
                        //ItemStr += String.Format("<br />(Option {0})", i);
                        ItemStr += String.Format("<br />(Item {0})", i);

                    OptionStr = (string)Session[String.Format("{0}Option_{1}", name, i)];
                    ItemStr += String.Format("<br />{0}Total: ", OptionStr);
                    ItemStr += String.Format("{0:C}", Session[String.Format("{0}Price{1}", name, i)]);
                    ItemStr += "</b></td>" + Environment.NewLine;
                    ItemStr += "<td align=\"center\"><b><i>" + Session[String.Format("{0}Path{1}", name, i)];
                    ItemStr += "</i></b></td></tr>" + Environment.NewLine;
                    total += Convert.ToDecimal(Session[String.Format("{0}Price{1}", name, i)]);
                }
            return ItemStr;
        }

        // Builds a string that is an text lists of all of the products purchased
        public string GetSessionItemString2(string name, string title, int amount, ref decimal total, string prevStr)
        {
            string ItemStr = "", OptionStr;
            for (int i = 1; i <= amount; i++)
                if (!string.IsNullOrEmpty((string)Session[String.Format("{0}Amount{1}", name, i)]) &&
                     (string)Session[String.Format("{0}Amount{1}", name, i)] != "0")
                {
                    if (!string.IsNullOrEmpty(ItemStr))
                        ItemStr += "%%%";
                    ItemStr += String.Format("{0} {1}", Session[String.Format("{0}Amount{1}", name, i)], title);
                    if ((string)Session[String.Format("{0}Amount{1}", name, i)] != "1" &&
                              ItemStr.ToLower().Substring(ItemStr.Length - 1) != "s")
                        ItemStr += "s";
                    if (Session[String.Format("{0}ProductName{1}", name, i)] != null &&
                           !string.IsNullOrEmpty((string)Session[String.Format("{0}ProductName{1}", name, i)]))
                        ItemStr += String.Format(" ({0}) for ",
                                                 (string)Session[String.Format("{0}ProductName{1}", name, i)]);
                    else
                        //ItemStr += String.Format(" (Option {0}) for ", i);
                        ItemStr += String.Format(" (Item {0}) for ", i);
                    ItemStr += String.Format("{0:C}", Session[String.Format("{0}Price{1}", name, i)]);
                    total += Convert.ToDecimal(Session[String.Format("{0}Price{1}", name, i)]);

                    OptionStr = (string)Session[String.Format("{0}Option2_{1}", name, i)];
                    if (OptionStr != "")
                        ItemStr += OptionStr;
                }
            if (!string.IsNullOrEmpty(ItemStr) & !string.IsNullOrEmpty(prevStr))
                ItemStr = "%%%" + ItemStr;
            return ItemStr;
        }

        // Action Method for Checkout View
        public ActionResult CheckOut()
        {
            ViewBag.Message = "Checking Out - The following items are in your Shopping Cart:";

            string ItemList = "";
            decimal SubTotalPrice = 0.0M;
            for (int i = 0; i < tabViews.Length; ++i)
                if (Session[tabViews[i] + "ItemAmount"] != null)
                {
                    int amount = Int32.Parse(Session[tabViews[i] + "ItemAmount"].ToString());
                    ItemList += GetSessionItemString(tabViews[i], tabHeadings[i], amount, ref SubTotalPrice);
                }

            ViewBag.HasItems = false;
            if (string.IsNullOrEmpty(ItemList))
                ItemList += "<pre style=\"font-size: 16px;\"><b>  [ Nothing Was Purchased ]</b></pre>";
            else
            {
                ItemList = "<table>" + ItemList + "</table>";
                ItemList += "<p></p><style type=\"text/css\">";
                ItemList += "table.summary { border-width: 0px; }";
                ItemList += "table.summary td { border-width: 0px; font-size: 16px; ";
                ItemList += "padding: 3px; font-weight:bold; text-align:right; }";
                ItemList += "</style><table class=\"summary\">";
                ItemList += "<tr><td>SubTotal:</td><td width=\"30\"></td><td>";
                ItemList += String.Format("{0:0.00}", SubTotalPrice);
                ItemList += "</td></tr><tr><td>Tax:</td><td></td><td>";
                ItemList += String.Format("{0:0.00}", decimal.Round(SubTotalPrice * taxRate, 2));
                ItemList += "</td></tr><tr><td>Total Purchase Price:</td><td></td><td>";
                ItemList += String.Format("{0:C}", SubTotalPrice + decimal.Round(SubTotalPrice * taxRate, 2));
                ItemList += "</td></tr>";
                ItemList += "</table>";
                ViewBag.HasItems = true;
            }
            ViewBag.Message2 = ItemList;

            return View();
        }

        // Action Method for getting Customers billing (registration) information
        public ActionResult ShoppingCartAccount()
        {
            ViewBag.Message = "Please Fill In Your Billing Information";
            ViewBag.Message += " (entries with * are required):";
            return View();
        }

        // Action Method for getting Customers billing (registration) information
        [HttpPost]
        public ActionResult ShoppingCartAccount(Customer accountToCreate)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ViewBag.Message = "Please correct the following error(s):";
                    return View();
                }

                string ItemList = "";
                decimal SubTotalPrice = 0.0M;
                for (int i = 0; i < tabViews.Length; ++i)
                    if (Session[tabViews[i] + "ItemAmount"] != null)
                    {
                        int amount = Int32.Parse(Session[tabViews[i] + "ItemAmount"].ToString());
                        ItemList += GetSessionItemString2(tabViews[i], tabHeadings[i], amount, ref SubTotalPrice, ItemList);
                    }
                ItemList += String.Format("%%%%%%<h3>SubTotal: {0:C}", SubTotalPrice);
                ItemList += String.Format("%%%Tax: {0:C}", decimal.Round(SubTotalPrice * taxRate, 2));
                ItemList += String.Format("%%%Total Purchase Price: {0:C}</h3>", SubTotalPrice +
                                                           decimal.Round(SubTotalPrice * taxRate, 2));

                Session["Name"] = String.Format("{0} {1}", accountToCreate.FirstName, accountToCreate.LastName);
                Session["Email"] = accountToCreate.Email;
                Session["ItemList"] = ItemList;

                using (ShoppingCartDBEntities1Entities db = new ShoppingCartDBEntities1Entities())
                {
                    db.Customers.Add(accountToCreate);
                    db.SaveChanges();
                }

                for (int i = 0; i < tabViews.Length; ++i)
                    if (Session[tabViews[i] + "ItemAmount"] != null)
                    {
                        int amount = Int32.Parse(Session[tabViews[i] + "ItemAmount"].ToString());
                        for (int j = 1; j <= amount; ++j)
                        {
                            Session[tabViews[i] + "Amount" + j] = "0";
                            Session[tabViews[i] + "Price" + j] = 0.0;
                            Session[tabViews[i] + "Option_" + j] = "";
                            Session[tabViews[i] + "Option2_" + j] = "";
                        }
                    }

                return RedirectToAction("ConfirmPurchase");
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Error processing data: " + GetError(ex);
                return View();
            }
        }

        // Action Method for confirming the Customer's purchases
        public ActionResult ConfirmPurchase()
        {
            ViewBag.Message = "Thanks for making your purchase with " + siteHeading + "!";
            ViewBag.Message2 = "Your items are being shipped, and an email has been sent<br />";
            ViewBag.Message2 += "with the following order details for your records:<p></p><hr /><p></p>";
            ViewBag.Message2 += Session["ItemList"].ToString().Replace("%%%", "<br />");
            ViewBag.Message2 += "<p></p><hr />";

            MailMessage message = new MailMessage();
            message.From = new MailAddress(websiteEmail);
            message.To.Add(new MailAddress(Session["Email"].ToString()));
            message.Subject = "Store Purchase Confirmation (" + DateTime.Now.ToString("MM/dd/yyyy") + ")";
            message.Body = "Hi " + Session["Name"].ToString() + ",<p>";
            message.Body += "The following order was received, and will be shipped shortly:<p>";
            message.Body += Session["ItemList"].ToString().Replace("%%%", "<br>")
                               .Replace("<h3>", "").Replace("</h3>", "");
            message.IsBodyHtml = true;

            SmtpClient client = new SmtpClient();
            client.Host = "208.73.222.114";
            client.Port = 7301;
            client.Send(message);

            return View();
        }

        // Action Method for providing admin functions
        [Authorize]
        public ActionResult Admin()
        {
            ViewBag.Message = "Website Administration:";
            return View();
        }

        // Admin view for listing all Customer Accounts
        [Authorize]
        public ActionResult Customers(string sortOrder)
        {
            using (ShoppingCartDBEntities1Entities db = new ShoppingCartDBEntities1Entities())
            {
                ViewBag.Message = "Customer Accounts:";

                ViewBag.LastNameSortParm = String.IsNullOrEmpty(sortOrder) ? "LastName desc" : "";
                ViewBag.FirstNameSortParm = (sortOrder == "FirstName" ? "FirstName desc" : "FirstName");
                ViewBag.IDSortParm = (sortOrder == "ID" ? "ID desc" : "ID");
                ViewBag.AmountSortParm = (sortOrder == "Amount" ? "Amount desc" : "Amount");

                var accounts = from a in db.Customers select a;

                switch (sortOrder)
                {
                    case "FirstName":
                        accounts = accounts.OrderBy(s => s.FirstName);
                        break;
                    case "FirstName desc":
                        accounts = accounts.OrderByDescending(s => s.FirstName);
                        break;
                    case "ID":
                        accounts = accounts.OrderBy(s => s.ID);
                        break;
                    case "ID desc":
                        accounts = accounts.OrderByDescending(s => s.ID);
                        break;
                    case "Amount":
                        accounts = accounts.OrderBy(s => s.ID);
                        break;
                    case "Amount desc":
                        accounts = accounts.OrderByDescending(s => s.ID);
                        break;
                    case "LastName desc":
                        accounts = accounts.OrderByDescending(s => s.LastName);
                        break;
                    default:
                        accounts = accounts.OrderBy(s => s.LastName);
                        break;
                }

                return View(accounts.ToList());
            }
        }

        // Admin view for reviewing a Customer Account
        [Authorize]
        public ActionResult CustomerDetails(int ID)
        {
            using (ShoppingCartDBEntities1Entities db = new ShoppingCartDBEntities1Entities())
            {
                ViewBag.Message = "Customer Account Details:";
                try
                {
                    Customer theAccount = db.Customers.First(p => p.ID == ID);
                    return View(theAccount);
                }
                catch
                {
                    return RedirectToAction("Error");
                }
            }
        }

        // Admin view for editing a Customer Account
        [Authorize]
        public ActionResult EditCustomer(int ID)
        {
            using (ShoppingCartDBEntities1Entities db = new ShoppingCartDBEntities1Entities())
            {
                ViewBag.Message = "Edit Customer Account:";
                try
                {
                    Customer theAccount = db.Customers.First(p => p.ID == ID);
                    return View(theAccount);
                }
                catch
                {
                    return RedirectToAction("Error");
                }
            }
        }

        // Admin view for editing a Customer Account
        [HttpPost, Authorize]
        public ActionResult EditCustomer(Customer account)
        {
            using (ShoppingCartDBEntities1Entities db = new ShoppingCartDBEntities1Entities())
            {
                try
                {
                    if (!ModelState.IsValid)
                    {
                        ViewBag.Message = "Error editing account:";
                        return View("EditCustomer", account);
                    }

                    Customer theAccount = db.Customers.First(p => p.ID == account.ID);

                    theAccount.FirstName = account.FirstName;
                    theAccount.LastName = account.LastName;
                    theAccount.StreetAddress = account.StreetAddress;
                    theAccount.City = account.City;
                    theAccount.State = account.State;
                    theAccount.Zip = account.Zip;
                    theAccount.Phone = account.Phone;
                    theAccount.Email = account.Email;
                    db.SaveChanges();

                    return RedirectToAction("Customers");
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "Error editing account: " + GetError(ex);
                    return View("EditCustomer", account);
                }
            }
        }

        // General error message view
        public ActionResult Error()
        {
            ViewBag.Message = "System Error: Invalid Data";
            return View();
        }

        // Gets the appropriate error message from an exception
        public string GetError(Exception ex)
        {
            if (ex == null || ex.Message == null)
                return "";
            if (ex.Message.ToLower().IndexOf("inner exception") > -1)
            {
                string message = ex.InnerException.ToString();
                int n = -1;
                var match = Regex.Match(message, "\\.\\s");
                if (match.Success)
                {
                    n = match.Index;
                    match = Regex.Match(message.Substring(n + 1), "\\.\\s");
                    if (match.Success)
                        n += match.Index + 1;
                }
                return (n < 1) ? message : message.Substring(0, n + 1);
            }
            return ex.Message;
        }

        public ActionResult HelpDesk(string sentence)
        {
            ViewBag.Title = "Help Desk";
            ViewBag.Message = "Welcome to the Help Desk!";
            ViewBag.Message2 = "Help Desk Response:";
            ViewBag.Message3 = "Your Question:";

            return View();
        }

     
             public ActionResult AnswerQuestion(string sentence)
        {
            ChatBot chat = new ChatBot();
            string answer1 = "You want a fighting Game";
            string answer2 = "You want a Shooting Game";
            string answer3 = "You want a Open World Game";
            string answer4 = "You want a New Console";
            string answer5 = "Yes this game is Great";
            string answer6 = "You Want GTA V";
            string answer7 = "You Want Dragonball Xeneoverse";
            string answer8 = "Tekken Would Be Great for You";
            string answer9 = "Call Of Duty Black Ops 3 Is the fastest";
            string answer10 = "Battlefield 1 would suit you well";
            string answer11 = "How Can I Help You";
            string answer12 = "It has Great Reviews";
            string answer13 = "They All are Great";
            string answer14 = "You want a Xbox Then";
            string answer15 = "No Problem!";
            string answer16 = "How Can I Help You";
           

            chat.KeyResponseAny(answer1, "Violent", "fight", "fun");
            chat.KeyResponseAny(answer2, "Guns", "Running", "fun");
            chat.KeyResponseAny(answer3, "Driving","Shoot","Drive","game");
            chat.KeyResponseAny(answer4, "play", "want","i");
            chat.KeyResponseAny(answer5, "is", "that", "game","fun");
            chat.KeyResponseAny(answer6, "driving", "shoot","hugh");
            chat.KeyResponseAny(answer7, "fly","fighting","game","where");
            chat.KeyResponseAny(answer8, "skill","fighting","oldschool");
            chat.KeyResponseAny(answer9, "fast", "pace","popular","shooting");
            chat.KeyResponseAny(answer10, "traditional", "shooting", "realistic", "game");
            chat.KeyResponseAny(answer11, "");
            chat.KeyResponseAny(answer12, "reviews","what","ratings");
            chat.KeyResponseAny(answer13, "good", "Game", "which","console");
            chat.KeyResponseAny(answer14, "cheapest", "console");
            chat.KeyResponseAny(answer15, "Thank", "you", "Thanks", "cool");
            chat.KeyResponseAny(answer16, "Hello", "Hey", "Hi");
            chat.KeyResponseAny("Hello, how can I help you?", "Hello", "Hi", "What's up");
            chat.NoMatchMessage("Can you reprase that?");
            chat.NoMatchMessage("Your terminology is unfamiliar with me?");
            chat.NoMatchMessage("I don't understand?");

            string answer = chat.GetResponse(sentence, true);
            return Content(answer);
        }
    }


    }
