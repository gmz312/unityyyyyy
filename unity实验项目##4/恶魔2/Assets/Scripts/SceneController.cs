using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SceneController
{
    void LoadResources();                           
    int getObjPos(string name); 
    void moveObjTo(string name);
    void Reset();
} 