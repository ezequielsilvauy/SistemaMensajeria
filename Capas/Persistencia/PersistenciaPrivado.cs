using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;
using System.Data;
using EntidadesCompartidas;
namespace Persistencia
{
    public class PersistenciaPrivado
    {
        public static void Alta(Privado pPrivado)
        {
            SqlConnection oConexion = new SqlConnection(CONEXION.STR);
            SqlCommand oComando = new SqlCommand("AgregarPrivado", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@CedulaE", pPrivado.CedulaE.Cedula);
            oComando.Parameters.AddWithValue("@CedulaR", pPrivado.CedulaR.Cedula);
            oComando.Parameters.AddWithValue("@Asunto", pPrivado.Asunto);
            oComando.Parameters.AddWithValue("@Texto", pPrivado.Texto);
            oComando.Parameters.AddWithValue("@FechaHora", pPrivado.Fechahora);
            oComando.Parameters.AddWithValue("@FechaCad", pPrivado.FechaCad);

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
                    throw new Exception("La fecha de caducación debe ser posterior a hoy");
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

        public static List<Privado> ListarEnviados(Usuarios pCedulaE)
        {
            List<Privado> listaEnviados = new List<Privado>();
            SqlDataReader oReader;

            SqlConnection oConexion = new SqlConnection(CONEXION.STR);
            SqlCommand oComando = new SqlCommand("ListarMensajesPrivadosEnviados", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

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
                        Privado P = new Privado(oReader["asunto"].ToString(), oReader["texto"].ToString(), PersistenciaUsuarios.Buscar(Convert.ToInt32(oReader["cedulaE"])), PersistenciaUsuarios.Buscar(Convert.ToInt32(oReader["cedulaR"])),
                            Convert.ToDateTime(oReader["fechaCad"]), Convert.ToInt32(oReader["numInt"]), Convert.ToDateTime(oReader["fechaHora"]));
                        listaEnviados.Add(P);
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

        public static List<Privado> ListarRecibidos(Usuarios pCedulaR)
        {
            List<Privado> listaRecibidos = new List<Privado>();
            SqlDataReader oReader;

            SqlConnection oConexion = new SqlConnection(CONEXION.STR);
            SqlCommand oComando = new SqlCommand("ListarMensajesPrivadosRecibidos", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

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
                        Privado P = new Privado(oReader["asunto"].ToString(), oReader["texto"].ToString(), PersistenciaUsuarios.Buscar(Convert.ToInt32(oReader["cedulaE"])), PersistenciaUsuarios.Buscar(Convert.ToInt32(oReader["cedulaR"])),
                            Convert.ToDateTime(oReader["fechaCad"]), Convert.ToInt32(oReader["numInt"]), Convert.ToDateTime(oReader["fechaHora"]));
                        listaRecibidos.Add(P);
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
