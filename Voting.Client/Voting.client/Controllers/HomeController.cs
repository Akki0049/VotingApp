using Microsoft.AspNetCore.Mvc;

using Newtonsoft.Json;

using Voting.client.Models;

using Voting.Client.Models;

using System.Diagnostics;

namespace Voting.client.Controllers

{

    public class HomeController : Controller

    {

        private readonly HttpClient _httpClient;

        private readonly ILogger<HomeController> _logger;

        public HomeController(IHttpClientFactory httpClientFactory, ILogger<HomeController> logger)

        {

            _logger = logger ?? throw new ArgumentNullException(nameof(logger));

            _httpClient = httpClientFactory.CreateClient("VotingAPIClient");

        }

        public async Task<IActionResult> Index()

        {

            var response = await _httpClient.GetAsync("/product");

            var content = await response.Content.ReadAsStringAsync();

            var productList = JsonConvert.DeserializeObject<IEnumerable<Product>>(content);

            return View(productList);

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

