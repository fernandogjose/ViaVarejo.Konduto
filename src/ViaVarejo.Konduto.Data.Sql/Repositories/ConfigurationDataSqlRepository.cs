using ViaVarejo.Konduto.Domain.Interfaces.SqlRepositories;
using ViaVarejo.Konduto.Domain.Models;

namespace ViaVarejo.Konduto.Data.SqlRepositories {

    public class ConfigurationDataSqlRepository : BaseSqlRepository, IConfigurationDataSqlRepository {

        private readonly string _connectionString;

        public ConfigurationDataSqlRepository (string connectionString) {
            _connectionString = connectionString;
        }

        public ConfigurationData GetByKey (string key) {

            //--- Fernando - Criar o método para buscar no banco de dados sql
            return new ConfigurationData();
        }

        // public void Create (ChatCreateRequest chatCreateRequest) {
        //     using (SqlConnection conn = new SqlConnection (ConnectionString ())) {
        //         conn.Open ();

        //         using (var cmd = new SqlCommand ()) {
        //             cmd.Connection = conn;
        //             cmd.CommandText = _chatSql.SqlCreate ();
        //             cmd.CommandType = CommandType.Text;
        //             cmd.Parameters.AddWithValue ("@UserId", GetDbValue (chatCreateRequest.UserId));
        //             cmd.Parameters.AddWithValue ("@Message", GetDbValue (chatCreateRequest.Message));
        //             cmd.ExecuteNonQuery ();
        //         }
        //     }
        // }

        // public List<Chat> List () {
        //     List<Chat> chatsResponse = new List<Chat> ();

        //     using (SqlConnection conn = new SqlConnection (ConnectionString ())) {
        //         using (var cmd = new SqlCommand ()) {
        //             cmd.Connection = conn;
        //             cmd.CommandText = _chatSql.SqlList ();
        //             cmd.CommandType = CommandType.Text;

        //             conn.Open ();
        //             using (DbDataReader dr = cmd.ExecuteReader ()) {
        //                 while (dr.Read ()) {
        //                     Chat chat = new Chat ();
        //                     chat.Message = dr["Message"].ToString ();
        //                     chat.Date = Convert.ToDateTime (dr["Date"].ToString ());
        //                     chat.User = new User ();
        //                     chat.User.Name = dr["UserName"].ToString ();
        //                     chatsResponse.Add (chat);
        //                 }
        //             }
        //         }
        //     }

        //     return chatsResponse;
        // }
    }
}