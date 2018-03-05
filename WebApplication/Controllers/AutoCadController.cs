using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using netDxf.Entities;
using Newtonsoft.Json;
using RtSafe.DxfCore;
using WebApplication.Models;
using WebGrease.Css.Extensions;

namespace WebApplication.Controllers
{
    public class AutoCadController : Controller
    {
        // GET: AutoCAD
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetData(string type)
        {

            FileInfo fileInfo = new FileInfo(@"D:\学习\asp.net\Github\WebApplication\WebApplication\Draw3.dxf");
            var fileStream = fileInfo.OpenRead();
            DxfHelperReader dxfHelperReader = new DxfHelperReader();
            var list1 =    dxfHelperReader.Read(fileStream, int.Parse(type));

            //
            //P:\Demo\WebApplication\WebApplication\Draw3.dxf
            return Json(list1, JsonRequestBehavior.AllowGet);
        }
    }
}