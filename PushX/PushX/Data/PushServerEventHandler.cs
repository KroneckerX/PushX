namespace PushX.Data
{
    public delegate void PushServerEventHandler(string senderServer, PushServerEventArgs e);

    public delegate void PushServerErrorEventHandler(string serderServer, PushServerErrorEventArgs e);
}
