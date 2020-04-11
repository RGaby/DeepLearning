# -*- coding: utf-8 -*-
"""
Created on Thu Feb 20 13:50:29 2020

@author: rstefanescu
"""

import sys

from imageClassification import ImageClassification
from spamClassification import SpamClassification
from imdbClassification import IMDBClassification

class NeuralNetworksManager():
    imageCls = None
    currentNN = None
    spamCls = None
    imbdCls = None
    @staticmethod   
    def GetImageClassificator():
        if NeuralNetworksManager.imageCls is None:
            NeuralNetworksManager.imageCls = ImageClassification( batch_size = 32, epochs = 125, steps_per_epoch = 1000)

        return NeuralNetworksManager.imageCls
    
    @staticmethod
    def GetSpamClassificator():
        if NeuralNetworksManager.spamCls is None:
            NeuralNetworksManager.spamCls = SpamClassification(batch_size = 60, epochs = 10)

        return NeuralNetworksManager.spamCls
    
    @staticmethod
    def GetIMDBClassificator():
        if NeuralNetworksManager.imbdCls is None:
            NeuralNetworksManager.imbdCls = IMDBClassification(batch_size = 64, epochs = 3)

        return NeuralNetworksManager.imbdCls
    
    @staticmethod
    def ChooseNeuralNetwork(choose):
        if choose == "image":
            NeuralNetworksManager.currentNN = NeuralNetworksManager.GetImageClassificator()
        elif choose == "spam":
            NeuralNetworksManager.currentNN = NeuralNetworksManager.GetSpamClassificator()
        elif choose == "imdb":
            NeuralNetworksManager.currentNN = NeuralNetworksManager.GetIMDBClassificator()
        else:
            NeuralNetworksManager.currentNN = None
            
    @staticmethod     
    def Predict(data):
       return NeuralNetworksManager.currentNN.Predict(data)
            