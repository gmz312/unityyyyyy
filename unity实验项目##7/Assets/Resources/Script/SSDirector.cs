﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SSDirector : System.Object {

    private static SSDirector _instance;

    public ISceneController currentScenceController { get; set; }
    //用于存储当前场景的场景控制器
    private SSDirector() { }
    public static SSDirector getInstance()
    {
        if (_instance == null)
        {
            _instance = new SSDirector();
        }
         return _instance;
    }

    public int getFPS()
    {
        return Application.targetFrameRate;
    }
    public void setFPS(int fps)
    {
        Application.targetFrameRate = fps;
    }
}
