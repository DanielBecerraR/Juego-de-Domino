using Microsoft.AspNetCore.Mvc;
using Persistence.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interface
{
    public interface IDominoService
    {
        string OrdenDomino(List<DominoDto> json);
        List<DominoDto> FormarDomino(string fichas);
        bool ContieneDatosCorrectos(List<DominoDto> listadoFichas);
    }
}
