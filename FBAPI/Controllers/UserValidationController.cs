using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FBAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserValidationController : ControllerBase
    {
        ILogger _logger;
        IDataStore _dataStore;

        public UserValidationController(ILogger<UserValidationController> logger, IDataStore dataStore)
        {
            _logger = logger;
            _dataStore = dataStore;
        }

        //Post
        [HttpGet]
        public string Get()
        {
            return "Hello World";
        }
        //Cache tax rates
        [HttpPost()]
        public async Task<IEnumerable<string>> GetUserRoles([FromBody] string token)
        {
            IEnumerable<AspNetRole> roles;

            try
            {
                roles = await _dataStore.GetUserRolesAsync(token) as IEnumerable<AspNetRole>;
            }
            catch (InvalidOperationException e)
            {
                throw new Exception("Not a valid token!!");
            }

            List<string> strings = new List<string>();

            if (roles is null || roles.Count() == 0)
            {
                strings.Add("This user has no roles");
                return strings;
            }

            foreach (var role in roles)
                strings.Add(role.Name);

            return strings;
        }
    }
}
