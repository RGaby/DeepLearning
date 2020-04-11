using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Preditions
{
    class NetworkManager
    {
        private static readonly HttpClient client = new HttpClient();
        private const string url = "http://127.0.0.1:5000/predict";
        private static NetworkManager instance;

        public string type;

        public static NetworkManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new NetworkManager();
                return instance;
            }
        }

        public void SendTextRequest(string _data, Action<PredictResponse> _callback)
        {
            PredictTextRequest req = new PredictTextRequest(type, _data);
            string json = JsonConvert.SerializeObject(req);
            SendRequestAsync(json, _callback);
        }

        public void SendImageRequest(List<List<List<float>>> _data, Action<PredictResponse> _callback)
        {
            PredictImageRequest req = new PredictImageRequest(type, _data);
            string json = JsonConvert.SerializeObject(req);
            SendRequestAsync(json, _callback);
        }

        public async void SendRequestAsync(string data, Action<PredictResponse> _callback)
        {
            var content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage postTask = await Task.Run(() => client.PostAsync(url, content));

            string resp = await postTask.Content.ReadAsStringAsync();
            PredictResponse response = JsonConvert.DeserializeObject<PredictResponse>(resp);
            _callback?.Invoke(response);
        }
    }
}
