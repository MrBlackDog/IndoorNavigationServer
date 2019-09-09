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
        public volatile static Dictionary<String, List<Log>> xd = new Dictionary<String, List<Log>>();
        public List<Log> LogList;
        private static string name;
        private string writepath = @"D:\WifiIndoorNavigation";
        private WifiInfoContext db;
        private LppDatabaseContext _ctx = new LppDatabaseContext();
        /*   public LogController(WifiInfoContext context)
           {
               db = context;
           }*/
        [HttpGet]
        public ActionResult Get(String namestring, String logstring)
        {
            LocationRoom LocRoom = new LocationRoom();
            LocRoom.Name = namestring;
            String[] rawlog = logstring.Split("|");
            LogList = new List<Log>();
            foreach (string str in rawlog)
            {
                if (str != "")
                {
                    String[] infomass = str.Split(" ");
                    Log log = new Log();
                    log.SSID = infomass[0];
                    log.BSSID = infomass[1];
                    log.AvgLevel = Convert.ToDouble(infomass[2]);
                    log.LocationId = LocRoom.Id;
                    log.LocRomm = LocRoom;
                    LogList.Add(log);
                }
            }
            if (xd.ContainsKey(LocRoom.Name))
                foreach(Log lg in LogList)
                {
                    xd[LocRoom.Name].Find(x => x.BSSID.Contains(lg.BSSID)).AvgLevel += lg.AvgLevel;
                    //xd[LocRoom].Find(x => x.BSSID.Contains(LogList.BSSID)).AvgLevel += Convert.ToDouble(wifiInfo.level.Split("dBm")[0]);
                    // xd[LocRoom].Find(x => x.BSSID.Contains(LogList.BSSID)).NumBerOfMentions++;
                }
            else
                xd.Add(LocRoom.Name, LogList);
            return Ok();
        }
   /*     [HttpGet]
        public ActionResult Get(String namestring, String logstring)
        {
            LocationRoom LocRoom = new LocationRoom();
            LocRoom.Name = namestring;
            _ctx.LocationRooms.Add(LocRoom);
            _ctx.SaveChanges();
            String[] rawlog = logstring.Split("|");
            foreach (string str in rawlog)
            {
                if (str != "")
                {
                    String[] infomass = str.Split(" ");
                    Log log = new Log();
                    log.SSID = infomass[0];
                    log.BSSID = infomass[1];
                    log.AvgLevel = infomass[2];
                    log.LocationId = LocRoom.Id;
                    log.LocRomm = LocRoom;
                    _ctx.Logs.Add(log);
                }
            }
            _ctx.SaveChanges();
            return Ok();
            /*var Log = _ctx.Logs.Select(L => L.BSSID +
            L.SSID + L.AvgLevel + L.LocRomm.Name).ToArray();
            return Log;
        }*/


        /* [HttpGet]
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
             wifi.NumberOfMentions = 3;
             //  db.SaveChanges();
             db.SaveChangesAsync();
             return Ok();
         }*/
        //[HttpGet]*/
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
        [HttpGet]
        public List<Log> Getting(int Id)
        {
            LppDatabaseContext db = new LppDatabaseContext();

            var logs = (from item in db.Logs
                        where item.LocationId == Id
                        select item).ToList();
            return logs;
        }
    }
}