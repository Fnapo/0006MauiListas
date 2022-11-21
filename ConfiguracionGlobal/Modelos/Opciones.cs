using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfiguracionGlobal.Modelos
{
	public sealed class Opciones
	{
		private string baseDatos;
		private string servidor;
		private string puerto;
		private string usuario;
		private string password;

		public string Servidor { get => servidor; set => servidor = value; }
		public string Puerto { get => puerto; set => puerto = value; }
		public string Usuario { get => usuario; set => usuario = value; }
		public string Password { get => password; set => password = value; }
		public string BaseDatos { get => baseDatos; set => baseDatos = value; }

		public Opciones()
		{

		}
	}
}
