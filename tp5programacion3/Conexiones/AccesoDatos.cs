using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace tp5programacion3.Conexiones
{
    public class AccesoDatos
    {
        String rutaBDProductos = "Data Source=DESKTOP-F9A9FA7\\SQLEXPRESS;Initial Catalog=Neptuno;Integrated Security=True";

        public AccesoDatos()
        {

        }


        public SqlConnection ObtenerConexion()
        {
            SqlConnection cn = new SqlConnection(rutaBDProductos);
            try
            {
                cn.Open();
                return cn;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public SqlDataAdapter ObtenerAdaptador(String consultaSql)
        {
            SqlDataAdapter adaptador;
            try
            {
                adaptador = new SqlDataAdapter(consultaSql, ObtenerConexion());
                return adaptador;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public int EjecutarProcedimientoAlmacenado(SqlCommand Comando, String NombreSP) //comando que recibe tiene los parametros incluidos
        {
            int FilasCambiadas;
            SqlConnection Conexion = ObtenerConexion();
            SqlCommand cmd = new SqlCommand();
            cmd = Comando;
            cmd.Connection = Conexion;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = NombreSP;
            FilasCambiadas = cmd.ExecuteNonQuery();
            Conexion.Close();
            return FilasCambiadas;
        }

       







    }

}