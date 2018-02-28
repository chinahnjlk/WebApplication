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
        public JsonResult GetData()
        {

            JsonSerializerSettings setting = new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                
            };

           
            FileInfo fileInfo = new FileInfo(@"P:\Demo\WebApplication\WebApplication\Draw3.dxf");
            var fileStream = fileInfo.OpenRead();
            DxfHelperReader dxfHelperReader = new DxfHelperReader();
            var list1 =    dxfHelperReader.Read(fileStream);

            //netDxf.DxfDocument dxfDocument = netDxf.DxfDocument.Load(fileStream);
            //IReadOnlyList<netDxf.Entities.Line> lines= dxfDocument.Lines;
            //IReadOnlyList<netDxf.Entities.Arc> arcs = dxfDocument.Arcs;
            //IReadOnlyList<netDxf.Entities.Text> texts = dxfDocument.Texts;

            //var number = 5 / 5;

            

            //List<netDxf.Entities.Arc> list = new List<Arc>();
            //List<netDxf.Entities.Line> lineList = new List<Line>();
            //List<TextElement> textList = new List<TextElement>();

            //texts.ForEach(c =>
            //{
            //    TextElement text = new TextElement();
            //    //text.Alignment = c.Alignment;
            //    //text.Height = c.Height;
            //    //text.ObliqueAngle = c.ObliqueAngle;
            //    //text.Position = c.Position;
            //    //text.Rotation = c.Rotation;
            //    //text.Style = c.Style;
            //    //text.Value = c.Value;
            //    //text.WidthFactor = c.WidthFactor;
            //    text.EPoint.X = c.Position.X;
            //    text.EPoint.Y = c.Position.Y;
            //    textList.Add(text);
            //});




            ////arcs.ForEach(c =>
            ////{
            ////    Arc arc = new Arc();
            ////    arc.Center = c.Center;
            ////    arc.EndAngle = c.EndAngle;
            ////    arc.Radius = c.Radius;
            ////    arc.Thickness = c.Thickness;
            ////    var arcCodeName = arc.CodeName;

            ////    list.Add(arc);
            ////});


            ////lines.ForEach(c =>
            ////{
            ////    Line line = new Line
            ////    {
            ////        Thickness = c.Thickness,
            ////        EndPoint = c.EndPoint,
            ////        StartPoint = c.StartPoint
            ////    };
            ////    //line.Direction = c.Direction;
            ////    lineList.Add(line);
            ////});


            //var serializer = new JavaScriptSerializer();
            //serializer.MaxJsonLength = Int32.MaxValue;    //设置为int的最大值 
            ////return serializer.Serialize(jsonObj);
            var ret = JsonConvert.SerializeObject(list1, setting);
           
            
            //if (!System.IO.File.Exists("P:/2.json"))
            //{
            //    FileStream fileStream1 = System.IO.File.Create("P:/2.json");

            //    fileStream.Lock(0, fileStream1.Length);
            //    StreamWriter sw = new StreamWriter(fileStream1);
            //    sw.Write(ret);
            //    //sw.WriteLine("我是写入\n的字符串");
            //    //fileStream.Unlock(0, fileStream.Length);
            //    sw.Flush();
            //}

            return Json(list1, JsonRequestBehavior.AllowGet);
        }
    }
}