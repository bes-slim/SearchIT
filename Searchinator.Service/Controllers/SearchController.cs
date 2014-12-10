using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Searchinator.Service.Core;
using Searchinator.Service.Core.Contracts;
using Searchinator.Service.Models;

namespace Searchinator.Service.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class SearchController : ApiController
    {
        private readonly ISearch _search;

        public SearchController(ISearch search)
        {
            _search = search;
        }

        public object Post([FromBody]SearchQuery query)
        {

            return new { result = _search.SearchFor(query)};
        }
        [HttpGet]
        public decimal Fake()
        {
            return 123m;
        }
    }
}
