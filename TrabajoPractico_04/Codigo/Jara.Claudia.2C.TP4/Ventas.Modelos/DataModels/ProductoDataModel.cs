using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ventas.Modelos.DataModels
{
    public class ProductoDataModel : BaseDataModel
    {
        private string descripcion;
        private double precio;


        public string Descripcion
        {
            get { return this.descripcion; }
            set { this.descripcion = value; }
        }


        public double Precio
        {
            get { return this.precio; }
            set { this.precio = value; }
        }

        public ProductoDataModel(string descripcion, double precio) : base(0)
        {
            Descripcion = descripcion;
            Precio = precio;
        }

        public ProductoDataModel(int id, string descripcion, double precio) : this(descripcion, precio)
        {
            Id = id;
        }
    }
}
