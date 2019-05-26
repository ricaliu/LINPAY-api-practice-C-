using System;
using System.IO;
using System.Net;

namespace Check
{
    class Check
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World");
            WebRequest request = WebRequest.Create("https://sandbox-api-pay.line.me/v2/payments/orders/TW2019-LINE-00005/check");
            // 使用 HttpWebRequest.Create 實際上也是呼叫 WebRequest.Create

            //指定 request 使用的 http verb
            request.Method = "GET";

            request.Headers.Add("Content-Type", "application/json");
            request.Headers.Add("X-LINE-ChannelId", "1649580251");
            request.Headers.Add("X-LINE-ChannelSecret", "ddca54d0f3e50847af3f6ec4fcaef890");
            //使用 GetResponse 方法將 request 送出，如果不是用 using 包覆，請記得手動 close WebResponse 物件，避免連線持續被佔用而無法送出新的 request
            using (var httpResponse = (HttpWebResponse)request.GetResponse())

            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                Console.WriteLine(result);
            }
        }

    }
}