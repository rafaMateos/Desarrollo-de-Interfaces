using EjercicioPreExamen_UI_UWP.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioPreExamen_UI_UWP.BD
{
    public class clsListados
    {

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<clsCategoria> listadoCategoria() {

            List<clsCategoria> lista = new List<clsCategoria>();
            clsCategoria oCategoria = null;

            clsMyConnection gestoraConexion = new clsMyConnection();
            SqlConnection conexion = null;

            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector = null;

            try
            { //try no obligatorio ya que lo controlamos en la clase clsMyConnection


                //Obtenemos una conexion abierta
                conexion = gestoraConexion.getConnection();

                //Definir los parametros del comando
                miComando.CommandText = "SELECT * FROM categorias";
                miComando.Connection = conexion;
                miLector = miComando.ExecuteReader();

                //Si hay lineas en el lector
                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        oCategoria = new clsCategoria();

                        //Definir los atributos
                        oCategoria.idCategoria = (int)miLector["idCategoria"];
                        oCategoria.nombreCategoria = (String)miLector["nombreCategoria"];
                       

                        //Annanir a la lista
                        lista.Add(oCategoria);
                    }
                }

            }
            catch (SqlException exSql)
            {
                throw exSql;
            }
            finally
            {

                miLector.Close();
                gestoraConexion.closeConnection(ref conexion);
            }

            return lista;

        }

        public List<clsPersonaje> listaPersonajesID(int id)
        {

            List<clsPersonaje> lista = new List<clsPersonaje>();

            clsPersonaje oPer = null;

            clsMyConnection gestoraConexion = new clsMyConnection();
            SqlConnection conexion = null;

            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector = null;

            try
            { //try no obligatorio ya que lo controlamos en la clase clsMyConnection


                //Obtenemos una conexion abierta
                conexion = gestoraConexion.getConnection();

                SqlParameter param = new SqlParameter();
                param.ParameterName = "@id";
                param.SqlDbType = System.Data.SqlDbType.Int;
                param.Value = id;
                miComando.Parameters.Add(param);

                //Definir los parametros del comando
                miComando.CommandText = "SELECT * FROM personajes WHERE idCategoria = @id";

                //Añadir un parametro version larga

               
                //*/

                //Añadir un parametro version corta
                //miComando.Parameters.Add("@IDPersona", System.Data.SqlDbType.Int).Value = oPersona.nombre;

                miComando.Connection = conexion;
                miLector = miComando.ExecuteReader();

                //Si hay lineas en el lector
                if (miLector.HasRows)
                {
                    while (miLector.Read()) {

                        oPer = new clsPersonaje();

                        //Definir los atributos
                        oPer.idPersonaje = (int)miLector["idPersonaje"];
                        oPer.nombrePersonaje = (string)miLector["nombre"];
                        oPer.alias = (string)miLector["alias"];
                        oPer.vida = (double)miLector["vida"];
                        oPer.regeneracion = (double)miLector["regeneracion"];
                        oPer.danno = (double)miLector["danno"];
                        oPer.armadura = (double)miLector["armadura"];
                        oPer.velAtaque = (double)miLector["velAtaque"];
                        oPer.resistencia = (double)miLector["resistencia"];
                        oPer.velMovimiento = (double)miLector["velMovimiento"];
                        oPer.idCategoria = (int)miLector["idCategoria"];
                        lista.Add(oPer);

                    }

                  



                }

            }
            catch (SqlException exSql)
            {
                throw exSql;
            }
            finally
            {

                miLector.Close();
                gestoraConexion.closeConnection(ref conexion);
            }

            return lista;


        }


        public List<clsPersonaje> ListadoPersonajes()
        {

            List<clsPersonaje> lista = new List<clsPersonaje>();
            clsPersonaje oPer = null;

            clsMyConnection gestoraConexion = new clsMyConnection();
            SqlConnection conexion = null;

            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector = null;

            try
            { //try no obligatorio ya que lo controlamos en la clase clsMyConnection


                //Obtenemos una conexion abierta
                conexion = gestoraConexion.getConnection();

                //Definir los parametros del comando
                miComando.CommandText = "SELECT * FROM personajes";
                miComando.Connection = conexion;
                miLector = miComando.ExecuteReader();

                //Si hay lineas en el lector
                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        oPer = new clsPersonaje();

                        //Definir los atributos
                        oPer.idPersonaje = (int)miLector["idPersonaje"];
                        oPer.nombrePersonaje = (string)miLector["nombre"];
                        oPer.alias = (string)miLector["alias"];
                        oPer.vida = (double)miLector["vida"];
                        oPer.regeneracion = (double)miLector["regeneracion"];
                        oPer.danno = (double)miLector["danno"];
                        oPer.armadura = (double)miLector["armadura"];
                        oPer.velAtaque = (double)miLector["velAtaque"];
                        oPer.resistencia = (double)miLector["resistencia"];
                        oPer.velMovimiento = (double)miLector["velMovimiento"];
                        oPer.idCategoria = (int)miLector["idCategoria"];
                        lista.Add(oPer);
                    }
                }

            }
            catch (SqlException exSql)
            {
                throw exSql;
            }
            finally
            {

                miLector.Close();
                gestoraConexion.closeConnection(ref conexion);
            }

            return lista;

        }


        public clsPersonaje BuscarPerPorID_DAL(int id)
        {

            SqlConnection miConexion;
            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector;
            clsPersonaje oPer = new clsPersonaje();
            clsMyConnection connection = new clsMyConnection();


            miConexion = connection.getConnection();

            miComando.CommandText = "SELECT * FROM personajes where idPersonaje = @id";
            miComando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;


            miComando.Connection = miConexion;
            miLector = miComando.ExecuteReader();




            if (miLector.HasRows)
            {

                miLector.Read();
                oPer.idPersonaje = (int)miLector["idPersonaje"];
                oPer.nombrePersonaje = (string)miLector["nombre"];
                oPer.alias = (string)miLector["alias"];
                oPer.vida = (double)miLector["vida"];
                oPer.regeneracion = (double)miLector["regeneracion"];
                oPer.danno = (double)miLector["danno"];
                oPer.armadura = (double)miLector["armadura"];
                oPer.velAtaque = (double)miLector["velAtaque"];
                oPer.resistencia = (double)miLector["resistencia"];
                oPer.velMovimiento = (double)miLector["velMovimiento"];
                oPer.idCategoria = (int)miLector["idCategoria"];

            }


            miLector.Close();
            connection.closeConnection(ref miConexion);

            return oPer;

        }

        }



    }

