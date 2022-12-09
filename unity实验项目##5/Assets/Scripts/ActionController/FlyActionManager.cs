using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyActionManager : SSActionManager {
    public DiskFlyAction fly;  
    public void DiskFly(GameObject dtsk, float angle, float v) {
        int leftOrRight = 1;//from left is 1, from right is -1
        if (dtsk.transform.position.x > 0) leftOrRight = -1;
        fly = DiskFlyAction.GetSSAction(leftOrRight, angle, v);
        this.StartAction(dtsk, fly);
    }
}
