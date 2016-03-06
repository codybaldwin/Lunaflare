using JamSesh69.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace JamSesh69.Controllers
{
    [RoutePrefix("api/Playlist")]
    public class PlaylistController : ApiController
    {
        [Route("AddSong")]
        // GET api/PlayListController
        [HttpPost]
        public bool AddSong([FromBody] Song song)
        {

            return false;
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
    }
}