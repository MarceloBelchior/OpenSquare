using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace OpenSquare.Controllers
{
   // [OpenSquare.Authorize]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly Core.Business.Interface.IUserBS _userbs;
        private readonly Core.Business.Interface.IProfile _profilebs;

        public UserController(Core.Business.Interface.IUserBS userbs, Core.Business.Interface.IProfile profilebs)
        {
            _userbs = userbs;
            _profilebs = profilebs;
        }
        // GET: api/values
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/values/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/values
        //[HttpPost]
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{

        //}
        [HttpGet]
        public IEnumerable<Core.Model.Entity.Profile> Get()
        {
            Expression<Func<Core.Model.Entity.Profile, bool>> expression = m => m.id > 0;
            return _profilebs.GetProfile(expression);
        }


    }
}
