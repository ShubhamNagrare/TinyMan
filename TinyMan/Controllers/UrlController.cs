using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TinyMan.Controllers
{
    [Route("api")]
    [ApiController]
    public class UrlController : ControllerBase
    {




        [HttpGet]
        [Route("v1/{url}")]
        public void GetLongUrll(string url)
        {
            var shortU = Repository.UrlTableRepository.GetLongUrl(url);

            // object redirectToRoute = HttpResponse.RedirectToRoute;
            Response.Redirect("https://" + shortU);
            //return;

           // return d).Redirect(); RedirectToRoute
           // return "https://" + shortU;
        }


        [HttpPost]
        [Route("getshorturl")]
        public async Task<GetShortUrlResponse> GetShortUrl([FromBody] GetShortUrlRequest longUrlObj)
        {
            GetShortUrlResponse response = new GetShortUrlResponse();

            try
            {
                if (longUrlObj == null)
                {
                    response.statusCode = 400;
                    return response;
                }


                var record = await Repository.UrlTableRepository.InsertLongUrl(longUrlObj.longUrl);



                //      var id = record.Id;


                //     var longUrl = longUrlObj.longUrl;
                //     var shortUrl = Util.GetBase62(id);
                response.statusCode = 200;
                response.shortUrl = "https://localhost:5001/api/v1/" + record.ShorlUrl;



                // Insert shorlurl back to db
                //   Repository.UrlTableRepository.InsertShortUrl(shortUrl, id);


                return response;




                // take md% hash 
                // save to db
                // return
            }
            catch (Exception e)
            {
                response.statusCode = 400;
                return response;
            }
        }


        public class GetShortUrlRequest
        {
            public string longUrl { get; set; }

        }

        public class GetShortUrlResponse
        {

            public string shortUrl { get; set; }
            public int statusCode { get; set; }
        }





    }




}
