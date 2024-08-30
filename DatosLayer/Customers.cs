using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosLayer
{
    // Clase que representa la entidad Customers en la base de datos.
    public class Customers
    {
        // Propiedad que representa el ID del cliente.
        public string CustomerID { get; set; }

        // Propiedad que representa el nombre de la compañía del cliente.
        public string CompanyName { get; set; }

        // Propiedad que representa el nombre del contacto del cliente.
        public string ContactName { get; set; }

        // Propiedad que representa el título del contacto del cliente.
        public string ContactTitle { get; set; }

        // Propiedad que representa la dirección del cliente.
        public string Address { get; set; }

        // Propiedad que representa la ciudad del cliente.
        public string City { get; set; }

        // Propiedad que representa la región del cliente.
        public string Region { get; set; }

        // Propiedad que representa el código postal del cliente.
        public string PostalCode { get; set; }

        // Propiedad que representa el país del cliente.
        public string Country { get; set; }

        // Propiedad que representa el número de teléfono del cliente.
        public string Phone { get; set; }

        // Propiedad que representa el número de fax del cliente.
        public string Fax { get; set; }
    }
}

