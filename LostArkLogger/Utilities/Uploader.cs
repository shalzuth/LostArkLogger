using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LostArkLogger.Utilities
{
    public static class Uploader
    {
        static String baseUrl = "http://lostark.shalzuth.com/";
        //static String baseUrl = "http://127.0.0.1/";
        public static void UploadLog(Byte[] bytes)
        {
            try // ignore server failures
            {
                var request = (HttpWebRequest)WebRequest.Create(baseUrl + "appupload2c");
                var logHash = string.Concat(MD5.Create().ComputeHash(bytes).Select(x => x.ToString("x2")));
                var compressed = ObjectSerialize.Compress(bytes);
                request.Method = "POST";
                request.ContentType = "application/octet-stream";
                request.ContentLength = compressed.Length;
                using (var stream = request.GetRequestStream()) stream.Write(compressed, 0, compressed.Length);
                var response = (HttpWebResponse)request.GetResponse();
                var hashValue = new StreamReader(response.GetResponseStream()).ReadToEnd();
                System.Diagnostics.Process.Start(baseUrl + "log/" + hashValue);
            }
            catch (Exception ex) { }
        }
    }
}
