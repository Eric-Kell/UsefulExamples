import numpy as np
import cv2
import matplotlib.pyplot as plt

#see text http://docs.opencv.org/master/da/d6e/tutorial_py_geometric_transformations.html#gsc.tab=0

img = cv2.imread('C:\\messi5.jpg')
cv2.imshow('image',img)

#####################
# resize x2 - 2 equally ways

res = cv2.resize(img,None,fx=2, fy=2, interpolation = cv2.INTER_CUBIC)
cv2.imshow('res',res)

height, width = img.shape[:2]
res = cv2.resize(img,(2*width, 2*height), interpolation = cv2.INTER_CUBIC)
cv2.imshow('res',res)

#####################
# Translation is the shifting of object's location with matrix 2x3
M = np.float32([[1,0,100],[0,1,50]])
dst = cv2.warpAffine(img,M,(width,height))
cv2.imshow('img',dst)
####################

####################
# Rotation
rows,cols = img.shape[:2]
M = cv2.getRotationMatrix2D((cols/2,rows/2),90,1)
dst = cv2.warpAffine(img,M,(cols,rows))
cv2.imshow('img2',dst)
####################

####################
# Affine Transformation
pts1 = np.float32([[50,50],[200,50],[50,200]])
pts2 = np.float32([[10,100],[200,50],[100,250]])

M = cv2.getAffineTransform(pts1,pts2)
dst = cv2.warpAffine(img,M,(cols,rows))

plt.subplot(121),plt.imshow(img),plt.title('Input')
plt.subplot(122),plt.imshow(dst),plt.title('Output')
plt.show()
####################

####################
# Perspective Transformation
img3 = cv2.imread('C:\\woman.jpg')
rows,cols,ch = img3.shape[:3]
pts1 = np.float32([[56,65],[368,52],[28,387],[389,390]])
pts2 = np.float32([[0,0],[300,0],[0,300],[300,300]])

M = cv2.getPerspectiveTransform(pts1,pts2)
dst = cv2.warpPerspective(img3,M,(300,300))

plt.subplot(121),plt.imshow(img3),plt.title('Input')
plt.subplot(122),plt.imshow(dst),plt.title('Output')
plt.show()

cv2.waitKey(0)
cv2.destroyAllWindows()