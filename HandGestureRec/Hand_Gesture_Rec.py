#----------------------------------------------------------#
#       調用攝影機檢測並以socket傳遞結果至C#控制程式
#----------------------------------------------------------#
from keras.layers import Input
from PIL import Image
import numpy as np
import cv2
import time
import socket
from yolo import YOLO
import globals


yolo = YOLO()

# 開啟攝影機
capture=cv2.VideoCapture(0) 

fps = 0.0
'''
#建立Socket server
host = '127.0.0.1'#wifi6
port = 1111
server = socket.socket(socket.AF_INET,socket.SOCK_STREAM)#創建TCP Socket server/AF_INET使用的是IPv4協定，而AF_INET6則是IPv6協定

server.setsockopt(socket.SOL_SOCKET, socket.SO_REUSEADDR, 1) #設定這個TCP connection可以再度重複使用
server.bind((host,port))#將套接字綁定到地址，在AF_INET下，以tuple(host, port)的方式傳入
server.listen(3)#開始監聽TCP傳入連接，引數backlog指定在拒絕鏈接前，操作系統可以掛起的最大連接數，該值最少為1
print('Server start at: %s:%s'  % ( host , port ))
print('Waiting for connect...')
conn, addr = server.accept()#接受TCP鏈接並返回（conn, address），其中conn是新的套接字對象，可以用來接收和發送數據，address是鏈接客戶端的地址。
print('Accept new connection from %s:%s' % addr)
conn.send(bytes('Connected!!'.encode('utf-8')))
client_msg = conn.recv(1024).decode('utf-8')   
    '''
    
#while client_msg=="使用者欲辨識手勢":
while(1):
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
    #cv2.putText(影像, 文字, 座標(文字左下角), 字型, 大小(縮放比例), 顏色, 線條寬度, 線條種類(可省略))
    frame = cv2.putText(frame, "fps= %.2f"%(fps), (0, 40), cv2.FONT_HERSHEY_SIMPLEX, 1, (0, 255, 0), 2)
        
    cv2.imshow("video",frame)
    #cv2.waitkey是OpenCV內置的函式，用途是在給定的時間內(單位毫秒)等待使用者的按鍵觸發，否則持續循環
    #0xFF是十六進制常數，二進制值為11111111,這個寫法只留下原始的最後8位，和後面的ASCII碼對照
    c= cv2.waitKey(30) & 0xff 
    
    # 判斷手勢為單雙手、左右手、何種手勢
    Command=""
    if globals.number_of_boxes == 1:#單手
        box = globals.location_of_boxes[0]
        top, left, bottom, right = box
        if left < 240:
            if globals.class1 == "gesture0":
                Command="單手左手手勢零"
            elif globals.class1 == "gesture1":
                Command="單手左手手勢一"
            elif globals.class1 == "gesture2":
                Command="單手左手手勢二"
            elif globals.class1 == "gesture3":
                Command="單手左手手勢三"
            elif globals.class1 == "gesture4":
                Command="單手左手手勢四"
            elif globals.class1 == "gesture5":
                Command="單手左手手勢五"
            elif globals.class1 == "gesture6":
                Command="單手左手手勢六"
            elif globals.class1 == "gestureOK":
                Command="單手左手手勢O"
            elif globals.class1 == "gestureR1":
                Command="單手左手手R1"
            elif globals.class1 == "gestureR2":
                Command="單手左手手R2"
            elif globals.class1 == "gestureR3":
                Command="單手左手手R3"
            elif globals.class1 == "gestureR4":
                Command="單手左手手R4"
            elif globals.class1 == "gestureR5":
                Command="單手左手手R5"
            elif globals.class1 == "gestureR6":
                Command="單手左手手R6"
            
        elif left > 240:
            if globals.class1 == "gesture0":
                Command="單手右手手勢零"
            elif globals.class1 == "gesture1":
                Command="單手右手手勢一"
            elif globals.class1 == "gesture2":
                Command="單手右手手勢二"
            elif globals.class1 == "gesture3":
                Command="單手右手手勢三"
            elif globals.class1 == "gesture4":
                Command="單手右手手勢四"
            elif globals.class1 == "gesture5":
                Command="單手右手手勢五"
            elif globals.class1 == "gesture6":
                Command="單手右手手勢六"
            elif globals.class1 == "gestureOK":
                Command="單手右手手勢O"
            elif globals.class1 == "gestureR1":
                Command="單手右手手R1"
            elif globals.class1 == "gestureR2":
                Command="單手右手手R2"
            elif globals.class1 == "gestureR3":
                Command="單手右手手R3"
            elif globals.class1 == "gestureR4":
                Command="單手右手手R4"
            elif globals.class1 == "gestureR5":
                Command="單手右手手R5"
            elif globals.class1 == "gestureR6":
                Command="單手右手手R6"
    
    elif globals.number_of_boxes == 2:#雙手 
        box1 = globals.location_of_boxes[0]
        box2 = globals.location_of_boxes[1]
        top1, left1, bottom1, right1 = box1
        top2, left2, bottom2, right2 = box2
        if left1 < 240:
            if left2 > 240:
                #左手
                if globals.class1 == "gesture0":
                    lefthand="手勢零"
                elif globals.class1 == "gesture1":
                    lefthand="手勢一"
                elif globals.class1 == "gesture2":
                    lefthand="手勢二"
                elif globals.class1 == "gesture3":
                    lefthand="手勢三"                    
                elif globals.class1 == "gesture4":
                    lefthand="手勢四"
                elif globals.class1 == "gesture5":
                    lefthand="手勢五"
                elif globals.class1 == "gesture6":
                    lefthand="手勢六"            
                elif globals.class1 == "gestureOK":
                    lefthand="手勢O"   
                elif globals.class1 == "gestureR1":
                    lefthand="手R1"
                elif globals.class1 == "gestureR2":
                    lefthand="手R2"
                elif globals.class1 == "gestureR3":
                    lefthand="手R3"
                elif globals.class1 == "gestureR4":
                    lefthand="手R4"
                elif globals.class1 == "gestureR5":
                    lefthand="手R5"
                elif globals.class1 == "gestureR6":
                    lefthand="手R6"            
                #右手
                if globals.class2 == "gesture0":
                    righthand="手勢零"
                elif globals.class2 == "gesture1":
                    righthand="手勢一"
                elif globals.class2 == "gesture2":
                    righthand="手勢二"
                elif globals.class2 == "gesture3":
                    righthand="手勢三"                    
                elif globals.class2 == "gesture4":
                    righthand="手勢四"
                elif globals.class2 == "gesture5":
                    righthand="手勢五"
                elif globals.class2 == "gesture6":
                    righthand="手勢六"            
                elif globals.class2 == "gestureOK":
                    righthand="手勢O"   
                elif globals.class2 == "gestureR1":
                    righthand="手R1"
                elif globals.class2 == "gestureR2":
                    righthand="手R2"
                elif globals.class2 == "gestureR3":
                    righthand="手R3"                    
                elif globals.class2 == "gestureR4":
                    righthand="手R4"
                elif globals.class2 == "gestureR5":
                    righthand="手R5"
                elif globals.class2 == "gestureR6":
                    righthand="手R6"            
                
                Command="雙手左手"+lefthand+"右手"+righthand
                
        elif left1 > 240:
            if left2 < 240:
                #左手
                if globals.class2 == "gesture0":
                    lefthand="手勢零"
                elif globals.class2 == "gesture1":
                    lefthand="手勢一"
                elif globals.class2 == "gesture2":
                    lefthand="手勢二"
                elif globals.class2 == "gesture3":
                    lefthand="手勢三"                    
                elif globals.class2 == "gesture4":
                    lefthand="手勢四"
                elif globals.class2 == "gesture5":
                    lefthand="手勢五"
                elif globals.class2 == "gesture6":
                    lefthand="手勢六"            
                elif globals.class2 == "gestureOK":
                    lefthand="手勢O"   
                elif globals.class1 == "gestureR1":
                    lefthand="手R1"
                elif globals.class1 == "gestureR2":
                    lefthand="手R2"
                elif globals.class1 == "gestureR3":
                    lefthand="手R3"
                elif globals.class1 == "gestureR4":
                    lefthand="手R4"
                elif globals.class1 == "gestureR5":
                    lefthand="手R5"
                elif globals.class1 == "gestureR6":
                    lefthand="手R6"      
                #右手
                if globals.class1 == "gesture0":
                    righthand="手勢零"
                elif globals.class1 == "gesture1":
                    righthand="手勢一"
                elif globals.class1 == "gesture2":
                    righthand="手勢二"
                elif globals.class1 == "gesture3":
                    righthand="手勢三"                    
                elif globals.class1 == "gesture4":
                    righthand="手勢四"
                elif globals.class1 == "gesture5":
                    righthand="手勢五"
                elif globals.class1 == "gesture6":  
                    righthand="手勢六"            
                elif globals.class1 == "gestureOK":
                    righthand="手勢O"       
                elif globals.class2 == "gestureR1":
                    righthand="手R1"
                elif globals.class2 == "gestureR2":
                    righthand="手R2"
                elif globals.class2 == "gestureR3":
                    righthand="手R3"                    
                elif globals.class2 == "gestureR4":
                    righthand="手R4"
                elif globals.class2 == "gestureR5":
                    righthand="手R5"
                elif globals.class2 == "gestureR6":
                    righthand="手R6"           
                
                Command="雙手左手"+lefthand+"右手"+righthand          
                
    elif globals.number_of_boxes == 0:#未偵測到手
        pass            
    #    Command="無手"
               
    print(Command)     
    
    
    '''try:
        conn.send(bytes(Command.encode('utf-8')))
        
    except:
        pass''
            
    if client_msg=="暫停辨識手勢":
        break'''
    if c==27:#使用者按下Esc建
        capture.release()
        cv2.destroyAllWindows()
        #break
    
    
    '''
    while client_msg=="暫停辨識手勢":
    print("Waiting")
    if client_msg=="使用者欲辨識手勢":
        break
    '''