using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelos;

namespace Datos
{
    public class DAOLibro
    {
        
        public List<Libro> cargarDatos()
        {
            try
            {
                if (Conexion.conectar())
                {
                    //Se cargarán los datos que no tengan borrado lógico
                    SqlCommand comando = new SqlCommand(@"select * from Libros order by titulo asc");

                    //Se establece la conexión con la que se ejecutará la consulta
                    comando.Connection = Conexion.conexion;

                    //Este objeto nos ayudará a llenar una tabla con el resultado de la consulta
                    SqlDataAdapter adapter = new SqlDataAdapter(comando);
                    DataTable resultado = new DataTable();
                    adapter.Fill(resultado);
                    List<Libro> listaLibro = new List<Libro>();
                    Libro objlibro = null;
                    //Cuando la consulta si obtuvo resultados la tabla trae filas

                    foreach (DataRow fila in resultado.Rows)
                    {
                        objlibro = new Libro();
                        objlibro.ID = Convert.ToInt32(fila["id"]);
                        objlibro.ISBN = Convert.ToInt32(fila["isbn"]);
                        objlibro.titulo = fila["titulo"].ToString();
                        objlibro.numeroEdicion = Convert.ToInt32(fila["numeroEdicion"]);
                        objlibro.anioPublicacion = Convert.ToInt32(fila["anioPublicacion"]);
                        objlibro.nombreAutores = fila["autores"].ToString();
                        objlibro.paisPublicacion = fila["paisPublicacion"].ToString();
                        objlibro.sinopsis = fila["sinopsis"].ToString();
                        objlibro.carrera = fila["carrera"].ToString();
                        objlibro.materia = fila["materia"].ToString();

                        listaLibro.Add(objlibro);
                    }

                    return listaLibro;
                }
                else
                {
                    throw new Exception("No se ha podido conectar con el servidor");
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo obtener la información de los libro");
            }
            finally
            {
                Conexion.desconectar();
            }
        }
        public int agregarLibro(Libro libro)
        {
            try
            {
                if (Conexion.conectar())
                {
                    SqlCommand comando = new SqlCommand(
                        @"INSERT INTO Libros VALUES(@id,@isbn,@titulo,@numeroEdicion, @anioPublicacion, 
                        @autores, @paisPublicacion, @sinopsis, @carrera, @materia);");

                    comando.Parameters.AddWithValue("@id", libro.ID);
                    comando.Parameters.AddWithValue("@isbn", libro.ISBN);
                    comando.Parameters.AddWithValue("@titulo", libro.titulo);
                    comando.Parameters.AddWithValue("@numeroEdicion", libro.numeroEdicion);
                    comando.Parameters.AddWithValue("@anioPublicacion", libro.anioPublicacion);
                    comando.Parameters.AddWithValue("@autores", libro.nombreAutores);
                    comando.Parameters.AddWithValue("@paisPublicacion", libro.paisPublicacion);
                    comando.Parameters.AddWithValue("@sinopsis", libro.sinopsis);
                    comando.Parameters.AddWithValue("@carrera", libro.carrera);
                    comando.Parameters.AddWithValue("@materia", libro.materia);

                    comando.Connection = Conexion.conexion;

                    int agregado = comando.ExecuteNonQuery();

                    return agregado;
                }
                else
                {
                    throw new Exception("No se ha podido conectar con el servidor");
                }
            }
            catch (SqlException)
            {
                throw new Exception();
            }
            finally
            {
                Conexion.desconectar();
            }
        }
    }
}
