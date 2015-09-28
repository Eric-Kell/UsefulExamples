import cv2
import numpy as np
from matplotlib import pyplot as plt

img1 = cv2.imread('C:\\1.jpg') #1 and 2 must be same sized
img2 = cv2.imread('C:\\2.jpg')
cv2.imshow('image',img1)
cv2.imshow('image2',img2)

dst = cv2.addWeighted(img1,0.7,img2,0.3,0) # coefficients a + b = 1

cv2.imshow('dst',dst)

cv2.waitKey(0)
cv2.destroyAllWindows()