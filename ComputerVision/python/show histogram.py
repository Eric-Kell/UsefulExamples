import numpy as np
import cv2
from matplotlib import pyplot as plt

#see more in http://docs.opencv.org/master/de/db2/tutorial_py_table_of_contents_histograms.html#gsc.tab=0

img = cv2.imread('C:\\low-contrast.png',0)
hist = cv2.calcHist([img],[0],None,[256],[0,256])

cv2.imshow('img',img)

plt.hist(img.ravel(),256,[0,256]); plt.show()
# hist,bins = np.histogram(img.ravel(),256,[0,256]) or even np.bincount()


cv2.waitKey(0)
cv2.destroyAllWindows()