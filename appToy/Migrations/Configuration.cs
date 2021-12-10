namespace appToy.Migrations
{
    using appToy.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<JugetesdbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(JugetesdbContext context)
        {
            context.Juguete.AddOrUpdate(
                new Juguete { Nombre = "Spider-Man", Descripcion = "Figura de acción", RestriccionEdad = 6, Compania = "Marvel", Precio = 499.99M },
                new Juguete { Nombre = "Castillo Juguete", Descripcion = "Tienda Casita Castillo Juguete Niños Plegable Estrellas Luna", RestriccionEdad = 3, Compania = "Allmight", Precio = 298.88M },
                new Juguete { Nombre = "Excavadora Control Remoto", Descripcion = "Rc Juguete 6canal Niños Metal", RestriccionEdad = 10, Compania = "ELMAR", Precio = 485.88M },
                new Juguete { Nombre = "Trampolín Brincolín", Descripcion = "Trampolín Brincolín De 8 Pies 2.43m Diametro", RestriccionEdad = 12, Compania = "Fuxion Sports", Precio = 2899.99M }
                );
        }
    }
}
