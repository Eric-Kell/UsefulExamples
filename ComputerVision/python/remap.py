import cv2
import numpy as np

img = cv2.imread('C:\\somepic.jpg')
cv2.imshow("original", img)

h,w = img.shape[:2]

map_x = np.zeros((h,w*2.0),np.float32)
map_y = np.zeros((h,w*2.0),np.float32)

for x in range(0,h-1):
    for y in range(0,w*2-1):
        map_x.itemset((x,y), y / 2.0)
        map_y.itemset((x,y), x / 1.0)

res = cv2.remap(img, map_x, map_y, cv2.INTER_CUBIC)
cv2.imshow("original2", res)

cv2.waitKey(0)
cv2.destroyAllWindows()