using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Persistence.Dto
{
    public class DominoDto
    {
        //[RegularExpression(@"^[0-6]$", ErrorMessage = "Debe ingresar un numero entre el 0 y el 6")]
        public int Izquierda { get; set; }
        //[RegularExpression(@"^[0-6]$", ErrorMessage = "Debe ingresar un numero entre el 0 y el 6")]
        public int Derecha { get; set; }
    }

    public class CantidadDto
    {
        //[RegularExpression(@"^[2-6]$", ErrorMessage = "Debe ingresar un numero entre el 2 y el 6")]
        //public int Cantidad { get; set; }
        public string FichasDomino { get; set; }
    }
}
