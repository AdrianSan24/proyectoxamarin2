using MySql.Data.MySqlClient;
using System;

namespace App3000
{
    public class Conexiones
    {
        MySqlConnection cn;
        MySqlCommand consulta;

        string user;
        string pass;
        public Conexiones()
        {


        }


        public bool conectar()
        {

            string servidor = "localhost";
            string puerto = "3306";
            string usuario = "root";
            string password = "";
            string database = "prueba";

            //Cadena de conexion
            string cadenaConexion = String.Format("server={0};port={1};user id={2}; password={3}; database={4};", servidor, puerto, usuario, password, database);

            cn = new MySqlConnection(cadenaConexion);
            cn.OpenAsync();
            cn.Open();//se abre la conexion
            if (cn.State == System.Data.ConnectionState.Open)
            {

                return true;
            }
            else
            {
                return false;
            }

        }
        public bool acceso(string usuario, string pass)
        {
            user = usuario;
            this.pass = pass;
            consulta = new MySqlCommand("SELECT usuario,contrasena FROM operarios ", cn);
            MySqlDataReader lector = consulta.ExecuteReader();
            while (lector.Read())
            {
                if (usuario.Equals(lector.GetString("usuario")) && pass.Equals(lector.GetString("contrasena")))
                {
                    lector.Close();
                    return true;
                }


            }
            return false;

        }
    }
}