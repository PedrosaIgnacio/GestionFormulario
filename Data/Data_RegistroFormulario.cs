using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
namespace Data
{
    public class Data_RegistroFormulario
    {
        public static int? ObtenerUltimoIdRegistro()
        {
            string conexion = System.Configuration.ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            SqlConnection con = new SqlConnection(conexion);

            int id = -1;

            try
            {

                string proc = "UltimaFilaRegistro";
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = proc;

                con.Open();
                cmd.Connection = con;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        id = int.Parse(dr["Id"].ToString());
                    }
                }
                return id;
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
        public static void GuardarRegistroDeFormulario(List<RegistroFormulario> lstReg)
        {
            string conexion = System.Configuration.ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            SqlConnection con = new SqlConnection(conexion);
            try
            {
                string proc = "RegistrarDatos" ;
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = proc;

                con.Open();
                cmd.Connection = con;

                for (int i = 0; i < lstReg.Count; i++)
                {
                    cmd.Parameters.Clear();

                    cmd.Parameters.AddWithValue("@valor", lstReg[i].valor);
                    cmd.Parameters.AddWithValue("@idFormulario", lstReg[i].idFormulario);
                    cmd.Parameters.AddWithValue("@idDetalleFormulario", lstReg[i].idDetalleFormulario);
                    cmd.Parameters.AddWithValue("@idFormulario", lstReg[i].idFormulario);
                    cmd.Parameters.AddWithValue("@idUltimaFilaRegistrada", lstReg[i].idFilaRegistro);

                    cmd.ExecuteNonQuery();
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
    }
}
