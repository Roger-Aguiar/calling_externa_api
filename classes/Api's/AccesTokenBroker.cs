namespace CallingExternalWebApi
{
    public class AccessTokenBroker
    {
        private int idUsuario;
        private string nomeUsuario;
        private string loginUsuario;
        private string idSistema;
        private string codigoErroAutenticacao;
        private string mensagemAutenticacao;
        private string token;
        private string parameterRelatorioAcionistasGruposDiferentes;

        public int IdUsuario { get => idUsuario; set => idUsuario = value; }
        public string NomeUsuario { get => nomeUsuario; set => nomeUsuario = value; }
        public string LoginUsuario { get => loginUsuario; set => loginUsuario = value; }
        public string IdSistema { get => idSistema; set => idSistema = value; }
        public string CodigoErroAutenticacao { get => codigoErroAutenticacao; set => codigoErroAutenticacao = value; }
        public string MensagemAutenticacao { get => mensagemAutenticacao; set => mensagemAutenticacao = value; }
        public string Token { get => token; set => token = value; }
        public string ParameterRelatorioAcionistasGruposDiferentes { get => parameterRelatorioAcionistasGruposDiferentes; set => parameterRelatorioAcionistasGruposDiferentes = value; }
    }
}