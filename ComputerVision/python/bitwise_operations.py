import cv2
import numpy as np
from matplotlib import pyplot as plt

cv2.useOptimized()

e1 = cv2.getTickCount()

img1 = cv2.imread('C:\\messi5.jpg') #1 and 2 must be same sized
img2 = cv2.imread('C:\\logo2.png')

cv2.imshow('image',img1)
cv2.imshow('image2',img2)

# I want to put logo on top-left corner, So I create a ROI
rows,cols,channels = img2.shape
roi = img1[0:rows, 0:cols ]

#Now create a mask of logo and create its inverse mask also
img2gray = cv2.cvtColor(img2, cv2.COLOR_BGR2GRAY)
ret, mask = cv2.threshold(img2gray, 10, 255, cv2.THRESH_BINARY)
mask_inv = cv2.bitwise_not(mask)

# Now black-out the area of logo in ROI
img1_bg = cv2.bitwise_and(roi,roi,mask = mask_inv)

#Take only region of logo from logo image.
img2_fg = cv2.bitwise_and(img2,img2,mask = mask)

# Put logo in ROI and modify the main image
dst = cv2.add(img1_bg,img2_fg)
img1[0:rows, 0:cols ] = dst

cv2.imshow('res',img1)

e2 = cv2.getTickCount()
time = (e2 - e1)/ cv2.getTickFrequency()
print time
cv2.waitKey(0)
cv2.destroyAllWindows()