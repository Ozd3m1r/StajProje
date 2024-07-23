#region aaaaaaaaaaaaaaaaaaaaaaa

//using System.Net.Http;
//using System.Net.Http.Headers;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Newtonsoft.Json; using System.Net.Http;
//using stajProjeLogin.Models;
//using Microsoft.AspNetCore.Authentication.JwtBearer;
//namespace stajProjeLogin.Controllers
//{
//    public class LoginController : Controller
//    {
//        private readonly IHttpClientFactory _clientFactory;

//        public LoginController(IHttpClientFactory clientFactory)
//        {
//            _clientFactory = clientFactory;
//        }

//        [HttpGet]
//        public IActionResult Index()
//        {
//            return View();
//        }

//        [HttpPost]
//        public async Task<IActionResult> Index(LoginModel model)
//        {
//            if (!ModelState.IsValid)
//                return View(model);

//            var client = _clientFactory.CreateClient("APIClient");
//            var content = new StringContent(JsonConvert.SerializeObject(model), System.Text.Encoding.UTF8, "application/json");

//            var response = await client.PostAsync("api/auth/login", content);

//            if (response.IsSuccessStatusCode)
//            {
//                var token = await response.Content.ReadAsStringAsync();
//                HttpContext.Session.SetString("JWToken", token);
//                return RedirectToAction("Index", "Home");
//            }

//            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
//            return View(model);
//        }
//    }
//}
#endregion
#region bbbbbbbbbbbbbbbbbb güzel b

//using System.Net.Http;
//using System.Net.Http.Headers;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Newtonsoft.Json;
//using stajProjeLogin.Models;

//namespace stajProjeLogin.Controllers
//{
//    public class LoginController : Controller
//    {
//        private readonly IHttpClientFactory _clientFactory;

//        public LoginController(IHttpClientFactory clientFactory)
//        {
//            _clientFactory = clientFactory;
//        }

//        [HttpGet]
//        public IActionResult Index()
//        {
//            return View();
//        }

//        [HttpPost]
//        public async Task<IActionResult> Index(LoginModel model)
//        {
//            if (!ModelState.IsValid)
//                return View(model);

//            var client = _clientFactory.CreateClient("APIClient");
//            var content = new StringContent(JsonConvert.SerializeObject(model), System.Text.Encoding.UTF8, "application/json");

//            var response = await client.PostAsync("api/auth/login", content);

//            if (response.IsSuccessStatusCode)
//            {
//                var token = await response.Content.ReadAsStringAsync();
//                HttpContext.Session.SetString("JWToken", token);
//                return RedirectToAction("Index", "Home");
//            }

//            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
//            return View(model);
//        }
//    }
//}
#endregion

#region dene bakalım

using System.Data.SqlClient;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using stajProjeLogin.Models;
using System.Threading.Tasks;

namespace stajProjeLogin.Controllers
{
    public class LoginController : Controller
    {
        private readonly IConfiguration _configuration;

        public LoginController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            bool isValidUser = false;
            string username = string.Empty;

            // Veritabanında kullanıcı adı ve şifreyi doğrulama
            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand("SELECT * FROM Users WHERE KULLANICI_ADI = @KULLANICI_ADI AND SIFRE = @SIFRE", connection);
                command.Parameters.AddWithValue("@KULLANICI_ADI", model.KULLANICI_ADI);
                command.Parameters.AddWithValue("@SIFRE", model.SIFRE);

                connection.Open();
                var result = await command.ExecuteScalarAsync();
                if (result != null)
                {
                    isValidUser = true;
                    //username = result.ToString();
                    username = model.KULLANICI_ADI;
                }
            }

            if (isValidUser)
            {
                // Kullanıcı geçerli ise JWT token oluştur
                var token = GenerateJwtToken(username);

                // Token'ı ViewBag'e ekleyip başarılı sayfayı göster
                ViewBag.Token = token;
                return View("LoginSuccess");
            }

            // Hatalı giriş durumunda model state'e hata ekleyin
            ModelState.AddModelError(string.Empty, "Geçersiz giriş denemesi.");
            return View(model);
        }

        private string GenerateJwtToken(string username)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, username)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}

#endregion
