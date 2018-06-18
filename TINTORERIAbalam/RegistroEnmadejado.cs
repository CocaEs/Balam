using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TINTORERIAbalam
{
    class RegistroEnmadejado
    {
        string tipodehilo;
        Decimal cantidad;
        string numerodemaquina;
        DateTime fechaenmadejado;

        public string Tipodehilo { get => tipodehilo; set => tipodehilo = value; }
        public decimal Cantidad { get => cantidad; set => cantidad = value; }
        public string Numerodemaquina { get => numerodemaquina; set => numerodemaquina = value; }
        public DateTime Fechaenmadejado { get => fechaenmadejado; set => fechaenmadejado = value; }
    }
}
