import cv2
import numpy as np

img = cv2.imread('C:\\somepic.jpg')
cv2.imshow('image',img)

b,g,r = cv2.split(img) # Splitting  image channels or |b = img[:,:,0]|
img = cv2.merge((b,g,r)) # merging imahe channels
img[:,:,2] = 0 # make all the red pixels to zero

cv2.imshow('image2',img)

cv2.waitKey(0)
cv2.destroyAllWindows()