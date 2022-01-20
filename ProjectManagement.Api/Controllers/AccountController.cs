using Ehealthcare.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EHealthcare.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        private IBaseRepository<Account> AccountRepo { get; set; }
        public AccountController(IBaseRepository<Account> repository)
        {
            AccountRepo = repository;
        }

        [HttpGet("accountInfo/{email}")]
        public Account getAccountDetails(String email)
        {
            return AccountRepo.Get().Where(a => a.Email == email).FirstOrDefault();
        }

        [HttpPut("addFunds")]
        public String AddFunds([FromBody] Account account)
        {
            var result = AccountRepo.Get().Where(a => a.Email == account.Email).First();
            account.Amount = result.Amount + account.Amount;
            var updated = AccountRepo.Update(account).Result;
            return "Account updated";
        }
    }
}
