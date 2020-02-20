using PererraC.Models;
using System;
using System.Collections.Generic;

namespace PererraC.DAL
{
    public class PerreraInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<PerreraContext>
    {
        protected override void Seed(PerreraContext context)
        {
            var listaClientes = new List<Clientes>
            {
                new Clientes{NombreCompleto="Carson",Telefono="621007456",Correo="mila@gmail.com", DNI = "12345678A"},
                new Clientes{NombreCompleto="Lucas",Telefono="621007456",Correo="msdfsa@gmail.com", DNI = "12345678A"},
                new Clientes{NombreCompleto="Rocky",Telefono="621007456",Correo="milfds@gmail.com", DNI = "15465678A"},
                new Clientes{NombreCompleto="Turilli",Telefono="621007456",Correo="mila@gmail.com", DNI = "12546455678A"},
                new Clientes{NombreCompleto="Paco",Telefono="621007456",Correo="msdfsa3@gmail.com", DNI = "12345678A"},
                new Clientes{NombreCompleto="Luca",Telefono="621007456",Correo="mijkjla@gmail.com", DNI = "12345678A"},
                new Clientes{NombreCompleto="Gimena",Telefono="621007456r",Correo="mila@gmail.com", DNI = "12345678A"}
            };
            listaClientes.ForEach(s => context.Clientes.Add(s));
            context.SaveChanges();

            var listaEmpleados = new List<Empleados>
            {
                new Empleados{NombreCompleto="Gimena",Telefono="621007456",Correo="mila@gmail.com", DNI = "12345678A"},
                new Empleados{NombreCompleto="Paco",Telefono="621007456",Correo="mila@gmail.com", DNI = "12345678A"},
                new Empleados{NombreCompleto="Runa",Telefono="621007456",Correo="mila@gmail.com", DNI = "12345678A"},
                new Empleados{NombreCompleto="harvey",Telefono="621007456",Correo="mila@gmail.com", DNI = "12345678A"},
                new Empleados{NombreCompleto="Lesbi",Telefono="621007456",Correo="mila@gmail.com", DNI = "12345678A"},
                new Empleados{NombreCompleto="Jessy",Telefono="621007456",Correo="mila@gmail.com", DNI = "12345678A"},
                new Empleados{NombreCompleto="Shuck",Telefono="621007456",Correo="mila@gmail.com", DNI = "12345678A"},
                new Empleados{NombreCompleto="Saul",Telefono="621007456",Correo="mila@gmail.com", DNI = "12345678A"},
            };
            listaEmpleados.ForEach(s => context.Empleados.Add(s));
            context.SaveChanges();

            var listaJaulas = new List<Jaulas>
            {
                new Jaulas{Id=1, NombreJaula= "Jaula Pequeña"},
                new Jaulas{Id=2, NombreJaula= "Jaula Grande"}
            };
            listaJaulas.ForEach(s => context.Jaulas.Add(s));
            context.SaveChanges();

            var listaRazas = new List<Razas>
            {
                new Razas{Id=1,Nombre= "Doberman"},
                new Razas{Id=2, Nombre= "Chiguagua"},
                new Razas{Id=3, Nombre= "Boxer"}
            };
            listaRazas.ForEach(s => context.Razas.Add(s));
            context.SaveChanges();

            var listaPerros = new List<Perros>
            {
                new Perros{Nombre="Dumbo", Chip= "1050JUTE", FechaNacimiento= DateTime.Parse("2006-04-11"), IdJaula = 1, CodRazaId = 1},
                new Perros{Nombre="Frank", Chip= "3456HYRC", FechaNacimiento= DateTime.Parse("2008-02-21"), IdJaula = 1, CodRazaId = 1},
                new Perros{Nombre="Rocky", Chip= "1050GHYI", FechaNacimiento= DateTime.Parse("2002-05-01"), IdJaula = 2, CodRazaId = 2},
                new Perros{Nombre="Mickey", Chip= "1050IYRJ", FechaNacimiento= DateTime.Parse("2006-08-20"), IdJaula = 2, CodRazaId = 1},
                new Perros{Nombre="Voli", Chip= "1050TREJ", FechaNacimiento= DateTime.Parse("2007-01-14"), IdJaula = 1, CodRazaId = 3},
                new Perros{Nombre="Capitan", Chip= "1050RTUJ", FechaNacimiento= DateTime.Parse("2001-06-16"),IdJaula = 1, CodRazaId = 1},
                new Perros{Nombre="Capitan", Chip= "1050RTUJ", FechaNacimiento= DateTime.Parse("2001-06-16"),IdJaula = 1, CodRazaId = 1},
                new Perros{Nombre="Tommy", Chip= "1050OIUJ", FechaNacimiento= DateTime.Parse("2009-08-16"),IdJaula = 2, CodRazaId = 3},
                new Perros{Nombre="Luna", Chip= "1050ADFJ", FechaNacimiento= DateTime.Parse("2010-07-22"),IdJaula = 1, CodRazaId = 1},
            };
            listaPerros.ForEach(s => context.Perros.Add(s));
            context.SaveChanges();

            var listaAdopciones = new List<Adopciones>
            {
                new Adopciones{PerroId= 1, ClienteId = 1, EmpleadoId = 1, FechaEntrega =DateTime.Parse("2019-06-11") },
                new Adopciones{PerroId= 2, ClienteId = 2, EmpleadoId = 2, FechaEntrega =DateTime.Parse("2020-06-12") },
                new Adopciones{PerroId= 3, ClienteId = 3, EmpleadoId = 3, FechaEntrega =DateTime.Parse("2016-08-09") },
                new Adopciones{PerroId= 4, ClienteId = 5, EmpleadoId = 4, FechaEntrega =DateTime.Parse("2019-10-07") },
                new Adopciones{PerroId= 5, ClienteId = 6, EmpleadoId = 5, FechaEntrega =DateTime.Parse("2020-11-11") }
            };
            listaAdopciones.ForEach(s => context.Adopciones.Add(s));
            context.SaveChanges();
        }
    }
}