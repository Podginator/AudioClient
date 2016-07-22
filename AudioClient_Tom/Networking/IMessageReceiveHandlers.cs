namespace AudioClient_Tom.Networking
{
    public interface IMessageReceiveHandlers
    {
        void HandleMessageReceived(object sender, MessageHandlerArgs args);
    }
}