
using System;
using System.Net;
using Newtonsoft.Json;


namespace Add
{
    class PostData
    {
        static void Main(string[] args)
        {
            
          
            // 建立 WebClient
            using (WebClient webClient = new WebClient())
            {
             
                // 指定 WebClient 的 Content-Type header
                webClient.Headers.Add(HttpRequestHeader.ContentType, "application/json");

                webClient.Headers.Add("X-LINE-ChannelId", "1649580251");
                webClient.Headers.Add("X-LINE-ChannelSecret", "ddca54d0f3e50847af3f6ec4fcaef890");
                // 準備寫入的 data
                KeyData TheKeyData = new KeyData() { productName = "test product", amount = 100, currency = "TWD", orderId = "merchant_test_order_7", oneTimeKey = "385893423804400219" };
                // 將 data 轉為 json
                string json = JsonConvert.SerializeObject(TheKeyData);
                // 執行 post 動作
                var result = webClient.UploadString("https://sandbox-api-pay.line.me/v2/payments/oneTimeKeys/pay", json);
                // linqpad 將 post 結果輸出
                Console.WriteLine(result);

            }
        }
    }
    public class KeyData
    {       
            public string productName;
            public int amount;
            public string currency;
            public string orderId;
            public string oneTimeKey;
    }
}