using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TestDevWebApp.Models;
using TestDevWebApp.Services.LoginService;

namespace TestDevWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAccountService _accountService;
        public HomeController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
               var requestedUser =  _accountService.GetUser(new Models.User { Username = model.UserName, Password = model.Password });

                if(requestedUser != null)
                {
                    if (requestedUser.RoleDescription == "Admin")
                    {
                        List<string> users = new List<string>();
                        using (var httpClient = new HttpClient())
                        {
                            using (var response = await httpClient.GetAsync("http://localhost:8080/TestDevWebService/Services/GetUsers"))
                            {
                                var apiResponse = await response.Content.ReadAsStringAsync();
                                users = JsonConvert.DeserializeObject<List<string>>(apiResponse).ToList();
                            }
                        }
                        foreach (var item in users)
                        {
                            requestedUser.UserList.Add(new SelectListItem { Text = item, Value = item });
                        }

                        return View("UserPage", requestedUser);
                    }
                    else
                    {
                        return View("UserPage", requestedUser);
                    }
                }
            }
            return RedirectToAction("Login");
        }



        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //private async Task<List<string>> GetUserData(string username)
        private async Task<JsonResult> GetUserData(string username)
        {
            //tüm kullanıcı listesi
            List<string> users = new List<string>();
            using (var httpClient = new HttpClient())
            {
                using (var response =  await httpClient.GetAsync($"http://localhost:8080/TestDevWebService/Services/Users/{username}"))
                {
                    var apiResponse =  await response.Content.ReadAsStringAsync();
                    users = JsonConvert.DeserializeObject<List<string>>(apiResponse);
                }
            }
            return new JsonResult(users.ToList());
        }
        public async Task<JsonResult> GetData(string UserName)
        {
            UserDto user = new UserDto();
            MemoryStream stream = new MemoryStream();
            Request.Body.CopyTo(stream);
            stream.Position = 0;
            using (StreamReader reader = new StreamReader(stream))
            {
                string requestBody = reader.ReadToEnd();
                if (requestBody.Length > 0)
                {
                    user = JsonConvert.DeserializeObject<UserDto>(requestBody);
                }
            }

            UserDataDto userData = new UserDataDto();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"http://localhost:8080/TestDevWebService/Services/User/{user.Username}"))
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    try
                    {
                        userData = JsonConvert.DeserializeObject<UserDataDto>(apiResponse);
                    }
                    catch (System.Exception e)
                    {

                        throw;
                    }
                   
                }
            }
            return new JsonResult(userData);

            //return Json(user);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
