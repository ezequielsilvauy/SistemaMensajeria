using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;
using System.Data;
using EntidadesCompartidas;

namespace Persistencia
{
    public class PersistenciaComun
    {
        public static void Alta(Comun pComun)
        {
            SqlConnection oConexion = new SqlConnection(CONEXION.STR);
            SqlCommand oComando = new SqlCommand("AgregarComun", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@CedulaE", pComun.CedulaE.Cedula);
            oComando.Parameters.AddWithValue("@CedulaR", pComun.CedulaR.Cedula);
            oComando.Parameters.AddWithValue("@Asunto", pComun.Asunto);
            oComando.Parameters.AddWithValue("@Texto", pComun.Texto);
            oComando.Parameters.AddWithValue("@FechaHora", pComun.Fechahora);
            oComando.Parameters.AddWithValue("@CodigoInterno", pComun.tipoMensaje.codigoInterno);

            SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;
            oComando.Parameters.Add(oRetorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();

                int oAfectados = (int)oComando.Parameters["@Retorno"].Value;

                if (oAfectados == 0)
                {
                    throw new Exception("No existe el usuario emisor");
                }
                else if (oAfectados == -1)
                {
                    throw new Exception("No existe el usuario receptor");
                }
                else if (oAfectados == -3)
                {
                    throw new Exception("No existe el tipo de mensaje");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
            finally
            {
                oConexion.Close();
            }
        }

        public static List<Comun> ListarEnviadosxTipo(Usuarios pCedulaE, TipoMensaje pTipoMensaje)
        {
            List<Comun> listaEnviados = new List<Comun>();
            SqlDataReader oReader;

            SqlConnection oConexion = new SqlConnection(CONEXION.STR);
            SqlCommand oComando = new SqlCommand("ListarMensajesComunesDeUnUsuario", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@codigoInterno", pTipoMensaje.codigoInterno);
            oComando.Parameters.AddWithValue("@cedulaUsuario", pCedulaE.Cedula);
            oComando.Parameters.AddWithValue("@listado", true);

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();

                if (oReader.HasRows)
                {
                    while (oReader.Read())
                    {
                        Comun C = new Comun(oReader["asunto"].ToString(), oReader["texto"].ToString(), PersistenciaUsuarios.Buscar(Convert.ToInt32(oReader["cedulaE"])), PersistenciaUsuarios.Buscar(Convert.ToInt32(oReader["cedulaR"])),
                            Convert.ToInt32(oReader["numInt"]), Convert.ToDateTime(oReader["fechaHora"]), PersistenciaTipoMensaje.Buscar(oReader["tipoMensaje"].ToString()));
                        listaEnviados.Add(C);
                    }
                }

                oReader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la persistencia: " + ex.Message);
            }
            finally
            {
                oConexion.Close();
            }

            return listaEnviados;
        }

        public static List<Comun> ListarRecibidosxTipo(Usuarios pCedulaR, TipoMensaje pTipoMensaje)
        {
            List<Comun> listaRecibidos = new List<Comun>();
            SqlDataReader oReader;

            SqlConnection oConexion = new SqlConnection(CONEXION.STR);
            SqlCommand oComando = new SqlCommand("ListarMensajesComunesRecibidos", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@codigoInterno", pTipoMensaje.codigoInterno);
            oComando.Parameters.AddWithValue("@cedulaUsuario", pCedulaR.Cedula);
            oComando.Parameters.AddWithValue("@listado", false);

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();

                if (oReader.HasRows)
                {
                    while (oReader.Read())
                    {
                        Comun C = new Comun(oReader["asunto"].ToString(), oReader["texto"].ToString(), PersistenciaUsuarios.Buscar(Convert.ToInt32(oReader["cedulaE"])), PersistenciaUsuarios.Buscar(Convert.ToInt32(oReader["cedulaR"])),
                            Convert.ToInt32(oReader["numInt"]), Convert.ToDateTime(oReader["fechaHora"]), PersistenciaTipoMensaje.Buscar(oReader["tipoMensaje"].ToString()));
                        listaRecibidos.Add(C);
                    }
                }

                oReader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la persistencia: " + ex.Message);
            }
            finally
            {
                oConexion.Close();
            }

            return listaRecibidos;
        }
    }



}
