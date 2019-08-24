﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Entregas
{
    public class IngresosBL
    {
        Contexto _contexto;
        public BindingList<Ingreso> ListaIngresos { get; set; }

        public IngresosBL()
        {

            _contexto = new Contexto();
            ListaIngresos = new BindingList<Ingreso>();

           

        }
        public BindingList<Ingreso> ObtenerIngresos()
        {
            _contexto.ingresos.Load();
            ListaIngresos = _contexto.ingresos.Local.ToBindingList();

            return ListaIngresos;
        }
        public Resultado GuardarIngreso(Ingreso ingreso)
        {
            var resultado = Validar(ingreso);
            if (resultado.Exitoso == false)
            {
                return resultado;
            }

            _contexto.SaveChanges();
            resultado.Exitoso = true;
            return resultado;
        }
        public void AgregarIngreso()
        {
            var nuevoIngreso = new Ingreso();
            ListaIngresos.Add(nuevoIngreso);
        }

        public bool EliminarIngreso(int id)
        {
            foreach (var ingreso in ListaIngresos)
            {
                if (ingreso.id == id)
                {
                    ListaIngresos.Remove(ingreso);
                    _contexto.SaveChanges();
                    return true;
                }
            }

            return false;
        }

        private Resultado Validar(Ingreso ingreso)
        {
            var resultado = new Resultado();
            resultado.Exitoso = true;


            if ( String.IsNullOrEmpty (ingreso.Descripcion) == true)
            {
                resultado.Mensaje = "Iingrese una descripcion";
                resultado.Exitoso = false;
            }

            if (ingreso.Codigo<0)
            {
                resultado.Mensaje = "El codigo debe ser mayor que cero";
                resultado.Exitoso = false;
            }
            if (ingreso.Precio < 0)
            {
                resultado.Mensaje = "El codigo debe ser mayor que cero";
                resultado.Exitoso = false;
            }



            return resultado;
        
            
          }


    }            
    public class Ingreso
        {
            public int id { get; set; }
            public string Nombre { get; set; }
            public string Descripcion { get; set; }
            public double Precio { get; set; }
            public int Codigo { get; set; }
            public bool Activo { get; set; }
            
        }
        public class Resultado
        {
            public bool Exitoso { get; set; }
            public string Mensaje { get; set; }
        }
    }


