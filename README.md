# Hand_Gesture_Training-yolov4

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
| Moving down | 👎 | Move the robotic arm down to the material position |
| Carry | 🤏 | Close the gripper of the robotic arm |
| Drop | ✌ | Open the gripper of the robotic arm |
| Confirm | 👌 | Confirm execution of voice commands |
| Pause | ✊ | Pause the current command action |
| Cancel | 🤞 | Cancel the current voice command and re-identify |


Factory moving situation
    ***What is Euclidean Geometry?***
Log in to Google Drive and get image, xml and py files
Prepare the corresponding environment



