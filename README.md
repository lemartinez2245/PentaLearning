Para utilizar el proyecto necesita cargar el archivo `Penta Learning.sln`  en Visual Studio y correr el proyecto o abrir el archivo `Penta Learning.exe` en el directorio `Penta Learning/bin/Debug`.

Dependencias de Python3:

- Opencv (opencv-python)
- Tensorflow
- Keras
- Matplotlib
- Numpy

El ejecutable `Penta Learning.exe` llama por detrás a `segmentation.py` para la segmentación y a `predict.py` para la clasificación y el uso de la red neuronal `trained_neuronal_network.h5` que es la red sin feature extraction.