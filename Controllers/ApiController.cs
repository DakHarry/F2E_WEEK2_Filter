using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using f2e_week2_filter.Models;

namespace f2e_week2_filter.Controllers {
    [Route("api/[controller]")]
    public class ApiController : Controller {
        KSContext db;
        //相依性注入DB
        public ApiController (KSContext _db){
            this.db = _db;
        }

        [HttpGet ("/ReadData")]
        public IActionResult ReadJsonData() {
            SpotsData allData = SpotsData.FromJson(System.IO.File.ReadAllText("data.json"));          
            return Json(allData);
        }

        [HttpGet ("/ImportData")]
        public IActionResult ImortJsonData() {
            SpotsData allData = SpotsData.FromJson(System.IO.File.ReadAllText("data.json"));
            foreach(var spot in allData.Result.Records){
                this.db.Add(spot);
            }
            //this.db.SaveChanges();
            return Json(allData);
        }
    }
}