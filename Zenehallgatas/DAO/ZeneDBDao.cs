using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Zenehallgatas.Model;

namespace Zenehallgatas.DAO
{
    internal class ZeneDBDao : IZeneDao
    {
        public static readonly string S_CONNECTION_STRING = @"Data Source= db/zenelista.db";

        public bool addZene(Zene zene)
        {
            if(zene == null) return false;

            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(S_CONNECTION_STRING))
                {
                    conn.Open();

                    using (SQLiteCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "INSERT INTO zene (id, cim, eloado, kiadas, hossz, prioritas)" +
                            "VALUES (NULL, @cim, @eloado, @kiadas, @hossz, @prioritas);";

                        cmd.Parameters.AddWithValue("@cim", zene.Cim);
                        cmd.Parameters.AddWithValue("@eloado", zene.Eloado);
                        cmd.Parameters.AddWithValue("@kiadas", zene.Kiadas);
                        cmd.Parameters.AddWithValue("@hossz", zene.Hossz);
                        cmd.Parameters.AddWithValue("@prioritas", zene.Prioritas);

                        int row = cmd.ExecuteNonQuery();

                       if(row != 1) return false;
                    }

                    conn.Close();
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool modifyZene(Zene zene)
        {
            if(zene == null) return true;

            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(S_CONNECTION_STRING))
                {
                    conn.Open();

                    using (SQLiteCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "UPDATE zene SET prioritas = @prioritas WHERE id = @id;";

                        cmd.Parameters.AddWithValue("@id", zene.ID);
                        cmd.Parameters.AddWithValue("@prioritas", zene.Prioritas);

                        int row = cmd.ExecuteNonQuery();

                        if (row != 1) return false;
                    }

                    conn.Close();
                }

                return true;
            }
            catch (Exception ex)
            {
                return false ;
            }
        }

        public Zene getZeneById(int zeneId)
        {
            return new Zene();
        }

        public List<Zene> getAllZene()
        {
            List<Zene> zenek = new List<Zene>();

            using (SQLiteConnection conn = new SQLiteConnection(S_CONNECTION_STRING))
            {
                conn.Open();

                using (SQLiteCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM zene ORDER BY prioritas DESC";

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        zenek = this.getAllZeneFromReader(reader);
                    }
                }

                conn.Close();
            }
            return zenek;
        }

        private List<Zene> getAllZeneFromReader(SQLiteDataReader reader)
        {
            List<Zene> zenek = new List<Zene>();

            while (reader.Read())
            {
                Zene zene = new Zene();
                zene.ID = reader.GetInt32(reader.GetOrdinal("id"));
                zene.Cim = reader.GetString(reader.GetOrdinal("cim"));
                zene.Eloado = reader.GetString(reader.GetOrdinal("eloado"));
                zene.Kiadas = reader.GetInt32(reader.GetOrdinal("kiadas"));
                zene.Hossz = reader.GetInt32(reader.GetOrdinal("hossz"));
                zene.Prioritas = reader.GetInt32(reader.GetOrdinal("prioritas"));

                zenek.Add(zene);
            }

            return zenek;
        }
    }
}
