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
    // Get Resource information by using resource’s ID, location, interest keyword(s), city, province, category etc.
    // </summary>
    [AuthorizeIPAddress]
    [FilterIP]
    public class ResourceController : ApiController
    {



        #region Get Resource by Lang
        #region JSON
        //path
        // <summary>
        // Get all allowable resource list by language.
        // </summary>
        // <param name="lang">Language. English = "en"; French = "fr"</param>
        // <param name="token">Access token</param>
        // <returns>Return JSON format resource list, filter by language</returns>
        [ActionName("json")]
        // RAM
        [Route("api/v2/resource/json/{token}/{lang}")]
        [Route("api/v2/Ressource/json/{token}/{lang}")]
        [HttpGet]
        public HttpResponseMessage GetAllResourcesByLang(string lang, string token)
        {
            HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
            var json = this.GetAllResourcesByLang(lang, token).ToList();
            response = toJson(json, lang);
            request = HttpContext.Current.Request;


            return response;
        }

        //2020-11-07 add get subset resource by 4D asked
        // <summary>
        // Get allowable subset of resource list by language.
        // </summary>
        // <param name="lang">Language. English = "en"; French = "fr"</param>
        // <param name="token">Access token</param>
        // <returns>Return JSON format resource list, filter by language</returns>
        [ActionName("json")]
        // sub
        [Route("api/v3/resource/json/{token}/{lang}")]
        [Route("api/v3/Ressource/json/{token}/{lang}")]
        [HttpGet]
        public HttpResponseMessage GetAllSubsetResourcesByLang(string lang, string token)
        {
            HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
            var json = this.GetAllSubResourcesByLang(lang, token).ToList();
            response = toJson(json, lang);
            request = HttpContext.Current.Request;


            return response;
        }

        //Query String
        // <summary>
        // Query string style getting allowable resource list by language.
        // </summary>
        // <param name="lang">Language. English = "en"; French = "fr"</param>
        // <param name="token">Access token</param>
        // <returns>Return JSON format resource list, filter by language</returns>
        [ActionName("json")]
        [Route("api/v2/resource/json")]
        [Route("api/v2/Ressource/json")]
        // RAM
        [HttpGet]
        public HttpResponseMessage GetAllResourcesByLang_QS(string lang, string token)
        {
            HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
            var json = this.GetAllResourcesByLang(lang, token).ToList();
            response = toJson(json, lang);
            request = HttpContext.Current.Request;


            return response;
        }

        //2020-11-07 get subset RAM Resources 
        //Query String
        // <summary>
        // Query string style getting allowable subset resource list by language.
        // </summary>
        // <param name="lang">Language. English = "en"; French = "fr"</param>
        // <param name="token">Access token</param>
        // <returns>Return JSON format resource list, filter by language</returns>
        [ActionName("json")]
        [Route("api/v3/resource/json")]
        [Route("api/v3/Ressource/json")]
        // sub
        [HttpGet]
        public HttpResponseMessage GetAllSubsetResourcesByLang_QS(string lang, string token)
        {
            HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
            var json = this.GetAllSubResourcesByLang(lang, token).ToList();
            response = toJson(json, lang);
            request = HttpContext.Current.Request;


            return response;
        }

        #endregion JSON

        #region XML
        //Friendly
        // <summary>
        // Get all allowable resource list by language.
        // </summary>
        // <param name="lang">Language. English = "en"; French = "fr"</param>
        // <param name="token">Access token</param>
        // <returns>Return XML format resource list, filter by language</returns>
        [ActionName("xml")]
        [Route("api/v2/resource/xml/{token}/{lang}")]
        [Route("api/v2/Ressource/xml/{token}/{lang}")]
        // RAM
        [HttpGet]
        public HttpResponseMessage GetAllResourcesByLang_XML(string lang, string token)
        {
            HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
            response = createResourcehResult(lang, token);
            request = HttpContext.Current.Request;
 

            return response;
        }
        //Query String
        // <summary>
        // Query String style getting all allowable resource list by language.
        // </summary>
        // <param name="lang">Language. English = "en"; French = "fr"</param>
        // <param name="token">Access token</param>
        // <returns>Return XML format resource list, filter by language</returns>
        [ActionName("xml")]
        [Route("api/v2/resource/xml")]
        [Route("api/v2/Ressource/xml")]
        // RAM
        [HttpGet]
        public HttpResponseMessage GetAllResourcesByLang_XML_QS(string lang, string token)
        {
            HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
            response = createResourcehResult(lang, token);
            request = HttpContext.Current.Request;
 

            return response;
        }
        #endregion XML

        private HttpResponseMessage createResourcehResult(string lang, string token)
        {
            lang = lang.ToLower();
            if ((lang == "en") || (lang == "fr"))
            {
                var xml = this.GetAllResourcesByLang(lang, token).ToList();

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
        #endregion Get Resource by Lang


        #region Get all Resource
            #region JSON
            // <summary>
            // Get allowable resource list return in JSON fromat
            // </summary>
            // <param name="token">Access token</param>
            // <returns>Return resource list format in JSON</returns>
            [ActionName("Resource")]
            [Route("api/v2/resource/all/json/{token}")]
            [Route("api/v2/ressource/tout/json/{token}")]
            // RAM
            [HttpGet]
            public HttpResponseMessage GetAllResources(string token)
            {
                HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
                var json = this.GetAllResources(token).ToList();
                response = toJson(json, "en");
                request = HttpContext.Current.Request;
 
                return response;
            }

            //Query String
            // <summary>
            // Query string style getting allowable resource list return in JSON format.
            // </summary>
            // <param name="token">Access token</param>
            // <returns>Return JSON format resource list</returns>
            [ActionName("json")]
            [Route("api/v2/resource/all/json")]
            [Route("api/v2/Ressource/tout/json")]
            // RAM
            [HttpGet]
            public HttpResponseMessage GetAllResources_QS(string token)
            {
                HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
                var json = this.GetAllResources(token).ToList();
                response = toJson(json, "en");
                request = HttpContext.Current.Request;
 
                return response;
            }

            #endregion JSON
            
            #region XML
                // <summary>
                // Get allowable resource list return in XML style.
                // </summary>
                // <param name="token">Access token</param>
                // <returns>Return allowable resource list format in XML</returns>
                [ActionName("Resource")]
                [Route("api/v2/resource/all/xml/{token}")]
                [Route("api/v2/Ressource/tout/xml/{token}")]
                // RAM
                [HttpGet]
                public HttpResponseMessage GetAllResources_xml(string token)
                {
                    HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
                    request = HttpContext.Current.Request;
                    var xml = this.GetAllResources(token).ToList();
                    if (xml.Count > 0)
                    {
                        var response = Request.CreateResponse(HttpStatusCode.OK, xml, "application/xml");
 
                        return response;
                    }
                    else
                    {
                        response = Request.CreateResponse(HttpStatusCode.NoContent);
 

                        return response;
                    }
                }

                //Query String
                // <summary>
                // Query String style getting all allowable resource list.
                // </summary>
                // <param name="token">Access token</param>
                // <returns>Return XML format allowable resource list</returns>
                [ActionName("xml")]
                [Route("api/v2/resource/all/xml")]
                [Route("api/v2/Ressource/tout/xml")]
                // RAM
                [HttpGet]
                public HttpResponseMessage GetAllResources_XML_QS( string token)
                {
                    HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
                    request = HttpContext.Current.Request;
                    var xml = this.GetAllResources(token).ToList();
                    if (xml.Count > 0)
                    {
                        var response = Request.CreateResponse(HttpStatusCode.OK, xml, "application/xml");
   

                        return response;
                    }
                    else
                    {
                        response = Request.CreateResponse(HttpStatusCode.NoContent);
 

                        return response;
                    }
                }

        #endregion XML
        #endregion Get All Resource


        #region Get Resource By Type
        #region JSON
        #region Path
        // <summary>
        // Path resource type to get allowable resource list filter by language.
        // </summary>
        // <param name="type">Resource type Map:"M"; List:"L"; Both:"B"; Shelter:"S";</param>
        // <param name="token">Access token</param>
        // <param name="lang">language. English = "en"; French = "fr"</param>
        // <returns>Return allowable resource list format in json</returns>
        [ActionName("Resource")]
        [Route("api/v2/resource/type/json/{token}/{lang}/{type}")]
        [Route("api/v2/ressource/type/json/{token}/{lang}/{type}")]
        // RAM
        [HttpGet]
        public HttpResponseMessage GetResourcesByType(string type, string lang, string token)
        {
            HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
            var json = this.GetResourceByType(type,lang,token).ToList();
            response = toJson(json, lang);
            request = HttpContext.Current.Request;
 
            return response;
        }
        #endregion Path

        #region queryString
        // <summary>
        // Query resource type to get allowable resource list filter by language.
        // </summary>
        // <param name="type">Resource type Map:"M"; List:"L"; Both:"B"; Shelter:"S";</param>
        // <param name="lang">Language. English = "en"; French = "fr"</param>
        // <param name="token">Access token</param>
        // <returns>Return allowable resource list format in json</returns>
        [ActionName("Resource")]
        [Route("api/v2/resource/type/json")]
        [Route("api/v2/ressource/type/json")]
        // RAM
        [HttpGet]
        public HttpResponseMessage GetResourcesByType_QS(string type, string lang, string token)
        {
            HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
            var json = this.GetResourceByType(type, lang, token).ToList();
            response = toJson(json, lang);
            request = HttpContext.Current.Request;
 
            return response;
        }
        #endregion queryString
        #endregion JSON

        #region XML
        #region Path
        // <summary>
        // Path resource type to get allowable resource xml list filter by language.
        // </summary>
        // <param name="type">Resource type Map:"M"; List:"L"; Both:"B"; Shelter:"S";</param>
        // <param name="lang">Language. English = "en"; French = "fr"</param>
        // <param name="token">Access token</param>
        // <returns>Return allowable resource list format in XML</returns>
        [ActionName("Resource")]
        [Route("api/v2/resource/type/xml/{token}/{lang}/{type}")]
        [Route("api/v2/ressource/type/xml/{token}/{lang}/{type}")]
        // RAM
        [HttpGet]
        public HttpResponseMessage GetResourcesByType_XML(string type, string lang, string token)
        {
            HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
            //var json = this.GetResourceByType(type, lang, token).ToList();
            request = HttpContext.Current.Request;
            response = createResourcehTypeResult(type, lang, token);
 
            return response;
        }
        #endregion Path

        #region queryString
        // <summary>
        // Query resource type to get allowable resource xml list filter by language.
        // </summary>
        // <param name="type">Resource type Map:"M"; List:"L"; Both:"B"; Shelter:"S";</param>
        // <param name="lang">Language. English = "en"; French = "fr"</param>
        // <param name="token">Access token</param>
        // <returns>Return allowable resource list format in XML</returns>
        [ActionName("Resource")]
        [Route("api/v2/resource/type/xml")]
        [Route("api/v2/ressource/type/xml")]
        // RAM
        [HttpGet]
        public HttpResponseMessage GetResourcesByType_XML_QS(string type, string lang, string token)
        {
            HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
            //var json = this.GetResourceByType(type, lang, token).ToList();
            request = HttpContext.Current.Request;
            response = createResourcehTypeResult(type, lang, token);
 

            return response;
        }
        #endregion queryString
        private HttpResponseMessage createResourcehTypeResult(string type, string lang, string token)
        {
            lang = lang.ToLower();
            if ((lang == "en") || (lang == "fr"))
            {
                var xml = this.GetResourceByType(type, lang, token).ToList();

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
        #endregion Get Resource By Type


        #region Get Resource By ID
        #region JSON
        //Friendly
        // <summary>
        //  Get specific allowable resource by its id, filter by resource's language 
        // </summary>
        // <param name="lang">language. English = "en"; French = "fr"</param>
        // <param name="rid">resource id</param>
        // <param name="token">Access token</param>
        // <returns>return a JSON format specific resource's detail information</returns>
        [ActionName("json")]
        [Route("api/v2/resource/json/{token}/{lang}/{rid}")] 
        // rid is ETLLOADID in the SP Proc_Get_Resource_by_ID
        [Route("api/v2/Ressource/json/{token}/{lang}/{rid}")]
        // RAM
        [HttpGet]
        public HttpResponseMessage GetResourcesByID(string lang, int rid, string token)
        {
            HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
            var json = this.GetResourcesByID(lang,rid,token);
                response =toJson(json, lang);
                request = HttpContext.Current.Request;

            //construct keywords
            string keywords = "";
            keywords =  this.constructKeywords(rid);
 
            return response;
        }
        //Query String
        // <summary>
        //  Query String style getting allowable specific resource by its id, filter by resource's language 
        // </summary>
        // <param name="lang">language. English = "en"; French = "fr"</param>
        // <param name="rid">resource id</param>
        // <param name="token">Access token</param>
        // <returns>return a JSON format specific resource's detail information</returns>
        [ActionName("json")]
        [Route("api/v2/resource/json")]
        [Route("api/v2/Ressource/json")]
        // RAM
        [HttpGet]
        public HttpResponseMessage GetResourcesByID_QS(string lang, int rid, string token)
        {
            HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
            var json = this.GetResourcesByID(lang, rid, token);
            response = toJson(json, lang);
            request = HttpContext.Current.Request;
 

            //construct keywords
            string keywords = "";
            keywords = this.constructKeywords(rid);
 
            return response;

        }




        //2021-03-17
        //Friendly
        // <summary>
        //  Get specific allowable resource by its id, filter by resource's language 
        // </summary>
        // <param name="lang">language. English = "en"; French = "fr"</param>
        // <param name="rid">resource id</param>
        // <param name="token">Access token</param>
        // <returns>return a JSON format specific resource's detail information</returns>
        [ActionName("json")]
        [Route("api/v3/resource/json/{token}/{lang}/{rid}")]
        // rid is ETLLOADID in the SP Proc_Get_Resource_by_ID
        [Route("api/v3/Ressource/json/{token}/{lang}/{rid}")]
        // sub
        [HttpGet]
        public HttpResponseMessage Get_Subset_ResourcesByID(string lang, int rid, string token)
        {
            
            HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
            var json = this.Get_Subset_ResourcesByID(lang, rid, token); //rid = etlloadid in table RAMResource 
            response = toJson(json, lang);
            request = HttpContext.Current.Request;

            //construct keywords
            string keywords = "";
            keywords = this.constructKeywords(rid);
   
            return response;
        }
        //Query String
        // <summary>
        //  Query String style getting allowable specific resource by its id, filter by resource's language 
        // </summary>
        // <param name="lang">language. English = "en"; French = "fr"</param>
        // <param name="rid">resource id</param>
        // <param name="token">Access token</param>
        // <returns>return a JSON format specific resource's detail information</returns>
        [ActionName("json")]
        [Route("api/v3/resource/json")]
        [Route("api/v3/Ressource/json")]
        // sub
        [HttpGet]
        public HttpResponseMessage Get_Subset_ResourcesByID_QS(string lang, int rid, string token)
        {
            HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
            var json = this.Get_Subset_ResourcesByID(lang, rid, token);// rid is ETLLOADID in the SP Proc_Get_Resource_by_ID
            response = toJson(json, lang);
            request = HttpContext.Current.Request;
 

            //construct keywords
            string keywords = "";
 
            return response; 

        }

         
        //2021-03-26
        //Friendly
        // <summary>
        //  Get specific allowable resource information in full by its id, filter by resource's language 
        // </summary>
        // <param name="lang">language. English = "en"; French = "fr"</param>
        // <param name="rid">resource id</param>
        // <param name="token">Access token</param>
        // <returns>return a JSON format specific resource's detail information in full</returns>
        [ActionName("json")]
        [Route("api/v3/resource/full/json/{token}/{lang}/{rid}")]
        // rid is ETLLOADID in the SP Proc_Get_Resource_by_ID
        [Route("api/v3/Ressource/complète/json/{token}/{lang}/{rid}")]
        //[(V3_Full_Resource))]
        [HttpGet]
        public HttpResponseMessage Get_full_ResourcesByID(string lang, int rid, string token)
        {

            HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
            var json = this.Get_full_ResourcesByID(lang, rid, token); //rid = etlloadid in table RAMResource 
            response = toJson(json, lang);
            request = HttpContext.Current.Request;

            //construct keywords
            string keywords = "";
            keywords = this.constructKeywords(rid);
 
            return response;
        }
        //Query String
        // <summary>
        //  Query String style getting allowable specific resource information in full by its id, filter by resource's language 
        // </summary>
        // <param name="lang">language. English = "en"; French = "fr"</param>
        // <param name="rid">resource id</param>
        // <param name="token">Access token</param>
        // <returns>return a JSON format specific resource's detail information in full</returns>
        [ActionName("json")]
        [Route("api/v3/resource/full/json")]
        [Route("api/v3/Ressource/complète/json")]
        //[(V3_Full_Resource))]
        [HttpGet]
        public HttpResponseMessage Get_full_ResourcesByID_QS(string lang, int rid, string token)
        {
            HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
            var json = this.Get_full_ResourcesByID(lang, rid, token); 
            response = toJson(json, lang);
            request = HttpContext.Current.Request;
 

 
 
            return response;

        }

        #endregion JSON

        #region XML
        // <summary>
        //  Get allowable specific resource by its id, filter by resource's language 
        // </summary>
        // <param name="lang">language. English = "en"; French = "fr"</param>
        // <param name="rid">resource id</param>
        // <param name="token">Access token</param>
        // <returns>return a XML format specific resource's detail information</returns>
        //Friendly
        [ActionName("xml")]
        [Route("api/v2/resource/xml/{token}/{lang}/{rid}")]
        [Route("api/v2/Ressource/xml/{token}/{lang}/{rid}")]
        // RAM
        [HttpGet]
        public HttpResponseMessage GGetResourcesByID_XML(string lang, int rid, string token)
        {
            HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
            response =  CreateResourcesByID(lang, rid, token);
            request = HttpContext.Current.Request;
 
    
            return response;
        }
        //Query String
        // <summary>
        //  Query String style getting allowable specific resource by its id, filter by resource's language 
        // </summary>
        // <param name="lang">language. English = "en"; French = "fr"</param>
        // <param name="rid">resource id</param>
        // <param name="token">Access token</param>
        // <returns>return a XML format specific resource's detail information</returns>
        [ActionName("xml")]
        [Route("api/v2/resource/xml")]
        [Route("api/v2/Ressource/xml")]
        // RAM
        [HttpGet]
        public HttpResponseMessage GetResourcesByID_XML_QS(string lang, int rid, string token)
        {
            HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
            response = CreateResourcesByID(lang, rid, token);
            request = HttpContext.Current.Request;
 
 
            return response;
        }
        private HttpResponseMessage CreateResourcesByID(string lang, int rid, string token)
        {
            lang = lang.ToLower();
            if ((lang == "en") || (lang == "fr"))
            {
                var xml = this.GetResourcesByID(lang, rid, token);
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
        #endregion Get Resource By ID


        #region Get Unique Resource By 
        #region JSON
        //Friendly
        // <summary>
        //  For email favour list to user, it will track user selected resource for a period of time. get specific resource by language, map, resource agency number, SubCategory id, top category id 
        // </summary>
        // <param name="lang">language. English = "en"; French = "fr"</param>
        // <param name="map">map resource. such as mapped, list, both, shelter</param>
        // <param name="ran">resourceAgencyNum id</param>
        // <param name="sid">SubCategoryid id</param>
        // <param name="tid">top category id</param>
        // <param name="token">Access token</param>
        // <returns>return a JSON format specific resource's detail information</returns>
        // 
        [ActionName("json")]
        [Route("api/v2/resource/favour/json/{token}/{lang}/{map}/{ran}/{sid}/{tid}")]
        [Route("api/v2/Ressource/favoriser/json/{token}/{lang}/{map}/{ran}/{sid}/{tid}")]
        // RAM
        [HttpGet]
        public HttpResponseMessage GetUniqueResources(string lang, string map, string ran, int sid, int tid, string token)
        {
            HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
            var json = this.GetUniqueResources(map, ran, sid, tid, lang, token);
            response = toJson(json, lang);
            request = HttpContext.Current.Request;
 
            return response;
        }
        //Query String
        // <summary>
        //  For email favour list to user, it will track user selected resource for a period of time. Query String style getting specific resource by by language, map, resource agency number, SubCategory id, top category id 
        // </summary>
        // <param name="lang">language. English = "en"; French = "fr"</param>
        // <param name="map">map resource. such as mapped, list, both, shelter</param>
        // <param name="ran">resourceAgencyNum id</param>
        // <param name="sid">SubCategoryid id</param>
        // <param name="tid">top category  id</param>
        // <param name="token">Access token</param>
        // <returns>return a JSON format specific resource's detail information</returns>
        [ActionName("json")]
        [Route("api/v2/resource/favour/json")]
        [Route("api/v2/Ressource/favoriser/json")]
        // RAM
        [HttpGet]
        public HttpResponseMessage GetUniqueResources_QS(string lang, string map, string ran, int sid, int tid, string token)
        {
            HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
            var json = this.GetUniqueResources(map, ran, sid, tid, lang, token);
            response = toJson(json, lang);
            request = HttpContext.Current.Request;
 
            return response;
        }
        #endregion JSON

        #region XML
        // <summary>
        //  For email favour list to user, it will track user selected resource for a period of time. XML format, get specific resource by language, map, resource agency number, SubCategory id, top category id 
        // </summary>
        // <param name="lang">language. English = "en"; French = "fr"</param>
        // <param name="map">map resource. such as mapped, list, both, shelter</param>
        // <param name="ran">resourceAgencyNum id</param>
        // <param name="sid">SubCategoryid id</param>
        // <param name="tid">top category  id</param>
        // <param name="token">Access token</param>
        // <returns>return a XML format specific resource's detail information</returns>
        //Friendly
        [ActionName("xml")]
        [Route("api/v2/resource/favour/xml/{token}/{lang}/{map}/{ran}/{sid}/{tid}")]
        [Route("api/v2/Ressource/favoriser/xml/{token}/{lang}/{map}/{ran}/{sid}/{tid}")]
        // RAM
        [HttpGet]
        public HttpResponseMessage GetUniqueResources_XML(string lang, string map, string ran, int sid, int tid, string token)
        {
            HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
            response = CreateUniqueResources(lang, map, ran, sid, tid, token);
            request = HttpContext.Current.Request;
 
            return response;
        }
        //Query String
        // <summary>
        //  For email favour list to user, it will track user selected resource for a period of time. Query String style getting specific resource by language, map, resource agency number, SubCategory id, top category id 
        // </summary>
        // <param name="lang">language. English = "en"; French = "fr"</param>
        // <param name="map">map resource. such as mapped, list, both, shelter</param>
        // <param name="ran">resourceAgencyNum id</param>
        // <param name="sid">SubCategory id</param>
        // <param name="tid">top category  id</param>
        // <param name="token">Access token</param>
        // <returns>return a XML format specific resource's detail information</returns>
        [ActionName("xml")]
        [Route("api/v2/resource/favour/xml")]
        [Route("api/v2/Ressource/favoriser/xml")]
        // RAM
        [HttpGet]
        public HttpResponseMessage GetUniqueResources_XML_QS(string lang, string map, string ran, int sid, int tid, string token)
        {
            HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
            response = CreateUniqueResources(lang, map, ran, sid, tid, token);
            request = HttpContext.Current.Request;
 
            return response;
        }
        private HttpResponseMessage CreateUniqueResources(string lang, string map, string ran, int sid, int tid, string token)
        {
            lang = lang.ToLower();
            if ((lang == "en") || (lang == "fr"))
            {
                var xml = this.GetUniqueResources(map, ran, sid, tid, lang, token);
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
        #endregion Get Unique Resource By


        #region Get Resource By City ID
            #region JSON
                // Path
                // <summary>
                //  Get resource list in the specific allowable city filter by resource's language 
                // </summary>
                // <param name="lang">language. English = "en"; French = "fr"</param>
                // <param name="cid">city id</param>
                // <param name="token">Access token</param>
                // <returns>return a JSON format resource list located in a specific city</returns>
                [ActionName("json")]
                [Route("api/v2/resource/city/json/{token}/{lang}/{cid}")]
                [Route("api/v2/Ressource/ville/json/{token}/{lang}/{cid}")]
                // RAM
                [HttpGet]
                public HttpResponseMessage GetAllResourcesByCity(string lang, int cid, string token)
                {
                    HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
                    var json = this.GetResourcesByCity(cid, lang, token).ToList();
                    response = toJson(json, lang);
                    request = HttpContext.Current.Request;
  

                    return response;
                }

        //2020-12-01 Add
        // <summary>
        //  Get Subset of resource list in the specific allowable city filter by resource's language 
        // </summary>
        // <param name="lang">language. English = "en"; French = "fr"</param>
        // <param name="cid">city id</param>
        // <param name="token">Access token</param>
        // <returns>return a JSON format subset of resource list located in a specific city</returns>
        [ActionName("json")]
        [Route("api/v3/resource/city/json/{token}/{lang}/{cid}")]
        [Route("api/v3/Ressource/ville/json/{token}/{lang}/{cid}")]
        // sub
        [HttpGet]
        public HttpResponseMessage GetAll_SubResourcesByCity(string lang, int cid, string token)
        {
            HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
            var json = this.GetSubResourcesByCity(cid, lang, token).ToList();
            response = toJson(json, lang);
            request = HttpContext.Current.Request;
 

            return response;
        }


        // Query String
        // <summary>
        //  Query String getting resource list in the specific allowable city filter by resource's language 
        // </summary>
        // <param name="lang">language. English = "en"; French = "fr"</param>
        // <param name="cid">city id</param>
        // <param name="token">Access token</param>
        // <returns>return a JSON format resource list located in a specific city</returns>
        [ActionName("json")]
                [Route("api/v2/resource/city/json")]
                [Route("api/v2/Ressource/ville/json")]
                // RAM
                [HttpGet]
                public HttpResponseMessage GetAllResourcesByCity_QS(string lang, int cid, string token)
                {
                    HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
                    var json = this.GetResourcesByCity(cid, lang, token).ToList();
                    response = toJson(json, lang);
                    request = HttpContext.Current.Request;
 

                    return response;
                }

        //2020-12-01 add
        // <summary>
        //  Query String getting subset of resource list in the specific allowable city filter by resource's language 
        // </summary>
        // <param name="lang">language. English = "en"; French = "fr"</param>
        // <param name="cid">city id</param>
        // <param name="token">Access token</param>
        // <returns>return a JSON format subset of resource list located in a specific city</returns>
        [ActionName("json")]
        [Route("api/v3/resource/city/json")]
        [Route("api/v3/Ressource/ville/json")]
        // sub
        [HttpGet]
        public HttpResponseMessage GetAll_SubResourcesByCity_QS(string lang, int cid, string token)
        {
            HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
            var json = this.GetSubResourcesByCity(cid, lang, token).ToList();
            response = toJson(json, lang);
            request = HttpContext.Current.Request;
 

            return response;
        }
        #endregion JSON

        #region XML
        // Friendly
        // <summary>
        //  Get resource list in the specific allowable city filter by resource's language 
        // </summary>
        // <param name="lang">language. English = "en"; French = "fr"</param>
        // <param name="cid">city id</param>
        // <param name="token">Access token</param>
        // <returns>return a XML format resource list located in a specific city</returns>
        [ActionName("xml")]
            [Route("api/v2/resource/city/xml/{token}/{lang}/{cid}")]
            [Route("api/v2/Ressource/ville/xml/{token}/{lang}/{cid}")]
            // RAM
            [HttpGet]
            public HttpResponseMessage GetAllResourcesByCity_XML(string lang, int cid, string token)
            {
                HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
                response = createResourcesByCityResult(cid, lang, token);
                request = HttpContext.Current.Request;
 
                return response;
            }
        // Query String
        // <summary>
        //  Query String style getting resource list in the specific allosing city filter by resource's language 
        // </summary>
        // <param name="lang">language. English = "en"; French = "fr"</param>
        // <param name="cid">city id</param>
        // <param name="token">Access token</param>
        // <returns>return a XML format resource list located in a specific city</returns>
        [ActionName("xml")]
        [Route("api/v2/resource/city/xml")]
        [Route("api/v2/Ressource/ville/xml")]
        // RAM
        [HttpGet]
        public HttpResponseMessage GetAllResourcesByCity_XML_QS(string lang, int cid, string token)
        {
            HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
            response = createResourcesByCityResult(cid, lang, token);
            request = HttpContext.Current.Request;
 
            return response;
        }
        private HttpResponseMessage createResourcesByCityResult(int cid, string lang, string token)
        {
            lang = lang.ToLower();
            if ((lang == "en") || (lang == "fr"))
            {
                var xml = this.GetResourcesByCity(cid, lang, token).ToList();

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
        #endregion Get Resource By City ID


        #region Get Resource By Province ID
            #region JSON
                // Path
                // <summary>
                //  Get resource list in the specific allowable province filter by resource's language 
                // </summary>
                // <param name="lang">language. English = "en"; French = "fr"</param>
                // <param name="pid">province id</param>
                // <param name="token">Access token</param>
                // <returns>return a JSON format resource list located in a specific province</returns>
                [ActionName("json")]
                [Route("api/v2/resource/province/json/{token}/{lang}/{pid}")]
                [Route("api/v2/Ressource/province/json/{token}/{lang}/{pid}")]
                // RAM
                [HttpGet]
                public HttpResponseMessage GetAllResourcesByProvince(string lang, int pid, string token)
                {
                    HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
                    var json = this.GetResourcesByProvince(pid, lang, token).ToList();
                    response = toJson(json, lang);
                    request = HttpContext.Current.Request;
     

                    return response;
                }

        //2020-12-01 add
        // <summary>
        //  Get subset of resource list in the specific allowable province filter by resource's language 
        // </summary>
        // <param name="lang">language. English = "en"; French = "fr"</param>
        // <param name="pid">province id</param>
        // <param name="token">Access token</param>
        // <returns>return a JSON format subset of resource list located in a specific province</returns>
        [ActionName("json")]
        [Route("api/v3/resource/province/json/{token}/{lang}/{pid}")]
        [Route("api/v3/Ressource/province/json/{token}/{lang}/{pid}")]
        // sub
        [HttpGet]
        public HttpResponseMessage GetAll_SubResourcesByProvince(string lang, int pid, string token)
        {
            HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
            var json = this.GetSubResourcesByProvince(pid, lang, token).ToList();
            response = toJson(json, lang);
            request = HttpContext.Current.Request;
 

            return response;
        }


        // Query String
        // <summary>
        //  Query String getting resource list in the specific allowable province filter by resource's language 
        // </summary>
        // <param name="lang">language. English = "en"; French = "fr"</param>
        // <param name="pid">province id</param>
        // <param name="token">Access token</param>
        // <returns>return a XML format resource list located in a specific province</returns>
        [ActionName("json")]
                [Route("api/v2/resource/province/json")]
                [Route("api/v2/Ressource/province/json")]
                // RAM
                [HttpGet]
                public HttpResponseMessage GetAllResourcesByProvince_QS(string lang, int pid, string token)
                {
                    HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
                    var json = this.GetResourcesByProvince(pid, lang, token).ToList();
                    response = toJson(json, lang);
                    request = HttpContext.Current.Request;
 

                    return response;
                }

        //2020-12-01 add
        // <summary>
        //  Query String getting subset of resource list in the specific allowable province filter by resource's language 
        // </summary>
        // <param name="lang">language. English = "en"; French = "fr"</param>
        // <param name="pid">province id</param>
        // <param name="token">Access token</param>
        // <returns>return a XML format resource list located in a specific province</returns>
        [ActionName("json")]
        [Route("api/v3/resource/province/json")]
        [Route("api/v3/Ressource/province/json")]
        // sub
        [HttpGet]
        public HttpResponseMessage GetAll_subResourcesByProvince_QS(string lang, int pid, string token)
        {
            HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
            var json = this.GetSubResourcesByProvince(pid, lang, token).ToList();
            response = toJson(json, lang);
            request = HttpContext.Current.Request;
 
            return response;
        }
        #endregion JSON

        #region XML
        // Friendly
        // <summary>
        //  Get resource list in the specific allowable province filter by resource's language 
        // </summary>
        // <param name="lang">language. English = "en"; French = "fr"</param>
        // <param name="pid">province id</param>
        // <param name="token">Access token</param>
        // <returns>return a XML format resource list located in a specific province</returns>
        [ActionName("xml")]
                [Route("api/v2/resource/province/xml/{token}/{lang}/{pid}")]
                [Route("api/v2/Ressource/province/xml/{token}/{lang}/{pid}")]
                // RAM
                [HttpGet]
                public HttpResponseMessage GetAllResourcesByProvince_XML(string lang, int pid, string token)
                {
                    HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
                    response = createResourcesByProvinceResult(pid, lang, token);
                    request = HttpContext.Current.Request;
 
                    return response;
                }
                // Query String
                // <summary>
                //  Query String style getting resource list in the specific allowable province filter by resource's language 
                // </summary>
                // <param name="lang">language. English = "en"; French = "fr"</param>
                // <param name="pid">province id</param>
                // <param name="token">Access token</param>
                // <returns>return a XML format resource list located in a specific province</returns>
                [ActionName("xml")]
                [Route("api/v2/resource/province/xml")]
                [Route("api/v2/Ressource/province/xml")]
                // RAM
                [HttpGet]
                public HttpResponseMessage GetAllResourcesByProvince_XML_QS(string lang, int pid, string token)
                {
                    HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
                    response = createResourcesByProvinceResult(pid, lang, token);
                    request = HttpContext.Current.Request;
 
                    return response;
                }
                private HttpResponseMessage createResourcesByProvinceResult(int pid, string lang, string token)
                {
                    lang = lang.ToLower();
                    if ((lang == "en") || (lang == "fr"))
                    {
                        var xml = this.GetResourcesByProvince(pid, lang, token).ToList();

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
        #endregion Get Resource By Province ID


        #region Get Resource By SubCategory ID
            #region JSON
                // Path
                // <summary>
                //  Get resource list under the SubCategory filter by resource's language 
                // </summary>
                // <param name="lang">language. English = "en"; French = "fr"</param>
                // <param name="sid">SubCategory id.</param>
                // <param name="token">Access token</param>
                // <returns>Return a JSON format resource list under the specific SubCategory</returns>
                [ActionName("json")]
                [Route("api/v2/Resource/SubCategory/json/{token}/{lang}/{sid}")]
                [Route("api/v2/Ressource/souscatégorie/json/{token}/{lang}/{sid}")]
                // RAM
                [HttpGet]
                public HttpResponseMessage GetAllResourcesBySubCategory(string lang, int sid, string token)
                {
                    HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
                    var json = this.GetResourcesBySubCategory(sid, lang, token).ToList();
                    response = toJson(json, lang);
                    request = HttpContext.Current.Request;
 
                    return response;
                }


        // 2020-11-20 V3
        // Friendly
        // <summary>
        //  Get subset of resource list under the SubCategory filter by resource's language 
        // </summary>
        // <param name="lang">language. English = "en"; French = "fr"</param>
        // <param name="sid">SubCategory id.</param>
        // <param name="token">Access token</param>
        // <returns>Return a JSON format resource list under the specific SubCategory</returns>
        [ActionName("json")]
        [Route("api/v3/Resource/SubCategory/json/{token}/{lang}/{sid}")]
        [Route("api/v3/Ressource/souscatégorie/json/{token}/{lang}/{sid}")]
        // sub
        [HttpGet]
        public HttpResponseMessage GetAll_Sub_ResourcesBySubCategory(string lang, int sid, string token)
        {
            HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
            var json = this.GetSubResourcesBySubCategory(sid, lang, token).ToList();
            response = toJson(json, lang);
 
            return response;
        }



        // Query String
        // <summary>
        //  Query String style, Get resource list under the SubCategory filter by resource's language 
        // </summary>
        // <param name="lang">language. English = "en"; French = "fr"</param>
        // <param name="sid">SubCategory id.</param>
        // <param name="token">Access token</param>
        // <returns>Return a JSON format resource list under the specific SubCategory</returns>
        [ActionName("json")]
                [Route("api/v2/resource/SubCategory/json")]
                [Route("api/v2/Ressource/souscatégorie/json")]
                // RAM
                [HttpGet]
                public HttpResponseMessage GetAllResourcesBySubCategory_QS(string lang, int sid, string token)
                {
                    HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
                    var json = this.GetResourcesBySubCategory(sid, lang, token).ToList();
                    response = toJson(json, lang);
                    request = HttpContext.Current.Request;
 
                    return response;
                }


        // 2020-11-20 V3
        // <summary>
        //  Query String style, Get Subset of resource list under the SubCategory filter by resource's language 
        // </summary>
        // <param name="lang">language. English = "en"; French = "fr"</param>
        // <param name="sid">SubCategory id.</param>
        // <param name="token">Access token</param>
        // <returns>Return a JSON format resource list under the specific SubCategory</returns>
        [ActionName("json")]
        [Route("api/v3/resource/SubCategory/json")]
        [Route("api/v3/Ressource/souscatégorie/json")]
        // sub
        [HttpGet]
        public HttpResponseMessage GetAll_Sub_ResourcesBySubCategory_QS(string lang, int sid, string token)
        {
            HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
            var json = this.GetSubResourcesBySubCategory(sid, lang, token).ToList();
            response = toJson(json, lang);
            request = HttpContext.Current.Request;
 
            return response;
        }

        #endregion JSON




        #region XML
        // Friendly
        // <summary>
        //  Get resource list under the SubCategory filter by resource's language 
        // </summary>
        // <param name="lang">language. English = "en"; French = "fr"</param>
        // <param name="sid">SubCategory id.</param>
        // <param name="token">Access token</param>
        // <returns>Return a XML format resource list under the specific SubCategory</returns>
        [ActionName("xml")]
            [Route("api/v2/resource/SubCategory/xml/{token}/{lang}/{sid}")]
            [Route("api/v2/Ressource/souscatégorie/xml/{token}/{lang}/{sid}")]
            // RAM
            [HttpGet]
            public HttpResponseMessage GetAllResourcesBySubCategory_XML(string lang, int sid, string token)
            {
                HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
                response = createResourcesBySubCategoryResult(sid, lang, token);
                request = HttpContext.Current.Request;
 
                return response;
            }
            // Query String
            // <summary>
            //  Query String Style. Get resource list under the SubCategory filter by resource's language 
            // </summary>
            // <param name="lang">language. English = "en"; French = "fr"</param>
            // <param name="sid">SubCategory id.</param>
            // <param name="token">Access token</param>
            // <returns>Return a XML format resource list under the specific SubCategory</returns>
            [ActionName("xml")]
            [Route("api/v2/resource/SubCategory/xml")]
            [Route("api/v2/Ressource/souscatégorie/xml")]
            // RAM
            [HttpGet]
            public HttpResponseMessage GetAllResourcesBySubCategory_XML_QS(string lang, int sid, string token)
            {
                HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
                response = createResourcesBySubCategoryResult(sid, lang, token);
                request = HttpContext.Current.Request;
 
                return response;
            }
            private HttpResponseMessage createResourcesBySubCategoryResult(int sid, string lang, string token)
            {
                lang = lang.ToLower();
                if ((lang == "en") || (lang == "fr"))
                {
                    var xml = this.GetResourcesBySubCategory(sid, lang, token).ToList();

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
        #endregion Get Resource By SubCategory ID


        #region Get Resource By TopCategory ID
            #region JSON
            // Friendly
            // <summary>
            //  Get resource list under allowable TopCategory, filter by resource's language 
            // </summary>
            // <param name="lang">language. English = "en"; French = "fr"</param>
            // <param name="tid">TopCategory id.</param>
            // <param name="token">Access token</param>
            // <returns>Return a JSON format resource list under the specific TopCategory</returns>
            [ActionName("json")]
            [Route("api/v2/resource/topcategory/json/{token}/{lang}/{tid}")]
            [Route("api/v2/Ressource/catégorie/json/{token}/{lang}/{tid}")]
            // RAM
            [HttpGet]
            public HttpResponseMessage GetAllResourcesByTopCategory(string lang, int tid, string token)
            {
                HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
                var json = this.GetResourcesByTopCategory(tid, lang, token).ToList();
                response = toJson(json, lang);
                request = HttpContext.Current.Request;
 

                return response;
            }


        //2020-11-20 add
        // Friendly
        // <summary>
        //  Get subset of resource list under allowable TopCategory, filter by resource's language 
        // </summary>
        // <param name="lang">language. English = "en"; French = "fr"</param>
        // <param name="tid">TopCategory id.</param>
        // <param name="token">Access token</param>
        // <returns>Return a JSON format resource list under the specific TopCategory</returns>
        [ActionName("json")]
        [Route("api/v3/resource/topcategory/json/{token}/{lang}/{tid}")]
        [Route("api/v3/Ressource/catégorie/json/{token}/{lang}/{tid}")]
        // sub
        [HttpGet]
        public HttpResponseMessage GetAll_Sub_ResourcesByTopCategory(string lang, int tid, string token)
        {
            HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
            var json = this.GetSubResourcesByTopCategory(tid, lang, token).ToList();
            response = toJson(json, lang);
            request = HttpContext.Current.Request;
 

            return response;
        }




        // Query String
        // <summary>
        //  Query String Style. Get resource list under allowable TopCategory filter by resource's language 
        // </summary>
        // <param name="lang">language. English = "en"; French = "fr"</param>
        // <param name="tid">TopCategory id.</param>
        // <param name="token">Access token</param>
        // <returns>Return a JSON format resource list under the specific TopCategory</returns>
        [ActionName("json")]
            [Route("api/v2/resource/topcategory/json")]
            [Route("api/v2/Ressource/catégorie/json")]
            // RAM
            [HttpGet]
            public HttpResponseMessage GetAllResourcesByTopCategory_QS(string lang, int tid, string token)
            {
                HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
                var json = this.GetResourcesByTopCategory(tid, lang, token).ToList();
                response = toJson(json, lang);
                request = HttpContext.Current.Request;
 

                return response;
            }

        //2020-11-20 added
        // <summary>
        //  Query get subset of resource list under allowable TopCategory filter by resource's language 
        // </summary>
        // <param name="lang">language. English = "en"; French = "fr"</param>
        // <param name="tid">TopCategory id.</param>
        // <param name="token">Access token</param>
        // <returns>Return a JSON format resource list under the specific TopCategory</returns>
        [ActionName("json")]
        [Route("api/v3/resource/topcategory/json")]
        [Route("api/v3/Ressource/catégorie/json")]
        // sub
        [HttpGet]
        public HttpResponseMessage GetAll_Sub_ResourcesByTopCategory_QS(string lang, int tid, string token)
        {
            HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
            var json = this.GetSubResourcesByTopCategory(tid, lang, token).ToList();
            response = toJson(json, lang);
            request = HttpContext.Current.Request;
 

            return response;
        }




        #endregion JSON

        #region XML
        // Friendly
        // <summary>
        //  Get resource list under allowable TopCategory filter by resource's language 
        // </summary>
        // <param name="lang">language. English = "en"; French = "fr"</param>
        // <param name="tid">TopCategory id.</param>
        // <param name="token">Access token</param>
        // <returns>Return a XML format resource list under the specific TopCategory</returns>
        [ActionName("xml")]
            [Route("api/v2/resource/topcategory/xml/{token}/{lang}/{tid}")]
            [Route("api/v2/Ressource/catégorie/xml/{token}/{lang}/{tid}")]
            // RAM
            [HttpGet]
            public HttpResponseMessage GetAllResourcesByTopCategory_XML(string lang, int tid, string token)
            {
                HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
                response = createResourcesByTopcategoryResult(tid, lang, token);
                request = HttpContext.Current.Request;
 
                return response;
            }


            // Query String
            // <summary>
            //  Query String Style. Get resource list under allowable TopCategory filter by resource's language 
            // </summary>
            // <param name="lang">language. English = "en"; French = "fr"</param>
            // <param name="tid">TopCategory id.</param>
            // <param name="token">Access token</param>
            // <returns>Return a XML format resource list under the specific TopCategory</returns>
            [ActionName("xml")]
            [Route("api/v2/resource/topcategory/xml")]
            [Route("api/v2/Ressource/catégorie/xml")]
            // RAM
            [HttpGet]
            public HttpResponseMessage GetAllResourcesByTopCategory_XML_QS(string lang, int tid, string token)
            {
                HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
                response = createResourcesByTopcategoryResult(tid, lang, token);
                request = HttpContext.Current.Request;
 
                return response;
            }
            private HttpResponseMessage createResourcesByTopcategoryResult(int tid, string lang, string token)
            {
                lang = lang.ToLower();
                if ((lang == "en") || (lang == "fr"))
                {
                    var xml = this.GetResourcesByTopCategory(tid, lang, token).ToList();

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
        #endregion Get Resource By TopCategory ID


        #region Get Resource By Search Keywords
            #region JSON
            //Path
            // <summary>
            // Get allowable resource list by using interest key word(s). Format in JSON.
            // </summary>
            // <param name="kws">interest key words to be searched. Multiple interesting kords could be split by using Space, comma, semicolon</param>
            // <param name="lang">Language. English = "en"; French = "fr"</param>
            // <param name="token">Access token</param>
            // <returns>Return resource list. Returned resource includes any interest search key words or their synonym in his name, description, location, term, category etc. Format in JSON</returns>
            [ActionName("search")]
            [Route("api/v2/resource/kws/json/{token}/{lang}/{kws}")]
            [Route("api/v2/Ressource/kws/json/{token}/{lang}/{kws}")]
            // RAM
            [HttpGet]
            public HttpResponseMessage search(string kws, string lang, string token)
            {
                HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
                var json = this.GetResourceByKeywords(kws, lang, token).ToList();
                response = toJson(json, lang);
                request = HttpContext.Current.Request;
 
                return response;
     
            }
            //Query String
            // <summary>
            // Query String style pass interest keyword(s), response allowable JSON resource list.  
            // </summary>
            // <param name="kws">interest key words to be search. Multiple interesting kords could be split by using Space, comma, semicolon</param>
            // <param name="lang">Language. English = "en"; French = "fr"</param>
            // <param name="token">Access token</param>
            // <returns>Return resource list. Returned resource includes any interest search key words or their synonym in his name, description, location, term, category etc. Format in JSON</returns>
            [ActionName("search")]
            [Route("api/v2/resource/kws/json")]
            [Route("api/v2/Ressource/kws/json")]
            // RAM
            [HttpGet]
            public HttpResponseMessage search_QS(string lang, string kws, string token)
            {
                HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
                var json = this.GetResourceByKeywords(kws, lang, token).ToList();
                response = toJson(json, lang);
                request = HttpContext.Current.Request;
     
                return response;
            }
            #endregion JSON

            #region XML
            //Friendly
            // <summary>
            // Get XML format allowable resource list by using interest key word(s). 
            // </summary>
            // <param name="kws">interest key words to be search. Multiple interesting kords could be split by using Space, comma, semicolon</param>
            // <param name="lang">Language. English = "en"; French = "fr"</param>
            // <param name="token">Access token</param>
            // <returns>Return resource list. Returned resource includes any interest search key words or their synonym in his name, description, location, term, category etc. Format in XML</returns>
            [ActionName("xml")]
            [Route("api/v2/resource/kws/xml/{token}/{lang}/{kws}")]
            [Route("api/v2/Ressource/kws/xml/{token}/{lang}/{kws}")]
            // RAM
            [HttpGet]
            public HttpResponseMessage search_XML(string lang, string kws, string token)
            {
                HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
                response = createSearchResult(kws, lang, token);
                request = HttpContext.Current.Request;
 
                return response;
            }
            //Query String
            // <summary>
            // Query String style pass interest keyword(s), response XML fromat allowable resource list. 
            // </summary>
            // <param name="kws">interest key words to be search. Multiple interesting kords could be split by using Space, comma, semicolon</param>
            // <param name="lang">Language. English = "en"; French = "fr"</param>
            // <param name="token">Access token</param>
            // <returns>Return resource list. Returned resource includes any interest search key words or their synonym in his name, description, location, term, category etc. Format in XML</returns>
            [ActionName("xml")]
            [Route("api/v2/resource/kws/xml")]
            [Route("api/v2/Ressource/kws/xml")]
            // RAM
            [HttpGet]
            public HttpResponseMessage search_XML_QS(string lang, string kws, string token)
            {
                HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
                response = createSearchResult(kws, lang, token);
                request = HttpContext.Current.Request;
 
                return response;
            }
            #endregion XML

            private HttpResponseMessage createSearchResult(string kws, string lang, string token)
            {
                lang = lang.ToLower();
                if ((lang == "en") || (lang == "fr"))
                {
                    var xml = this.GetResourceByKeywords(kws, lang, token).ToList();

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

        #endregion Get Resource By Search Keywords


        #region Proc_Get_All_Resources_In_Radius
            #region JSON
            //path
            // <summary>
            // Get allowable resources which locate in a circular area. current location is center of the circle; radius (Km) is distance. 
            // </summary>
            // <param name="lang">Language: English = "en" ;  French = "fr"</param>
            // <param name="lat">Latitude of current location </param>
            // <param name="lon">Longitude of current location </param>
            // <param name="radius">radius: How many Kilometre from current location</param>
            // <param name="token">Access token</param>
            // <returns>Return a resource list in a circular area, current location is center, radius  is the distance,fromat in JSON </returns>
            [ActionName("json")]
            [Route("api/v2/resource/circular/json/{token}/{lang}/{lat}/{lon}/{radius}")]
            [Route("api/v2/Ressource/circulaire/json/{token}/{lang}/{lat}/{lon}/{radius}")]
            // RAM
            [HttpGet]
            public HttpResponseMessage GetResourcesInRadiusList(string lang, decimal lat, decimal lon, decimal radius, string token)
            {
                HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
                var json = this.GetResourcesInRadiusList(lang, lat, lon, radius, token).ToList();
                response = toJson(json, lang);
                request = HttpContext.Current.Request;
 
                return response;
            }

            //Query String
            // <summary>
            // Query String style, get allowable resources which locate in a circular area. current location is center of the circle; radius (Km) is distance. 
            // </summary>
            // <param name="lang">Language: English = "en" ;  French = "fr"</param>
            // <param name="lat">Latitude of current location</param>
            // <param name="lon">Longitude of current location</param>
            // <param name="radius">radius: How many Kilometre from current location</param>
            // <param name="token">Access token</param>
            // <returns>Return a resource list in a circular area, current location is center, radius is the distance, fromat in JSON </returns>
            [ActionName("json")]
            [Route("api/v2/resource/circular/json")]
            [Route("api/v2/Ressource/circulaire/json")]
            // RAM
            [HttpGet]
            public HttpResponseMessage GetResourcesInRadiusList_QS(string lang, decimal lat, decimal lon, decimal radius, string token)
            {
                HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
                var json = this.GetResourcesInRadiusList(lang, lat, lon, radius, token).ToList();
                response = toJson(json, lang);
                request = HttpContext.Current.Request;
  
                return response;
            }
            #endregion JSON

            #region XML
            //Friendly
            // <summary>
            // Get allowable resources which locate in a circular area. current location is center of the circle; radius (Km) is distance. 
            // </summary>
            // <param name="lang">Language: English = "en" ;  French = "fr"</param>
            // <param name="lat">Latitude of current location </param>
            // <param name="lon">Longitude of current location </param>
            // <param name="radius">radius: How many Kilometre from current location</param>
            // <param name="token">Access token</param>
            // <returns>Return a resource list, current location is center, wish distance is the radius, fromat in XML </returns>
            [ActionName("xml")]
            [Route("api/v2/resource/circular/xml/{token}/{lang}/{lat}/{lon}/{radius}")]
            [Route("api/v2/Ressource/circulaire/xml/{token}/{lang}/{lat}/{lon}/{radius}")]
            // RAM
            [HttpGet]
            public HttpResponseMessage GetResourcesInRadiusList_XML(string lang, decimal lat, decimal lon, decimal radius, string token)
            {
                HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
                response = createCircularResult(lang, lat, lon, radius, token);
                request = HttpContext.Current.Request;
    
                return response;
            }

            //Query String
            // <summary>
            // Query String style, get allowable resources which locate in a circular area. current location is center of the circle; radius (Km) is distance. 
            // </summary>
            // <param name="lang">Language: English = "en" ;  French = "fr"</param>
            // <param name="lat">Latitude of current location</param>
            // <param name="lon">Longitude of current location</param>
            // <param name="radius">radius: How many Kilometre from current location</param>
            // <param name="token">Access token</param>
            // <returns>Return a resource list, current location is center, wish distance is the radius, fromat in XML</returns>
            [ActionName("xml")]
            [Route("api/v2/resource/circular/xml")]
            [Route("api/v2/Ressource/circulaire/xml")]
            // RAM
            [HttpGet]
            public HttpResponseMessage GetResourcesInRadiusList_XML_QS(string lang, decimal lat, decimal lon, decimal radius, string token)
            {
                HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
                response = createCircularResult(lang, lat, lon, radius, token);
                request = HttpContext.Current.Request;
          
                return response;
            }
            #endregion XML
            private HttpResponseMessage createCircularResult(string lang, decimal lat, decimal lon, decimal radius, string token)
            {
                lang = lang.ToLower();
                if ((lang == "en") || (lang == "fr"))
                {
                    var xml = this.GetResourcesInRadiusList(lang, lat, lon, radius, token).ToList();

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

        #endregion Proc_Get_All_Resources_In_Radius


        #region Proc_Get_All_Resource_In_Radius_boundary_Box
            #region JSON
            //Friendly
            // <summary>
            // Get allowable resources which locate in a Boundary-Box area. current location is center of the boundary box; Radius (Km) is center to Northern, Southern, Eastern and Western boundary. 
            // </summary>
            // <param name="lang">Language: English = "en" ;  French = "fr"</param>
            // <param name="lat">Latitude of current location </param>
            // <param name="lon">Longitude of current location </param>
            // <param name="radius">radius: How many Kilometre from current location</param>
            // <param name="token">Access token</param>
            // <returns>Return a resource list in Boundary-Box area, current location is center. Radius (Km) is the distance to Northern, Southern, Eastern and Western, fromat in JSON </returns>
            [ActionName("json")]
            [Route("api/v2/resource/box/json/{token}/{lang}/{lat}/{lon}/{radius}")]
            [Route("api/v2/Ressource/boîte/json/{token}/{lang}/{lat}/{lon}/{radius}")]
            // RAM
            [HttpGet]
            public HttpResponseMessage GetResourcesInBoxList(string lang, decimal lat, decimal lon, decimal radius, string token)
            {
                var json = this.GetResourcesInRadiusBoundaryBoxList(lang, lat, lon, radius, token).ToList();
                response = toJson(json, lang);
                request = HttpContext.Current.Request;
     
                return response;
            }

            //Query String
            // <summary>
            // Query String style, get allowable resources which locate in a Boundary-Box area. current location is center of the boundary box; Radius (Km) is center to Northern, Southern, Eastern and Western boundary.  
            // </summary>
            // <param name="lang">Language: English = "en" ;  French = "fr"</param>
            // <param name="lat">Latitude of current location</param>
            // <param name="lon">Longitude of current location</param>
            // <param name="radius">radius: How many Kilometre from current location</param>
            // <param name="token">Access token</param>
            // <returns>Return a resource list in Boundary-Box area, current location is center. Radius (Km) is the distance to Northern, Southern, Eastern and Western, fromat in JSON </returns>
            [ActionName("json")]
            [Route("api/v2/resource/box/json")]
            [Route("api/v2/Ressource/boîte/json")]
            // RAM
            [HttpGet]
            public HttpResponseMessage GetResourcesInBoxList_QS(string lang, decimal lat, decimal lon, decimal radius, string token)
            {
                HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
                var json = this.GetResourcesInRadiusBoundaryBoxList(lang, lat, lon, radius, token).ToList();
                response = toJson(json, lang);
                request = HttpContext.Current.Request;
 
                return response;
            }
            #endregion JSON

            #region XML
            //Friendly
            // <summary>
            // Get allowable resources which locate in a Boundary-Box area. current location is center of the boundary box; Radius (Km) is center to Northern, Southern, Eastern and Western boundary.  
            // </summary>
            // <param name="lang">Language: English = "en" ;  French = "fr"</param>
            // <param name="lat">Latitude of current location </param>
            // <param name="lon">Longitude of current location </param>
            // <param name="radius">radius: How many Kilometre from current location</param>
            // <param name="token">Access token</param>
            // <returns>Return a resource list in Boundary-Box area, current location is center. Radius (Km) is the distance to Northern, Southern, Eastern and Western, ,fromat in XML </returns>
            [ActionName("xml")]
            [Route("api/v2/resource/box/xml/{token}/{lang}/{lat}/{lon}/{radius}")]
            [Route("api/v2/Ressource/boîte/xml/{token}/{lang}/{lat}/{lon}/{radius}")]
            // RAM
            [HttpGet]
            public HttpResponseMessage GetResourcesInBoxList_XML(string lang, decimal lat, decimal lon, decimal radius, string token)
            {
                HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
                response = createBoxResult(lang, lat, lon, radius, token);
                request = HttpContext.Current.Request;
 
                return response;
            }

            //Query String
            // <summary>
            // Query String style, get allowable resources which locate in a Boundary-Box area. current location is center of the boundary box; Radius (Km) is center to Northern, Southern, Eastern and Western boundary.   
            // </summary>
            // <param name="lang">Language: English = "en" ;  French = "fr"</param>
            // <param name="lat">Latitude of current location</param>
            // <param name="lon">Longitude of current location</param>
            // <param name="radius">radius: How many Kilometre from current location</param>
            // <param name="token">Access token</param>
            // <returns>Return a resource list in Boundary-Box area, current location is center. Radius (Km) is the distance to Northern, Southern, Eastern and Western, fromat in XML</returns>
            [ActionName("xml")]
            [Route("api/v2/resource/box/xml")]
            [Route("api/v2/Ressource/boîte/xml")]
            // RAM
            [HttpGet]
            public HttpResponseMessage GetResourcesInBoxList_XML_QS(string lang, decimal lat, decimal lon, decimal radius, string token)
            {
                HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
                response = createBoxResult(lang, lat, lon, radius, token);
                request = HttpContext.Current.Request;
 
                return response;
            }
            #endregion XML
            private HttpResponseMessage createBoxResult(string lang, decimal lat, decimal lon, decimal radius, string token)
            {
                HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
                lang = lang.ToLower();
                if ((lang == "en") || (lang == "fr"))
                {
                    var xml = this.GetResourcesInRadiusBoundaryBoxList(lang, lat, lon, radius, token).ToList();

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
        #endregion Proc_Get_All_Resource_In_Radius_boundary_Box


        #region Search Resource by Coverage
        #region JSON
        // Path
        // <summary>
        //  Get allowable resources by its coverage   
        // </summary>
        // <param name="lang">language. English = "en"; French = "fr"</param>
        // <param name="coverage">coverage</param>
        // <param name="token">Access token</param>
        // <returns>return a JSON format resource list</returns>
        [ActionName("json")]
        [Route("api/v2/resource/coverage/json/{token}/{lang}/{coverage}")]
        [Route("api/v2/Ressource/couverture/json/{token}/{lang}/{coverage}")]
        // RAM
        [HttpGet]
        public HttpResponseMessage GetAllResourcesByCoverage(string lang, string coverage, string token)
        {
            HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
            var json = this.GetResourceByCoverage(coverage, lang, token).ToList();
            response = toJson(json, lang);
            request = HttpContext.Current.Request;
 

            return response;
        }

        //2020-12-01 added
        // Path
        // <summary>
        //  Get allowable subset of resources by its coverage   
        // </summary>
        // <param name="lang">language. English = "en"; French = "fr"</param>
        // <param name="coverage">coverage</param>
        // <param name="token">Access token</param>
        // <returns>return a JSON format subset of resource list</returns>
        [ActionName("json")]
        [Route("api/v3/resource/coverage/json/{token}/{lang}/{coverage}")]
        [Route("api/v3/Ressource/couverture/json/{token}/{lang}/{coverage}")]
        // sub
        [HttpGet]
        public HttpResponseMessage GetAll_SubSet_ResourcesByCoverage(string lang, string coverage, string token)
        {
            HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
            var json = this.Get_subResource_ByCoverage(coverage, lang, token).ToList();
            response = toJson(json, lang);
            request = HttpContext.Current.Request;
 

            return response;
        }



        // Query String
        // <summary>
        //  Query String style get resources by its coverage   
        // </summary>
        // <param name="lang">language. English = "en"; French = "fr"</param>
        // <param name="coverage">coverage</param>
        // <param name="token">Access token</param>
        // <returns>return a json format resource list</returns>
        [ActionName("json")]
        [Route("api/v2/resource/coverage/json")]
        [Route("api/v2/Ressource/couverture/json")]
        // RAM
        [HttpGet]
        public HttpResponseMessage GetAllResourcesByCoverage_QS(string lang, string coverage, string token)
        {
            HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
            var json = this.GetResourceByCoverage(coverage, lang, token).ToList();
            response = toJson(json, lang);
            request = HttpContext.Current.Request;
 

            return response;
        }

        //2020-12-01 add
        // <summary>
        //  Query String get Subset of resources by its coverage   
        // </summary>
        // <param name="lang">language. English = "en"; French = "fr"</param>
        // <param name="coverage">coverage</param>
        // <param name="token">Access token</param>
        // <returns>return a json format subset of resource list</returns>
        [ActionName("json")]
        [Route("api/v3/resource/coverage/json")]
        [Route("api/v3/Ressource/couverture/json")]
        // sub
        [HttpGet]
        public HttpResponseMessage GetAll_Subset_ResourcesByCoverage_QS(string lang, string coverage, string token)
        {
            HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
            var json = this.Get_subResource_ByCoverage(coverage, lang, token).ToList();
            response = toJson(json, lang);
            request = HttpContext.Current.Request;
 

            return response;
        }
        #endregion JSON

        #region XML
        // Friendly
        // <summary>
        //  Get resources by its coverage 
        // </summary>
        // <param name="lang">language. English = "en"; French = "fr"</param>
        // <param name="coverage">coverage</param>
        // <param name="token">Access token</param>
        // <returns>return a XML format resource list</returns>
        [ActionName("xml")]
        [Route("api/v2/resource/coverage/xml/{token}/{lang}/{coverage}")]
        [Route("api/v2/Ressource/couverture/xml/{token}/{lang}/{coverage}")]
        // RAM
        [HttpGet]
        public HttpResponseMessage GetAllResourcesByCoverage_XML(string lang, string coverage, string token)
        {
            HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
            response = createResourcesByCoverageResult(coverage, lang, token);
            request = HttpContext.Current.Request;
 
            return response;
        }
        // Query String
        // <summary>
        //  Query String style get resources in single province filter by resource's language 
        // </summary>
        // <param name="lang">language. English = "en"; French = "fr"</param>
        // <param name="coverage">Coverage</param>
        // <param name="token">Access token</param>
        // <returns>return a XML format resource list located in a specific province</returns>
        [ActionName("xml")]
        [Route("api/v2/resource/coverage/xml")]
        [Route("api/v2/Ressource/couverture/xml")]
        // RAM
        [HttpGet]
        public HttpResponseMessage GetAllResourcesByCoverage_XML_QS(string lang, string coverage, string token)
        {
            HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
            response = createResourcesByCoverageResult(coverage, lang, token);
            request = HttpContext.Current.Request;
 
            return response;
        }
        private HttpResponseMessage createResourcesByCoverageResult(string coverage, string lang, string token)
        {
            lang = lang.ToLower();
            if ((lang == "en") || (lang == "fr"))
            {
                var xml = this.GetResourceByCoverage(coverage, lang, token).ToList();

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

        #endregion Search Resource by Coverage


        //2020-11-08 add
        #region Proc_Get_All_SubResources_by_keywords_In_Radius
        #region JSON
        //path
        // <summary>
        // Get allowable subset of resources list by searching key words in a circular area. current location is center of the circle; radius (Km) is distance. 
        // </summary>
        // <param name="lang">Language: English = "en" ;  French = "fr"</param>
        // <param name="lat">Latitude of current location </param>
        // <param name="lon">Longitude of current location </param>
        // <param name="radius">radius: How many Kilometre from current location</param>
        // <param name="token">Access token</param>
        // <param name="kws">search key words</param>
        // <returns>Return a Subset of resource list, current location is center, radius is the distance, fromat in JSON.</returns>
        [ActionName("json")]
        [Route("api/v3/resource/circular/json/{kws}/{token}/{lang}/{lat}/{lon}/{radius}")]
        [Route("api/v3/Ressource/circulaire/json/{kws}/{token}/{lang}/{lat}/{lon}/{radius}")]
        // sub
        [HttpGet]
        public HttpResponseMessage GetSubResourcesByKwsInRadiusList(string lang, decimal lat, decimal lon, decimal radius, string token, string kws)
        {
            HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
            var json = this.GetResourcesInRadiusbyKwsList(kws, lang, lat, lon, radius, token).ToList();
            response = toJson(json, lang);
            request = HttpContext.Current.Request;
 
            return response;
        }

        //Query String
        // <summary>
        // Query String style, get allowable subset of resource list by searching keywords in a circular area. current location is center of the circle; radius (Km) is distance. 
        // </summary>
        // <param name="lang">Language: English = "en" ;  French = "fr"</param>
        // <param name="lat">Latitude of current location</param>
        // <param name="lon">Longitude of current location</param>
        // <param name="radius">radius: How many Kilometre from current location</param>
        // <param name="token">Access token</param>
        // <param name="kws">search key words</param>
        // <returns>Return a Subset of resource list, current location is center, radius is the distance, fromat in JSON.</returns>
        [ActionName("json")]
        [Route("api/v3/resource/circular/json")]
        [Route("api/v3/Ressource/circulaire/json")]
        // sub
        [HttpGet]
        public HttpResponseMessage GetSubResourcesInRadiusList_QS(string lang, decimal lat, decimal lon, decimal radius, string token, string kws)
        {
            HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
            var json = this.GetResourcesInRadiusbyKwsList(kws,lang, lat, lon, radius, token).ToList();
            response = toJson(json, lang);
            request = HttpContext.Current.Request;
 
            return response;
        }
        #endregion JSON

        #region XML
        //PATH
        // <summary>
        // Get allowable resources by key words in a circular area. current location is center of the circle; radius (Km) is distance. 
        // </summary>
        // <param name="lang">Language: English = "en" ;  French = "fr"</param>
        // <param name="lat">Latitude of current location </param>
        // <param name="lon">Longitude of current location </param>
        // <param name="radius">radius: How many Kilometre from current location</param>
        // <param name="token">Access token</param>
        // <param name="kws">search key words</param>
        // <returns>Return a subset of resource list, current location is center, wish distance is the radius, fromat in XML </returns>
        [ActionName("xml")]
        [Route("api/v3/resource/circular/xml/{token}/{lang}/{lat}/{lon}/{radius}/{kws}")]
        [Route("api/v3/Ressource/circulaire/xml/{token}/{lang}/{lat}/{lon}/{radius}/{kws}")]
        // sub
        [HttpGet]
        public HttpResponseMessage GetSubResourcesbyKwsInRadiusList_XML(string lang, decimal lat, decimal lon, decimal radius, string token, string kws)
        {
            HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
            response = createKwsCircularResult(lang, lat, lon, radius, token, kws);
            request = HttpContext.Current.Request; 
            return response;
        }

        //Query String
        // <summary>
        // Query String style, get allowable resources which locate in a circular area. current location is center of the circle; radius (Km) is distance. 
        // </summary>
        // <param name="lang">Language: English = "en" ;  French = "fr"</param>
        // <param name="lat">Latitude of current location</param>
        // <param name="lon">Longitude of current location</param>
        // <param name="radius">radius: How many Kilometre from current location</param>
        // <param name="token">Access token</param>
        // <returns>Return a subset of resource list, current location is center, wish distance is the radius, fromat in XML.</returns>
        [ActionName("xml")]
        [Route("api/v3/resource/circular/xml")]
        [Route("api/v3/Ressource/circulaire/xml")]
        // sub
        [HttpGet]
        public HttpResponseMessage GetResourcesInRadiusList_XML_QS(string lang, decimal lat, decimal lon, decimal radius, string token, string kws)
        {
            HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
            response = createKwsCircularResult(lang, lat, lon, radius, token, kws);
            request = HttpContext.Current.Request;
 
            return response;
        }
        #endregion XML
        private HttpResponseMessage createKwsCircularResult(string lang, decimal lat, decimal lon, decimal radius, string token, string kws)
        {
            lang = lang.ToLower();
            if ((lang == "en") || (lang == "fr"))
            {
                var xml = this.GetResourcesInRadiusbyKwsList(kws, lang, lat, lon, radius, token).ToList();

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

        #endregion Proc_Get_All_SubResources_by_keywords_In_Radius


        //2021-01-06
        #region Get subset of resources by phone number 
        // Path
        // <summary>
        //  Get allowable subset of resources by phone number   
        // </summary>
        // <param name="lang">language. English = "en"; French = "fr"</param>
        // <param name="phone">phone number</param>
        // <param name="token">Access token</param>
        // <returns>return a JSON format subset of resource list</returns>
        [ActionName("json")]
        [Route("api/v3/resource/phone/json/{token}/{lang}/{phone}")]
        [Route("api/v3/Ressource/telephone/json/{token}/{lang}/{phone}")]
        // sub
        [HttpGet]
        public HttpResponseMessage GetAll_SubSet_ResourcesByPhone(string lang, string phone, string token)
        {
            HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
            var json = this.Get_subResource_ByPhone(phone, lang, token).ToList();
            response = toJson(json, lang);
            request = HttpContext.Current.Request;
 

            return response;
        }
        // Query
        // <summary>
        //  Query String get Subset of resources by its phone number   
        // </summary>
        // <param name="lang">language. English = "en"; French = "fr"</param>
        // <param name="phone">phone number</param>
        // <param name="token">Access token</param>
        // <returns>return a json format subset of resource list</returns>
        [ActionName("json")]
        [Route("api/v3/resource/phone/json")]
        [Route("api/v3/Ressource/telephone/json")]
        // sub
        [HttpGet]
        public HttpResponseMessage GetAll_Subset_ResourcesByPhone_QS(string lang, string phone, string token)
        {
            HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
            var json = this.Get_subResource_ByPhone(phone, lang, token).ToList();
            response = toJson(json, lang);
            request = HttpContext.Current.Request;
 

            return response;
        }
        #endregion  Get subset of resources by phone number 


        //2021-06-13
        #region Get subset of resources by Helpline 
        // Path
        // <summary>
        //  Get Subset of all Helpline resources by language    
        // </summary>
        // <param name="lang">language. English = "en"; French = "fr"; English and French = "all" </param>
        // <param name="token">Access token</param>
        // <returns>return a subset of Helpline resource list format in json</returns>
        [ActionName("json")]
        [Route("api/v3/resource/helpline/json/{token}/{lang}")]
        [Route("api/v3/Ressource/dassistance/json/{token}/{lang}")]
        // sub
        [HttpGet]
        public HttpResponseMessage GetAll_SubSet_ResourcesByHelpline(string lang,  string token)
        {
            HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
            var json = this.Get_subResource_Helpline( lang, token).ToList();
            response = toJson(json, lang);
            request = HttpContext.Current.Request;
 

            return response;
        }
        // Query
        // <summary>
        //  Query String get Subset of all Helpline resources by language   
        // </summary>
        // <param name="lang">language. English = "en"; French = "fr"; English and French = "all" </param>
        // <param name="token">Access token</param>
        // <returns>return a subset of  helpline resource list format in json</returns>
        [ActionName("json")]
        [Route("api/v3/resource/helpline/json")]
        [Route("api/v3/Ressource/dassistance/json")]
        // sub
        [HttpGet]
        public HttpResponseMessage GetAll_SubSet_ResourcesByHelpline_QS(string lang, string token)
        {
            HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
            var json = this.Get_subResource_Helpline(  lang, token).ToList();
            response = toJson(json, lang);
            request = HttpContext.Current.Request;
 

            return response;
        }
        #endregion  Get subset of resources by phone number 







 
    }
}
