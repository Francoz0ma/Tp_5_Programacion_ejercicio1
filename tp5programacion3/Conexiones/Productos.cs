using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace tp5programacion3.Conexiones
{
    public class Productos
    {
        private int i_idProducto;
        private String s_NombreProducto;
        private int i_idProveedor;
        private String s_CantidadPorUnidad;
        private decimal d_PrecioUnidad;


        public Productos()
        {

        }

        public Productos( int i_idProducto, String s_NombreProducto,int i_idProveedor, String s_CantidadPorUnidad, decimal d_PrecioUnidad)
        {
            this.i_idProducto = i_idProducto;
            this.s_NombreProducto = s_NombreProducto;
            this.i_idProveedor = i_idProveedor;
            this.s_CantidadPorUnidad = s_CantidadPorUnidad;
            this.d_PrecioUnidad = d_PrecioUnidad;
        }

        public int IdProducto
        {
            get { return i_idProducto; }
            set { i_idProducto = value; }
        }

        public String NombreProducto
        {
            get { return s_NombreProducto; }
            set { s_NombreProducto = value; }
        }

        public int IdProveedor
        {
            get { return i_idProveedor; }
            set { i_idProveedor = value; }
        }

        public String CantidadPorUnidad
        {
            get { return s_CantidadPorUnidad; }
            set { s_CantidadPorUnidad = value; }
        }

        public decimal PrecioUnidad
        {
            get { return d_PrecioUnidad; }
            set { d_PrecioUnidad = value; }
        }










    }
}