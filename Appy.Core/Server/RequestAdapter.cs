using HttpMultipartParser;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace Appy.Core
{
    public class RequestAdapter
    {
        HttpListenerRequest Source;

        public RequestAdapter(HttpListenerRequest source)
        {
            Source = source;
        }

        public static Request GetRequest(HttpListenerRequest source)
        {
            return new RequestAdapter(source).GetRequest();
        }

        public virtual Request GetRequest()
        {
            Request destination = new Request();

            destination.AcceptTypes = Source.AcceptTypes;
            destination.ContentEncoding = Source.ContentEncoding;
            destination.ContentLength = Source.ContentLength64;
            destination.ContentType = Source.ContentType;
            destination.Cookies = Source.Cookies;
            destination.Headers = Source.Headers;
            destination.RawUrl = Source.RawUrl;
            destination.UserAgent = Source.UserAgent;
            destination.QueryString = Source.QueryString;
            destination.LowLevelRequest = Source;
            destination.Form = new Dictionary<string, string>();
            destination.Files = new List<HttpFile>();

            if (Source.ContentLength64 < 1)
                return destination;

            Stream inputStream = Source.InputStream;
            MultipartFormDataParser parser = new MultipartFormDataParser(inputStream);

            foreach (var parameterName in parser.Parameters.Keys)
            {
                destination.Form.Add(parameterName, parser.Parameters[parameterName].Data);
            }

            foreach (var file in parser.Files)
            {
                HttpFile httpFile = new HttpFile
                {
                    ContentType = file.ContentType,
                    ContentDisposition = file.ContentDisposition,
                    FileName = file.FileName,
                    Name = file.Name,
                    Data = file.Data
                };
            }

            return destination;
        }
    }
}
