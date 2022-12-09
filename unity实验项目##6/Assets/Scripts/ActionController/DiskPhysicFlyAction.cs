using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiskPhysicFlyAction : SSAction {
    private Vector3 start_vector;                              
    public float power;
    private DiskPhysicFlyAction() { }
    
    public static DiskPhysicFlyAction GetSSAction(int lor, float power) {
        DiskPhysicFlyAction action = CreateInstance<DiskPhysicFlyAction>();
        if (lor == -1) {
            action.start_vector = Vector3.left * power;
        }
        else {
            action.start_vector = Vector3.right * power;
        }
        action.power = power;
        return action;
    }

    public override void Update() { }

    public override void FixedUpdate() {
        if (transform.position.y <= -10f) {
            gameobject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            this.enable = false;  
        }
    }

    public override void Start() {
        gameobject.GetComponent<Rigidbody>().AddForce(start_vector * 10, ForceMode.Impulse);
    }
}