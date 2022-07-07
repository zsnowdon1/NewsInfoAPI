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
        public List<NewsItem> GetBasketball()
        {
            HtmlWeb web = new HtmlWeb();
            var htmlDoc = web.Load("https://www.espn.com/nba/");
            List<NewsItem> items = new List<NewsItem>();
            foreach (HtmlNode node in htmlDoc.DocumentNode.SelectNodes("//section[@class='"
                + "contentItem__content contentItem__content--story has-image has-video" +
                " contentItem__content--collection contentItem__content--enhanced contentItem__content--fullWidth" + "']"))
            {
                Debug.WriteLine(node.SelectSingleNode("//img").Attributes["data-default-src"].Value);

                //items.Add(new NewsItem
                //{
                //    Title = node.SelectSingleNode("//h1[@class='" + "contentItem__title contentItem__title--story" + "']").InnerText,
                //    Subtitle = node.SelectSingleNode("//p[@class='" + "contentItem__subhead contentItem__subhead--story" + "']").InnerText,
                //    PicUrl = node.SelectSingleNode("//img[@class='media-wrapper_image  imageLoaded lazyloaded']").Attributes["data-default-src"].Value
                //});
            }
            for(int i = 0; i < items.Count; i++)
            {
                Debug.WriteLine(items[i].Title);
                Debug.WriteLine(items[i].Subtitle);
                Debug.WriteLine(items[i].PicUrl);
                Debug.WriteLine(' ');
            }
            return items;
        }
    }
}
