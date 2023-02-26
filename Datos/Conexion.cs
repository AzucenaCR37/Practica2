using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Conexion
    {
        public static SqlConnection conexion;
        public static SqlTransaction transaccion;
        static string usuario = "PruebaPractica2/David";
        static string password = "Kurogane365$";
        static string bd = "itsur";
        static string servidor = "74.235.39.122";
        static string puerto = "3306";

        public static bool conectar()
        {
            try
            {
                conexion = new SqlConnection("Data Source=74.235.39.122; Initial Catalog=itsur;" +
            "User ID=azucena;Password=1234;");
                conexion.Open();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static void desconectar()
        {
            try
            {
                conexion.Close();
            }
            catch (Exception)
            { }
        }
    }
}
