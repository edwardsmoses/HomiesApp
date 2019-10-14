using Data.Models;
using Data.Services.UnitOfWork;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Routing;

namespace AppService.Controllers.Base
{
    public class BaseController : ApiController
    {
        protected BaseController(IHomiesDataSystem data)
        {
            this.Data = data;
        }

        protected BaseController(IHomiesDataSystem data, ApplicationUser userProfile)
            : this(data)
        {
        }

        public IHomiesDataSystem Data { get; }
       
    }
}
