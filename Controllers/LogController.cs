using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    // [Route("api/[controller]")]
    // [ApiController]
    public class LogController : ControllerBase
    {
        private static string name;
        private string writepath = @"D:\WifiIndoorNavigation";
        private WifiInfoContext db;
        public LogController(WifiInfoContext context)
        {
            db = context;
        }

        [HttpGet]
        public IActionResult LogString(String namestring, String logstring)
        {
            WifiInfoContext.Table = namestring;
            writepath += @"\" + namestring + ".txt";
            StreamWriter sw = new StreamWriter(writepath, true, System.Text.Encoding.Default);
            String[] rawlog = logstring.Split("|");
            //sw.Write(logstring);
            foreach (string str in rawlog)
            {
                if (str != "")
                {
                    String[] infomass = str.Split(" ");
                    WifiInfo wifi = new WifiInfo();
                    wifi.SSID = infomass[0];
                    wifi.BSSID = infomass[1];
                    wifi.AvgLevel = infomass[2];
                    //  wifi.NumberOfMentions++;
                    db.WifiInfos.Add(wifi);                 
                }
                sw.WriteLine(str);
            }
            sw.Close();
           /* WifiInfo wifi = new WifiInfo();
            wifi.SSID = "MEGAxdtest";
            wifi.BSSID = "ULTRAxdxdtest";
            wifi.AvgLevel = "-59";
            wifi.NumberOfMentions = 3;*/
            //  db.SaveChanges();
            db.SaveChangesAsync();
            return Ok();
        }
        //[HttpGet]
        /*public IActionResult GetZone(String zone)
        {
            // return Content($"{};{};{}");
            return Ok();
        }
        public async Task<IActionResult> Index()
        {
            return View(await db.WifiInfos.ToListAsync());
        }
        [HttpPost]
        public async Task<IActionResult> Create(WifiInfo wifiInfo)
        {
            db.WifiInfos.Add(wifiInfo);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }*/
    }
}