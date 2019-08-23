using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace Aplicacion_Aboga2.Models
{
    public class BD
    {
        public static string connectionString = "Server=10.128.8.16;Database=Aboga2.0;User ID=usr_aboga;Password=proyecto2019+";

        public static SqlConnection Conectar()
        {
            SqlConnection Conexion = new SqlConnection(connectionString);
            Conexion.Open();
            return Conexion;
        }

        public static void Desconectar(SqlConnection Conexion)
        {
            Conexion.Close();
        }


        public static int ModificarExpediente(Expediente expedientes)
        {
            SqlConnection Conexion = Conectar();
            SqlCommand consulta = Conexion.CreateCommand();
            consulta.CommandText = "sp_modificar_Expedientes";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.Parameters.AddWithValue("@ID_EXPEDIENETES", expedientes.IdExpediente);
            consulta.Parameters.AddWithValue("@ID_TIPO_EXPEDIENTES", expedientes.IdTipoExpediente);
            consulta.Parameters.AddWithValue("@DESCRIPCION", expedientes.Descripcion);
            consulta.Parameters.AddWithValue("@ID_JUZGADO_EXPEDIENTE", expedientes.IdJuzgadoExpediente);
            consulta.Parameters.AddWithValue("@NUMERO_EXPEDIENTES", expedientes.NumeroExpediente);
            consulta.Parameters.AddWithValue("@ESTADO", expedientes.Estado);
            consulta.Parameters.AddWithValue("@CARATULA", expedientes.Caratula);
            int RegsAfectados = consulta.ExecuteNonQuery();
            Desconectar(Conexion);
            return RegsAfectados;
        }



        public static int InsertarExpediente(Expediente expedientes)
        {
            SqlConnection Conexion = Conectar();
            SqlCommand consulta = Conexion.CreateCommand();
            consulta.CommandText = "sp_Crear_cliente_ORIGINAL";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.Parameters.AddWithValue("@ID_EXPEDIENETES", expedientes.IdExpediente);
            consulta.Parameters.AddWithValue("@ID_TIPO_EXPEDIENTES", expedientes.IdTipoExpediente);
            consulta.Parameters.AddWithValue("@DESCRIPCION", expedientes.Descripcion);
            consulta.Parameters.AddWithValue("@ID_JUZGADO_EXPEDIENTE", expedientes.IdJuzgadoExpediente);
            consulta.Parameters.AddWithValue("@NUMERO_EXPEDIENTES", expedientes.NumeroExpediente);
            consulta.Parameters.AddWithValue("@ESTADO", expedientes.Estado);
            consulta.Parameters.AddWithValue("@CARATULA", expedientes.Caratula);
            int RegsAfectados = consulta.ExecuteNonQuery();
            Desconectar(Conexion);
            return RegsAfectados;
        }



        public static List<Expediente> TraerExpedientes()
        {
            /*List<Personaje> ListaPj = new List<Personaje>();*/
            List<Expediente> Lista = new List<Expediente>();
            SqlConnection Conexion = Conectar();
            SqlCommand consulta = Conexion.CreateCommand();
            consulta.CommandText = "sp_Traer_Expedientes";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader dataReader = consulta.ExecuteReader();
            while (dataReader.Read())
            {
                int IdExpedientes = Convert.ToInt32(dataReader["ID_EXPEDIENETES"]);
                int IdTipoExpedientes = Convert.ToInt32(dataReader["ID_TIPO_EXPEDIENTES"]);
                string Descripcion = dataReader["DESCRIPCION"].ToString();
                int IdJuzgadoExpedientes = Convert.ToInt32(dataReader["ID_JUZGADO_EXPEDIENTE"]);
                int NumeroExpedientes = Convert.ToInt32(dataReader["NUMERO_EXPEDIENTES"]);
                int Estado = Convert.ToInt32(dataReader["ESTADO"]);
                string Caratula = dataReader["CARATULA"].ToString();
                Expediente exp = new Expediente(IdExpedientes, IdTipoExpedientes, Descripcion, IdJuzgadoExpedientes, NumeroExpedientes, Estado, Caratula);
                Lista.Add(exp);
            }
            Desconectar(Conexion);
            return Lista;
        }
        public static int Eliminar(int IdExpediente)
        {
            SqlConnection Conexion = Conectar();
            SqlCommand consulta = Conexion.CreateCommand();
            consulta.CommandText = "sp_eliminar_Expedientes";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.Parameters.AddWithValue("id", IdExpediente);
            int RegsAfectados = consulta.ExecuteNonQuery();
            Desconectar(Conexion);
            return RegsAfectados;
        }


        public static Expediente TraerExpediente(int idexpediente)
        {
            /*List<Personaje> ListaPj = new List<Personaje>();*/
            SqlConnection Conexion = Conectar();
            SqlCommand consulta = Conexion.CreateCommand();
            consulta.CommandText = "sp_Traer_Expediente";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.Parameters.AddWithValue("@Id_Expedientes", idexpediente);
            SqlDataReader dataReader = consulta.ExecuteReader();
            Expediente exp=new Expediente();
            while (dataReader.Read())
            {
                int IdExpedientes = Convert.ToInt32(dataReader["ID_EXPEDIENETES"]);
                int IdTipoExpedientes = Convert.ToInt32(dataReader["ID_TIPO_EXPEDIENTES"]);
                string Descripcions = dataReader["DESCRIPCION"].ToString();
                int IdJuzgadoExpedientes = Convert.ToInt32(dataReader["ID_JUZGADO_EXPEDIENTE"]);
                int NumeroExpedientes = Convert.ToInt32(dataReader["NUMERO_EXPEDIENTES"]);
                int Estado = Convert.ToInt32(dataReader["ESTADO"]);
                string Caratula = dataReader["CARATULA"].ToString();
                exp = new Expediente(IdExpedientes, IdTipoExpedientes, Descripcions, IdJuzgadoExpedientes, NumeroExpedientes, Estado, Caratula);
            }
            Desconectar(Conexion);
            return exp;
        }

        public static int ModificarContacto(Contacto contactos)
        {
            SqlConnection Conexion = Conectar();
            SqlCommand consulta = Conexion.CreateCommand();
            consulta.CommandText = "sp_Modificar_Contacto";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.Parameters.AddWithValue("@ID_CONTACTO", contactos.IdContacto);
            consulta.Parameters.AddWithValue("@NOMBRE", contactos.Nombre);
            consulta.Parameters.AddWithValue("@APELLIDO", contactos.Apellido);
            consulta.Parameters.AddWithValue("@NUM_TELEFONO", contactos.NumTelefono);
            consulta.Parameters.AddWithValue("@ESTADO", contactos.Estado);
            int RegsAfectados = consulta.ExecuteNonQuery();
            Desconectar(Conexion);
            return RegsAfectados;
        }
        public static List<Contacto> TraerContactos()
        {
            /*List<Personaje> ListaPj = new List<Personaje>();*/
            List<Contacto> Lista = new List<Contacto>();
            SqlConnection Conexion = Conectar();
            SqlCommand consulta = Conexion.CreateCommand();
            consulta.CommandText = "sp_Traercontactos";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader dataReader = consulta.ExecuteReader();
            while (dataReader.Read())
            {
                int IdContacto = Convert.ToInt32(dataReader["ID_CONTACTO"]);
                string Nombre = dataReader["NOMBRE"].ToString();
                string Apellido = dataReader["APELLIDO"].ToString();
                int NumeroTelefono = Convert.ToInt32(dataReader["NUM_TELEFONO"]);
                bool Estado = Convert.ToBoolean(dataReader["ESTADO"]);

                Contacto cont = new Contacto(IdContacto, Nombre, Apellido, NumeroTelefono, Estado);
                Lista.Add(cont);
            }
            Desconectar(Conexion);
            return Lista;
        }
        public static int EliminarContactos(int Idcontacto)
        {
            SqlConnection Conexion = Conectar();
            SqlCommand consulta = Conexion.CreateCommand();
            consulta.CommandText = "sp_eliminar_Contacto";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.Parameters.AddWithValue("@id", Idcontacto);
            int RegsAfectados = consulta.ExecuteNonQuery();
            Desconectar(Conexion);
            return RegsAfectados;
        }

        public static Contacto TraerContacto(int id)
        {
            SqlConnection Conexion = Conectar();
            SqlCommand consulta = Conexion.CreateCommand();
            consulta.CommandText = "sp_Traer_Contacto";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            Contacto cont = new Contacto();
            consulta.Parameters.AddWithValue("@id_contacto", id);
            SqlDataReader dataReader = consulta.ExecuteReader();
            if (dataReader.Read())
            {
                int IdContacto = Convert.ToInt32(dataReader["ID_CONTACTO"]);
                string Nombre = dataReader["NOMBRE"].ToString();
                string Apellido = dataReader["APELLIDO"].ToString();
                int NumeroTelefono = Convert.ToInt32(dataReader["NUM_TELEFONO"]);
                bool Estado = Convert.ToBoolean(dataReader["ESTADO"]);

                cont = new Contacto(IdContacto, Nombre, Apellido, NumeroTelefono, Estado);

            }
            Desconectar(Conexion);
            return cont;
        }

        public static int InsertarContacto(Contacto contactos)
        {
            SqlConnection Conexion = Conectar();
            SqlCommand consulta = Conexion.CreateCommand();
            consulta.CommandText = "sp_CrearContacto";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.Parameters.AddWithValue("@ID_CONTACTO", contactos.IdContacto);
            consulta.Parameters.AddWithValue("@NOMBRE", contactos.Nombre);
            consulta.Parameters.AddWithValue("@APELLIDO", contactos.Apellido);
            consulta.Parameters.AddWithValue("@NUM_TELEFONO", contactos.NumTelefono);
            consulta.Parameters.AddWithValue("@ESTADO", contactos.Estado);
            int RegsAfectados = consulta.ExecuteNonQuery();
            Desconectar(Conexion);
            return RegsAfectados;
        }




        public static int InsertarFojas(ExpedienteFojas fojas)
        {
            SqlConnection Conexion = Conectar();
            SqlCommand consulta = Conexion.CreateCommand();
            consulta.CommandText = "SP_INSERTAR_FOJA";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.Parameters.AddWithValue("@FECHA_INICIO",fojas.FechaInicio);
            consulta.Parameters.AddWithValue("@FECHA_FIN", fojas.FechaFin);
            consulta.Parameters.AddWithValue("@ESTADO_ESPECIFICO", fojas.EstadoEspecifico);
            consulta.Parameters.AddWithValue("@DESCRIPCION", fojas.Descripcion);
            int RegsAfectados = consulta.ExecuteNonQuery();
            Desconectar(Conexion);
            return RegsAfectados;
        }

        public static int EliminarFojas(int idFojas)
        {
            SqlConnection Conexion = Conectar();
            SqlCommand consulta = Conexion.CreateCommand();
            consulta.CommandText = "SP_ELIMINAR_FOJAS";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.Parameters.AddWithValue("@ID_EXPEDIENTE_FOJAS", idFojas);
            int RegsAfectados = consulta.ExecuteNonQuery();
            Desconectar(Conexion);
            return RegsAfectados;
        }

        public static ExpedienteFojas TraerExpediente_fojas(int id)
        {
            SqlConnection Conexion = Conectar();
            SqlCommand consulta = Conexion.CreateCommand();
            consulta.CommandText = "SP_TRAERFOJA";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            ExpedienteFojas Foj = new ExpedienteFojas();
            consulta.Parameters.AddWithValue("@ID_FOJA", id);
            SqlDataReader dataReader = consulta.ExecuteReader();
            if (dataReader.Read())
            {
                int IdFojas = Convert.ToInt32(dataReader["ID_FOJAS"]);
                int IdExp = Convert.ToInt32(dataReader["ID_EXPEDIENTE"]);
                DateTime FechaInicio = Convert.ToDateTime(dataReader["FECHA_INICIO"]);
                DateTime FechaFin = Convert.ToDateTime(dataReader["FECHA_FIN"]);
                string EstadoEsp = dataReader["ESTADO_ESPECIFICO"].ToString();
                string Descripcion = dataReader["DESCRIPCION"].ToString();
                

                Foj = new ExpedienteFojas(IdFojas, IdExp, FechaInicio, FechaFin, EstadoEsp, Descripcion);

            }
            Desconectar(Conexion);
            return Foj;
        }

        public static List<ExpedienteFojas>TraerLasExpFojas(int id)
        {
            /*List<Personaje> ListaPj = new List<Personaje>();*/
            List<ExpedienteFojas> Lista = new List<ExpedienteFojas>();
            SqlConnection Conexion = Conectar();
            SqlCommand consulta = Conexion.CreateCommand();
            consulta.CommandText = "SP_TRAERFOJASDONDE";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.Parameters.AddWithValue("@ID_EXPEDIENTE",id );
            SqlDataReader dataReader = consulta.ExecuteReader();
            while (dataReader.Read())
            {
                int IdFojas = Convert.ToInt32(dataReader["ID_FOJAS"]);
                int IdExp = Convert.ToInt32(dataReader["ID_EXPEDIENTE"]);
                DateTime FechaInicio = Convert.ToDateTime(dataReader["FECHA_INICIO"]);
                DateTime FechaFin = Convert.ToDateTime(dataReader["FECHA_FIN"]);
                string EstadoEsp = dataReader["ESTADO_ESPECIFICO"].ToString();
                string Descripcion = dataReader["DESCRIPCION"].ToString();


                ExpedienteFojas Foj = new ExpedienteFojas(IdFojas, IdExp, FechaInicio, FechaFin, EstadoEsp, Descripcion);

                     Lista.Add(Foj);
            }
            Desconectar(Conexion);
            return Lista;
        }

        public static int ModificarExpFojas(ExpedienteFojas fojas)
        {
            SqlConnection Conexion = Conectar();
            SqlCommand consulta = Conexion.CreateCommand();
            consulta.CommandText = "sp_Modificar_Contacto";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.Parameters.AddWithValue("@ID_FOJA", fojas.IdFojas);
            consulta.Parameters.AddWithValue("@FECHA_INICIO", fojas.FechaInicio);
            consulta.Parameters.AddWithValue("@FECHA_FIN", fojas.FechaFin);
            consulta.Parameters.AddWithValue("@ESTADO_ESPECIFICO", fojas.EstadoEspecifico);
            consulta.Parameters.AddWithValue("@DESCRIPCION", fojas.Descripcion);
            int RegsAfectados = consulta.ExecuteNonQuery();
            Desconectar(Conexion);
            return RegsAfectados;
        }





    }
}