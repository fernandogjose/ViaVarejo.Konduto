using ViaVarejo.Konduto.Domain.Interfaces.SqlRepositories;

namespace ViaVarejo.Konduto.Data.SqlRepositories {

    public class ConfigurationSqlRepository : BaseSqlRepository, IConfigurationSqlRepository {

        private readonly string _connectionString;

        public ConfigurationSqlRepository (string connectionString) {
            _connectionString = connectionString;
        }

        public string GetByKey (string key) {

            //--- Fernando - Criar o método para buscar no banco de dados sql
            return GetDbValue (key).ToString ();
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