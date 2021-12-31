using Jcf.Web.Models.Funcao;
using Microsoft.AspNetCore.Mvc;

namespace Jcf.Web.Controllers
{
    public class FuncaoController : Controller
    {
        public IActionResult Index()
        {
            var lista = new List<FuncaoViewModel>();

            return View(lista);
        }

        public IActionResult Novo()
        {
            var model = new FuncaoViewModel();

            return View(model);
        }
    }
}
