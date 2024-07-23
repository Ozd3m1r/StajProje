//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Configuration;
//using Newtonsoft.Json;
//using StajProje.Models.User;
//using System.Data;
//using System.Data.SqlClient;
//using System.Data.SqlTypes;
//using System.Text.Json.Serialization;
//namespace StajProje.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class UserController : ControllerBase
//    {
//        private readonly IConfiguration _configuration;

//        public  UserController(IConfiguration configuration)
//        {
//            _configuration = configuration;
//        }
//        [HttpGet]
//        [Route("GetAllUser")]
//        public string GetUser()
//        { 
//            SqlConnection con=new SqlConnection(_configuration.GetConnectionString("StajProje").ToString());
//            SqlDataAdapter da=new SqlDataAdapter("SELECT * From USER",con);
//            DataTable dt = new DataTable();
//            da.Fill(dt);
//            List<Users> usersList = new List<Users>();
//            if (dt.Rows.Count > 0)
//            {
//                for (int i = 0; i < dt.Rows.Count; i++)
//                {
//                    Users user = new Users();
//                    user.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
//                    user.ADI = Convert.ToString(dt.Rows[i]["ADI"]);
//                    user.SOYADI = Convert.ToString(dt.Rows[i]["SOYADI"]);
//                    user.KULLANICI_ADI = Convert.ToString(dt.Rows[i]["KULLANICI_ADI"]);
//                    user.SIFRE = Convert.ToString(dt.Rows[i]["SIFRE"]);
//                    usersList.Add(user);
//                }
//                if(usersList.Count>0)
//                {
//                   return JsonConvert.SerializeObject(usersList);    
//                }
//                else
//                {
//                    return JsonConvert.SerializeObject(usersList);
//                }
//            }
//            else
//            {
//                return JsonConvert.SerializeObject(usersList);
//            }
//        }



//    }
//}


using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using StajProje.Models.User;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace StajProje.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public UserController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        [Route("GetAllUser")]
        public IActionResult GetUser()
        {
            string connectionString = _configuration.GetConnectionString("StajProje");
            string query = "SELECT * FROM [Users]"; // Tablonuzun adını burada doğru şekilde kullanın

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(query, con))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        List<Users> usersList = new List<Users>();

                        foreach (DataRow row in dt.Rows)
                        {
                            Users user = new Users
                            {
                                ID = Convert.ToInt32(row["ID"]),
                                ADI = Convert.ToString(row["ADI"]),
                                SOYADI = Convert.ToString(row["SOYADI"]),
                                KULLANICI_ADI = Convert.ToString(row["KULLANICI_ADI"]),
                                SIFRE = Convert.ToString(row["SIFRE"])
                            };
                            usersList.Add(user);
                        }

                        return Ok(usersList); // JSON dönüşü sağlar
                    }
                }
            }
            catch (SqlException ex)
            {
                // Hata durumunda uygun bir HTTP yanıtı döner
                return StatusCode(StatusCodes.Status500InternalServerError, $"SQL Hatası: {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Beklenmedik Hata: {ex.Message}");
            }
        }
    }
}

