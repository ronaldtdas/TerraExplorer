using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;
using TerraExplorerProject.Models;
using Newtonsoft.Json;

namespace TerraExplorerProject.Controllers
{
    public class HomeController : Controller
    {
        const string baseURL = "https://images-api.nasa.gov/search?q=";
        public HomeController()
        {
        }
        public IActionResult Demo()
        {
            return View();
        }





        public IActionResult Index()
        {
            using (var httpClient = new HttpClient())
            {
                try
                {
                    var apiUrl = baseURL + "geology&media_type=image";
                    var response = httpClient.GetStringAsync(apiUrl).Result;
                    var nasaImageData = JsonConvert.DeserializeObject<NasaImageDataModel>(response);

                    return View(nasaImageData);
                }
                catch (Exception ex)
                {
                    // Log or handle the exception appropriately
                    Console.WriteLine(ex.Message);
                    throw; // Rethrow the exception to indicate an error
                }

                //NasaImageDataModel nasaImageData = new NasaImageDataModel();
                //return View(nasaImageData);
            }

        }

        [HttpPost]
        public IActionResult SearchResults(string param)
        {
            using (var httpClient = new HttpClient())
            {
                try
                {
                    var apiUrl = baseURL + param + "&media_type=image";
                    var response = httpClient.GetStringAsync(apiUrl).Result;
                    var nasaImageData = JsonConvert.DeserializeObject<NasaImageDataModel>(response);
                    int index = 0;
                    foreach (var item in nasaImageData.Collection.Items)
                    {
                        item.ItemId = index;
                        index++;
                    }
                    ViewBag.Param = param;
                    return View(nasaImageData);
                }
                catch (Exception ex)
                {
                    // Log or handle the exception appropriately
                    Console.WriteLine(ex.Message);
                    throw; // Rethrow the exception to indicate an error
                }
            }
            //NasaImageDataModel nasaImageData = new NasaImageDataModel();
            //return View(nasaImageData);

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