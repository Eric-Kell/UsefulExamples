import cv2
import numpy as np
from matplotlib import pyplot as plt
 
img = cv2.imread('C:\\low-contrast.png',0)

cv2.imshow('img',img)
 
hist,bins = np.histogram(img.flatten(),256,[0,256])
cdf = hist.cumsum()

cdf_m = np.ma.masked_equal(cdf,0)
cdf_m = (cdf_m - cdf_m.min())*255/(cdf_m.max()-cdf_m.min())
cdf = np.ma.filled(cdf_m,0).astype('uint8')


cdf_normalized = cdf * hist.max()/ cdf.max()
img2 = cdf[img]
cv2.imshow('img2',img2)

plt.plot(cdf_normalized, color = 'b')
plt.hist(img.flatten(),256,[0,256], color = 'r')
plt.xlim([0,256])
plt.legend(('cdf','histogram'), loc = 'upper left')
plt.show()