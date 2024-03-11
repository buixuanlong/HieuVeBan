using System.Net;
using System.Xml;

namespace HieuVeBan.Services
{
    public class LoginUEHService
    {
        private static HttpWebRequest CreateWebRequest(string url, string action)
        {
#pragma warning disable SYSLIB0014 // Type or member is obsolete
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
#pragma warning restore SYSLIB0014 // Type or member is obsolete
            webRequest.Headers.Add("SOAPAction", action);
            webRequest.ContentType = "text/xml;charset=\"utf-8\"";
            webRequest.Accept = "text/xml";
            webRequest.Method = "POST";
            return webRequest;
        }

        private static XmlDocument CreateSoapEnvelope(string xml)
        {
            XmlDocument soapEnvelopeDocument = new XmlDocument();

            soapEnvelopeDocument.LoadXml(xml);
            return soapEnvelopeDocument;
        }

        private static void InsertSoapEnvelopeIntoWebRequest(XmlDocument soapEnvelopeXml, HttpWebRequest webRequest)
        {
            using (Stream stream = webRequest.GetRequestStream())
            {
                soapEnvelopeXml.Save(stream);
            }
        }

        public static string Login(string token)
        {
            var _url = "http://login.ueh.edu.vn/token.asmx";
            var _action = "http://tempuri.org/GetUEHValue";
            string xmlStr = @"<soap:Envelope xmlns:xsi=""http://www.w3.org/1999/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/1999/XMLSchema"" xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/""><soap:Body><GetUEHValue xmlns=""http://tempuri.org/""><token>" + token + "</token></GetUEHValue></soap:Body></soap:Envelope>";
            try
            {
                XmlDocument soapEnvelopeXml = CreateSoapEnvelope(xmlStr);
                HttpWebRequest webRequest = CreateWebRequest(_url, _action);
                InsertSoapEnvelopeIntoWebRequest(soapEnvelopeXml, webRequest);

                // begin async call to web request.
                IAsyncResult asyncResult = webRequest.BeginGetResponse(null, null);

                // suspend this thread until call is complete. You might want to
                // do something usefull here like update your UI.
                asyncResult.AsyncWaitHandle.WaitOne();

                // get the response from the completed web request.
                string soapResult;
                using (WebResponse webResponse = webRequest.EndGetResponse(asyncResult))
                {
                    using (StreamReader rd = new StreamReader(webResponse.GetResponseStream()))
                    {
                        soapResult = rd.ReadToEnd();
                    }
                    XmlDocument xml = new XmlDocument();
                    xml.LoadXml(soapResult);

                    //Display all the book titles.
                    XmlNodeList elemList = xml.GetElementsByTagName("GetUEHValueResult");
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                    string result = elemList[0].InnerXml;
#pragma warning restore CS8602 // Dereference of a possibly null reference.
                    return result.Split('|')[0];
                }
            }
            catch (Exception e)
            {
                return "error";
            }
        }
    }
}
