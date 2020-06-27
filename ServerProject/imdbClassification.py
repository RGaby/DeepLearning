# LSTM and CNN for sequence classification in the IMDB dataset
import numpy as np
from keras.datasets import imdb
from keras.models import Sequential
from keras.layers import Dense
from keras.layers import LSTM
from keras.layers.convolutional import Conv1D
from keras.layers.convolutional import MaxPooling1D
from keras.layers.embeddings import Embedding
from keras.preprocessing import sequence
from BaseNetwork import BaseNetwork
# fix random seed for reproducibility
np.random.seed(7)
# load the dataset but only keep the top n words, zero the rest
top_words = 5000
# save np.load
np_load_old = np.load

labels = ['negative', 'positive']

class IMDBClassification(BaseNetwork):
    
    def __init__(self, batch_size, epochs):        
        self.batch_size = batch_size
        self.num_classes = 2
        self.epochs = epochs

        self.save_dir = 'saved_models'
        self.model_name = 'imdb.h5'
        
    def PrepareData(self):
        np.load = lambda *a,**k: np_load_old(*a, allow_pickle=True, **k)

        # call load_data with allow_pickle implicitly set to true
        (self.X_train, self.y_train), (self.X_test, self.y_test) = imdb.load_data(num_words=10000)
        # restore np.load for future normal usage
        np.load = np_load_old
        self.max_review_length = 500
        self.X_train = sequence.pad_sequences(self.X_train, maxlen=self.max_review_length)
        self.X_test = sequence.pad_sequences(self.X_test, maxlen=self.max_review_length)

    def CreateModel(self):
        model = Sequential()
        model.add(Embedding(top_words, 32, input_length=self.max_review_length))
        model.add(Conv1D(filters=32, kernel_size=3, padding='same', activation='relu'))
        model.add(MaxPooling1D(pool_size=2))
        model.add(LSTM(100))
        model.add(Dense(1, activation='sigmoid'))
        model.compile(loss='binary_crossentropy', optimizer='RMSprop', metrics=['accuracy'])
        self.history = model.fit(self.X_train, self.y_train, epochs=3, batch_size=64, validation_split = 0.2)
        self.scores = model.evaluate(self.X_test, self.y_test, verbose=0)
        self.model = model
        
        #print("Accuracy: %.2f%%" % (self.scores[1]*100))
        
    def Predict(self, predict_data, forceTrain = False):
        super(IMDBClassification, self).Predict(forceTrain)

        remove_data =''
        for e in predict_data:
            if e.isalpha() or e == ' ':
                remove_data += e
            else:
                remove_data += ' '
        predict_data = " ".join(remove_data.split())

        predict_data = predict_data.lower().split(' ')
        word2index = imdb.get_word_index()
        test_seq = np.array([word2index[word] for word in predict_data])
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
a= IMDBClassification(64,3)
#data = "this film was just brilliant casting location scenery story direction everyone's really suited the part they played and you could just imagine being there robert is an amazing actor and now the same being director father came from the same scottish island as myself so i loved the fact there was a real connection with this film the witty remarks throughout the film were great it was just brilliant so much that i bought the film as soon as it was released for and would recommend it to everyone to watch and the fly fishing was amazing really cried at the end it was so sad and you know what they say if you cry at a film it must have been good and this definitely was also to the two little boy's that played the of norman and paul they were just brilliant children are often left out of the list i think because the stars that play them all grown up are such a big profile for the whole film but these children are amazing and should be praised for what they have done don't you think the whole story was so lovely because it was true and was someone's life after all that was shared with us all"
data ="If you like original gut wrenching laughter you will like this movie If you are young or old then you will love this movie hell even my mom liked it Great Camp"
a.Predict(data, forceTrain=True)
'''