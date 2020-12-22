using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Dal;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private TelComContext db = new TelComContext();
        public ActionResult Index()
        {
            return View();
        }
        
        
        public ActionResult BuildReport()
        {
            int CallN = 0;
            int CallD = 0;
            double sum = 0;
            foreach (var call in db.Calls.ToList())
            {
               var DotA = db.Abonents.Find(call.Abonent_A_ID).TelDot;
               var DotB = db.Abonents.Find(call.Abonent_B_ID).TelDot;
                var a = db.Tarifs.Find(7);
                List<Models.Tarif> t1 = db.Tarifs.Where(s => s.TelDot_A.Equals(DotA)).ToList();
                List<Models.Tarif> t2 = t1.Where(s => s.TelDot_B.Contains(DotB)).ToList();
                var D = call.Duration;
                var PN = t2.First().Price_N;
                var PD = t2.First().Price_D;
                double price;
                

                if (call.IsNight)
                {
                    price = D * PN;
                    CallN++;
                    sum += price; 
                }
                else
                {
                    price = D * PD;
                    CallD++;
                    sum += price;
                }
                
            }
            ViewBag.Sum = sum;
            ViewBag.CallD = CallD;
            ViewBag.CallN = CallN;
            return View(ViewBag);
        }
        
        public ActionResult BuildReport2(string searchinput)
        {
            if (db.Abonents.Where(s => s.INN.Equals(searchinput)).ToList().Count != 0)
            {
                var OneDB = db.Abonents.Where(s => s.INN.Equals(searchinput)).ToList().First();
                var Calls = db.Calls.Where(s => s.Abonent_A_ID.Equals(OneDB.ID)).ToList();
                int CallN = 0;
                int CallD = 0;
                double sum = 0;
                foreach (var call in Calls)
                {
                    var DotA = db.Abonents.Find(call.Abonent_A_ID).TelDot;
                    var DotB = db.Abonents.Find(call.Abonent_B_ID).TelDot;
                    var a = db.Tarifs.Find(7);
                    List<Models.Tarif> t1 = db.Tarifs.Where(s => s.TelDot_A.Equals(DotA)).ToList();
                    List<Models.Tarif> t2 = t1.Where(s => s.TelDot_B.Contains(DotB)).ToList();
                    var D = call.Duration;
                    var PN = t2.First().Price_N;
                    var PD = t2.First().Price_D;
                    double price;


                    if (call.IsNight)
                    {
                        price = D * PN;
                        CallN++;
                        sum += price;
                    }
                    else
                    {
                        price = D * PD;
                        CallD++;
                        sum += price;
                    }

                }
                ViewBag.Sum = sum;
                ViewBag.CallD = CallD;
                ViewBag.CallN = CallN;
                return View(ViewBag);
            }
            else
            {
                return Redirect("Index");
            }
        }



    }
}