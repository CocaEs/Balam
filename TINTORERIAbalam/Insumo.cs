using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TINTORERIAbalam
{
    class Insumo
    {
        string nombreproducto;
        Decimal cantidad;
        string proveedor;
        string descripcion;

        public string Nombreproducto { get => nombreproducto; set => nombreproducto = value; }
        public decimal Cantidad { get => cantidad; set => cantidad = value; }
        public string Proveedor { get => proveedor; set => proveedor = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
    }
}
