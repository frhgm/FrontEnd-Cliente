﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CapaEntidades;

namespace CapaAccesoDatos
{
    public class BloqueDAO
    {
        #region "PATRON SINGLETON"
        private static BloqueDAO daoBloque = null;
        private BloqueDAO() { }
        public static BloqueDAO getInstance()
        {
            if (daoBloque == null)
            {
                daoBloque = new BloqueDAO();
            }
            return daoBloque;
        }
        #endregion
        /*
        public Reserva RegistrarReserva(Reserva objReserva)
        {
            SqlConnection conexion = Conexion.getInstance().ConexionBD();
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            Reserva objReserva = null;

            try
            {
                cmd = new SqlCommand("spRegistrarHorarioAtencion", conexion);
                cmd.Parameters.AddWithValue("@prmIdMedico", objHorarioAtencion.Medico.IdMedico);
                cmd.Parameters.AddWithValue("@prmHora", objHorarioAtencion.Hora.hora);
                cmd.Parameters.AddWithValue("@prmFecha", objHorarioAtencion.Fecha);
                cmd.CommandType = CommandType.StoredProcedure;

                conexion.Open();

                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    objHorario = new HorarioAtencion()
                    {
                        IdHorarioAtencion = Convert.ToInt32(dr["idHorarioAtencion"].ToString()),
                        Fecha = Convert.ToDateTime(dr["fecha"].ToString()),
                        Hora = new Hora()
                        {
                            IdHora = Convert.ToInt32(dr["idHora"].ToString()),
                            hora = dr["hora"].ToString()
                        },
                        Estado = Convert.ToBoolean(dr["estado"].ToString())
                    };
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Close();
            }

            return objHorario;
        }
        */
        public List<BloqueHora> Listar(int rut)
        {
            SqlConnection conexion = Conexion.getInstance().ConexionBD();
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            List<BloqueHora> Lista = null;

            try
            {
                cmd = new SqlCommand("[spListaHorariosAtencion]", conexion);
                cmd.Parameters.AddWithValue("@prmRut", rut);
                cmd.CommandType = CommandType.StoredProcedure;

                conexion.Open();

                dr = cmd.ExecuteReader();

                Lista = new List<BloqueHora>();

                while (dr.Read())
                {
                    // llenamos los objetos
                    BloqueHora objHora = new BloqueHora();
                    objHora.Hora_Inicio = TimeSpan.Parse(dr["hora_inicio"].ToString());
                    objHora.Hora_Final = TimeSpan.Parse(dr["hora_final"].ToString());

                    Lista.Add(objHora);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
            return Lista;
        }
        /*
        public List<HorarioAtencion> ListarHorarioReservas(Int32 IdEspecialidad, DateTime Fecha)
        {
            SqlConnection conexion = Conexion.getInstance().ConexionBD();
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            List<HorarioAtencion> Lista = null;

            try
            {
                cmd = new SqlCommand("spListarHorariosAtencionPorFecha", conexion);
                cmd.Parameters.AddWithValue("@prmIdEspecialidad", IdEspecialidad);
                cmd.Parameters.AddWithValue("@prmFecha", Fecha);
                cmd.CommandType = CommandType.StoredProcedure;

                conexion.Open();

                dr = cmd.ExecuteReader();

                Lista = new List<HorarioAtencion>();

                while (dr.Read())
                {
                    // llenamos los objetos
                    HorarioAtencion objHorarioAtencion = new HorarioAtencion();
                    Medico objMedico = new Medico();
                    Hora objHora = new Hora();

                    objHora.IdHora = Convert.ToInt32(dr["idHora"].ToString());
                    objHora.hora = dr["hora"].ToString();
                    objHorarioAtencion.Hora = objHora;

                    objMedico.IdMedico = Convert.ToInt32(dr["idMedico"].ToString());
                    objMedico.Nombre = dr["nombres"].ToString();
                    objHorarioAtencion.Medico = objMedico;

                    objHorarioAtencion.IdHorarioAtencion = Convert.ToInt32(dr["idHorarioAtencion"].ToString());
                    objHorarioAtencion.Fecha = Convert.ToDateTime(dr["fecha"].ToString());

                    Lista.Add(objHorarioAtencion);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
            return Lista;
        }

        public bool Eliminar(int idHorarioAtencion)
        {
            SqlConnection conexion = Conexion.getInstance().ConexionBD();
            SqlCommand cmd = null;
            bool ok = false;
            try
            {
                cmd = new SqlCommand("spEliminarHorarioAtencion", conexion);
                cmd.Parameters.AddWithValue("@prmIdHorarioAtencion", idHorarioAtencion);
                cmd.CommandType = CommandType.StoredProcedure;

                conexion.Open();

                cmd.ExecuteNonQuery();

                ok = true;
            }
            catch (Exception ex)
            {
                ok = false;
                throw ex;
            }
            finally
            {
                conexion.Close();
            }

            return ok;
        }


        public bool Editar(HorarioAtencion objHorario)
        {
            SqlConnection conexion = Conexion.getInstance().ConexionBD();
            SqlCommand cmd = null;
            bool ok = false;

            try
            {
                cmd = new SqlCommand("spActualizarHorarioAtencion", conexion);
                cmd.Parameters.AddWithValue("@prmIdMedico", objHorario.Medico.IdMedico);
                cmd.Parameters.AddWithValue("@prmIdHorario", objHorario.IdHorarioAtencion);
                cmd.Parameters.AddWithValue("@prmFecha", objHorario.Fecha);
                cmd.Parameters.AddWithValue("@prmHora", objHorario.Hora.hora);
                cmd.CommandType = CommandType.StoredProcedure;

                conexion.Open();

                cmd.ExecuteNonQuery();

                ok = true;
            }
            catch (Exception ex)
            {
                ok = false;
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
            return ok;
        }
        */
    }
}