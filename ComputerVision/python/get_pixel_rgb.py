import cv2
import numpy as np

img = cv2.imread('C:\\messi5.jpg')
px = img[100,100] # row column coordinates
blue = img[100,100,0] # BGR - 0 = Blue
print blue
print px

#your can modify it's value
img[100,100] = [255,255,255]
print img[100,100]

# accessing RED value
img.item(10,10,2)
img.itemset((10,10,2),100)
print img.item(10,10,2)