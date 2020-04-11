import os
from keras.models import load_model
from keras import backend as K
import sys
sys.path.append('../NeuralNetworkScripts')
class BaseNetwork():
   
    def PrepareData(self):
        pass
        
    def CreateModel(self):
        pass
    
    def Train(self):
        self.PrepareData()
        self.CreateModel()
        self.SaveModel()
        #self.GetPlots()
        
    def Predict(self, forceTrain = False):
        
        was_train = False
        model_path = os.path.join(self.save_dir, self.model_name)
        if True:
            was_train = True
            self.Train()
        elif not os.path.exists(self.save_dir) or not os.path.exists(model_path):
            was_train = True
            self.Train()
        
        if was_train == False:
            K.clear_session()
            self.model = load_model(model_path)        
    
    def SaveModel(self):
        if not os.path.isdir(self.save_dir):
            os.makedirs(self.save_dir)    
            
        model_path = os.path.join(self.save_dir, self.model_name)

        self.model.save(model_path)
        print('Saved trained model at %s ' % model_path)
        
    def GetSummary(self):
        model_path = os.path.join(self.save_dir, self.model_name)
        self.model = load_model(model_path)
        self.model.summary()
        