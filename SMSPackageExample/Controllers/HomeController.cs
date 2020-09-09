using Newtonsoft.Json;
using SMSClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace SMSPackageExample.Controllers
{
    public class HomeController : Controller
    {
        private IBulkSMSSender _SMSClient;
        public HomeController()
        {
            _SMSClient = new SMSInficare();
        }
        public ActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult SendSMS()
        {
            ViewBag.Msg = "Please Continue...";
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        [ActionName("SendSMS")]
        public ActionResult SendSMSConformed(string no, string msg, string url, string appid, string userid, string pwd, string senderid)
        {
            IDictionary<string, string> Params = new Dictionary<string, string>();
            //optional
            Params.Add("APIUrl", url);
            //optional
            Params.Add("APP_ID", appid);
            Params.Add("UserID", userid);
            Params.Add("APP_KEY", pwd);
            Params.Add("SenderID", senderid);
            _SMSClient.InitConfig(Params);
            var res = _SMSClient.SendSMS(no, msg);
            ViewBag.Msg = JsonConvert.SerializeObject(res);

            return View(); ;
        }
    }

}
