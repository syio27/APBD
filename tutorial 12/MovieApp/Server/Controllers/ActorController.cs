using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.Server.Controllers
{
    [Authorize]
    [Route("api/actors")]
    public class ActorController : ControllerBase
    {
        
    }
}
