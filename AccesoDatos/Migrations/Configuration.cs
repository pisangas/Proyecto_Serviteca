namespace AccesoDatos.Migrations
{
    using Modelos.Entidades;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AccesoDatos.SQLServer.ContextoSQLServer>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }
        protected override void Seed(AccesoDatos.SQLServer.ContextoSQLServer context)
        {
            context.Clientes.AddOrUpdate(

                c => c.Nombre,
                new Modelos.Entidades.Cliente
                {
                    Nombre = "Eduardo Luis",
                    Apellido = "Gomez Alvarez",
                    Cedula = 14397678,
                    Telefono = "3017390140",
                    Direccion = "Cra 6A # 47A - 40",
                    Edad = 27,
                    Vehiculos = new List<Vehiculo>
                    {
                        new Vehiculo
                        {
                            Kilometraje = 2300,
                            Matricula = "SNL987",
                            Servicios = new List<Servicio>
                            {
                                new Servicio
                                {
                                    Descripcion = "Cambio Aceite",
                                    ValorServicio = 50000,
                                },

                                new Servicio
                                {
                                    Descripcion = "Balanceo",
                                    ValorServicio = 75000,
                                },
                            }
                        },

                        new Vehiculo
                        {
                            Kilometraje = 56959,
                            Matricula = "LUI54E",
                            Servicios = new List<Servicio>
                            {
                                new Servicio
                                {
                                    Descripcion = "Cambio Pastillas",
                                    ValorServicio = 98000,
                                },

                                new Servicio
                                {
                                    Descripcion = "Cambio Liquido de Frenos",
                                    ValorServicio = 43200,
                                },
                            }
                        }

                    }
                },

                new Modelos.Entidades.Cliente
                {
                    Nombre = "Jorge Camilo",
                    Apellido = "Sanchez Moreno",
                    Cedula = 101546987,
                    Telefono = "304258963",
                    Direccion = "Cra 9 # 7C - 60",
                    Edad = 27,
                    Vehiculos = new List<Vehiculo>
                    {
                        new Vehiculo
                        {
                            Kilometraje = 165000,
                            Matricula = "HKC86T",
                            Servicios = new List<Servicio>
                            {
                                new Servicio
                                {
                                    Descripcion = "Cambio Aceite",
                                    ValorServicio = 120000,
                                },

                                new Servicio
                                {
                                    Descripcion = "Balanceo",
                                    ValorServicio = 120000,
                                },
                            }
                        },

                        new Vehiculo
                        {
                            Kilometraje = 70000,
                            Matricula = "FER54E",
                            Servicios = new List<Servicio>
                            {
                                new Servicio
                                {
                                    Descripcion = "Cambio Pastillas",
                                    ValorServicio = 198000,
                                },

                                new Servicio
                                {
                                    Descripcion = "Cambio Liquido de Frenos",
                                    ValorServicio = 5400,
                                },
                            }
                        }

                    }
                });

        }
    }
}