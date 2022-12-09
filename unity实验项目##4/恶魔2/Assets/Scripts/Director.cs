using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Director : System.Object {
    private static Director instance_1;
    public SceneController scene { get; set; }
    public static Director GetInstance()
    {
        if (instance_1 == null){
            instance_1 = new Director();
        }
        return instance_1;
    }
}