# PushX
Push message structure written in C#


### Example

Push server:

First, create class of your data structure implementing IData interface, then

    public interface IGCM
    {
        object to { get; set; }//Registration Id of client
        IData data { get; set; }//Data structure
    }

    IGCM dataToSend = new Foo();

Second, create server settings

    PushServerSettings settings = new PushServerSettings()
    {
        Server = "https://gcm-http.googleapis.com/gcm/send",
        DeviceGroup = "https://android.googleapis.com/gcm/notification",
        ProjectNumber = "{yourProjectNumber}"
    };
    
    PushServer server = new PushServer();
    server.SetApiKey({yourApiKey});
    server.SetSettings(settings);
    
    string responseString = server.Send(dataToSend);
