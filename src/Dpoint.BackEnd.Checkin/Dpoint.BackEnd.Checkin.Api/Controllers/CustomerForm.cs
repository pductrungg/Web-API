using Dpoint.BackEnd.Checkin.Services.Interfaces;
using Dpoint.BackEnd.Checkin.Services.Models.Requests;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

// using Microsoft.AspNetCore.MvC;

namespace Dpoint.BackEnd.Checkin.Api.Controllers{
    [Route("api/customer-form")]
    [ApiController]
    public class customerForm : ControllerBase{
        private readonly FillinCF _fillinCF;

        public customerForm(FillinCF fillinCF){
            _fillinCF = fillinCF;
        }

        [HttpPost("fill-in-form")]

        public asyncn
    }
}
