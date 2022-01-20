using EHealthcare.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Data;
using ProjectManagement.Shared;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ProjectManagement.Api.Controllers
{
    [Route("api/[controller]")]
    public class BaseController<T> : ControllerBase where T : BaseEntity
    {
        protected readonly IBaseRepository<T> Repository;
        private readonly IBaseRepository<User> UserRepository;
        private readonly IHttpContextAccessor HttpContextAccessor;

        public BaseController()
        {
            Repository = DependencyResolver.Current.GetService<IBaseRepository<T>>();
            UserRepository = DependencyResolver.Current.GetService<IBaseRepository<User>>();
            HttpContextAccessor = DependencyResolver.Current.GetService<IHttpContextAccessor>();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Repository.Get());
        }

        [HttpGet("{id}")]
        public virtual IActionResult Get(long? id)
        {
            if (!id.HasValue)
            {
                return NoContent();
            }
            T result = Repository.Get(id.Value);
            if (result is null)
            {
                return NoContent();
            }

            return Ok(result);
        }


        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Post(T entity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            T result = await Repository.Add(entity);
            return Ok(result);
        }

        [Authorize]
        [HttpPut]
        public async Task<IActionResult> Put(T entity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            T result = await Repository.Update(entity);
            return Ok(result);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async virtual Task<IActionResult> Delete(long id)
        {
            T existing = Repository.Get(id);
            if (existing is null)
            {
                return BadRequest();
            }

            await Repository.Delete(id);

            return Ok();
        }

        protected User SessionUser
        {
            get
            {
                var claim = HttpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
                if (claim != null)
                {
                    return UserRepository.Get(Convert.ToInt64(claim.Value));
                }
                return null;
            }
        }
    }
}
