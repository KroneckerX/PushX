# PushX

[![PushX](https://img.shields.io/pypi/status/Django.svg)]()
[![PushX](https://img.shields.io/badge/.NET-4.5-green.svg)]()
[![Build Status](https://travis-ci.org/KroneckerX/PushX.svg?branch=master)](https://travis-ci.org/KroneckerX/PushX)


3rd party push server structure written in C#.

## Contents
- [Example](#example)
    - [GCM Push Server](#gcm-push-server)
    - [GCM Device Group](#gcm-device-group)

### Example

#### GCM Push Server:

1.Create class of your data structure implementing IData interface
```csharp
    public class Foo : IData { }
```
2.Create a class implementing IGCM interface
```csharp
    public class Fubar : IGCM
```
3.Create and instance and place your data to the box
```csharp
    IGCM dataToSend = new Fubar();
```
4.Create server settings and server
```csharp
    PushServerSettings settings = new PushServerSettings()
    {
        Server = "https://gcm-http.googleapis.com/gcm/send",
        DeviceGroup = "https://android.googleapis.com/gcm/notification",
        ProjectNumber = "{yourProjectNumber}"
    };
    
    GCMPushServer server = new GCMPushServer();
    server.SetApiKey({yourApiKey});
    server.SetSettings(settings);
```
4.Push your data 
```csharp
    string responseString = server.Send(dataToSend);
```

#### GCM Device Group:
```csharp
    DeviceGroup deviceGroup = null;
```   
**Create**
```csharp
    deviceGroup = new DeviceGroup("FooGroupName",server); //server is an instance of GCMPushServer
```   
**Call Existing Group**
```csharp
    deviceGroup = new DeviceGroup({groupName},{groupKey},server);//server is an instance of GCMPushServer
```
Notice that, any existing device group does NOT include the data of its past registration ids creating above way.

**Add New Devices**
```csharp
    public bool Add(RegistrationIdCollection collection)
    
    deviceGroup.Add(collection);
```    
**Remove Devices**
```csharp
    public bool Remove(RegistrationIdCollection collection)
    
    deviceGroup.Remove(collection)
```    
**Send**
```csharp
    public string Send(IData data)
    
    deviceGroup.Send(data);
```
