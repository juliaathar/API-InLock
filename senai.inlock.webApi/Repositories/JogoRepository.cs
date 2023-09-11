using senai.inlock.webApi_.Domains;
using senai.inlock.webApi_.Interfaces;
using System.Data.SqlClient;
using System.Globalization;

namespace senai.inlock.webApi_.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        private string stringConexao = "Data Source = NOTE15-S14; Initial Catalog = inlock_games_manha; User Id = sa; Pwd = Senai@134";
        public void Atualizar(JogoDomain jogo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdate = "UPDATE Jogo SET Nome = @Nome, IdEstudio = @IdEstudio, Descricao = @Descricao, DataLancamento = @DataLancamento, Valor = @Valor";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {
                    cmd.Parameters.AddWithValue("IdEstudio", jogo.IdEstudio);
                    cmd.Parameters.AddWithValue("Nome", jogo.Nome);
                    cmd.Parameters.AddWithValue("Descricao", jogo.Descricao);
                    cmd.Parameters.AddWithValue("DataLancamento", jogo.DataLancamento);
                    cmd.Parameters.AddWithValue("Valor", jogo.Valor);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public JogoDomain Buscar(int id)
        {
            JogoDomain jogo = new JogoDomain();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySearch = "SELECT IdJogo, IdEstudio, Nome, Descricao, DataLancamento, Valor FROM Jogo WHERE IdJogo = @IdJogo";

                using (SqlCommand cmd = new SqlCommand(querySearch, con))
                {
                    cmd.Parameters.AddWithValue("@IdJogo", id);

                    con.Open();

                    SqlDataReader rdr;

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        jogo = new JogoDomain
                        {
                            IdJogo = Convert.ToInt32(rdr["IdJogo"]),
                            IdEstudio = Convert.ToInt32(rdr["IdEstudio"]),
                            Nome = rdr["Nome"].ToString(),
                            Descricao = rdr["Descricao"].ToString(),
                            DataLancamento = Convert.ToDateTime(rdr["DataLancamento"]),
                            Valor = Convert.ToSingle(rdr["Valor"])
                        };
                    }
                }
            }

            return jogo;
        }

        public void Cadastrar(JogoDomain novoJogo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO Jogo (IdEstudio, Nome, Descricao, DataLancamento, Valor) VALUES (@IdEstudio, @Nome, @Descricao, @DataLancamento, @Valor)";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("IdEstudio", novoJogo.IdEstudio);
                    cmd.Parameters.AddWithValue("Nome", novoJogo.Nome);
                    cmd.Parameters.AddWithValue("Descricao", novoJogo.Descricao);
                    cmd.Parameters.AddWithValue("DataLancamento", novoJogo.DataLancamento);
                    cmd.Parameters.AddWithValue("Valor", novoJogo.Valor);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM Jogo WHERE IdJogo = @IdJogo";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@IdJogo", id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<JogoDomain> ListarTodos()
        {
            List<JogoDomain> listarJogos = new List<JogoDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT IdJogo, IdEstudio, Nome, Descricao, DataLancamento, Valor FROM Jogo";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        JogoDomain jogo = new JogoDomain
                        {
                            IdJogo = Convert.ToInt32(rdr["IdJogo"]),
                            IdEstudio = Convert.ToInt32(rdr["IdEstudio"]),
                            Nome = rdr["Nome"].ToString(),
                            Descricao = rdr["Descricao"].ToString(),
                            DataLancamento = Convert.ToDateTime(rdr["DataLancamento"]),
                            Valor = Convert.ToSingle(rdr["Valor"])
                        };

                        listarJogos.Add(jogo);
                    }
                }
            }
            return listarJogos;
        }
    }
}
