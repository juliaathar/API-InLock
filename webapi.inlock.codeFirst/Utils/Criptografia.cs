namespace webapi.inlock.codeFirst.Utils
{
    public static class Criptografia
    {
        /// <summary>
        /// gera uma hash a partir de uma senha 
        /// </summary>
        /// <param name="senha">senha a ser criptografada</param>
        /// <returns>senha criptografada com a hash</returns>
        public static string GerarHash(string senha)
        {
            return BCrypt.Net.BCrypt.HashPassword(senha);
        }

        /// <summary>
        /// verifica se a hash da senha informada é igual a hash salva no banco 
        /// </summary>
        /// <param name="senhaForm">senha informada pelo usuario</param>
        /// <param name="senhaBanco">senha cadastrada no banco</param>
        /// <returns>True ou False (senha é verdadeira?)</returns>
        public static bool CompararHash(string senhaForm, string senhaBanco)
        {
            return BCrypt.Net.BCrypt.Verify(senhaForm, senhaBanco);
        }
    }
}
