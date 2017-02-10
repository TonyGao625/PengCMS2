using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Umbraco.Web.WebApi;
using Umbraco.Web.Editors;
using Umbraco.Core.Persistence;

namespace My.Controllers
{
    [Umbraco.Web.Mvc.PluginController("My")]
    public class PersonApiController : UmbracoAuthorizedJsonController
    {
        public IEnumerable<Person> GetAll()
        {
            //get the database
            var db = UmbracoContext.Application.DatabaseContext.Database;
            //build a query to select everything the people table
            var query = new Sql().Select("*").From("people");
            //fetch data from DB with the query and map to Person object
            return db.Fetch<Person>(query);
        }
    }
}