using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiskFlyAction : SSAction {
    public float gravity = -0.1f;                              //重力加速度(-9.8过快)
    private Vector3 start_velocity;                            //初速度
    private Vector3 delta_velocity = Vector3.zero;             //由重力引起的速度改变量
    private Vector3 current_angle = Vector3.zero;              //当前速度的欧拉角
    private float time;                                        //已经过去的时间

    private DiskFlyAction() { }
    public static DiskFlyAction GetSSAction(int lor, float angle, float speed) {
        //初始化物体速度
        DiskFlyAction action = CreateInstance<DiskFlyAction>();
        if (lor == -1) {
            action.start_velocity = Quaternion.Euler(new Vector3(0, 0, -angle)) * Vector3.left * speed;
        }
        else {
            action.start_velocity = Quaternion.Euler(new Vector3(0, 0, angle)) * Vector3.right * speed;
        }
        return action;
    }

    public override void Update() {
        //计算物体的向下的速度(水平速度不变)
        time += Time.fixedDeltaTime;
        delta_velocity.y = gravity * time;

        //移动物体
        transform.position += (start_velocity + delta_velocity) * Time.fixedDeltaTime;
        current_angle.z = Mathf.Atan((start_velocity.y + delta_velocity.y) / start_velocity.x) * Mathf.Rad2Deg;
        transform.eulerAngles = current_angle;

        //检测移动是否结束
        if (this.transform.position.y < -10) {
            this.enable = false;  
        }
    }

    public override void FixedUpdate() { }
    public override void Start() { }
}
