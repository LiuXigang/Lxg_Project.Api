using Microsoft.AspNetCore.Mvc;
using Project.API.Dto;

namespace Project.API.Controllers
{
    public class BaseController : ControllerBase
    {
        protected UserIdentity UserIdentity
        {
            get
            {
                var identity = new UserIdentity
                {
                    UserId = 1,
                    Name = "jesse",
                    Company = "company",
                    Avatar = "avatar",
                    Title = "title"
                };
                return identity;
            }
        }
    }
}
