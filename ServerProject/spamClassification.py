# -*- coding: utf-8 -*-
"""
Created on Tue Feb 11 13:01:43 2020

@author: rstefanescu
"""
import sys
sys.path.append('../NeuralNetworkScripts')

from keras.models import Sequential
from keras.layers import Embedding, Dense, LSTM
from keras.callbacks import Callback
from keras.preprocessing.text import Tokenizer
from keras.preprocessing.sequence import pad_sequences
from sklearn.metrics import confusion_matrix
from BaseNetwork import BaseNetwork

import pandas as pd
import numpy as np
import matplotlib.pyplot as plt
import seaborn as sns; sns.set()
import time


labels = ['ham', 'spam']

class LogCallback(Callback):

    def __init__(self):
        self.times = []
        # use this value as reference to calculate cummulative time taken
        self.timetaken = time.clock()
        
    def on_epoch_end(self,epoch,logs = {}):
        self.times.append((epoch,time.clock() - self.timetaken))
        
    def on_train_end(self,logs = {}):
        plt.xlabel('Epoch')
        plt.ylabel('Total time taken until an epoch in seconds')
        plt.plot(*zip(*self.times))
        plt.show()

class SpamClassification(BaseNetwork):
    
    def __init__(self, batch_size, epochs, max_features = 10000, maxlen = 500):    
        
        self.batch_size = batch_size
        self.num_classes = 2
        self.epochs = epochs
        self.max_features = max_features
        self.maxlen = maxlen
        
        self.save_dir = 'saved_models'
        self.model_name = 'TextClasssification_trained_model.h5'        
        
        
    def TokenizerData(self):
        data = pd.read_csv("Database\\spam.csv", encoding =  "latin-1", error_bad_lines = False)
        
        self.texts = []
        self.labels = []
        
        for i, label in enumerate(data['label']):
            self.texts.append(data['content'][i])
            if label == 'ham':
                self.labels.append(0)
            else:
                self.labels.append(1)

        self.texts = np.asarray(self.texts)
        self.labels = np.asarray(self.labels)
        
        self.tokenizer = Tokenizer()
        self.tokenizer.fit_on_texts(self.texts)
        sequences = self.tokenizer.texts_to_sequences(self.texts)
        
        word_index = self.tokenizer.word_index
        
        data = pad_sequences(sequences, maxlen=self.maxlen)
        return data
    
    def PrepareData(self):
        
        data = self.TokenizerData()
        
        #print("data shape: ", data.shape)
        
        np.random.seed(42)
        # shuffle data
        indices = np.arange(data.shape[0])
        np.random.shuffle(indices)
        data = data[indices]
        self.labels = self.labels[indices]
        
        training_samples = int(len(data) * .75)
        
        self.texts_train = data[:training_samples]
        self.y_train = self.labels[:training_samples]
        self.texts_test = data[training_samples:]
        self.y_test = self.labels[training_samples:]
        
    def CreateModel(self):
        
        timetaken = LogCallback()
        self.model = Sequential()
        self.model.add(Embedding(self.max_features, 32))
        self.model.add(LSTM(32))
        self.model.add(Dense(1, activation='sigmoid'))
        self.model.compile(optimizer='rmsprop', loss='binary_crossentropy', metrics=['acc'])
        self.model.summary()
        history_ltsm = self.model.fit(self.texts_train, self.y_train, epochs=self.epochs, batch_size=self.batch_size, validation_split=0.25,  callbacks=[timetaken])
        
        
        self.acc = history_ltsm.history['acc']
        self.val_acc = history_ltsm.history['val_acc']
        self.loss = history_ltsm.history['loss']
        self.val_loss = history_ltsm.history['val_loss']
        
    
    def Predict(self, predict_data, forceTrain = False):
        super(SpamClassification, self).Predict(forceTrain)
        self.TokenizerData()
        
        remove_data =''
        for e in predict_data:
            if e.isalpha() or e == ' ':
                remove_data += e
            else:
                remove_data += ' '
        predict_data = " ".join(remove_data.split())
        
        predict_data = predict_data.lower().split(' ')
        test_seq = np.array([self.tokenizer.word_index[word] for word in predict_data])
        test_seq = np.pad(test_seq, (500-len(test_seq), 0),
                          'constant', constant_values=(0))
        test_seq = test_seq.reshape(1, 500)
        
        proba_ltsm = self.model.predict_proba(test_seq)
        values = [1 - proba_ltsm[0,0], proba_ltsm[0,0] ]
        dictionary = dict(zip(labels, values))
        sorted_dict ={ k: v for k, v in sorted(dictionary.items(), key=lambda item: item[1], reverse = True)}
        #print(sorted_dict)
        return sorted_dict    
 
'''
a = SpamClassification(60,10)
data = "Go until jurong point, crazy.. Available only in bugis n great world la e buffet... Cine there got amore wat..."
a.Predict(data)
'''