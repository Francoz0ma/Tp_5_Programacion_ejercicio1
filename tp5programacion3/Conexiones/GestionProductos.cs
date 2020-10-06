using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace tp5programacion3.Conexiones
{
    public class GestionProductos
    {

        public GestionProductos()
        {

        }

        private DataTable ObtenerTabla(String Nombre, String Sql)
        {
            DataSet ds = new DataSet();
            AccesoDatos datos = new AccesoDatos();
            SqlDataAdapter adap = datos.ObtenerAdaptador(Sql);
            adap.Fill(ds, Nombre);
            return ds.Tables[Nombre];
        }

        public DataTable ObtenerTodosLosProductos()
        {
            return ObtenerTabla("Productos", "Select IdProducto as Id_Producto,NombreProducto as Nombre_Producto, CantidadPorUnidad as Cantidad_por_Unidad,PrecioUnidad as Precio_Unidad from Productos");
        }


        private void ArmarParametrosProductos(ref SqlCommand Comando, Productos producto)
        {
            SqlParameter Sqlparametros = new SqlParameter();
            Sqlparametros = Comando.Parameters.Add("@IdProducto", SqlDbType.Int);
            Sqlparametros.Value = producto.IdProducto;
            Sqlparametros = Comando.Parameters.Add("@NombreProducto", SqlDbType.VarChar);
            Sqlparametros.Value = producto.NombreProducto;
            Sqlparametros = Comando.Parameters.Add("@CantidadPorUnidad", SqlDbType.VarChar);
            Sqlparametros.Value = producto.CantidadPorUnidad;
            Sqlparametros = Comando.Parameters.Add("@PrecioUnidad", SqlDbType.Money);
            Sqlparametros.Value = producto.PrecioUnidad;

        }

        private void ArmarParametrosEliminarProductos(ref SqlCommand comando, Productos producto)
        {
            SqlParameter sqlParametros = new SqlParameter();
            sqlParametros = comando.Parameters.Add("@IdProducto", SqlDbType.Int);
            sqlParametros.Value = producto.IdProducto;
        }






        public bool EliminarProducto(Productos pro)
        {
            SqlCommand Comando = new SqlCommand();
            ArmarParametrosEliminarProductos(ref Comando, pro);
            AccesoDatos adatos = new AccesoDatos();
            int FilasInsertadas = adatos.EjecutarProcedimientoAlmacenado(Comando, "spEliminarProducto");
            if (FilasInsertadas == 1)
                return true;
            else
                return false;
        }



        public bool ActualizarProductos(Productos producto)
        {
            SqlCommand Comando = new SqlCommand();
            ArmarParametrosProductos(ref Comando, producto);
            AccesoDatos conex = new AccesoDatos();
            int Filas = conex.EjecutarProcedimientoAlmacenado(Comando, "spActualizarProducto");
            if (Filas == 1)
                return true;
            else
                return false;
        }
























    }
}