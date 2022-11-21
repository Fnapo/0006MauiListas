using ClasesPryca.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesPryca.Modelos.Static
{
    public static class DBPryca
    {
        private static PrycaContext _contexto = new PrycaContext();

        public static PrycaContext Contexto { get => _contexto; }
    }
}
