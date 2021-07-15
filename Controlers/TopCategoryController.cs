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
    // Get TopCategory information.
    // </summary>
    [AuthorizeIPAddress]
    [FilterIP]
    public class TopCategoryController : ApiController
    {


        #region GetAllTopCategory List
        #region json

        // Friendly
        // <summary>
        // Get allowable TopCategory JSON list by language.
        // </summary>
        // <param name="lang">Language. English = "en", French = "fr"</param>
        // <param name="token">Acess token </param>
        // <returns>Authorized user get JSON style allowable Topcategory list, [TopCategoryID], [TOpCategory]. Filter by language and access token</returns>
        [ActionName("json")]
                [Route("api/v2/TopCategory/json/{token}/{lang}")]
                [Route("api/v2/catégorie/json/{token}/{lang}")]
                // top
                [HttpGet]
                public HttpResponseMessage GetAllTopCategories(string lang, string token)
                {
                    var json = this.GetAllTopCategories(lang, token).ToList();
                    response = toJson(json, lang);
                    request = HttpContext.Current.Request;


                    return response;
                }
                //Query String
                // <summary>
                // Query String Style. Get allowable TopCategory JSON list by language.
                // </summary>
                // <param name="lang">Language. English = "en", French = "fr"</param>
                // <param name="token">Acess token </param>
                // <returns>Authorized user get JSON style allowable Topcategory list, [TopCategoryID], [TopCategory]. Filter by language</returns>
                [ActionName("json")]
                [Route("api/v2/TopCategory/json")]
                [Route("api/v2/catégorie/json")]
                // top
                [HttpGet]
                public HttpResponseMessage GetAllTopCategories_QS(string lang, string token)
                {
                    var json = this.GetAllTopCategories(lang,token).ToList();
                    response = toJson(json, lang);
                    request = HttpContext.Current.Request;

                    return response;
                }
            #endregion json

            #region xml
                // Friendly
                // <summary>
                // Get allowable TopCategory list by language. Fromat in XML
                // </summary>
                // <param name="lang">Language. English = "en", French = "fr"</param>
                // <param name="token">Acess token </param>
                // <returns>Return XML style TopCategory list, [TopCategoryID], [TopCategory]. Filter by language</returns>
                [ActionName("xml")]
                [Route("api/v2/TopCategory/xml/{token}/{lang}")]
                [Route("api/v2/catégorie/xml/{token}/{lang}")]
                // top
                [HttpGet]
                public HttpResponseMessage GetAllTopCategories_xml(string lang, string token)
                {
                    response = createAllTopCategory_XML(lang, token);
                    request = HttpContext.Current.Request;


                    return response;
                }

                // Query String
                // <summary>
                // Query String Style. Get TopCategory list by language.
                // </summary>
                // <param name="lang">Language. English = "en", French = "fr"</param>
                // <param name="token">Acess token.</param>
                // <returns>Return XML style TopCategory list, [TopCategoryID], [TopCategory]. Filter by language</returns>
                [ActionName("xml")]
                [Route("api/v2/TopCategory/xml")]
                [Route("api/v2/catégorie/xml")]
                // top
                [HttpGet]
                public HttpResponseMessage GetAllTopCategories_xml_QS(string lang, string token)
                {
                    response = createAllTopCategory_XML(lang, token);
                    request = HttpContext.Current.Request;


                    return response;
                }
                private HttpResponseMessage createAllTopCategory_XML(string lang, string token)
                {
                    lang = lang.ToLower();
                    if ((lang == "en") || (lang == "fr"))
                    {
                        var xml = this.GetAllTopCategories(lang,token).ToList();

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
            #endregion xml
        #endregion GetAllTopCategory List


        #region GetTopCategoryByID
            #region JSON
                // Friendly
                // <summary>
                // Get TopCategory by TopCategoryID, Return a json format
                // </summary>
                // <param name="lang">Language. English = "en", French = "fr"</param>
                // <param name="tid">TopCategory ID.</param>
                // <param name="token">access token</param>
                // <returns>return TopCategory format in json </returns>
                [ActionName("json")]
                [Route("api/v2/TopCategory/json/{token}/{lang}/{tid}")]
                [Route("api/v2/catégorie/json/{token}/{lang}/{tid}")]
                // top
                [HttpGet]
                public HttpResponseMessage GetTopCategoryByID(string lang, int tid, string token)
                {
                    var json = this.GetTopCategoryByID(lang, tid, token);
                    response = toJson(json, lang);
                    request = HttpContext.Current.Request;


                    return response;
                }
                // Query String
                // <summary>
                // Query String Style. Get TopCategory by TopCategoryID Return a json format
                // </summary>
                // <param name="lang">Language. English = "en", French = "fr"</param>
                // <param name="tid">TopCategory ID.</param>
                // <param name="token">access token</param>
                // <returns>return TopCategory format in json </returns>
                [ActionName("json")]
                [Route("api/v2/TopCategory/json")]
                [Route("api/v2/catégorie/json")]
                // top
                [HttpGet]
                public HttpResponseMessage GetTopCategoryByID_QS(string lang, int tid, string token)
                {
                    var json = this.GetTopCategoryByID(lang, tid, token);
                    response = toJson(json, lang);
                    request = HttpContext.Current.Request;


                    return response;
                }
            #endregion JSON

            #region XML
                // Friendly
                // <summary>
                // Get TopCategory by TopCategoryID
                // </summary>
                // <param name="lang">Language. English = "en", French = "fr"</param>
                // <param name="tid">TopCategory ID.</param>
                // <param name="token">access token</param>
                // <returns>return TopCategory format in XML </returns>
                [ActionName("xml")]
                [Route("api/v2/TopCategory/xml/{token}/{lang}/{tid}")]
                [Route("api/v2/catégorie/xml/{token}/{lang}/{tid}")]
                // top
                [HttpGet]
                public HttpResponseMessage GetTopCategoryByID_XML(string lang, int tid, string token)
                {
                    response = getTopCategoryByID_XML(lang, tid, token);
                    request = HttpContext.Current.Request;


                    return response;
                }

                // Query String
                // <summary>
                // Query String style. Get TopCategory by TopCategoryID
                // </summary>
                // <param name="lang">Language. English = "en", French = "fr"</param>
                // <param name="tid">TopCategory ID.</param>
                // <param name="token">access token</param>
                // <returns>return TopCategory format in XML </returns>
                [ActionName("xml")]
                [Route("api/v2/TopCategory/xml")]
                [Route("api/v2/catégorie/xml")]
                // top
                [HttpGet]
                public HttpResponseMessage GetTopCategoryByID_XML_QS(string lang, int tid, string token)
                {
                    response = getTopCategoryByID_XML(lang,tid, token);
                    request = HttpContext.Current.Request;


                    return response;
                }
                private HttpResponseMessage getTopCategoryByID_XML(string lang, int tid, string token)
                {
                    lang = lang.ToLower();
                    if ((lang == "en") || (lang == "fr"))
                    {
                        var xml = this.GetTopCategoryByID(lang, tid, token);
                        if (xml != null)
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
            #endregion XML
        #endregion GetTopCategoryByID

 
    }
}
