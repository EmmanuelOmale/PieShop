using BeathanyPieShop.Models;
using BeathanyPieShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BeathanyPieShop.Controllers
{
    public class PieController : Controller
    {
        private readonly IPieRepository _pieRepository;
        private readonly ICategoryRepository _categoryRepository;

        public PieController(IPieRepository pieRepository, ICategoryRepository categoryRepository)
        {
            _pieRepository = pieRepository;
            _categoryRepository = categoryRepository;
        }

        public IActionResult List()
        {
            /*ViewBag.CurrentCategory = "Cheese cakes";
            return View(_pieRepository.AllPies);*/
            PieListViewModel piesViewModel = new PieListViewModel(_pieRepository.AllPies, "Cheese cakes");
            return View(piesViewModel);

        }
    }
}
