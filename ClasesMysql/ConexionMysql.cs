
using MySqlConnector;

namespace ClasesMysql
{
	// All the code in this file is included in all platforms.

	public static class ConexionMysql
	{
		private static MySqlConnection conexion = null;
		public static MySqlConnection Conexion => conexion;

		public static string MensajeError => mensajeError;

		private static string mensajeError = "";


		public static string CrearCadenaConexion(string servidor, string puerto, string usuario, string password, string baseDatos)
		{
			string salida = "server=";			

			salida += servidor + ";port=";
			salida += puerto + ";uid=";
			salida += usuario + ";pwd=";
			salida += password + ";database=";
			salida += baseDatos + ";ssl mode=none;";

			return salida;
		}

		public static void CrearConexion(string cadenaConexion)
		{
			mensajeError = "Conexión correcta.";
			conexion = new MySqlConnection(cadenaConexion);
			try
			{
				conexion.Open();
				conexion.Close();
			}
			catch (Exception e)
			{
				conexion = null;
				mensajeError = e.Message;
			}
		}
	}
}