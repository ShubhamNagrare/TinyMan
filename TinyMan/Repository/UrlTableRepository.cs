using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using TinyMan.Models;
using URLShortner.Utility;

namespace TinyMan.Repository
{
    public class UrlTableRepository
    {

        public static async Task<UrlTable> InsertLongUrl(string longUrl)
        {
            try
            {

                UrlTable record = new UrlTable
                {
                    LongUrl = longUrl,
                    ExpiryDate = DateTime.Now,
                    IsExpired = false
                };
                using (var ctx = new urlshortnerContext())
                {
                    var rcd = ctx.Add(record);
                    long id = await ctx.SaveChangesAsync();

                    var ID = record.Id;

                    var shorturl = Util.GetBase62(ID);


                    record.ShorlUrl = shorturl;
                    ctx.SaveChanges();

                    //  var recordd = ctx.UrlTable.Where(e => e.Id == (int)id).Single();



                    return record;
                }

                // logging & aaplication Insights
                // dependecy injection
                // Disponse contetx

            }
            catch (Exception e)
            {
                throw;
            }
        }

        public static void InsertShortUrl(string shortUrl, long id)
        {
            try
            {

                using (var ctxx = new urlshortnerContext())
                {

                    var d = ctxx.UrlTables.Where(e => e.LongUrl == "Shubham").FirstOrDefault();


                    var record = ctxx.UrlTables.Where(e => e.Id == (int)id).Single();
                    record.ShorlUrl = shortUrl;
                    ctxx.SaveChanges();
                }
                   
            }
            catch (Exception e)
            {
                throw;
            }
        }


        public static string GetLongUrl(string shortUrl)
        {
            try
            {
                using (var ctx = new urlshortnerContext())
                {


                    var longUrl = ctx.UrlTables.Where(x => x.ShorlUrl == shortUrl).FirstOrDefault();

   
                    return longUrl.LongUrl;

                  //  return RedirectToAction();// longUrl.LongUrl);
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }


    }
}
