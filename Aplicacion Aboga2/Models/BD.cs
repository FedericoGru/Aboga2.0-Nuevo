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



        public static void InsertarExpediente(Expediente expedientes)
        {
            int a = 0;
            SqlConnection Conexion = Conectar();
            SqlCommand consulta = Conexion.CreateCommand();
            consulta.CommandText = "sp_Crear_expediente";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            //consulta.Parameters.AddWithValue("@ID_EXPEDIENETES", expedientes.IdExpediente);
            consulta.Parameters.AddWithValue("@ID_TIPO_EXPEDIENTES", expedientes.IdTipoExpediente);
            consulta.Parameters.AddWithValue("@DESCRIPCION", expedientes.Descripcion);
            consulta.Parameters.AddWithValue("@ID_JUZGADO_EXPEDIENTE", expedientes.IdJuzgadoExpediente);
            consulta.Parameters.AddWithValue("@NUMERO_EXPEDIENTES", expedientes.NumeroExpediente);
            consulta.Parameters.AddWithValue("@ESTADO", expedientes.Estado);
            consulta.Parameters.AddWithValue("@CARATULA", expedientes.Caratula);
            consulta.ExecuteNonQuery();
            Desconectar(Conexion);

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
                string Descripcions = dataReader["DESCRIPCION"].ToString();
                int IdJuzgadoExpedientes = Convert.ToInt32(dataReader["ID_JUZGADO_EXPEDIENTE"]);
                int NumeroExpedientes = Convert.ToInt32(dataReader["NUMERO_EXPEDIENTES"]);
                int Estado = Convert.ToInt32(dataReader["ESTADO"]);
                string Caratula = dataReader["CARATULA"].ToString();
                Expediente exp = new Expediente(IdExpedientes, IdTipoExpedientes, Descripcions, IdJuzgadoExpedientes, NumeroExpedientes, Estado, Caratula);
                Lista.Add(exp);
            }
            Desconectar(Conexion);
            return Lista;
        }

        public static List<Juzgado> TraerJuzgados()
        {
            List<Juzgado> Lista = new List<Juzgado>();
            SqlConnection Conexion = Conectar();
            SqlCommand consulta = Conexion.CreateCommand();
            consulta.CommandText = "sp_Traer_Juzgados";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader dataReader = consulta.ExecuteReader();
            while (dataReader.Read())
            {
                int IdJuzgado = Convert.ToInt32(dataReader["ID_JUZGADO"]);
                int NunJuz = Convert.ToInt32(dataReader["NUMERO_JUZGADO"]);
                string Radicacion = dataReader["RADICACION"].ToString();
                Juzgado juz = new Juzgado(IdJuzgado, NunJuz, Radicacion);
                Lista.Add(juz);
            }
            Desconectar(Conexion);
            return Lista;
        }
        public static Juzgado TraerUnJuzgado(int idJuzgado)
        {
            SqlConnection Conexion = Conectar();
            SqlCommand consulta = Conexion.CreateCommand();
            consulta.CommandText = "sp_Traer_Un_Juzgado";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.Parameters.AddWithValue("@Id_Juzgado", idJuzgado);
            SqlDataReader dataReader = consulta.ExecuteReader();
            Juzgado Juz = new Juzgado();
            while (dataReader.Read())
            {
                int IdJuzgado = Convert.ToInt32(dataReader["ID_JUZGADO"]);
                int NunJuz = Convert.ToInt32(dataReader["NUMERO_JUZGADO"]);
                string Radicacion = dataReader["RADICACION"].ToString();

                Juz = new Juzgado(IdJuzgado, NunJuz, Radicacion);
            }
            Desconectar(Conexion);
            return Juz;
        }
        public static ExpedienteContacto TraerExpedientePorContacto (int IdExpedienteContacto)
        {
            SqlConnection Conexion = Conectar();
            SqlCommand consulta = Conexion.CreateCommand();
            consulta.CommandText = "TraerExpedientePorContacto";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.Parameters.AddWithValue("@pIdContacto", IdExpedienteContacto);
            SqlDataReader dataReader = consulta.ExecuteReader();
            ExpedienteContacto ExpCon = new ExpedienteContacto();
            while (dataReader.Read())
            {
                int IdExpCon = Convert.ToInt32(dataReader["ID_EXPEDIENTE_CONTACTO"]);
                int IdExp = Convert.ToInt32(dataReader["ID_EXPEDIENTE"]);
                int IdCon = Convert.ToInt32(dataReader["ID_CONTACTO"]);
                int IdTipoCon = Convert.ToInt32(dataReader["ID_TIPO_CONTACTO"]);

                ExpCon = new ExpedienteContacto(IdExpCon, IdExp, IdCon, IdTipoCon);
            }
            Desconectar(Conexion);
            return ExpCon;
        }
        /*public static Juzgado TraerUnJuzgado(int idJuzgado)
        {
            SqlConnection Conexion = Conectar();
            SqlCommand consulta = Conexion.CreateCommand();
            consulta.CommandText = "sp_Traer_Juzgado";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.Parameters.AddWithValue("@Id_Juzgado", idJuzgado);
            SqlDataReader dataReader = consulta.ExecuteReader();
            Juzgado Juz = new Juzgado();
            while (dataReader.Read())
            {
                int IdJuzgado = Convert.ToInt32(dataReader["ID_JUZGADO"]);
                int NunJuz = Convert.ToInt32(dataReader["NUMERO_JUZGADO"]);
                string Radicacion = dataReader["RADICACION"].ToString();

                Juz = new Juzgado(IdJuzgado, NunJuz, Radicacion);
            }
            Desconectar(Conexion);
            return Juz;
        }*/
        public static List<Tipo_de_expediente> TraerTipoDeExpedientes()
        {
            List<Tipo_de_expediente> Lista = new List<Tipo_de_expediente>();
            SqlConnection Conexion = Conectar();
            SqlCommand consulta = Conexion.CreateCommand();
            consulta.CommandText = "sp_Traer_Tipos_de_Expedientes";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader dataReader = consulta.ExecuteReader();
            while (dataReader.Read())
            {
                int IdTipoExp = Convert.ToInt32(dataReader["ID_TIPO_EXPEDIENTES"]);
                string TipoExp = dataReader["TIPO_EXPEDIENTE"].ToString();
                Tipo_de_expediente TipExp = new Tipo_de_expediente(IdTipoExp, TipoExp);
                Lista.Add(TipExp);
            }
            Desconectar(Conexion);
            return Lista;
        }
        public static Tipo_de_expediente TraerUnTipoDeExpediente(int Id)
        {
            
            SqlConnection Conexion = Conectar();
            SqlCommand consulta = Conexion.CreateCommand();
            consulta.CommandText = "sp_Traer_Tipo_de_Expediente";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.Parameters.AddWithValue("@Id_Tipo_De_Expediente", Id);
            SqlDataReader dataReader = consulta.ExecuteReader();
            Tipo_de_expediente TipExp = new Tipo_de_expediente();
            while (dataReader.Read())
            {
                int IdTipoExp= Convert.ToInt32(dataReader["ID_TIPO_EXPEDIENTES"]);
                string TipoExp = dataReader["TIPO_EXPEDIENTE"].ToString();
                Tipo_de_expediente tipExp = new Tipo_de_expediente(IdTipoExp, TipoExp);
            }
            Desconectar(Conexion);
            return TipExp;
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
        public static int ModificarContacto(Contactos contactos)
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
        public static List<Contactos> TraerContactos()
        {
            /*List<Personaje> ListaPj = new List<Personaje>();*/
            List<Contactos> Lista = new List<Contactos>();
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

                Contactos cont = new Contactos(IdContacto, Nombre, Apellido, NumeroTelefono, Estado);
                Lista.Add(cont);
            }
            Desconectar(Conexion);
            return Lista;
        }
        public static int EliminarContactos(Contactos contactos)
        {
            SqlConnection Conexion = Conectar();
            SqlCommand consulta = Conexion.CreateCommand();
            consulta.CommandText = "sp_eliminar_Contacto";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.Parameters.AddWithValue("@id", contactos.IdContacto);
            int RegsAfectados = consulta.ExecuteNonQuery();
            Desconectar(Conexion);
            return RegsAfectados;
        }

        public static Contactos TraerContacto(int id)
        {
            SqlConnection Conexion = Conectar();
            SqlCommand consulta = Conexion.CreateCommand();
            consulta.CommandText = "sp_Traer_Contacto";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            Contactos cont = new Contactos();
            consulta.Parameters.AddWithValue("@id_contacto", id);
            SqlDataReader dataReader = consulta.ExecuteReader();
            if (dataReader.Read())
            {
                int IdContacto = Convert.ToInt32(dataReader["ID_CONTACTO"]);
                string Nombre = dataReader["NOMBRE"].ToString();
                string Apellido = dataReader["APELLIDO"].ToString();
                int NumeroTelefono = Convert.ToInt32(dataReader["NUM_TELEFONO"]);
                bool Estado = Convert.ToBoolean(dataReader["ESTADO"]);

                cont = new Contactos(IdContacto, Nombre, Apellido, NumeroTelefono, Estado);

            }
            Desconectar(Conexion);
            return cont;
        }


        public static int InsertarContacto(Contactos contactos)
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
    }
}