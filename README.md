# PushX

[![PushX](https://img.shields.io/pypi/status/Django.svg)]()
[![PushX](https://img.shields.io/badge/.NET-4.5.2-green.svg)]()


3rd party push server structure written in C#.

## Contents
- [Example](#example)
    - [GCM Push Server](#gcm-push-server)

### Example

#### GCM Push Server:

1.Create class of your data structure implementing IData interface

    public class Foo : IData { }
    
2.Create a class implementing IGCM interface

    public class Fubar : IGCM

    public interface IGCM
    {
        object to { get; set; }//Registration Id of client
        IData data { get; set; }//Data structure
    }

    
3.Create and instance and place your data to the box
    
    IGCM dataToSend = new Fubar();

4.Create server settings and server

    PushServerSettings settings = new PushServerSettings()
    {
        Server = "https://gcm-http.googleapis.com/gcm/send",
        DeviceGroup = "https://android.googleapis.com/gcm/notification",
        ProjectNumber = "{yourProjectNumber}"
    };
    
    GCMPushServer server = new GCMPushServer();
    server.SetApiKey({yourApiKey});
    server.SetSettings(settings);

4.Push your data 

    string responseString = server.Send(dataToSend);


#### GCM Device Group:

    DeviceGroup deviceGroup = null;
    
##### Create

    deviceGroup = new DeviceGroup("FooGroupName",server); //server is an instance of GCMPushServer
    

