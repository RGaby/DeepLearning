using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Preditions
{
    class NetworkManager
    {
        private static readonly HttpClient client = new HttpClient();
        private const string url = "http://127.0.0.1:5000/predict";
        private static NetworkManager instance;

        public static NetworkManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new NetworkManager();
                return instance;
            }
        }

        public void SendTextRequest(string _type, string _data, Action<PredictResponse> _onSucces, Action _onError)
        {
            PredictTextRequest req = new PredictTextRequest(_type, _data);
            string json = JsonConvert.SerializeObject(req);
            SendRequestAsync(json, _onSucces, _onError);
        }

        public void SendImageRequest(string _type, List<List<List<float>>> _data, Action<PredictResponse> _onSucces, Action _onError)
        {
            PredictImageRequest req = new PredictImageRequest(_type, _data);
            string json = JsonConvert.SerializeObject(req);
            SendRequestAsync(json, _onSucces, _onError);
        }

        public async void SendRequestAsync(string data, Action<PredictResponse> _callback, Action _onError)
        {
            var content = new StringContent(data, Encoding.UTF8, "application/json");
            try
            {
                HttpResponseMessage postTask = await Task.Run(() => client.PostAsync(url, content));
                string resp = await postTask.Content.ReadAsStringAsync();
                PredictResponse response = JsonConvert.DeserializeObject<PredictResponse>(resp);
                _callback?.Invoke(response);
            }
            catch(Exception)
            {
                MessageBox.Show("Server error! \n Please run the server!");
                _onError?.Invoke();
            }
            
        }
    }
}
