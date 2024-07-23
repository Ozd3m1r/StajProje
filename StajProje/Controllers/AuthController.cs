#region aaaaaaaa
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Configuration;
//using StajProje.Models;
//using StajProje.Models.User;
//using System;
//using System.Data;
//using System.Data.SqlClient;
//using System.Threading.Tasks;

//namespace StajProje.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class AuthController : ControllerBase
//    {
//        private readonly IConfiguration _configuration;

//        public AuthController(IConfiguration configuration)
//        {
//            _configuration = configuration;
//        }

//        [HttpPost]
//        [Route("register")]
//        public async Task<IActionResult> Register([FromBody] RegisterModel model)
//        {
//            if (model == null || string.IsNullOrEmpty(model.KULLANICI_ADI) || string.IsNullOrEmpty(model.SIFRE))
//            {
//                return BadRequest("Invalid user data.");
//            }

//            string connectionString = _configuration.GetConnectionString("StajProje");

//            try
//            {
//                using (SqlConnection con = new SqlConnection(connectionString))
//                {
//                    using (SqlCommand cmd = new SqlCommand("INSERT INTO Users (KULLANICI_ADI, SIFRE, ADI, SOYADI) VALUES (@KULLANICI_ADI, @SIFRE, @ADI, @SOYADI)", con))
//                    {
//                        cmd.Parameters.AddWithValue("@KULLANICI_ADI", model.KULLANICI_ADI);
//                        cmd.Parameters.AddWithValue("@SIFRE", model.SIFRE);
//                        cmd.Parameters.AddWithValue("@ADI", model.ADI);
//                        cmd.Parameters.AddWithValue("@SOYADI", model.SOYADI);

//                        con.Open();
//                        await cmd.ExecuteNonQueryAsync();
//                        con.Close();
//                    }
//                }

//                return Ok("User registered successfully.");
//            }
//            catch (SqlException ex)
//            {
//                return StatusCode(StatusCodes.Status500InternalServerError, $"SQL Error: {ex.Message}");
//            }
//            catch (Exception ex)
//            {
//                return StatusCode(StatusCodes.Status500InternalServerError, $"Unexpected Error: {ex.Message}");
//            }
//        }
//    }
//}
#endregion
#region çalışan b 

//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Configuration;
//using Microsoft.IdentityModel.Tokens;
//using StajProje.Models;
//using StajProje.Models.User;
//using System;
//using System.Data.SqlClient;
//using System.IdentityModel.Tokens.Jwt;
//using System.Security.Claims;
//using System.Text;
//using System.Threading.Tasks;

//namespace StajProje.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class AuthController : ControllerBase
//    {
//        private readonly IConfiguration _configuration;

//        public AuthController(IConfiguration configuration)
//        {
//            _configuration = configuration;
//        }

//        [HttpPost]
//        [Route("register")]
//        public async Task<IActionResult> Register([FromBody] RegisterModel model)
//        {
//            if (model == null || string.IsNullOrEmpty(model.KULLANICI_ADI) || string.IsNullOrEmpty(model.SIFRE))
//            {
//                return BadRequest("Invalid user data.");
//            }

//            string connectionString = _configuration.GetConnectionString("StajProje");

//            try
//            {
//                using (SqlConnection con = new SqlConnection(connectionString))
//                {
//                    using (SqlCommand cmd = new SqlCommand("INSERT INTO Users (KULLANICI_ADI, SIFRE, ADI, SOYADI) VALUES (@KULLANICI_ADI, @SIFRE, @ADI, @SOYADI)", con))
//                    {
//                        cmd.Parameters.AddWithValue("@KULLANICI_ADI", model.KULLANICI_ADI);
//                        cmd.Parameters.AddWithValue("@SIFRE", model.SIFRE);
//                        cmd.Parameters.AddWithValue("@ADI", model.ADI);
//                        cmd.Parameters.AddWithValue("@SOYADI", model.SOYADI);

//                        con.Open();
//                        await cmd.ExecuteNonQueryAsync();
//                        con.Close();
//                    }
//                }

//                // JWT Token oluşturma
//                var token = GenerateJwtToken(model.KULLANICI_ADI);

//                return Ok(new
//                {
//                    Message = "User registered successfully.",
//                    Token = token
//                });
//            }
//            catch (SqlException ex)
//            {
//                return StatusCode(StatusCodes.Status500InternalServerError, $"SQL Error: {ex.Message}");
//            }
//            catch (Exception ex)
//            {
//                return StatusCode(StatusCodes.Status500InternalServerError, $"Unexpected Error: {ex.Message}");
//            }
//        }

//        private string GenerateJwtToken(string username)
//        {
//            var tokenHandler = new JwtSecurityTokenHandler();
//            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
//            var tokenDescriptor = new SecurityTokenDescriptor
//            {
//                Subject = new ClaimsIdentity(new Claim[]
//                {
//                    new Claim(ClaimTypes.Name, username)
//                }),
//                Expires = DateTime.UtcNow.AddHours(1),
//                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
//            };


//            var token = tokenHandler.CreateToken(tokenDescriptor);
//            return tokenHandler.WriteToken(token);
//        }
//    }
//}

#endregion
#region ccccccccccccccccc

//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Configuration;
//using StajProje.Models;
//using System.Data.SqlClient;
//using System.Threading.Tasks;

//namespace StajProje.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class AuthController : ControllerBase
//    {
//        private readonly IConfiguration _configuration;

//        public AuthController(IConfiguration configuration)
//        {
//            _configuration = configuration;
//        }

//        [HttpPost]
//        [Route("register")]
//        public async Task<IActionResult> Register([FromBody] RegisterModel model)
//        {
//            if (model == null || string.IsNullOrEmpty(model.KULLANICI_ADI) || string.IsNullOrEmpty(model.SIFRE))
//            {
//                return BadRequest("Invalid user data.");
//            }

//            string connectionString = _configuration.GetConnectionString("StajProje");

//            try
//            {
//                using (SqlConnection con = new SqlConnection(connectionString))
//                {
//                    using (SqlCommand cmd = new SqlCommand("INSERT INTO Users (KULLANICI_ADI, SIFRE, ADI, SOYADI) VALUES (@KULLANICI_ADI, @SIFRE, @ADI, @SOYADI)", con))
//                    {
//                        cmd.Parameters.AddWithValue("@KULLANICI_ADI", model.KULLANICI_ADI);
//                        cmd.Parameters.AddWithValue("@SIFRE", model.SIFRE);
//                        cmd.Parameters.AddWithValue("@ADI", model.ADI);
//                        cmd.Parameters.AddWithValue("@SOYADI", model.SOYADI);

//                        con.Open();
//                        await cmd.ExecuteNonQueryAsync();
//                        con.Close();
//                    }
//                }

//                var token = GenerateTokenForUser(model.KULLANICI_ADI);
//                return Ok(new { Message = "User registered successfully.", Token = token });
//            }
//            catch (SqlException ex)
//            {
//                return StatusCode(StatusCodes.Status500InternalServerError, $"SQL Error: {ex.Message}");
//            }
//            catch (Exception ex)
//            {
//                return StatusCode(StatusCodes.Status500InternalServerError, $"Unexpected Error: {ex.Message}");
//            }
//        }

//        private string GenerateTokenForUser(string userName)
//        {
//            // Token oluşturma kodunu buraya ekleyin
//            return "example-jwt-token-for-" + userName;
//        }
//    }
//}

#endregion

#region ddddddddddddddddddd
//using Microsoft.AspNetCore.Mvc;
//using Newtonsoft.Json;
//using StajProje.Models;
//using stajProjeLogin;
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

#region eeeeeeeeeeeeee
//login modeli silmeyi unutma en son
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using StajProje.Models;
using System;
using System.Data.SqlClient;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using StajProje.Models.User;

namespace StajProje.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            if (model == null || string.IsNullOrEmpty(model.KULLANICI_ADI) || string.IsNullOrEmpty(model.SIFRE))
            {
                return BadRequest("Invalid user data.");
            }

            string connectionString = _configuration.GetConnectionString("StajProje");

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO Users (KULLANICI_ADI, SIFRE, ADI, SOYADI) VALUES (@KULLANICI_ADI, @SIFRE, @ADI, @SOYADI)", con))
                    {
                        cmd.Parameters.AddWithValue("@KULLANICI_ADI", model.KULLANICI_ADI);
                        cmd.Parameters.AddWithValue("@SIFRE", model.SIFRE);
                        cmd.Parameters.AddWithValue("@ADI", model.ADI);
                        cmd.Parameters.AddWithValue("@SOYADI", model.SOYADI);

                        con.Open();
                        await cmd.ExecuteNonQueryAsync();
                        con.Close();
                    }
                }

                // JWT Token oluşturma
                var token = GenerateJwtToken(model.KULLANICI_ADI);

                return Ok(new
                {
                    Message = "User registered successfully.",
                    Token = token
                });
            }
            catch (SqlException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"SQL Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Unexpected Error: {ex.Message}");
            }
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            if (model == null || string.IsNullOrEmpty(model.KULLANICI_ADI) || string.IsNullOrEmpty(model.SIFRE))
            {
                return BadRequest("Invalid login attempt.");
            }

            string connectionString = _configuration.GetConnectionString("StajProje");

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM Users WHERE KULLANICI_ADI = @KULLANICI_ADI AND SIFRE = @SIFRE", con))
                    {
                        cmd.Parameters.AddWithValue("@KULLANICI_ADI", model.KULLANICI_ADI);
                        cmd.Parameters.AddWithValue("@SIFRE", model.SIFRE);

                        con.Open();
                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                // JWT Token oluşturma
                                var token = GenerateJwtToken(model.KULLANICI_ADI);
                                return Ok(new
                                {
                                    Message = "Login successful.",
                                    Token = token
                                });
                            }
                            else
                            {
                                return Unauthorized("Invalid username or password.");
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"SQL Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Unexpected Error: {ex.Message}");
            }
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
