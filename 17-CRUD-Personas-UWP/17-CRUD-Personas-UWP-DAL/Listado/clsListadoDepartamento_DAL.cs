using _07_CRUD_Personas_DAL.Conexion;
using _17_CRUD_Personas_UWP_Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17_CRUD_Personas_UWP_DAL.Listado
{
    public class clsListadoDepartamento_DAL
    {

        public List<clsDepartamento> listadoDep() {

            SqlConnection miConexion;
            List<clsDepartamento> ret = new List<clsDepartamento>();
            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector;
            clsDepartamento odep;
            clsMyConnection connection = new clsMyConnection();

            //Try no obligatorio ya que esta en clase myconnection
            miConexion = connection.getConnection();
            miComando.CommandText = "SELECT * FROM Departamentos";
            miComando.Connection = miConexion;
            miLector = miComando.ExecuteReader();


            if (miLector.HasRows)
            {

                while (miLector.Read())
                {

                    odep = new clsDepartamento();
                    odep.Id = (int)miLector["IDDepartamento"];
                    odep.Nombre = (String)miLector["nombreDepartamento"];
                 
                    ret.Add(odep);

                }
            }


            miLector.Close();
            connection.closeConnection(ref miConexion);

            return ret;
        }
    }
}
