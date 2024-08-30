using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration; // Necesario para leer la configuración de la aplicación.
using System.Xml.Linq;
using System.Data.SqlClient; // Necesario para trabajar con SQL Server en .NET.
using System.Runtime.CompilerServices;

namespace DatosLayer
{
    public class DataBase
    {
        // Propiedad estática que devuelve la cadena de conexión a la base de datos.
        public static string ConnectionString
        {
            get
            {
                // Obtiene la cadena de conexión de la configuración de la aplicación.
                string CadenaConexion = ConfigurationManager
                    .ConnectionStrings["NWConnection"]
                    .ConnectionString;

                // Construye una nueva cadena de conexión utilizando SqlConnectionStringBuilder.
                SqlConnectionStringBuilder conexionBuilder =
                    new SqlConnectionStringBuilder(CadenaConexion);

                // Asigna el nombre de la aplicación si está especificado, si no, mantiene el existente.
                conexionBuilder.ApplicationName =
                    ApplicationName ?? conexionBuilder.ApplicationName;

                // Configura el tiempo de espera de la conexión si se ha establecido un valor.
                conexionBuilder.ConnectTimeout = (ConnectionTimeout > 0)
                    ? ConnectionTimeout : conexionBuilder.ConnectTimeout;

                // Devuelve la cadena de conexión construida.
                return conexionBuilder.ToString();
            }
        }

        // Propiedad estática para definir el tiempo de espera de la conexión.
        public static int ConnectionTimeout { get; set; }

        // Propiedad estática para definir el nombre de la aplicación que se conectará a la base de datos.
        public static string ApplicationName { get; set; }

        // Método estático que devuelve una conexión SQL abierta.
        public static SqlConnection GetSqlConnection()
        {
            // Crea una nueva conexión SQL utilizando la cadena de conexión generada.
            SqlConnection conexion = new SqlConnection(ConnectionString);

            // Abre la conexión a la base de datos.
            conexion.Open();

            // Devuelve la conexión abierta.
            return conexion;
        }
    }
}
