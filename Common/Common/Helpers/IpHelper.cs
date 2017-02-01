using System.Net;
using System.Net.Http;
using System.ServiceModel.Channels;
using System.Web;

namespace Common.Helpers
{
    public class IpHelper
    {
        public static IpHelper Current = new IpHelper();

        public byte[] ConvertIpAddressStringToBytes(string ipAddressString)
        {
            byte[] ipAddressBytes = IPAddress.Parse(ipAddressString).GetAddressBytes();
            return ipAddressBytes;
        }

        public string ConvertIpAddressBytesToString(byte[] ipAddressBytes)
        {
            string ipAddressString = new IPAddress(ipAddressBytes).ToString();
            return ipAddressString;
        }

        public string GetClientIpFromHttpRequest(HttpRequestMessage request = null)
        {
            if (request == null)
            {
                return null;
            }
            if (request.Properties.ContainsKey("MS_HttpContext"))
            {
                return ((HttpContextWrapper)request.Properties["MS_HttpContext"]).Request.UserHostAddress;
            }
            if (request.Properties.ContainsKey(RemoteEndpointMessageProperty.Name))
            {
                RemoteEndpointMessageProperty prop = (RemoteEndpointMessageProperty)request.Properties[RemoteEndpointMessageProperty.Name];
                return prop.Address;
            }
            if (HttpContext.Current != null)
            {
                return HttpContext.Current.Request.UserHostAddress;
            }
            return null;
        }
    }
}
