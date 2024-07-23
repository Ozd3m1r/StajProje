#region aaaaaaaaaaaa
//using Microsoft.AspNetCore.Mvc;
//using Newtonsoft.Json;
//using stajProjeLogin.Models;
//using System.Net.Http;
//using System.Text;
//using System.Threading.Tasks;
//using stajProjeLogin.Models;

//namespace YourNamespace.Controllers
//{
//    public class RegisterController : Controller
//    {
//        private readonly IHttpClientFactory _clientFactory;

//        public RegisterController(IHttpClientFactory clientFactory)
//        {
//            _clientFactory = clientFactory;
//        }

//        [HttpGet]
//        public IActionResult Index()
//        {
//            return View();
//        }

//        [HttpPost]
//        public async Task<IActionResult> Index(RegisterModel model)
//        {
//            if (!ModelState.IsValid)
//                return View(model);

//            var client = _clientFactory.CreateClient("APIClient");
//            var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

//            var response = await client.PostAsync("api/auth/register", content);

//            if (response.IsSuccessStatusCode)
//            {

//                return RedirectToAction("Index", "Login");
//            }

//            ModelState.AddModelError(string.Empty, "Registration failed.");
//            return View(model);
//        }
//    }
//}
#endregion
#region bbbbbbbbbbbbbbbbb

//using Microsoft.AspNetCore.Mvc;
//using Newtonsoft.Json;
//using stajProjeLogin.Models;
//using System.Net.Http;
//using System.Text;
//using System.Threading.Tasks;

//namespace stajProjeLogin.Controllers
//{
//    public class RegisterController : Controller
//    {
//        private readonly IHttpClientFactory _clientFactory;

//        public RegisterController(IHttpClientFactory clientFactory)
//        {
//            _clientFactory = clientFactory;
//        }

//        [HttpGet]
//        public IActionResult Index()
//        {
//            return View();
//        }

//        [HttpPost]
//        public async Task<IActionResult> Index(RegisterModel model)
//        {
//            if (!ModelState.IsValid)
//                return View(model);

//            var client = _clientFactory.CreateClient("APIClient");
//            var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

//            var response = await client.PostAsync("api/auth/register", content);

//            if (response.IsSuccessStatusCode)
//            {
//                var responseBody = await response.Content.ReadAsStringAsync();
//                dynamic result = JsonConvert.DeserializeObject(responseBody);
//                ViewBag.Token = result?.Token;

//                return View("RegistrationSuccess"); // Başarı sayfasına yönlendirme
//            }

//            ModelState.AddModelError(string.Empty, "Registration failed.");
//            return View(model);
//        }
//    }
//}
#endregion
#region cccccccccccccccccc

//using Microsoft.AspNetCore.Mvc;
//using Newtonsoft.Json;
//using stajProjeLogin.Models;
//using System.Net.Http;
//using System.Text;
//using System.Threading.Tasks;
//using StajProje.Controllers;
//namespace YourNamespace.Controllers
//{
//    public class RegisterController : Controller
//    {

//        private readonly IHttpClientFactory _clientFactory;

//        public RegisterController(IHttpClientFactory clientFactory)
//        {
//            _clientFactory = clientFactory;
//        }

//        [HttpGet]
//        public IActionResult Index()
//        {
//            return View();
//        }

//        [HttpPost]
//        public async Task<IActionResult> Index(RegisterModel model)
//        {
//            if (!ModelState.IsValid)
//                return View(model);

//            var client = _clientFactory.CreateClient("APIClient");
//            var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

//            var response = await client.PostAsync("api/auth/register", content);

//            if (response.IsSuccessStatusCode)
//            {
//                var responseBody = await response.Content.ReadAsStringAsync();
//                var result = JsonConvert.DeserializeObject<dynamic>(responseBody);
//                var DenemeToken = result.Token;
//                ViewBag.Token = result?.Token;
//                return View("RegistrationSuccess"); // Başarı sayfasına yönlendirme
//            }

//            ModelState.AddModelError(string.Empty, "Registration failed.");
//            return View(model);
//        }
//    }
//}

#endregion
#region ddddddddddddddddd

//using Microsoft.AspNetCore.Mvc;
//using Newtonsoft.Json;
//using stajProjeLogin.Models;
//using System.Net.Http;
//using System.Text;
//using System.Threading.Tasks;
//using StajProje;
//using StajProje.Models;
//using stajProjeLogin.Models;
//namespace stajProjeLogin.Controllers
//{
//    public class RegisterController : Controller
//    {
//        private readonly IHttpClientFactory _clientFactory;

//        public RegisterController(IHttpClientFactory clientFactory)
//        {
//            _clientFactory = clientFactory;
//        }

//        [HttpGet]
//        public IActionResult Index()
//        {
//            return View();
//        }

//        [HttpPost]
//        public async Task<IActionResult> Index(stajProjeLogin.Models.RegisterModel model)
//        {
//            if (!ModelState.IsValid)
//                return View(model);

//            var client = _clientFactory.CreateClient("APIClient");
//            var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

//            var response = await client.PostAsync("api/auth/register", content);

//            if (response.IsSuccessStatusCode)
//            {
//                var responseBody = await response.Content.ReadAsStringAsync();
//                var tokenResponse = JsonConvert.DeserializeObject<TokenResponse>(responseBody);

//                if (tokenResponse != null && !string.IsNullOrEmpty(tokenResponse.Token))
//                {
//                    ViewBag.Token = tokenResponse.Token;
//                    return View("RegistrationSuccess");
//                }
//                else
//                {
//                    ModelState.AddModelError(string.Empty, "Invalid response format.");
//                }
//            }
//            else
//            {
//                ModelState.AddModelError(string.Empty, "Registration failed.");
//            }

//            return View(model);
//        }
//    }
//}
#endregion

#region eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee

//using Microsoft.AspNetCore.Mvc;
//using Newtonsoft.Json;
//using stajProjeLogin.Models;
//using System.Net.Http;
//using System.Text;
//using System.Threading.Tasks;

//namespace stajProjeLogin.Controllers
//{
//    public class RegisterController : Controller
//    {
//        private readonly IHttpClientFactory _clientFactory;

//        public RegisterController(IHttpClientFactory clientFactory)
//        {
//            _clientFactory = clientFactory;
//        }

//        [HttpGet]
//        public IActionResult Index()
//        {
//            return View();
//        }

//        [HttpPost]
//        public async Task<IActionResult> Index(RegisterModel model)
//        {
//            if (!ModelState.IsValid)
//                return View(model);

//            var client = _clientFactory.CreateClient("APIClient");
//            var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

//            var response = await client.PostAsync("api/auth/register", content);

//            if (response.IsSuccessStatusCode)
//            {
//                var responseBody = await response.Content.ReadAsStringAsync();
//                dynamic result = JsonConvert.DeserializeObject(responseBody);
//                ViewBag.Token = result?.Token;

//                // Token'ı view'da göstermek için
//                return View("RegistrationSuccess");
//            }

//            ModelState.AddModelError(string.Empty, "Registration failed.");
//            return View(model);
//        }
//    }
//}
#endregion

#region ffffffffffffffffffffffffff
//using Microsoft.AspNetCore.Mvc;
//using Newtonsoft.Json;
//using stajProjeLogin.Models;
//using System.Net.Http;
//using System.Text;
//using System.Threading.Tasks;

//namespace stajProjeLogin.Controllers
//{
//    public class RegisterController : Controller
//    {
//        private readonly IHttpClientFactory _clientFactory;

//        public RegisterController(IHttpClientFactory clientFactory)
//        {
//            _clientFactory = clientFactory;
//        }

//        [HttpGet]
//        public IActionResult Index()
//        {
//            return View();
//        }

//        [HttpPost]
//        public async Task<IActionResult> Index(RegisterModel model)
//        {
//            if (!ModelState.IsValid)
//                return View(model);

//            var client = _clientFactory.CreateClient("APIClient");
//            var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

//            var response = await client.PostAsync("api/auth/register", content);

//            if (response.IsSuccessStatusCode)
//            {
//                var responseBody = await response.Content.ReadAsStringAsync();
//                var result = JsonConvert.DeserializeObject<TokenResponse>(responseBody);
//                ViewBag.Token = result?.Token;

//                return View("RegistrationSuccess");
//            }

//            ModelState.AddModelError(string.Empty, "Registration failed.");
//            return View(model);
//        }
//    }
//}

//// TokenResponse.cs model dosyası
//public class TokenResponse
//{
//    public string Token { get; set; }
//}

#endregion



using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StajProje.Models;
using stajProjeLogin.Models;
using System.Data.SqlClient;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using RegisterModel = stajProjeLogin.Models.RegisterModel;

namespace stajProjeLogin.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IConfiguration _configuration;

        public RegisterController(IHttpClientFactory clientFactory, IConfiguration configuration)
        {
            _clientFactory = clientFactory;
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(RegisterModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var connectionString = _configuration.GetConnectionString("DefaultConnection");

            // Veritabanında kullanıcı adı kontrolü
            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand("SELECT COUNT(*) FROM Users WHERE KULLANICI_ADI = @KULLANICI_ADI", connection);
                command.Parameters.AddWithValue("@KULLANICI_ADI", model.KULLANICI_ADI);

                connection.Open();
                var userExists = (int)await command.ExecuteScalarAsync() > 0;

                if (userExists)
                {
                    ModelState.AddModelError(string.Empty, "Bu Kullanıcı Adı Var");
                    return View(model);
                }
            }

            // Kullanıcı adı mevcut değilse, API'ye kayıt isteği gönder
            var client = _clientFactory.CreateClient("APIClient");
            var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

            var response = await client.PostAsync("api/auth/register", content);

            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<TokenResponse>(responseBody);
                ViewBag.Token = result?.Token;

                return View("RegistrationSuccess");
            }

            ModelState.AddModelError(string.Empty, "Kayıt Başarısız");
            return View(model);
        }
    }
}




