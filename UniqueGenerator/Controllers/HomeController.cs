using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using UniqueGenerator.Models;

namespace UniqueGenerator.Controllers
{
    public class HomeController : Controller
    {
        static string text = "1-2 {комнатные|к.|ком.|Комн.} квартиры в {центре|центре города}. {Хороший|Отличный} ремонт, [пластиковые окна,|кабельное ТВ,|Интернет,|стиральная машина,|2 телевизора,|микроволновка,|пылесос,|утюг,|посуда,] новая мебель. Все {необходимые документы|документы}. В {этой|данной} квартире {очень|достаточно} [уютно,|тихо,] комфортно. {В шаговой доступности|Рядом|Рядом с домом} [2 аптеки,|3 супермаркета,] 2 стоянки для {авто|автомобилей}.";
        TextGenerator generator = new TextGenerator(text);

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Help()
        {
            return View();
        }

        public ActionResult TopVariant()
        {
            ViewBag.Message = generator.Generate();
            return View();
        }

        public ActionResult AllVariant()
        {
            ViewBag.Messages = generator.Generate(10);
            return View();
        }

        public ActionResult GetAllVariant()
        {
            var texts = generator.Generate(5000).ToArray();

            var content = String.Join("\r\n---------------------------------------\r\n", texts);

            return File(Encoding.UTF8.GetBytes(content), System.Net.Mime.MediaTypeNames.Application.Octet, $"Варианты {DateTime.Now}.txt");
        }
    }
}