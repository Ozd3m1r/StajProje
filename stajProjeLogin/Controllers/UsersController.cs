#region aaaaaaaaaa
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Http;
//using System.Collections.Generic;
//using System.Net.Http;
//using System.Net.Http.Headers;
//using System.Threading.Tasks;
//using Newtonsoft.Json;
//using stajProjeLogin.Models;
//using StajProje.Models.User; // Model referansı

//namespace StajProjeLogin.Controllers
//{
//    public class UsersController : Controller
//    {
//        private readonly IHttpClientFactory _clientFactory;

//        public UsersController(IHttpClientFactory clientFactory)
//        {
//            _clientFactory = clientFactory;
//        }

//        [HttpGet]
//        public async Task<IActionResult> Index()
//        {
//            var token = HttpContext.Session.GetString("JWToken");

//            if (string.IsNullOrEmpty(token))
//            {
//                return Unauthorized(); // Token yoksa yetkilendirme hatası döner
//            }

//            var client = _clientFactory.CreateClient("APIClient");
//            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

//            var response = await client.GetAsync("api/user/GetAllUser");

//            if (response.IsSuccessStatusCode)
//            {
//                var users = JsonConvert.DeserializeObject<List<stajProjeLogin.Models.Users>>(await response.Content.ReadAsStringAsync());
//                return View(users);
//            }

//            return StatusCode((int)response.StatusCode, "Error retrieving users");
//        }
//    }
//}
#endregion




#region bbbbbbbbbbbbbbbbb
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Configuration;
//using Newtonsoft.Json;
//using stajProjeLogin.Models;
//using stajProjeLogin.Models; // Model referansı
//using System.Collections.Generic;
//using System.Net.Http;
//using System.Net.Http.Headers;
//using System.Threading.Tasks;

//namespace StajProjeLogin.Controllers
//{
//    public class UsersController : Controller
//    {
//        private readonly IHttpClientFactory _clientFactory;
//        private readonly IConfiguration _configuration;

//        public UsersController(IHttpClientFactory clientFactory, IConfiguration configuration)
//        {
//            _clientFactory = clientFactory;
//            _configuration = configuration;
//        }

//        public async Task<IActionResult> Index()
//        {
//            var token = HttpContext.Session.GetString("JWToken");

//            if (string.IsNullOrEmpty(token))
//            {
//                return Unauthorized(); // Token yoksa yetkilendirme hatası döner
//            }

//            var client = _clientFactory.CreateClient("APIClient");
//            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

//            var response = await client.GetAsync("api/user/GetAllUser");

//            if (response.IsSuccessStatusCode)
//            {
//                var usersJson = await response.Content.ReadAsStringAsync();
//                var usersList = JsonConvert.DeserializeObject<List<Users>>(usersJson);

//                return View(usersList); // Listeyi View'a gönder
//            }

//            return StatusCode((int)response.StatusCode, "Error retrieving users");
//        }
//    }
//}
#endregion


using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using stajProjeLogin.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace StajProjeLogin.Controllers
{
    public class UsersController : Controller
    {
        private readonly IConfiguration _configuration;

        public UsersController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IActionResult> Index()
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            var usersList = new List<Users>();

            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand("SELECT * FROM [Users]", connection);
                connection.Open();

                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var user = new Users
                        {
                            ID = reader.GetInt32(reader.GetOrdinal("ID")),
                            ADI = reader.GetString(reader.GetOrdinal("ADI")),
                            SOYADI = reader.GetString(reader.GetOrdinal("SOYADI")),
                            KULLANICI_ADI = reader.GetString(reader.GetOrdinal("KULLANICI_ADI")),
                            SIFRE = reader.GetString(reader.GetOrdinal("SIFRE"))
                        };
                        usersList.Add(user);
                    }
                }
            }

            return View(usersList);
        }
    }
}

