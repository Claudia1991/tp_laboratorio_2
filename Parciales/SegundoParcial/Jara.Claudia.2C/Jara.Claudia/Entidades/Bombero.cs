using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;

namespace Entidades
{
    public delegate void FinDeSalida(int bomberoIndex);
    [Serializable]
    public class Bombero : IArchivos<Bombero>, IArchivos<string>
    {
        private string nombre;
        private List<Salidas> salidas;
        public event FinDeSalida MarcarFin;

        public Bombero() { }
        public Bombero(string nombre)
        {
            this.nombre = nombre;
            this.salidas = new List<Salidas>();
        }

        public string Nombre { get => this.nombre; set => this.nombre = value;}

        public  void Guardar(Bombero info) 
        {
            Stream stream;
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            using (stream = new FileStream("bombero.dat", FileMode.Create))
            {
                binaryFormatter.Serialize(stream, info);
            }
        }

        public  Bombero Leer()
        {
            Bombero bombero;
            Stream stream;
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            using (stream = new FileStream("bombero.dat", FileMode.Open))
            {
                bombero = (Bombero)binaryFormatter.Deserialize(stream);
            }
            return bombero;
        }

        public void AtenderSalida(object bomberoIndex)
        {
            this.salidas.Add(new Salidas());
            Random random = new Random();
            int segundosSalida = random.Next(2,4);
            Thread.Sleep(segundosSalida*1000);
            int ultimaSalida = this.salidas.Count - 1;
            this.salidas[ultimaSalida].FinalizarSalida();
            ((IArchivos<string>)this).Guardar(string.Format("Se finalizo la salida , rey. Bombero: {0}", this.nombre));
            if (!object.ReferenceEquals(this.MarcarFin, null))
            {
                this.MarcarFin.Invoke((int)bomberoIndex);
            }
        }

        void IArchivos<string>.Guardar(string info)
        {
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["20201119spDB"].ConnectionString);
            try
            {
                string sqlQuery = "insert into dbo.log values (@entrada, @alumno)";
                
                SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                sqlCommand.Parameters.AddWithValue("entrada", info);
                sqlCommand.Parameters.AddWithValue("alumno", "Claudia Jara");
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
            }
            finally
            {
                if (sqlConnection != null && sqlConnection.State == System.Data.ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }
        }

        string IArchivos<string>.Leer()
        {
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["20201119spDB"].ConnectionString);
            StringBuilder stringBuilder = new StringBuilder();
            try
            {
                string sqlQuery = "select * from dbo.log";
                
                SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);

                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    stringBuilder.Append(string.Concat("Id: ",Convert.ToInt32(sqlDataReader[0]), 
                        "Entrada: ", Convert.ToString(sqlDataReader[1]), 
                        "Alumno", Convert.ToString(sqlDataReader[2])));
                }

            }
            finally
            {
                if (sqlConnection != null && sqlConnection.State == System.Data.ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }
            return stringBuilder.ToString();
        }
    }
}
