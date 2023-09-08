using senai.inlock.webApi_.Domains;
using senai.inlock.webApi_.Interfaces;
using System.Data.SqlClient;

namespace senai.inlock.webApi_.Repositories
{
    public class TiposUsuarioRepository : ITiposUsuarioRepository
    {
        private string stringConexao = "Data Source = DESKTOP-H35FC4N; Initial Catalog = inlock_games_manha; User Id = sa; Pwd = 1976";

        public List<TiposUsuarioDomain> ListarTodos()
        {
            List<TiposUsuarioDomain> listarTiposUsuario = new List<TiposUsuarioDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT IdTipoUsuario, Titulo FROM TiposUsuario";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        TiposUsuarioDomain estudio = new TiposUsuarioDomain
                        {
                            IdTipoUsuario = Convert.ToInt32(rdr[("IdTipoUsuario")]),
                            Titulo = rdr["Titulo"].ToString()
                        };

                        listarTiposUsuario.Add(estudio);
                    }
                }
            }

            return listarTiposUsuario;
        }
    }
}
