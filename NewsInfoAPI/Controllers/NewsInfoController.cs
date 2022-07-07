using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NewsInfoAPI.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NewsInfoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NewsInfoController : ControllerBase
    {

        private readonly ILogger<NewsInfoController> _logger;

        public NewsInfoController(ILogger<NewsInfoController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetBasketball()
        {
            HtmlWeb web = new HtmlWeb();
            var htmlDoc = web.Load("https://www.espn.com/nba/");

            Debug.WriteLine("Done");
            foreach (HtmlNode node in htmlDoc.DocumentNode.SelectNodes("//section[@class='" + "contentItem contentItem--collection" + "']"))
            {
                NewsItem news = new NewsItem();
                //contentItem__content contentItem__content--story has - image has - video contentItem__content--collection
                Debug.WriteLine(node.ChildNodes[1].ParentNode.InnerText);

                //news.Title = node.ChildNodes[0].ChildNodes[0].InnerText;
                //Debug.WriteLine(node.ChildNodes[0].InnerText);
                //Debug.WriteLine(node.ChildNodes[1].InnerText);
                //Debug.WriteLine(node.ChildNodes[1].ChildNodes[0].InnerText);
                Debug.WriteLine(' ');
            }
                return null;
            //return Ok(htmlDoc.DocumentNode.SelectSingleNode("//head//contentItem__title contentItem__title--video"));
        }
    }
}
