using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {
    //响应鼠标点击
    void OnMouseDown()
    {
        Director.GetInstance().scene.moveObjTo(transform.name);
    }

}