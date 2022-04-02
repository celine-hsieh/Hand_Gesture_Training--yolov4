#-------------------------------------#
#       調用攝影機檢測
#-------------------------------------#
from keras.layers import Input
from yolo import YOLO
from PIL import Image
import numpy as np
import cv2
import time
yolo = YOLO()

# 調用攝影機(0:筆電鏡頭；1:webcam)
capture=cv2.VideoCapture(0) 
# capture=cv2.VideoCapture("1.mp4")

fps = 0.0
while(True):
    t1 = time.time()
    # 讀取某一幀

    ref,frame=capture.read()
    # 水平鏡像
    frame = cv2.flip(frame,1,dst=None)
    # 格式轉換，BGRtoRGB
    frame = cv2.cvtColor(frame,cv2.COLOR_BGR2RGB)
    # 轉換成Image
    frame = Image.fromarray(np.uint8(frame))

    # 進行檢測
    frame = np.array(yolo.detect_image(frame))

    # RGBtoBGR滿足opencv顯示格式
    frame = cv2.cvtColor(frame,cv2.COLOR_RGB2BGR)
    
    fps  = ( fps + (1./(time.time()-t1)) ) / 2
    print("fps= %.2f"%(fps))
    #cv2.putText(影像, 文字, 座標(文字左下角), 字型, 大小(縮放比例), 顏色, 線條寬度, 線條種類(可省略))
    frame = cv2.putText(frame, "fps= %.2f"%(fps), (0, 40), cv2.FONT_HERSHEY_SIMPLEX, 1, (0, 255, 0), 2)
    
    cv2.imshow("video",frame)
    c= cv2.waitKey(30) & 0xff 
    if c==27:
        capture.release()
        break

yolo.close_session()    
