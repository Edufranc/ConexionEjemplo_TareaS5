using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DatosLayer
{
    // Clase para manejar operaciones CRUD en la tabla Customers de la base de datos.
    public class CustomerRepository
    {
        // Método para obtener todos los registros de la tabla Customers.
        public List<Customers> ObtenerTodos()
        {
            // Abre una conexión a la base de datos utilizando un bloque using para asegurarse de que se cierre.
            using (var conexion = DataBase.GetSqlConnection())
            {
                // Construcción de la consulta SQL para seleccionar todos los campos de la tabla Customers.
                String selectFrom = "";
                selectFrom = selectFrom + "SELECT [CustomerID] " + "\n";
                selectFrom = selectFrom + "      ,[CompanyName] " + "\n";
                selectFrom = selectFrom + "      ,[ContactName] " + "\n";
                selectFrom = selectFrom + "      ,[ContactTitle] " + "\n";
                selectFrom = selectFrom + "      ,[Address] " + "\n";
                selectFrom = selectFrom + "      ,[City] " + "\n";
                selectFrom = selectFrom + "      ,[Region] " + "\n";
                selectFrom = selectFrom + "      ,[PostalCode] " + "\n";
                selectFrom = selectFrom + "      ,[Country] " + "\n";
                selectFrom = selectFrom + "      ,[Phone] " + "\n";
                selectFrom = selectFrom + "      ,[Fax] " + "\n";
                selectFrom = selectFrom + "  FROM [dbo].[Customers]";

                // Ejecuta la consulta y obtiene un SqlDataReader para leer los resultados.
                using (SqlCommand comando = new SqlCommand(selectFrom, conexion))
                {
                    SqlDataReader reader = comando.ExecuteReader();
                    List<Customers> Customers = new List<Customers>();

                    // Itera sobre los resultados y convierte cada fila en un objeto Customers.
                    while (reader.Read())
                    {
                        var customers = LeerDelDataReader(reader);
                        Customers.Add(customers);
                    }
                    return Customers;
                }
            }
        }

        // Método para obtener un registro específico de la tabla Customers por ID.
        public Customers ObtenerPorID(string id)
        {
            // Abre una conexión a la base de datos.
            using (var conexion = DataBase.GetSqlConnection())
            {
                // Construcción de la consulta SQL para seleccionar un cliente específico por ID.
                String selectForID = "";
                selectForID = selectForID + "SELECT [CustomerID] " + "\n";
                selectForID = selectForID + "      ,[CompanyName] " + "\n";
                selectForID = selectForID + "      ,[ContactName] " + "\n";
                selectForID = selectForID + "      ,[ContactTitle] " + "\n";
                selectForID = selectForID + "      ,[Address] " + "\n";
                selectForID = selectForID + "      ,[City] " + "\n";
                selectForID = selectForID + "      ,[Region] " + "\n";
                selectForID = selectForID + "      ,[PostalCode] " + "\n";
                selectForID = selectForID + "      ,[Country] " + "\n";
                selectForID = selectForID + "      ,[Phone] " + "\n";
                selectForID = selectForID + "      ,[Fax] " + "\n";
                selectForID = selectForID + $"  Where CustomerID = @customerId";

                // Ejecuta la consulta con el parámetro ID y obtiene el resultado.
                using (SqlCommand comando = new SqlCommand(selectForID, conexion))
                {
                    comando.Parameters.AddWithValue("customerId", id);

                    var reader = comando.ExecuteReader();
                    Customers customers = null;

                    // Si se encuentra un registro, se convierte en un objeto Customers.
                    if (reader.Read())
                    {
                        customers = LeerDelDataReader(reader);
                    }
                    return customers;
                }
            }
        }

        // Método para leer un registro de SqlDataReader y convertirlo en un objeto Customers.
        public Customers LeerDelDataReader(SqlDataReader reader)
        {
            Customers customers = new Customers();

            // Asigna los valores de las columnas a las propiedades del objeto Customers.
            customers.CustomerID = reader["CustomerID"] == DBNull.Value ? " " : (String)reader["CustomerID"];
            customers.CompanyName = reader["CompanyName"] == DBNull.Value ? "" : (String)reader["CompanyName"];
            customers.ContactName = reader["ContactName"] == DBNull.Value ? "" : (String)reader["ContactName"];
            customers.ContactTitle = reader["ContactTitle"] == DBNull.Value ? "" : (String)reader["ContactTitle"];
            customers.Address = reader["Address"] == DBNull.Value ? "" : (String)reader["Address"];
            customers.City = reader["City"] == DBNull.Value ? "" : (String)reader["City"];
            customers.Region = reader["Region"] == DBNull.Value ? "" : (String)reader["Region"];
            customers.PostalCode = reader["PostalCode"] == DBNull.Value ? "" : (String)reader["PostalCode"];
            customers.Country = reader["Country"] == DBNull.Value ? "" : (String)reader["Country"];
            customers.Phone = reader["Phone"] == DBNull.Value ? "" : (String)reader["Phone"];
            customers.Fax = reader["Fax"] == DBNull.Value ? "" : (String)reader["Fax"];

            return customers;
        }

        // Método para insertar un nuevo registro en la tabla Customers.
        public int InsertarCliente(Customers customer)
        {
            // Abre una conexión a la base de datos.
            using (var conexion = DataBase.GetSqlConnection())
            {
                // Construcción de la consulta SQL para insertar un nuevo cliente.
                String insertInto = "";
                insertInto = insertInto + "INSERT INTO [dbo].[Customers] " + "\n";
                insertInto = insertInto + "           ([CustomerID] " + "\n";
                insertInto = insertInto + "           ,[CompanyName] " + "\n";
                insertInto = insertInto + "           ,[ContactName] " + "\n";
                insertInto = insertInto + "           ,[ContactTitle] " + "\n";
                insertInto = insertInto + "           ,[Address] " + "\n";
                insertInto = insertInto + "           ,[City]) " + "\n";
                insertInto = insertInto + "     VALUES " + "\n";
                insertInto = insertInto + "           (@CustomerID " + "\n";
                insertInto = insertInto + "           ,@CompanyName " + "\n";
                insertInto = insertInto + "           ,@ContactName " + "\n";
                insertInto = insertInto + "           ,@ContactTitle " + "\n";
                insertInto = insertInto + "           ,@Address " + "\n";
                insertInto = insertInto + "           ,@City)";

                // Ejecuta la consulta y retorna el número de registros insertados.
                using (var comando = new SqlCommand(insertInto, conexion))
                {
                    int insertados = parametrosCliente(customer, comando);
                    return insertados;
                }
            }
        }

        // Método para actualizar un registro en la tabla Customers.
        public int ActualizarCliente(Customers customer)
        {
            // Abre una conexión a la base de datos.
            using (var conexion = DataBase.GetSqlConnection())
            {
                // Construcción de la consulta SQL para actualizar un cliente existente por ID.
                String ActualizarCustomerPorID = "";
                ActualizarCustomerPorID = ActualizarCustomerPorID + "UPDATE [dbo].[Customers] " + "\n";
                ActualizarCustomerPorID = ActualizarCustomerPorID + "   SET [CustomerID] = @CustomerID " + "\n";
                ActualizarCustomerPorID = ActualizarCustomerPorID + "      ,[CompanyName] = @CompanyName " + "\n";
                ActualizarCustomerPorID = ActualizarCustomerPorID + "      ,[ContactName] = @ContactName " + "\n";
                ActualizarCustomerPorID = ActualizarCustomerPorID + "      ,[ContactTitle] = @ContactTitle " + "\n";
                ActualizarCustomerPorID = ActualizarCustomerPorID + "      ,[Address] = @Address " + "\n";
                ActualizarCustomerPorID = ActualizarCustomerPorID + "      ,[City] = @City " + "\n";
                ActualizarCustomerPorID = ActualizarCustomerPorID + " WHERE CustomerID= @CustomerID";

                // Ejecuta la consulta y retorna el número de registros actualizados.
                using (var comando = new SqlCommand(ActualizarCustomerPorID, conexion))
                {
                    int actualizados = parametrosCliente(customer, comando);
                    return actualizados;
                }
            }
        }

        // Método para agregar parámetros de un objeto Customers a un SqlCommand.
        public int parametrosCliente(Customers customer, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("CustomerID", customer.CustomerID);
            comando.Parameters.AddWithValue("CompanyName", customer.CompanyName);
            comando.Parameters.AddWithValue("ContactName", customer.ContactName);
            comando.Parameters.AddWithValue("ContactTitle", customer.ContactName);
            comando.Parameters.AddWithValue("Address", customer.Address);
            comando.Parameters.Add
