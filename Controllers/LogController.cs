using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
   // [Route("api/[controller]")]
   // [ApiController]
    public class LogController : ControllerBase
    {
        private static string name;
        private string writepath = @"D:\WifiIndoorNavigation";

        [HttpGet]
        public IActionResult LogString(String namestring, String logstring)
        {
            writepath += @"\" + namestring + ".txt";
            StreamWriter sw = new StreamWriter(writepath, true, System.Text.Encoding.Default);
            String[] rawlog = logstring.Split("|");
            //sw.Write(logstring);
            foreach (string str in rawlog)
            {
                sw.WriteLine(str);
            }
            sw.Close();
            return Ok();
        }
    }
}