# Hand_Gesture_Training-yolov4

Train the gesture with Yolov4, which is used to control the robot arm in smart construction to solve the problem of insufficient manpower in construction industry

https://user-images.githubusercontent.com/69034494/161987988-897eb631-9699-40dc-9368-6200e5a35245.mp4

## Purpose

* issue 
    1. To improve the serious shortage of labor in Taiwan’s construction industry
    2. To solve the problem that laborers are unwilling to do a lot of rough work (eg: nailing templates, cutting templates, tying steel bars, etc.)

* Solution 
    1. Use robotic arms to replace manpower, and replace a lot of manual work by controlling the robotic arm and designing its operation script.
    2. Use the advantage that the mechanical arm can lift heavier objects to solve the situation of rough labor without human resources.

## Situational application

1. Construction site environment

    * Robotic Arm Construction System --- Gesture Recognition
    
        > In the second situation，when the scene is a relatively noisy construction site environment, because the sound cannot be well received, gesture recognition can be used to execute the written script in this situation, such as the path of stacking bricks.

2. Building materials wholesale factory environment

    * Robotic Arm Handling system --- Speech Recognition
    
        > In the first situation，since the hands of the workers need to do other tasks during the handling process in the factory, it is inconvenient for the hands to move. Therefore, in this case, voice recognition can be used to instruct the robotic arm to move the building materials, and carry them back and forth between two points.


## Gesture Recognition

| Command | Gesture | Purpose | 
|-------|:-----:|-------|
| Move to material point |  ☝  | The robot arm moves to the starting position for moving materials  |
| Move to destination |  🤙  | The robotic arm moves to the destination where the material is stacked |
| Start operation  |  🖐  | Activate the robot arm (servo on) |
| End operation | ✋ | Close the robot arm (servo off) |
| Down | 👎 | Move the robotic arm down to the material position |
| Clamp | 🤏 | Close the gripper of the robotic arm |
| Drop | ✌ | Open the gripper of the robotic arm |
| Confirm | 👌 | Confirm execution of voice commands |
| Pause | ✊ | Pause the current command action |
| Cancel | 🤞 | Cancel the current voice command and re-identify |

* Situation simulation: 
    1. Suppose there is an operational situation where materials need to be moved from A (x=10,y=10,z=0) to B (x=20,y=20,z=0).
Factory moving situation

* Operation process: 
    1. Manually input material point and destination point position on the user interface, and click the initialization command such as servo on.

    2. After the mechanical equipment is ready, enter the following sequence in front of the camera: 
       > "☝" -> "👎" -> "✊" -> "✌" ->"🤏" -> "🤙" -> "👎" -> "✊" -> "✌"

## Training

Training with Google Colab and Kaggle

* Log in to Google Drive and get image, xml and py files
* Prepare the corresponding environment
![image](https://user-images.githubusercontent.com/69034494/162375751-0f56bde1-4adb-4d83-ba4b-86dd20362336.png)

* Modify the corresponding file path in the train_add_plot.py file
* Execute train_add_plot.py directly
![image](https://user-images.githubusercontent.com/69034494/162375860-256b069c-0305-4f77-ae46-db4266142cea.png)

* When performing the first half of training (freeze training), one epoch takes about 12 minutes, and the training ends early at 19 epochs
![image](https://user-images.githubusercontent.com/69034494/162376058-3304fe72-6be6-41ab-bafe-7091e0038d00.png)

* When performing the second half of the training, one epoch takes about 15 to 20 minutes.
* Move to Kaggle for training starting at 32 epochs
![image](https://user-images.githubusercontent.com/69034494/162376274-c7f072c7-0548-4477-84db-b1c71d62d56f.png)

* Prepare the corresponding environment
* The default GPU driver version of Kaggle is Cuda 11.0.0, and Cuda 10.0.0 needs to be installed for tensorflow-gpu 1.13.2
![image](https://user-images.githubusercontent.com/69034494/162376530-a2deb13b-a8a5-41b5-b3cf-af4076e943e1.png)

* In the second half of the training part, one epoch takes about 7 minutes to execute, and 20 epochs take about 3 hours to execute (including environment installation)
![image](https://user-images.githubusercontent.com/69034494/162376694-f0cb312b-42ac-4caf-a149-73e538ec6fe0.png)

* Output can be downloaded
![image](https://user-images.githubusercontent.com/69034494/162376791-ef01bb75-def6-4e3e-90ad-32991fa6fe18.png)

* Final result: open and run yolo.py (first) and video.py (later)

https://user-images.githubusercontent.com/69034494/162377082-d1663c78-855e-4b93-b315-b36493aedb0b.mp4

## Conclusion

1. When using Colab in the first half, it is necessary to keep the webpage open, which will affect the performance of the laptop. The second half moves to Kaggle training to solve this problem.
2. Because it is not executed all at once, it cannot be drawn through the history parameter, and plt.plot cannot be displayed in the log result. If you use Kaggle to train from scratch and change the plot to saveimg, it should be able to solve the problem and get the pictures of acc and loss.
3. The environment versions of Colab and Kaggle are newer than the version required for yolo training, so there will be an error caused by inconsistency of function parameters. It is necessary to add instructions to install the corresponding version and downgrade tensorflow and keras to execut.
4. Colab's GPU limit is not clear, there have been cases where two accounts were restricted from using the GPU.

## Recommendations for Future Research

Data set can be expanded
1. The gesture data set is too simple, and the recognition results are limited and inaccurate. It requires gestures on a white background and a certain angle to be recognized.
2. The current model is that the training gesture data is not enough. In the future, more gestures from different people can be added to make the training more accurate.
