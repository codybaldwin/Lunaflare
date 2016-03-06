using JamSesh.Server.Services;
using JamSesh69.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace JamSesh.Controllers
{
    [RoutePrefix("api/Track")]
    public class TrackController : ApiController
    {
        TrackService TrackService = new TrackService();

        
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }

        // SEARCH api/TrackController/Search
        [Route("Search")]
        [HttpGet]
        public IEnumerable<Song> Search([FromUri]string queryString)
        {
            var result = TrackService.GetSearchList(queryString);
            return result;
        }
    }
}