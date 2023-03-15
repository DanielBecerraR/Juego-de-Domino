using Logic.Interface;
using Newtonsoft.Json;
using Persistence.Dto;
using System.Collections.Generic;

namespace Logic.Implementation
{
    public class DominoService : IDominoService
    {
        public DominoService() { }

        public List<DominoDto> FormarDomino(string fichas)
        {
            List<DominoDto> dominoList = JsonConvert.DeserializeObject<List<DominoDto>>(fichas);
            return dominoList;
        }
        public bool ContieneDatosCorrectos(List<DominoDto> listadoFichas)
        {
            if (listadoFichas.Count > 6)
                return false;

            for (int i = 0; i < listadoFichas.Count; i++)
            {
                if (listadoFichas[i].Izquierda == null || listadoFichas[i].Derecha == null)
                    return false;

                if (!validaRangonumeros(listadoFichas[i].Izquierda) || !validaRangonumeros(listadoFichas[i].Derecha))
                    return false;
            }
            return true;
        }

        public bool validaRangonumeros(int numero)
        {
            int numMinimo = 0;
            int numNaximo = 6;

            if (numero >= numMinimo && numero <= numNaximo)
                return true;
            return false;
        }

        public string OrdenDomino(List<DominoDto> fichas)
        {
            string resultado = string.Empty;

            int cantidadFichas = fichas.Count - 1;
            int campoSiguiente = 0;
            int Insertados = 0;

            List<DominoDto> fichasOrdenadas = new List<DominoDto>();

            DominoDto fichaActual = new DominoDto();
            DominoDto fichaSiguiente = new DominoDto();
            DominoDto OrdenPosicion = new DominoDto();

            for (int i = 0; i < fichas.Count; i++)
            {
                if (campoSiguiente < cantidadFichas)
                    campoSiguiente = campoSiguiente + 1;

                if (i < campoSiguiente)
                {
                    fichaActual = fichas[i];
                    fichaSiguiente = fichas[campoSiguiente];

                    //primera parte
                    if (fichaActual.Izquierda == fichaSiguiente.Izquierda && i == 0)
                    {
                        OrdenPosicion.Izquierda = fichaActual.Derecha;
                        OrdenPosicion.Derecha = fichaActual.Izquierda;
                        fichasOrdenadas.Add(OrdenPosicion);
                        OrdenPosicion = new DominoDto();
                        Insertados = Insertados + 1;
                    }

                    if (fichaActual.Izquierda == fichaSiguiente.Derecha && i == 0)
                    {
                        OrdenPosicion.Izquierda = fichaActual.Derecha;
                        OrdenPosicion.Derecha = fichaActual.Izquierda;
                        fichasOrdenadas.Add(OrdenPosicion);
                        OrdenPosicion = new DominoDto();
                        Insertados = Insertados + 1;

                        OrdenPosicion.Izquierda = fichaSiguiente.Derecha;
                        OrdenPosicion.Derecha = fichaSiguiente.Izquierda;
                        fichasOrdenadas.Add(OrdenPosicion);
                        OrdenPosicion = new DominoDto();
                        Insertados = Insertados + 1;
                    }

                    if (fichaActual.Derecha == fichaSiguiente.Izquierda && i == 0)
                    {
                        fichasOrdenadas.Add(fichaActual);
                        Insertados = Insertados + 1;
                        fichasOrdenadas.Add(fichaSiguiente);
                        Insertados = Insertados + 1;
                    }

                    if (fichaActual.Derecha == fichaSiguiente.Derecha && i == 0)
                    {
                        OrdenPosicion.Izquierda = fichaSiguiente.Derecha;
                        OrdenPosicion.Derecha = fichaSiguiente.Izquierda;
                    }

                    //segunda parte 
                    if (fichasOrdenadas[Insertados - 1].Derecha == fichaSiguiente.Izquierda && Insertados > 0)
                    {
                        fichasOrdenadas.Add(fichaSiguiente);
                        OrdenPosicion = new DominoDto();
                        Insertados = Insertados + 1;
                    }
                    else if (fichasOrdenadas[Insertados - 1].Derecha == fichaSiguiente.Derecha && Insertados > 0)
                    {
                        OrdenPosicion.Izquierda = fichaSiguiente.Derecha;
                        OrdenPosicion.Derecha = fichaSiguiente.Izquierda;
                        fichasOrdenadas.Add(OrdenPosicion);
                        Insertados = Insertados + 1;
                        OrdenPosicion = new DominoDto();
                    }
                }

            }
            if (Insertados != fichas.Count)
                return "No se pudieron unificar todas las fichas que se escribieron";

            if (fichasOrdenadas[0].Izquierda != fichasOrdenadas[fichasOrdenadas.Count - 1].Derecha)
                return "El valor de la primera ficha en la posicion 1, no coinside con la ultima ficha de la posicion 2";

            resultado = JsonConvert.SerializeObject(fichasOrdenadas);
            return resultado;
        }
    }
}
