using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntidadesCompartidas;
using System.Data.SqlClient;
using System.Data;


namespace Persistencia
{
    public class PersistenciaUsuarios
    {
        public static void Alta(Usuarios unU)
        {
            SqlConnection oConexion = new SqlConnection(CONEXION.STR);
            SqlCommand oComando = new SqlCommand("AltaUsuario", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@cedula", unU.Cedula);
            oComando.Parameters.AddWithValue("@nombre", unU.Nombre);
            oComando.Parameters.AddWithValue("@nomUsuario", unU.NomUsuario);

            SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;
            oComando.Parameters.Add(oRetorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();

                int oAfectados = (int)oComando.Parameters["@Retorno"].Value;

                if (oAfectados == -1)
                    throw new Exception("Ya existe la cédula");
                else if (oAfectados == -2)
                    throw new Exception("Ya existe el nombre de usuario");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oConexion.Close();
            }
        }

        public static void Modificar(Usuarios unU)
        {
            SqlConnection oConexion = new SqlConnection(CONEXION.STR);
            SqlCommand oComando = new SqlCommand("EditarUsuario", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@cedula", unU.Cedula);
            oComando.Parameters.AddWithValue("nombre", unU.Nombre);
            oComando.Parameters.AddWithValue("nomUsuario", unU.NomUsuario);

            SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;
            oComando.Parameters.Add(oRetorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();

                int oAfectados = (int)oComando.Parameters["@Retorno"].Value;

                if (oAfectados == -1)
                    throw new Exception("No existe la cédula");
                else if (oAfectados == -2)
                    throw new Exception("No existe el nombre de usuario");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oConexion.Close();
            }
        }

        public static void Eliminar(Usuarios unU)
        {
            SqlConnection oConexion = new SqlConnection(CONEXION.STR);
            SqlCommand oComando = new SqlCommand("EliminarUsuario", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@cedula", unU.Cedula);

            SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;
            oComando.Parameters.Add(oRetorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();

                int oAfectados = (int)oComando.Parameters["@Retorno"].Value;

                if (oAfectados == -1)
                    throw new Exception("No existe el usuario");
                else if (oAfectados == -2)
                    throw new Exception("El usuario tiene mensajes asociados");
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                oConexion.Close();
            }
        }

        public static Usuarios Buscar(int pCedula)
        {
            Usuarios U = null;
            SqlDataReader oReader;

            SqlConnection oConexion = new SqlConnection(CONEXION.STR);
            SqlCommand oComando = new SqlCommand("BuscarUsuario", oConexion); 
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@cedula", pCedula);

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();

                if (oReader.Read())
                    U = new Usuarios(Convert.ToInt32(oReader["cedula"]), oReader["nombre"].ToString(), oReader["nomUsuario"].ToString());

                oReader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oConexion.Close();
            }
            return U;
        }

        public static List<Usuarios> ListarUsuarios()
        {
            List<Usuarios> oLista = new List<Usuarios>();
            SqlDataReader oReader;

            SqlConnection oConexion = new SqlConnection(CONEXION.STR);
            SqlCommand oComando = new SqlCommand("ListarUsuarios", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();

                if (oReader.HasRows)
                {
                    while (oReader.Read())
                    {
                        Usuarios U = new Usuarios(Convert.ToInt32(oReader["cedula"]), oReader["nombre"].ToString(), oReader["nomUsuario"].ToString());
                        oLista.Add(U);
                    }
                }
                oReader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oConexion.Close();
            }
            return oLista;
        }
    }
}
