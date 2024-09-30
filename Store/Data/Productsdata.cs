
using Store.Connection;
using Store.Model;
using System.Data.SqlClient;
using Store.Data;

namespace Store.Data

{
    public class Productsdata
    {
        BDConnection conn = new BDConnection();
        public async Task<List<Modelstoredb>> showproducts()
        {
            var lista = new List<Modelstoredb>();
            using (var sql = new SqlConnection(conn.SQLchain()))
            {
                using (var cmd = new SqlCommand("showeverything", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var mproducts = new Modelstoredb();
                            mproducts.id = (int)reader["id"];
                            mproducts.price = (decimal)reader["price"];
                            mproducts.description = (string)reader["description"];
                            lista.Add(mproducts);

                        }
                    }
                }
            }
            return lista;
        }

        public async Task ProductsInsert(Modelstoredb parameters)
        {
            using (var sql = new SqlConnection(conn.SQLchain()))
            {
                using (var cmd = new SqlCommand("insertproducts", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("id", parameters.id);
                    cmd.Parameters.AddWithValue("description", parameters.description);
                    cmd.Parameters.AddWithValue("price", parameters.price);

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task ProductsUpdate(Modelstoredb parameters)
        {
            using (var sql = new SqlConnection(conn.SQLchain()))
            {
                using (var cmd = new SqlCommand("updateproducts", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("id", parameters.id);
                    cmd.Parameters.AddWithValue("description", parameters.description);
                    cmd.Parameters.AddWithValue("price", parameters.price);

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task ProductsDelete(Modelstoredb parameters)
        {
            using (var sql = new SqlConnection(conn.SQLchain()))
            {
                using (var cmd = new SqlCommand("deleteproducts", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("id", parameters.id);

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
