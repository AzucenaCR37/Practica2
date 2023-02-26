using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Datos;
using Modelos;

namespace Practica2.Models
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        public bool Guardado { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            cargarListaLibros();
        }
        public void cargarListaLibros()
        {
            List<Libro> lista = new DAOLibro().cargarDatos();
            dgvLibros.DataSource = lista;
            dgvLibros.DataBind();
        }
        int idLibro = 0;
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtID.Text.Trim() == "" || txtAnio.Text.Trim() == "" || txtCarrera.Text.Trim() == "" || txtISBN.Text.Trim() == "" || txtMateria.Text.Trim() == "" || txtNombreAutor.Text.Trim() == "" || txtNumeroEdicion.Text.Trim() == "" || txtPais.Text.Trim() == "" || txtTitulo.Text.Trim() == "")
            {
                lblResultado.Text="Hay campos OBLIGATORIOS vacíos (*)";
            }
            else
            {
                try
                {
                    Libro objLibro= new Libro();
                    objLibro.ID = Convert.ToInt32(txtID.Text);
                    objLibro.ISBN = Convert.ToInt32(txtISBN.Text);
                    objLibro.titulo = txtTitulo.Text.Trim();
                    objLibro.materia = txtMateria.Text.Trim();
                    objLibro.numeroEdicion = Convert.ToInt32(txtNumeroEdicion.Text);
                    objLibro.anioPublicacion = Convert.ToInt32(txtAnio.Text);
                    objLibro.nombreAutores = txtNombreAutor.Text.Trim();
                    objLibro.paisPublicacion = txtPais.Text.Trim();
                    objLibro.sinopsis = txtSinopsis.Text.Trim();
                    objLibro.carrera = txtCarrera.Text.Trim();

                    bool resultado = false;
                    if (idLibro == 0)
                    {
                        int agregado = new DAOLibro().agregarLibro(objLibro);
                        resultado = (agregado > 0);
                    }

                    if (resultado)
                    {
                        Guardado = true;
                        lblResultado.Text="Se registró correctamente el libro";
                        cargarListaLibros();
                    }
                    else
                    {
                        lblResultado.Text="Ya existe un libro con el mismo id en el sistema";
                    }
                }
                catch (Exception ex)
                {
                    lblResultado.Text="Error al guardar";
                }
            }
        }

        protected void txtNombreAutor_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnCargarDatos_Click(object sender, EventArgs e)
        {
            cargarListaLibros();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}