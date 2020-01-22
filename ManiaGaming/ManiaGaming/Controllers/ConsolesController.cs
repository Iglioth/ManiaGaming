using ManiaGaming.Converters;
using ManiaGaming.Models;
using ManiaGaming.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ManiaGaming.Controllers
{
    public class ConsolesController : Controller
    {
        // Repos
        private readonly ProductRepository productRepository;

        // Converter 
        private readonly ProductViewModelConverter converter = new ProductViewModelConverter();
        public ConsolesController
            (
                ProductRepository productRepository
            )
        {
            this.productRepository = productRepository;
        }

        public IActionResult Index()
        {
            ProductViewModel vm = new ProductViewModel
            {
                ProductDetailViewModels = converter.ModelsToViewModels(productRepository.GetAllConsole())
            };

            return View(vm);
        }

        public IActionResult Aanmaken()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }
    }
}
