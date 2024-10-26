using CRUDCORE.Models;
using System.Data.SqlClient;
using System.Data;

namespace CRUDCORE.Datos
{
    public class ContactoDatos
    {
        public List<ContactoModel> Listar()
        {

            var oLista = new List<ContactoModel>();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_Listar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        oLista.Add(new ContactoModel()
                        {
                            matricula = Convert.ToInt64(dr["matricula"]),
                            nombre = dr["nombre"].ToString(),
                            telefono = dr["telefono"].ToString(),
                            correo = dr["correo"].ToString()
                        });

                    }
                }
            }

            return oLista;
        }

        public ContactoModel Obtener(int matricula)
        {

            var oContacto = new ContactoModel();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_Obtener", conexion);
                cmd.Parameters.AddWithValue("matricula", matricula);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        oContacto.matricula = Convert.ToInt64(dr["matricula"]);
                        oContacto.nombre = dr["nombre"].ToString();
                        oContacto.telefono = dr["telefono"].ToString();
                        oContacto.correo = dr["correo"].ToString();
                    }
                }
            }

            return oContacto;
        }

        public bool Guardar(ContactoModel ocontacto)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Guardar", conexion);
                    cmd.Parameters.AddWithValue("matricula", ocontacto.matricula);
                    cmd.Parameters.AddWithValue("nombre", ocontacto.nombre);
                    cmd.Parameters.AddWithValue("telefono", ocontacto.telefono);
                    cmd.Parameters.AddWithValue("correo", ocontacto.correo);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;


            }
            catch (Exception e)
            {

                string error = e.Message;
                rpta = false;
            }



            return rpta;
        }


        public bool Editar(ContactoModel ocontacto)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Editar", conexion);
                    cmd.Parameters.AddWithValue("matricula", ocontacto.matricula);
                    cmd.Parameters.AddWithValue("nombre", ocontacto.nombre);
                    cmd.Parameters.AddWithValue("telefono", ocontacto.telefono);
                    cmd.Parameters.AddWithValue("correo", ocontacto.correo);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;


            }
            catch (Exception e)
            {

                string error = e.Message;
                rpta = false;
            }
            return rpta;
        }

        public bool Eliminar(int matricula)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Eliminar", conexion);
                    cmd.Parameters.AddWithValue("matricula", matricula);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;


            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }
            return rpta;
        }

    }
}
