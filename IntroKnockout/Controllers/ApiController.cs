using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using IntroKnockout.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IntroKnockout.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        [HttpGet]
        public JsonResult Get()
        {

            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\files\\muhtarlk-adres-bilgileri.csv");
            List<AddressInfo> list = new List<AddressInfo>();
            using (var reader = new StreamReader(path))
            {
                while (!reader.EndOfStream)
                {
                    AddressInfo info = new AddressInfo();
                    string lineValues = reader.ReadLine();
                    string[] values = lineValues.Split(';');
                    info.AddressId = values[0];
                    info.Name = values[1];
                    info.CountryName = values[2];
                    info.NeighborhoodName = values[3];
                    list.Add(info);
                }
            }
            var addressList = new JsonResult(list.Take(10));
            return addressList;
        }
    }
}