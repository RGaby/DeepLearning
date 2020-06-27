using System;
using System.Collections.Generic;
using System.Text;

namespace Preditions
{
    public class PredictImageRequest
    {
        public string type;
        public List<List<List<float>>> predict_data;

        public PredictImageRequest(string _type, List<List<List<float>>> _predict_data)
        {
            type = _type;
            predict_data = _predict_data;
        }
    }

    public class PredictTextRequest
    {
        public string type;
        public string predict_data;

        public PredictTextRequest(string _type, string _predict_data)
        {
            type = _type;
            predict_data = _predict_data;
        }
    }

    public class PredictResponse
    {
        public List<string> keys;
        public List<string> values;
    }
}
