using Microsoft.AspNetCore.Mvc;

namespace AppSemTemplate.Areas.Produtos.Controllers
{
    [Area("Produtos")]
    [Route("gestao-produtos")]
    public class CadastroController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("detalhe-produtos/{id:int}")]
        public IActionResult Detalhes(int id)
        {
            return View("Index");
        }
    }
}
