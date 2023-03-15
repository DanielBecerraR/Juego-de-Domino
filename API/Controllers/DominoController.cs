using Logic.Interface;
using Microsoft.AspNetCore.Mvc;
using Persistence.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
	public class DominoController : Controller
	{
		private readonly IDominoService _dominoService;

		public DominoController(IDominoService dominoService)
		{
			_dominoService = dominoService;
		}

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult EnvioDomino(string FichasDomino)
        {
            List<DominoDto> listadoFichas = _dominoService.FormarDomino(FichasDomino);

            bool contieneDatosCorrectos = _dominoService.ContieneDatosCorrectos(listadoFichas);

            if (!contieneDatosCorrectos)
            {
                TempData["Resultado"] = "Se presento un problema, no se identificaron los valores de las fichas, recuerde que deben ser numeros entre el 0 y el 6.";
                return RedirectToAction("Domino");
            }

            var result = _dominoService.OrdenDomino(listadoFichas);
            TempData["Resultado"] = result;
            return RedirectToAction("Domino");
        }
        //asp-for="FichasDomino"

        public IActionResult Domino()
        {
            return View();
        }

        public IActionResult EnvioFichas(List<DominoDto> fichas)
        {
            var result = _dominoService.OrdenDomino(fichas);
            return View(fichas);
        }
    }
}
