using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Configuration;
using System.Data;
using System.Data.SqlClient;

using MySql.Data.MySqlClient;
//using System.Convert;

namespace mmarticulos.Models
{
    public class MantenimientoArticulo
    {
        private MySqlConnection conexion = new MySqlConnection();
        private MySqlDataReader registros = null;
        private MySqlCommand comando = new MySqlCommand();
        
        public List<Articulo> RecuperarTodos()
        {
        //    string cadenaConexion = "datasource=localhost;port=3306;username=root;password=;database=soloenteros";
            string consulta = "select * from articulos";
            List<Articulo> articulos = new List<Articulo>();
            conexion.ConnectionString = ConfigurationManager.ConnectionStrings["localmysql"].ConnectionString;
            conexion.Open();
            comando.Connection = conexion;
            comando.CommandText = consulta;
            registros = comando.ExecuteReader();    
            Articulo art = new Articulo();
            //probar con linq
            while (registros.Read())
            {
            //    art = new Articulo(registros.GetInt32(0), registros.GetString(1), registros.GetFloat(2));
                
                art = new Articulo()
                {
                    Codigo = registros.GetInt32(0),
                    Descripcion = registros.GetString(1),
                    Precio = registros.GetFloat(2)
                };
                
                articulos.Add(art);
            }
            return articulos;
        }
        
        public int Alta(Articulo art)
        {
            int i = 0;
            string sql = "insert into articulos(codigo,descripcion,precio) values (@codigo,@descripcion,@precio)";
            conexion.ConnectionString = ConfigurationManager.ConnectionStrings["localmysql"].ConnectionString;
            conexion.Open();
            comando.Connection = conexion;
            comando.CommandText = sql;
            comando.Prepare();
            comando.Parameters.AddWithValue("@codigo", art.Codigo);
            comando.Parameters.AddWithValue("@descripcion", art.Descripcion);
            comando.Parameters.AddWithValue("@precio", art.Precio);
            i = comando.ExecuteNonQuery();
            return i;
            /*
            Conectar();
            SqlCommand comando = new SqlCommand("insert into articulos(codigo,descripcion,precio) values (@codigo,@descripcion,@precio)", con);
            comando.Parameters.Add("@codigo", SqlDbType.Int);
            comando.Parameters.Add("@descripcion", SqlDbType.VarChar);
            comando.Parameters.Add("@precio", SqlDbType.Float);
            comando.Parameters["@codigo"].Value = art.Codigo;
            comando.Parameters["@descripcion"].Value = art.Descripcion;
            comando.Parameters["@precio"].Value = art.Precio;
            con.Open();
            int i = comando.ExecuteNonQuery();
            con.Close();
            return i;
            */
        }
        
        /*
        public Articulo Recuperar(int codigo)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("select codigo,descripcion,precio from articulos where codigo=@codigo", con);
            comando.Parameters.Add("@codigo", SqlDbType.Int);
            comando.Parameters["@codigo"].Value = codigo;
            con.Open();
            SqlDataReader registros = comando.ExecuteReader();
            Articulo articulo = new Articulo();
            if (registros.Read())
            {
                articulo.Codigo = int.Parse(registros["codigo"].ToString());
                articulo.Descripcion = registros["descripcion"].ToString();
                articulo.Precio = float.Parse(registros["precio"].ToString());
            }
            con.Close();
            return articulo;
        }
        */
            /*
            public int Modificar(Articulo art)
            {
                Conectar();
                SqlCommand comando = new SqlCommand("update articulos set descripcion=@descripcion,precio=@precio where codigo=@codigo", con);
                comando.Parameters.Add("@descripcion", SqlDbType.VarChar);
                comando.Parameters["@descripcion"].Value = art.Descripcion;
                comando.Parameters.Add("@precio", SqlDbType.Float);
                comando.Parameters["@precio"].Value = art.Precio;
                comando.Parameters.Add("@codigo", SqlDbType.Int);
                comando.Parameters["@codigo"].Value = art.Codigo;
                con.Open();
                int i = comando.ExecuteNonQuery();
                con.Close();
                return i;
            }
            */
            /*
            public int Borrar(int codigo)
            {
                Conectar();
                SqlCommand comando = new SqlCommand("delete from articulos where codigo=@codigo", con);
                comando.Parameters.Add("@codigo", SqlDbType.Int);
                comando.Parameters["@codigo"].Value = codigo;
                con.Open();
                int i = comando.ExecuteNonQuery();
                con.Close();
                return i;
            }
            */
        }
}