from keras.models import load_model, Model
from keras.layers import Input, Dense, Activation
from keras import optimizers
from cv2 import *
import numpy as np
import os
import sys

d = {0: "Accent",
     1: "AltoCleff",
     2: "Barlines",
     3: "BassClef",
     4: "Beams",
     5: "Breve",
     6: "Dots",
     7: "Flat",
     8: "Naturals",
     9: "Notes",
     10: "NotesFlags",
     11: "NotesOpen",
     12: "Relations",
     13: "Rests1",
     14: "Rests2",
     15: "SemiBreve",
     16: "Sharps",
     17: "TimeSignatureL",
     18: "TimeSignatureN",
     19: "TrebleClef"}

def Classificator(path_images):

    x_test = []
    for path in path_images: 
        image = cv2.imread(path)
        # image = cv2.Canny(image, 50, 200)
        image = cv2.resize(image, (28, 28))
        pixels = []
        for x in image:
            pixel_x = []
            for y in x:
                p = y/255
                pixel_x.append(p)
            pixels.append(pixel_x)
        x_test.append(pixels)

    x_test = np.ndarray((len(x_test), len(x_test[0]), len(x_test[0]), 1), buffer=np.array(x_test), dtype=float)

    model = load_model("trained_neuronal_network.h5")

    pred = model.predict(x_test, batch_size=50)

    pred = pred.argmax(axis=1)

    predictions = open("predictions.pred", 'w')

    for i in range(len(path_images)):
        predictions.write(path_images[i] + ":" + d[pred[i]] + '\n')

    predictions.close()


    
if __name__ == '__main__':
    s = sys.argv[1]
    s = s[1:len(s) - 1]
    s = s.split(',')

    Classificator(s)
    