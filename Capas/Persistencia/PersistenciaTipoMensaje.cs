using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntidadesCompartidas;
using System.Data.SqlClient;
using System.Data;
namespace Persistencia
{
    public class PersistenciaTipoMensaje
    {
        public static void Alta(TipoMensaje unT)
        {
            SqlConnection oConexion = new SqlConnection(CONEXION.STR);
            SqlCommand oComando = new SqlCommand("AltaTipoMensaje", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@codigoInterno", unT.codigoInterno);
            oComando.Parameters.AddWithValue("@nombreTipo", unT.nombreTipo);

            SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;
            oComando.Parameters.Add(oRetorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();

                int oAfectados = (int)oComando.Parameters["@Retorno"].Value;

                if (oAfectados == -1)
                    throw new Exception("Ya existe el codigo interno");
                else if (oAfectados == -2)
                    throw new Exception("Ya existe el nombre del tipo de mensaje");
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

        public static void Modificar(TipoMensaje unT)
        {
            SqlConnection oConexion = new SqlConnection(CONEXION.STR);
            SqlCommand oComando = new SqlCommand("EditarTipoMensaje", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@codigoInterno", unT.codigoInterno);
            oComando.Parameters.AddWithValue("nombre", unT.nombreTipo);

            SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;
            oComando.Parameters.Add(oRetorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();

                int oAfectados = (int)oComando.Parameters["@Retorno"].Value;

                if (oAfectados == -1)
                    throw new Exception("No existe el tipo de mensaje");
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

        public static void Eliminar(TipoMensaje unT)
        {
            SqlConnection oConexion = new SqlConnection(CONEXION.STR);
            SqlCommand oComando = new SqlCommand("EliminarTipoMensaje", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@codigoInterno", unT.codigoInterno);

            SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;
            oComando.Parameters.Add(oRetorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();

                int oAfectados = (int)oComando.Parameters["@Retorno"].Value;

                if (oAfectados == -1)
                    throw new Exception("No existe el tipo de mensaje");
                else if (oAfectados == -2)
                    throw new Exception("El tipo de mensaje tiene mensajes asociados");
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

        public static TipoMensaje Buscar(string pCodigoInterno)
        {
            TipoMensaje T = null;
            SqlDataReader oReader;

            SqlConnection oConexion = new SqlConnection(CONEXION.STR);
            SqlCommand oComando = new SqlCommand("Exec BuscarTipoMensaje " + pCodigoInterno, oConexion);

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();

                if (oReader.Read())
                    T = new TipoMensaje(oReader["codigoInterno"].ToString(), oReader["nombreTipo"].ToString());

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
            return T;
        }

        public static List<TipoMensaje> ListarTipoMensaje(string codigoInterno)
        {
            List<TipoMensaje> oLista = new List<TipoMensaje>();
            SqlDataReader oReader;

            SqlConnection oConexion = new SqlConnection(CONEXION.STR);
            SqlCommand oComando = new SqlCommand("Exec ListarTipoMensaje ", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();

                if (oReader.HasRows)
                {
                    while (oReader.Read())
                    {
                        TipoMensaje T = new TipoMensaje(oReader["codigoInterno"].ToString(), oReader["nombreTipo"].ToString());
                        oLista.Add(T);
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
