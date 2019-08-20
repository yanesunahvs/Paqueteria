using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Entregas
{
    public class EntregasBL
    {
        Contexto _contexto;

        public BindingList<Entregas> ListaEntregas { get; set; }

        public EntregasBL()
        {
            _contexto = new Contexto();
            ListaEntregas = new BindingList<Entregas>();


        }
        public BindingList<Entregas> ObtenerEntregas()
        {
            _contexto.Entregas.Load();

            ListaEntregas = _contexto.Entregas.Local.ToBindingList();

            return ListaEntregas;
        }
    }
    public class Entregas
    {
        public string Nombre { get; set; }
        public int Id { get; set; }
        public string Direccion { get; set; }
        public double Precio { get; set; }
        public int Codigo { get; set; }
        public bool Activo { get; set; }

    }
}
