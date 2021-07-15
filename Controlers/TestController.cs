 using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using WebApi.Filters;

namespace WebApi.Controllers
{
    // <summary>
    // Provide a sample data set for user's testing, response format in JSON and XML. 
    // </summary>

    //[EnableCors(cors)]
    [AuthorizeIPAddress]
    [FilterIP]
    public class TestController : ApiController
    {


        #region response JSON

        //Friendly
        // <summary>
        // Return a JSON list.
        // </summary>
        // <param name="lang">language. English = "en", French = "fr"</param>
        // <param name="token">Access token</param>
        // <returns>return a json list fro testing</returns>
        [ActionName("json")]
        [Route("api/v2/test/json/{token}/{lang}")]
        [Route("api/v2/tester/json/{token}/{lang}")]
        // province
        [HttpGet]
        public HttpResponseMessage Demo(string lang, string token)
        {
            var json = this.GetAllProvinces(lang, token);
            response = toJson(json, lang);
            request = HttpContext.Current.Request;


            return response;
        }
    //Query String
        // <summary>
        // Query String Style. Response a JSON list.
        // </summary>
        // <param name="lang">language. English = "en", French = "fr"</param>
        // <param name="token">Access token</param>
        // <returns>return a json list for testing</returns>
        [ActionName("json")]
        [Route("api/v2/test/json")]
        [Route("api/v2/tester/json")]
        // province
        [HttpGet]
        public HttpResponseMessage Demo_QS(string lang, string token)
        {
            //var en = db.getProvinceList(lang, token);
            //db.Proc_apilog("GET", lang, token, "all", "test", string.Empty);
            //return toJson(en, lang);
            var json = this.GetAllProvinces(lang, token).ToList();
            response = toJson(json, lang);
            request = HttpContext.Current.Request;


            return response;

        }
        #endregion

        #region Response XML
        //Friendly
        // <summary>
        // Return a XML list.
        // </summary>
        // <param name="lang">language. English = "en", French = "fr"</param>
        // <param name="token">Access token</param>
        // <returns>return a XML list for testing</returns>
        [ActionName("value")]
        [Route("api/v2/test/xml/{token}/{lang}")]
        [Route("api/v2/tester/xml/{token}/{lang}")]
        // province
        [HttpGet]
        public HttpResponseMessage DemoX(string lang, string token)
        {
            response = createDemo(lang, token);
            request = HttpContext.Current.Request;


            return response;
        }
        //Query String
        // <summary>
        // Query String style, response a XML list.
        // </summary>
        // <param name="lang">language. English = "en", French = "fr"</param>
        // <param name="token">Access token</param>
        // <returns>return a XML list for testing</returns>
        [ActionName("value")]
        [Route("api/v2/test/xml")]
        [Route("api/v2/tester/xml")]
        // province
        [HttpGet]
        public HttpResponseMessage DemoX_QS(string lang, string token)
        {
            response = createDemo(lang, token);
            request = HttpContext.Current.Request;


            return response;
        }

        private HttpResponseMessage createDemo(string lang, string token)
        {
            lang = lang.ToLower();
            if ((lang == "en") || (lang == "fr"))
            {
                var xml = this.GetAllProvinces(lang, token).ToList();
                //var xml = db.getProvinceList(lang, token).ToList();
                //db.Proc_apilog("GET", lang, token, "all", "test", string.Empty);
                if (xml.Count > 0)
                {
                    var response = Request.CreateResponse(HttpStatusCode.OK, xml, "application/xml");

                    return response;
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NoContent);
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }
#endregion Response XML


 
    }
}
