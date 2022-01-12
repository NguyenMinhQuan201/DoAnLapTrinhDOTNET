using Models.Framework;
using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using PayPal.Api;
namespace Shop.Controllers
{
    public class CartsController : Controller
    {
        private LipstickDbContext db = new LipstickDbContext();
        // GET: Carts
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult AddCart(string cartTemp)
        {
            var jsoncart = new JavaScriptSerializer().Deserialize<List<Cart>>(cartTemp);

            foreach(var item in jsoncart)
            {
                int a = Convert.ToInt32(item.Colour);
                int b = Convert.ToInt32(item.Size);
                var fmau = db.MauSacs.Where(x => x.ID == a).FirstOrDefault();
                var fkich = db.KichCoes.Where(x => x.ID == b).FirstOrDefault();
                var find = db.ChiTietSanPhams.Where(x => x.IDSanPham == item.Id && x.KichCoSP == fkich.KichCoSP && x.MauSacSP == fmau.MauSacSP).FirstOrDefault();
                return Json(
                new
                {
                    status = true,
                    Prime = find.ID,
                    Img = find.Images,
                    Gia = find.Gia,
                    Ten = find.Ten,
                    Mau = find.MauSacSP,
                    Kich = find.KichCoSP,
                });
            }

            return Json(new { status = false });
        }
        //Work with Paypal Payment
        private Payment payment;
        //Create a payment using  an APIContext
        private Payment CreatePayment(string cartTemp, APIContext apiContext,string redirectUrl)
        {
            var listItems = new ItemList() { items = new List<Item>() };
            var jsoncart = new JavaScriptSerializer().Deserialize<List<Cart>>(cartTemp);
            foreach(var item in jsoncart)
            {
                listItems.items.Add(new Item()
                {
                    name=item.Name,
                    currency="USD",
                    price = item.Gia.ToString(),
                    quantity=item.SoLuong.ToString(),
                    sku="sku"
                });
            }
            var payer = new Payer() { payment_method = "paypal" };
            //Do the configuration RedirectURLs here with redirection object
            var redirUrls = new RedirectUrls()
            {
                cancel_url = redirectUrl,
                return_url = redirectUrl,
            };
            // Create amount obj
            var details = new Details()
            {
                tax = "1",
                shipping = "2",
                subtotal = jsoncart.Sum(x => x.Gia * x.SoLuong).ToString(),
            };
            var amount = new Amount()
            {
                currency = "USD",
                total=(Convert.ToDouble(details.tax)+Convert.ToDouble(details.shipping)+Convert.ToDouble(details.subtotal)).ToString(),
                details=details,
            };
            //Create transaction
            var transactionList = new List<Transaction>();
            transactionList.Add(new Transaction()
            {
                description= "Quan testing transaction description",
                invoice_number=Convert.ToString((new Random()).Next(100000)),
                amount=amount,
                item_list=listItems 
            });
            payment = new Payment()
            {
                intent = "sale",
                payer=payer,
                transactions= transactionList,
                redirect_urls=redirUrls
            };
            return payment.Create(apiContext);
        }
        //Craete executePayment method
        private Payment ExecutePayment(APIContext apiContext,string payerId,string paymentId)
        {
            var paymentExecution = new PaymentExecution()
            {
                payer_id = payerId
            };
            payment = new Payment()
            {
                id = paymentId
            };
            return payment.Execute(apiContext, paymentExecution);
        }
        //Create payment with paypal method
        public ActionResult PaymentWithPaypal(string cartTemp)
        {
            //Gettings context from  the paypal bases on clintId and Sec for Payment
            APIContext apiContext = PaypalConfiguration.GetAPIContext();
            try
            {
                string payerId = Request.Params["PayerID"];
                if (string.IsNullOrEmpty(payerId))
                {
                    //Creating a payment
                    string baseURI = Request.Url.Scheme + "://" + Request.Url.Authority + "/Carts/PaymentWithPaypal?";
                    var guid = Convert.ToString((new Random()).Next(100000));
                    var createPayment = CreatePayment(cartTemp, apiContext, baseURI + "guid=" + guid);
                    //Get links returned from paypal reponse to create call function
                    var links = createPayment.links.GetEnumerator();
                    string paypalRedirectUrl = string.Empty;
                    while (links.MoveNext())
                    {
                        Links link = links.Current;
                        if (link.rel.ToLower().Trim().Equals("approval_url"))
                        {
                            paypalRedirectUrl = link.href;
                        }
                    }
                    Session.Add(guid, createPayment.id);
                    /*return RedirectPermanent(paypalRedirectUrl);*/
                    return Json(
                    new
                    {
                        status = true,
                        url = paypalRedirectUrl
                    });

                }
                else
                {
                    //This one will be executed when we have received all the payment paramas from previous call
                    var guid = Request.Params["guid"];
                    var executedPayment = ExecutePayment(apiContext, payerId, Session[guid] as string);
                    if (executedPayment.state.ToLower() != "approved")
                    {
                        return View("Failure");
                        /*return Json(
                        new
                        {
                            status = false,
                        });*/

                    }
                }
            }
            catch(Exception e)
            {
                PaypalLogger.Log("Error: " + e.Message);
                /*return Json(new { status = false, });*/
                return View("Failure");
            }
            return View("Success");
            /*return Json(new { status = true, url="", JsonRequestBehavior.AllowGet });*/
        }
    }
}