# -*- coding: utf-8 -*-
"""
Created on Wed Feb 26 18:40:06 2020

@author: rstefanescu
"""
import json
import numpy as np

from flask import Flask, request
from NetworksManager import NeuralNetworksManager

app = Flask(__name__)

def ConvertDictionaryValuesToString(data : dict):
    #print(data)
    for k,v in data.items():
        data[k] = str(v)
        
    return data

def ParseData():
    #print(request.json)
    data = request.json
    #data = json.loads(data)
    #print(data, file=sys.stdout)
    neural_type = data['type']
    predict_data = data['predict_data']
    return neural_type, predict_data

def PredictData(predict_data, neural_type):
    NeuralNetworksManager.ChooseNeuralNetwork(neural_type)
    data = NeuralNetworksManager.Predict(predict_data) 
    return ConvertDictionaryValuesToString(data)

def CreateResponse(data: dict):
    data = {'keys' : list(data.keys()),
            'values': list(data.values())}
    
    #print(data)
    jsondata = json.dumps(data)
    #print(jsondata)
    response = app.response_class(
        response=jsondata,
        status=200,
        mimetype='application/json'
    )
    return response

@app.route("/predict", methods=['POST'])
def predictData():
    neural_type, predict_data = ParseData()
    if neural_type == 'image':
        predict_data = np.reshape(predict_data, (1,32,32,3)) 
    data = PredictData(predict_data, neural_type)
    return CreateResponse(data)
 
app.run(debug=True, use_reloader=False)
