using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*动作基类*/
public class SSAction : ScriptableObject {
    public bool enable = true;                      //是否进行
    public GameObject gameobject;                   //动作对象
    public Transform transform;                     //动作对象的transform

    /*防止用户自己new对象*/
    protected SSAction() { }

    public virtual void Start() {
        throw new System.NotImplementedException();
    }

    public virtual void Update() {
        throw new System.NotImplementedException();
    }

    public virtual void FixedUpdate() {
        throw new System.NotImplementedException();
    }
}
