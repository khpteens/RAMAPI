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
    // Get Subcategory information.
    // </summary>
    [AuthorizeIPAddress]
    [FilterIP]
    public class SubCategoryController : ApiController
    {

        #region Get All SubCategory
        #region JSON
        //Friendly
        // <summary>
        // Authorized users get allowable SubCategory JSON list, filter by language.
        // </summary>
        // <param name="lang">Language. English = "en", French = "fr"</param>
        // <param name="token">Access toke</param>
        // <returns>Return JSON style subcategory list, [SubCategoryID], [SubCategory], [SubCategoryDesc]. Filter by language</returns>
        [ActionName("json")]
                [Route("api/v2/SubCategory/json/{token}/{lang}")]
                [Route("api/v2/souscatégorie/json/{token}/{lang}")]
                // sub
                [HttpGet]
                public HttpResponseMessage GetAllSubCategories(string lang, string token)
                {
                    var json = this.GetAllSubCategories(lang, token).ToList();
                    response = toJson(json, lang);
                    request = HttpContext.Current.Request;


                    return response;
                }
                //Query String
                // <summary>
                // Query String Style. Authorized users get SubCategory JSON list filter by language.
                // </summary>
                // <param name="lang">Language. English = "en", French = "fr"</param>
                // <param name="token">Access toke</param>
                // <returns>Return JSON style subcategory list, [SubCategoryID], [SubCategory], [SubCategoryDesc]. Filter by language</returns>
                [ActionName("json")]
                [Route("api/v2/SubCategory/json")]
                [Route("api/v2/souscatégorie/json")]
                // sub
                [HttpGet]
                public HttpResponseMessage GetAllSubCategories_QS(string lang, string token)
                {
                    var json = this.GetAllSubCategories(lang, token).ToList();
                    response = toJson(json, lang);
                    request = HttpContext.Current.Request;


                    return response;
                }

        #endregion

        #region XML
        //Friendly
        // <summary>
        // Authorized users get allowable SubCategory XML list, filter by language.
        // </summary>
        // <param name="lang">Language. English = "en", French = "fr"</param>
        // <param name="token">Access token</param>
        // <returns>Return XML style subcategory list, [SubCategoryID], [SubCategory], [SubCategoryDesc]. Filter by language</returns>
        [ActionName("xml")]
                [Route("api/v2/SubCategory/xml/{token}/{lang}")]
                [Route("api/v2/souscatégorie/xml/{token}/{lang}")]
                // sub
                [HttpGet]
                public HttpResponseMessage GetAllSubCategories_XML(string lang, string token)
                {
                    response =createAllSubCategories(lang, token);
                    request = HttpContext.Current.Request;


                    return response;

                }
        //Query String
        // <summary>
        // Query String Style. Authorized users get allowable SubCategory XML list, filter by language.
        // </summary>
        // <param name="lang">Language. English = "en", French = "fr"</param>
        // <param name="token">Access token</param>
        // <returns>Return XML style subcategory list, [SubCategoryID], [SubCategory], [SubCategoryDesc]. Filter by language</returns>
        [ActionName("xml")]
                [Route("api/v2/SubCategory/xml")]
                [Route("api/v2/souscatégorie/xml")]
                // sub
                [HttpGet]
                public HttpResponseMessage GetAllSubCategories_XML_QS(string lang, string token)
                {
                    response = createAllSubCategories(lang, token);
                    request = HttpContext.Current.Request;


                    return response;
                }
                private HttpResponseMessage createAllSubCategories(string lang, string token)
                {
                    lang = lang.ToLower();
                    if ((lang == "en")||(lang == "fr"))
                    {
                        var xml = this.GetAllSubCategories(lang, token).ToList();
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
        #endregion
        #endregion

        #region Get SubCategory By Subcategory ID
        #region JSON
        // Friendly 
        // <summary>
        // Get certain SubCategory info by subcategoryID format in JSON.
        // </summary>
        // <param name="lang">Language. English = "en", French = "fr"</param>
        // <param name="sid">SubCategory ID.</param>
        // <param name="token">Access token</param>
        // <returns>return [SubCategoryID], [SubCategory], [SubCategoryDesc] format in json </returns>
        [ActionName("json")]
                    [Route("api/v2/SubCategory/json/{token}/{lang}/{sid}")]
                    [Route("api/v2/souscatégorie/json/{token}/{lang}/{sid}")]
                    // sub
                    [HttpGet]
                public HttpResponseMessage GetSubcategoryBySID(string lang, int sid, string token)
                    {
                        var json = this.GetSubcategoryBySID(sid,lang, token);
                        response = toJson(json, lang);
                        request = HttpContext.Current.Request;


                        return response;
                    }
        // Query String
        // <summary>
        // Query String Style. Get certain SubCategory info by subcategoryID format in JSON.
        // </summary>
        // <param name="lang">Language. English = "en", French = "fr"</param>
        // <param name="sid">SubCategory ID.</param>
        // <param name="token">Access token</param>
        // <returns>return [SubCategoryID], [SubCategory], [SubCategoryDesc]  format in json </returns>
        [ActionName("json")]
                    [Route("api/v2/SubCategory/json")]
                    [Route("api/v2/souscatégorie/json")]
                    // sub
                    [HttpGet]
                    public HttpResponseMessage GetSubcategoryBySID_QS(string lang, int sid, string token)
                    {
                        var json = this.GetSubcategoryBySID(sid, lang, token);
                        response = toJson(json, lang);
                        request = HttpContext.Current.Request;


                        return response;
                    }
        #endregion

        #region XML
        // <summary>
        // Get certain SubCategory info by subcategoryID format in XML.
        // </summary>
        // <param name="lang">Language. English = "en", French = "fr"</param>
        // <param name="sid">SubCategory ID.</param>
        // <param name="token">Access token</param>
        // <returns>return [SubCategoryID], [SubCategory], [SubCategoryDesc]  format in XML </returns>
        // Friendly 
        [ActionName("xml")]
                    [Route("api/v2/SubCategory/xml/{token}/{lang}/{sid}")]
                    [Route("api/v2/souscatégorie/xml/{token}/{lang}/{sid}")]
                    // sub
                    [HttpGet]
                    public HttpResponseMessage GetSubcategoryBySID_XML(string lang, int sid, string token)
                    {
                        response =  getSubCategoryByID(lang, sid, token);
                        request = HttpContext.Current.Request;


                        return response;
                    }
        // Query String
        // <summary>
        // Query String style. Get certain SubCategory info by subcategoryID format in XML.
        // </summary>
        // <param name="lang">Language. English = "en", French = "fr"</param>
        // <param name="sid">SubCategory ID.</param>
        // <param name="token">Access token</param>
        // <returns>return [SubCategoryID], [SubCategory], [SubCategoryDesc]  format in XML </returns>
        [ActionName("xml")]
                    [Route("api/v2/SubCategory/xml")]
                    [Route("api/v2/souscatégorie/xml")]
                    // sub
                    [HttpGet]
                    public HttpResponseMessage GetSubcategoryBySID_XML_QS(string lang, int sid, string token)
                    {
                        response = getSubCategoryByID(lang,sid, token);
                        request = HttpContext.Current.Request;


                        return response;
                    }
                    private HttpResponseMessage getSubCategoryByID(string lang,int sid, string token)
                    {
                        lang = lang.ToLower();
                        if ((lang == "en") || (lang == "fr"))
                        {
                            var xml = this.GetSubcategoryBySID(sid, lang, token);
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
                #endregion
        #endregion

        #region Get SubCategory List By TopCategory ID
            #region JSON

            //Friendly
                // <summary>
                // Get SubCategory JSON list under a certain TopCategory. Filter by Language and TopCategory ID.
                // </summary>
                // <param name="lang">Language. English = "en", French = "fr"</param>
                // <param name="tid">TopCategory ID</param>
                // <param name="token">Access token</param>
                // <returns>Return a subcategory list under allowable certain topcategory filter by language. [SubCategoryID], [SubCategory], [SubCategoryDesc] format in JSON</returns>
                [ActionName("json")]
                [Route("api/v2/SubCategory/TopCategory/json/{token}/{lang}/{tid}")]
                [Route("api/v2/souscatégorie/catégorie/json/{token}/{lang}/{tid}")]
                // sub
                [HttpGet]
                public HttpResponseMessage GetSubcategoryByTopID(string lang, int tid, string token)
                {

                    var json = this.GetSubcategoryByTopID(tid,lang, token);
                    response = toJson(json, lang);
                    request = HttpContext.Current.Request;


                    return response;
                }
            //Query String
                // <summary>
                // Query String Style. Get SubCategory JSON list under a certain TopCategory. Filter by Language and TopCategory ID.
                // </summary>
                // <param name="lang">Language. English = "en", French = "fr"</param>
                // <param name="tid">TopCategory ID.</param>
                // <param name="token">Access token</param>
                // <returns>Return a subcategory list under allowable certain topcategory filter by language. [SubCategoryID], [SubCategory], [SubCategoryDesc] format in JSON</returns>
                [ActionName("json")]
                [Route("api/v2/SubCategory/TopCategory/json")]
                [Route("api/v2/souscatégorie/catégorie/json")]
                // sub
                [HttpGet]
                public HttpResponseMessage GetSubcategoryByTopID_QS(string lang, int tid, string token)
                {
                    var json = this.GetSubcategoryByTopID(tid, lang, token);
                    response = toJson(json, lang);
                    request = HttpContext.Current.Request;


                    return response;
                }
            #endregion JSON

            #region XML
                //Friendly
                // <summary>
                // Get SubCategory XML list under a certain TopCategory. Filter by Language and TopCategory ID.
                // </summary>
                // <param name="lang">Language. English = "en", French = "fr"</param>
                // <param name="tid">TopCategory ID.</param>
                // <param name="token">Access token</param>
                // <returns>Return a subcategory list under allowable certain topcategory filter by language. [SubCategoryID], [SubCategory], [SubCategoryDesc] format in XML</returns>
                [ActionName("xml")]
                [Route("api/v2/SubCategory/TopCategory/xml/{token}/{lang}/{tid}")]
                [Route("api/v2/souscatégorie/catégorie/xml/{token}/{lang}/{tid}")]
                // sub
                [HttpGet]
                public HttpResponseMessage GetSubcategoryByTopID_XML(string lang, int tid, string token)
                {
                    response = getSubCategoriesByTID(lang, tid, token);
                    request = HttpContext.Current.Request;


                    return response;
                }
                //Query String

                // <summary>
                // Query String Style. Get SubCategory XML list under a certain TopCategory. Filter by Language and TopCategory ID.
                // </summary>
                // <param name="lang">Language. English = "en", French = "fr"</param>
                // <param name="tid">TopCategory ID.</param>
                // <param name="token">Access token</param>
                // <returns>Return a subcategory list under allowable certain topcategory filter by language. [SubCategoryID], [SubCategory], [SubCategoryDesc] format in XML</returns>
                [ActionName("xml")]
                [Route("api/v2/SubCategory/TopCategory/xml")]
                [Route("api/v2/souscatégorie/catégorie/xml")]
                // sub
                [HttpGet]
                public HttpResponseMessage GetSubcategoryByTopID_XML_QS(string lang, int tid, string token)
                {
                    response = getSubCategoriesByTID(lang, tid, token);
                    request = HttpContext.Current.Request;


                    return response;
                }

                private HttpResponseMessage getSubCategoriesByTID(string lang, int tid, string token)
                {
                    lang = lang.ToLower();
                    if ((lang == "en") || (lang == "fr"))
                    {
                        var xml = this.GetSubcategoryByTopID(tid, lang, token);
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


            #endregion XML
        #endregion Get SubCategory List By TopCategory ID


               
    }
}
