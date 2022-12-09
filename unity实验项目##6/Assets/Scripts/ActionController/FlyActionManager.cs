using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyActionManager : SSActionManager {
    public DiskFlyAction fly;  
    public DiskPhysicFlyAction ph_fly;

    public void DiskFly(GameObject disk, float angle, float speed) {
        disk.GetComponent<Rigidbody>().isKinematic = true;
        int leftOrRight = 1;//from left is 1, from right is -1
        if (disk.transform.position.x > 0) leftOrRight = -1;
        fly = DiskFlyAction.GetSSAction(leftOrRight, angle, speed);
        this.StartAction(disk, fly);
    }
    public void DiskFly(GameObject disk, float power) {
        disk.GetComponent<Rigidbody>().isKinematic = false;
        int leftOrRight = 1;
        if (disk.transform.position.x > 0) leftOrRight = -1;
        ph_fly = DiskPhysicFlyAction.GetSSAction(leftOrRight, power);
        this.StartAction(disk, ph_fly);
    }
}
