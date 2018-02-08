using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using UniqueGenerator.Models;

namespace UniqueGenerator.Controllers
{
    public class GeneratorController : ApiController
    {

        [HttpPost]
        public DataPart GetSample([FromBody] DataPart text)
        {
            TextGenerator generator = new TextGenerator(text.Text);

            return new DataPart()
            {
                Text = generator.Generate()
            };
        }

        [HttpPost]
        public IEnumerable<DataPart> GetSample([FromBody] DataPart text, string id)
        {
            int num = int.Parse(id);
            TextGenerator generator = new TextGenerator(text.Text);

            return generator.Generate(num).Select(t => new DataPart() { Text = t });
        }
    }

    public class DataPart
    {
        public string Text { get; set; }
    }
}