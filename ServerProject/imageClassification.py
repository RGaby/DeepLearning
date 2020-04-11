
import keras
import numpy as np
from matplotlib import pyplot as plt

from keras.datasets import cifar10
from keras.preprocessing import image
from keras.preprocessing.image import ImageDataGenerator
from keras.models import Sequential
from keras.layers import Dense, Dropout, Activation, Flatten, BatchNormalization
from keras.layers import Conv2D, MaxPooling2D
from keras import regularizers
from BaseNetwork import BaseNetwork

labels =  ['airplane','automobile','bird','cat','deer','dog','frog','horse','ship','truck']

class ImageClassification(BaseNetwork):
    
    def __init__(self, batch_size, epochs, steps_per_epoch):        
        self.batch_size = batch_size
        self.num_classes = 10
        self.epochs = epochs
        self.steps_per_epoch=steps_per_epoch

        self.save_dir = 'saved_models'
        self.model_name = 'keras_cifar10_trained_model.h5'
        
    def PrepareData(self):
        (self.x_train, self.y_train), (self.x_test, self.y_test) = cifar10.load_data()
        self.model_shape =  self.x_train.shape
        print('x_train shape:', self.x_train.shape)
        print(self.x_train.shape[0], 'train samples')
        print(self.x_test.shape[0], 'test samples')
        
        self.y_train = keras.utils.to_categorical(self.y_train, self.num_classes)
        self.y_test = keras.utils.to_categorical(self.y_test, self.num_classes)
        
        self.x_train = self.x_train.astype('float32')
        self.x_test = self.x_test.astype('float32')
        self.x_train /= 255
        self.x_test /= 255
        
    def CreateModel(self):
        weight_decay = 1e-4
        model = Sequential()
        model.add(Conv2D(32, (3,3), padding='same', kernel_regularizer=regularizers.l2(weight_decay), input_shape = self.x_train.shape[1:]))
        model.add(Activation('elu'))
        model.add(BatchNormalization())
        model.add(Conv2D(32, (3,3), padding='same', kernel_regularizer=regularizers.l2(weight_decay)))
        model.add(Activation('elu'))
        model.add(BatchNormalization())
        model.add(MaxPooling2D(pool_size=(2,2)))
        model.add(Dropout(0.2))
         
        model.add(Conv2D(64, (3,3), padding='same', kernel_regularizer=regularizers.l2(weight_decay)))
        model.add(Activation('elu'))
        model.add(BatchNormalization())
        model.add(Conv2D(64, (3,3), padding='same', kernel_regularizer=regularizers.l2(weight_decay)))
        model.add(Activation('elu'))
        model.add(BatchNormalization())
        model.add(MaxPooling2D(pool_size=(2,2)))
        model.add(Dropout(0.3))
         
        model.add(Conv2D(128, (3,3), padding='same', kernel_regularizer=regularizers.l2(weight_decay)))
        model.add(Activation('elu'))
        model.add(BatchNormalization())
        model.add(Conv2D(128, (3,3), padding='same', kernel_regularizer=regularizers.l2(weight_decay)))
        model.add(Activation('elu'))
        model.add(BatchNormalization())
        model.add(MaxPooling2D(pool_size=(2,2)))
        model.add(Dropout(0.4))
         
        model.add(Flatten())
        model.add(Dense(128, activation='relu', kernel_initializer='he_uniform'))
        model.add(Dropout(0.2))
        #model.add(Dense(10, activation='softmax'))
        model.add(Dense(self.num_classes, activation='softmax'))
         
        opt = keras.optimizers.RMSprop(lr=0.0001, decay=1e-6)

        model.compile(loss='categorical_crossentropy',
                      optimizer=opt,
                      metrics=['accuracy'])
        self.model = model

        datagen = ImageDataGenerator(
            featurewise_center=False,  # set input mean to 0 over the dataset
            samplewise_center=False,  # set each sample mean to 0
            featurewise_std_normalization=False,  # divide inputs by std of the dataset
            samplewise_std_normalization=False,  # divide each input by its std
            zca_whitening=False,  # apply ZCA whitening
            zca_epsilon=1e-06,  # epsilon for ZCA whitening
            rotation_range=0,  # randomly rotate images in the range (degrees, 0 to 180)
            # randomly shift images horizontally (fraction of total width)
            width_shift_range=0.1,
            # randomly shift images vertically (fraction of total height)
            height_shift_range=0.1,
            shear_range=0.,  # set range for random shear
            zoom_range=0.,  # set range for random zoom
            channel_shift_range=0.,  # set range for random channel shifts
            # set mode for filling points outside the input boundaries
            fill_mode='nearest',
            cval=0.,  # value used for fill_mode = "constant"
            horizontal_flip=True,  # randomly flip images
            vertical_flip=False,  # randomly flip images
            # set rescaling factor (applied before any other transformation)
            rescale=None,
            # set function that will be applied on each input
            preprocessing_function=None,
            # image data format, either "channels_first" or "channels_last"
            data_format=None,
            # fraction of images reserved for validation (strictly between 0 and 1)
            validation_split=0.0)

        # Compute quantities required for feature-wise normalization
        # (std, mean, and principal components if ZCA whitening is applied).
        datagen.fit(self.x_train)
    
        # Fit the model on the batches generated by datagen.flow().
        self.history = self.model.fit_generator(datagen.flow(self.x_train, self.y_train,
                                         batch_size = self.batch_size),
                            epochs = self.epochs,
                            validation_data=(self.x_test, self.y_test),
                            workers=4,
                            steps_per_epoch = self.steps_per_epoch)
        
        self.scores = self.model.evaluate(self.x_test, self.y_test, verbose=1)
       
        
    def GetPlots(self):
        print('Test loss:', self.scores[0])
        print('Test accuracy:', self.scores[1])
        
        
    def Predict(self, predict_image, forceTrain = False):
        
        super(ImageClassification, self).Predict(forceTrain)
        
        result_proba = self.model.predict_proba(predict_image)
        dictionary = dict(zip(labels, result_proba[0]))
        sorted_dict ={ k: v for k, v in sorted(dictionary.items(), key=lambda item: item[1], reverse = True)}
        print(sorted_dict)
        return sorted_dict
        
    
'''
10000/10000 [==============================] - 2s 160us/step
Test loss: 0.4491412910461426
Test accuracy: 0.8744
'''