using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Entities;
namespace Data
{
    public class DataFormulario
    {
        public static int? InsertFormulario(string name)
        {
            string conexion = System.Configuration.ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            SqlConnection con = new SqlConnection(conexion);
            try
            {
                int? idForm = null;
                string proc = "InsertarFormulario";

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = proc;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@nombre", name);

                con.Open();
                cmd.Connection = con;

                cmd.ExecuteNonQuery();

                proc = "ConsultarUltimoFormulario";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = proc;
                cmd.Parameters.Clear();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        idForm = int.Parse(dr["IdFormulario"].ToString());
                    }
                }
                return idForm;

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                con.Close();
            }


        }
        public static bool InsertDetallesEnFormulario(List<DetalleFormulario> lst, int id)
        {

            string conexion = System.Configuration.ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            SqlConnection con = new SqlConnection(conexion);
            try
            {
                string proc = "AsignarIdADetalles";
                List<DetalleFormulario> lst2 = new List<DetalleFormulario>();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = proc;
                con.Open();
                cmd.Connection = con;
                for (int i = 0; i < lst.Count; i++)
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@descripcion", lst[i].name);
                    cmd.Parameters.AddWithValue("@tipodato", lst[i].datatype);
                    cmd.Parameters.AddWithValue("@idformulario", id);
                    cmd.ExecuteNonQuery();
                    lst2.Add(lst[i]);
                }
                if (lst.Count == lst2.Count)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                con.Close();
            }

        }
        public static List<Formulario> ListaFormularios()
        {
            string conexion = System.Configuration.ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            SqlConnection con = new SqlConnection(conexion);
            try
            {
                List<Formulario> lst = new List<Formulario>();

                SqlCommand cmd = new SqlCommand();
                string proc = "ListaFormularios";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = proc;
                cmd.Parameters.Clear();
                con.Open();
                cmd.Connection = con;
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Formulario form = new Formulario();
                        form.id = int.Parse(dr["IdFormulario"].ToString());
                        form.name = dr["Nombre"].ToString();
                        lst.Add(form);
                    }
                }
                return lst;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                con.Close();
            }
        }

        public static List<DetalleFormulario> DetallesDeUnFormulario(int id)
        {
            string conexion = System.Configuration.ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            SqlConnection con = new SqlConnection(conexion);
            try
            {
                string proc = "ConsultarFormulario";
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = proc;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);

                con.Open();
                cmd.Connection = con;

                List<DetalleFormulario> lst = new List<DetalleFormulario>();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        DetalleFormulario dt = new DetalleFormulario();
                        dt.id = int.Parse(dr["IdDetalleFormulario"].ToString());
                        dt.name = dr["Descripcion"].ToString();
                        dt.datatype = dr["TipoDato"].ToString();
                        dt.idForm = int.Parse(dr["IdFormulario"].ToString());
                        lst.Add(dt);
                    }
                }
                return lst;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                con.Close();
            }
        }
        public static List<Formulario> Top5Formularios ()
        {
            try
            {
                ConexionDB.OpenConnection();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "Select top 5 * from Formularios order by Formularios.IdFormulario desc";
                SqlDataReader dr = ConexionDB.DataReader(cmd);
                List<Formulario> lstForm = new List<Formulario>();
                while (dr.Read())
                {
                    Formulario form = new Formulario();
                    form.id = int.Parse(dr["IdFormulario"].ToString());
                    form.name = dr["Nombre"].ToString();
                    lstForm.Add(form);
                }
                return lstForm;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
