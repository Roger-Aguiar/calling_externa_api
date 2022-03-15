namespace CallingExternalWebApi
{
    public class Broker 
    {
        private int errorKind;
        private BrokerResult [] result;

        public int ErrorKind { get => errorKind; set => errorKind = value; }
        public BrokerResult[] Result { get => result; set => result = value; }
    }
}