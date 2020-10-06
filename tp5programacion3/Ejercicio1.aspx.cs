using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using tp5programacion3.Conexiones;

namespace tp5programacion3
{
    public partial class Ejercicio1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                CargarGrilla();
            }
        }


        public void CargarGrilla()
        {
            GestionProductos gproductos = new GestionProductos();
            gvProductos.DataSource = gproductos.ObtenerTodosLosProductos();
            gvProductos.DataBind();
        }

        protected void gvProductos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            String i_IdProducto = ((Label)gvProductos.Rows[e.RowIndex].FindControl("lbl_it_IdProducto")).Text;

            Productos pro = new Productos();
            pro.IdProducto = Convert.ToInt32(i_IdProducto);

            GestionProductos gProductos = new GestionProductos();
            gProductos.EliminarProducto(pro);

            CargarGrilla();
        }

        protected void gvProductos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvProductos.EditIndex = e.NewEditIndex;
            CargarGrilla();
        }

        protected void gvProductos_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvProductos.EditIndex = -1;
            CargarGrilla();
        }

        protected void gvProductos_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            String i_IdProducto = ((Label)gvProductos.Rows[e.RowIndex].FindControl("lbl_eit_IdProducto")).Text;
            String s_NombreProducto = ((TextBox)gvProductos.Rows[e.RowIndex].FindControl("txt_eit_NombreProducto")).Text;
            String s_CantidadadPorUnidad = ((TextBox)gvProductos.Rows[e.RowIndex].FindControl("txt_eit_CantidadporUnidad")).Text;
            String i_PrecioUnidad = ((TextBox)gvProductos.Rows[e.RowIndex].FindControl("txt_eit_PrecioUnidad")).Text;

            Productos pro = new Productos();
            pro.IdProducto = int.Parse(i_IdProducto);
            pro.NombreProducto = s_NombreProducto;
            pro.CantidadPorUnidad = s_CantidadadPorUnidad;
            pro.PrecioUnidad = Convert.ToDecimal(i_PrecioUnidad);

            GestionProductos gproductos = new GestionProductos();
            gproductos.ActualizarProductos(pro);

            gvProductos.EditIndex = -1;

            CargarGrilla();
        }

        protected void gvProductos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvProductos.PageIndex = e.NewPageIndex;
            CargarGrilla();
        }
    }
}