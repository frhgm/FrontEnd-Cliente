﻿using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaAccesoDatos
{
    public class ClienteDAO
    {
        #region "PATRON SINGLETON"
        private static ClienteDAO daoCliente = null;
        private ClienteDAO() { }
        public static ClienteDAO getInstance()
        {
            if (daoCliente == null)
            {
                daoCliente = new ClienteDAO();
            }
            return daoCliente;
        }
        #endregion

        public Cliente AccesoSistema(String user, String pass)
        {
            SqlConnection conexion = null;
            SqlCommand cmd = null;
            Cliente objCliente = null;
            SqlDataReader dr = null;
            try
            {
                conexion = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("spAccesoSistema", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmUser", user);
                cmd.Parameters.AddWithValue("@prmPass", pass);
                conexion.Open();
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    objCliente = new Cliente();
                    objCliente.Rut = Convert.ToInt32(dr["rut_cliente"].ToString());
                    objCliente.Nombre = dr["nombre_cliente"].ToString();
                    objCliente.Apellido = dr["apellido_cliente"].ToString();
                    objCliente.Direccion = dr["direccion"].ToString();
                    objCliente.Telefono = Convert.ToInt32(dr["telefono"].ToString());
                    objCliente.Telefono_Adicional = Convert.ToInt32(dr["telefono_adicional"].ToString());
                    objCliente.Fecha_Nacimiento = Convert.ToDateTime(dr["fecha_nacimiento"].ToString());
                    objCliente.Id_Usuario = Convert.ToInt32(dr["usuario_id_usuario"].ToString());
                }
            }
            catch (Exception ex)
            {
                objCliente = null;
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
            return objCliente;
        }

        public Cliente BuscarCliente(String nroDocumento)
        {
            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            Cliente objCliente = new Cliente();

            try
            {
                con = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("spBuscarEmpleado", con);
                cmd.Parameters.AddWithValue("@prmNroDocumento", nroDocumento);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();

                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    objCliente.Rut = Convert.ToInt32(dr["rut_cliente"].ToString());
                    objCliente.Nombre = dr["nombre_cliente"].ToString();
                    objCliente.Apellido = dr["apellido_cliente"].ToString();
                    objCliente.Direccion = dr["direccion"].ToString();
                    objCliente.Telefono = Convert.ToInt32(dr["telefono"].ToString());
                    objCliente.Telefono_Adicional = Convert.ToInt32(dr["telefono_adicional"].ToString());
                    objCliente.Fecha_Nacimiento = Convert.ToDateTime(dr["fecha_nacimiento"].ToString());
                    objCliente.Id_Usuario = Convert.ToInt32(dr["usuario_id_usuario"].ToString());
                }

            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                con.Close();
            }

            return objCliente;
        }
    }
}