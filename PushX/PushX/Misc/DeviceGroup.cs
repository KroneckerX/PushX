﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PushX.Misc
{
    public class DeviceGroup
    {
        internal string _groupName = null;

        internal Servers.PushServer _server = null;

        private RegistrationIdCollection collection = null;
        private string _notf_group_id = null;

        public string NotificationGroupId
        {
            get
            {
                return _notf_group_id;
            }
        }

        public RegistrationIdCollection Collection
        {
            get
            {
                return collection;
            }
        }

        public DeviceGroup(string groupName, Servers.PushServer server)
        {
            _groupName = groupName;
            _server = server;
        }

        public static DeviceGroup Create(RegistrationIdCollection registers, string groupName, Servers.PushServer server)
        {
            string responsestr = createRequest(registers, groupName, server);

            if (responsestr == null)
            {
                return null;
            }
            else
            {
                DeviceGroup devgroup = new DeviceGroup(groupName, server);
                devgroup._notf_group_id = responsestr;
                devgroup.collection = registers;
            }

            return null;
        }

        private static string createRequest(RegistrationIdCollection registers, string groupName, Servers.PushServer server)
        {

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(server._settings.DeviceGroup);

            request.Method = "POST";
            request.ContentType = "application/json";
            request.Headers.Add(string.Format("Authorization:key={0}",server._apiKey));
            request.Headers.Add(string.Format("project_id:",server._settings.ProjectNumber));

            object reqContent = new
            {
                operation = "create",
                notification_key_name = groupName,
                registration_ids = registers.toList()
            };

            var requestStream = request.GetRequestStream();
            using(var swriter = new StreamWriter(requestStream))
            {
                swriter.Write(reqContent.ToJson());
                swriter.Flush();
            }

            var response = (HttpWebResponse)request.GetResponse();
            var responseStream = response.GetResponseStream();

            string responseStr = null;

            using(var sreader = new StreamReader(responseStream))
            {
                responseStr = sreader.ReadToEnd();
            }

            if(response.StatusCode == HttpStatusCode.OK)
            {
                return responseStr;
            }
            else
            {
                return null;
            }
        }

        public bool Add(RegistrationIdCollection collection)
        {
            return _operation(collection, "add") != null;
        }

        public bool Remove(RegistrationIdCollection collection)
        {
            return _operation(collection, "remove") != null;
        }


        private string _operation(RegistrationIdCollection collection,string operation)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(_server._settings.DeviceGroup);
            request.Method = "POST";
            request.ContentType = "application/json";
            request.Headers.Add(string.Format("Authorization:key={0}", _server._apiKey));
            request.Headers.Add(string.Format("project_id:", _server._settings.ProjectNumber));

            object reqObj = new
            {
                operation = operation,
                notification_key_name = _groupName,
                notification_key = _notf_group_id,
                registration_ids = collection
            };

            var requestStream = request.GetRequestStream();
            using(var swriter = new StreamWriter(requestStream))
            {
                swriter.Write(reqObj.ToJson());
                swriter.Flush();
            }

            var response = (HttpWebResponse)request.GetResponse();
            var responseStream = response.GetResponseStream();

            string responseStr = null;

            using(var sreader = new StreamReader(responseStream))
            {
                responseStr = sreader.ReadToEnd();
            }

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return responseStr;
            }
            else
            {
                return null;
            }
        }
    }
}
