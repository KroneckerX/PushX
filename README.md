# PushX

[![PushX](https://img.shields.io/pypi/status/Django.svg)]()
[![PushX](https://img.shields.io/badge/.NET-4.5.2-green.svg)]()


3rd party push server structure written in C#.


### Example

#### GCM Push server:

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
    
    GCMPushServer server = new GCMPushServer();
    server.SetApiKey({yourApiKey});
    server.SetSettings(settings);
    
    string responseString = server.Send(dataToSend);
