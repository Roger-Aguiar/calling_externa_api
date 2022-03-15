namespace CallingExternalWebApi
{
    public class BrokerResult
    {
        private int pkCadCorretora;
        private string nomePessoa;
        private string cpfCnpj;

        public int PkCadCorretora { get => pkCadCorretora; set => pkCadCorretora = value; }
        public string NomePessoa { get => nomePessoa; set => nomePessoa = value; }
        public string CpfCnpj { get => cpfCnpj; set => cpfCnpj = value; }
    }
}