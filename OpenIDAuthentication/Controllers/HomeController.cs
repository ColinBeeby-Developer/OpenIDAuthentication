using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Newtonsoft.Json;
using OpenIDAuthentication.Models;
using System.Diagnostics;

namespace OpenIDAuthentication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpClientFactory _httpClientFactory;

        public HomeController(ILogger<HomeController> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            return View();
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

        [Authorize]
        public async Task<IActionResult> Bookmarks()
        {
          var accessToken = await HttpContext
                   .GetTokenAsync(OpenIdConnectParameterNames.AccessToken);

            var openApiClient = _httpClientFactory.CreateClient("LearningHubOpenApiClient");
            var request = new HttpRequestMessage(HttpMethod.Get, "/Bookmark/GetAllByParent");

            var response = await openApiClient.SendAsync(request,
              HttpCompletionOption.ResponseHeadersRead)
                .ConfigureAwait(false);

            response.EnsureSuccessStatusCode();

            string responseContent = await response.Content.ReadAsStringAsync();

            List<BookmarkModel> bookmarks = JsonConvert.DeserializeObject<List<BookmarkModel>>(responseContent);

            ViewData["bookmarks"] = bookmarks;

            return View();
        }

        [Authorize]
        public async Task Logout()
        {
          await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
          await HttpContext.SignOutAsync(OpenIdConnectDefaults.AuthenticationScheme);
        }
    }
}