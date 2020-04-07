# IssueSceneHostMlapi
Project for issue report on MLAPI

**Describe the bug**
Main error : Cannot find pending soft sync object. Is the projects the same?
When starting an host that switch scene, the binding between any new client for any networkedobjects is not working. That result with different network id for scene objects (one that have networkedobject on).

**To Reproduce**
Steps to reproduce the behavior:
Go to this github repository :
Make 2 projects with this repository.
One should start playmode and press space to be the host.
One should start playmode and press b to be a client.

An error on client occured, you can check on the interaction scene the network id that are not the same.

**Expected behavior**
The networked behaviour should have the same networking idn and no error should be displayed

**Screenshots**
Error on client :
![image](https://user-images.githubusercontent.com/25880714/78668138-6c18f500-78da-11ea-8732-e0a08a987945.png)


**Environment (please complete the following information):**
 - OS:  Windows 10
 - Unity Version:  2019.3.3f1
 - MLAPI Version: 6.0.1


**Additional context**
Use in another context, find the bug and discuss it with NFMynster on discord. The workaround is to use the Unity Scene loader before starting the host like this : 
``` 
SceneManager.LoadScene("InteractionScene");
SceneManager.sceneLoaded += (arg0, arg1) => {
            NetworkingManager.Singleton.StartHost();
        };  
```
