using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiskFlyAction : SSAction {
    public float gravity = -0.1f;//模拟重力加速度
    private Vector3 start_velocity;//初始速度

    private Vector3 st_ty;//start velocity
    

    private Vector3 del_velocity = Vector3.zero;//速度变化量
    private Vector3 now_angle = Vector3.zero;//vector
    private float time;//time

    
    public static DiskFlyAction GetSSAction(int lor, float angle, float speed) {
        //初始化物体速度
        DiskFlyAction action = CreateInstance<DiskFlyAction>();
        if (lor == -1) {
            action.start_velocity = Quaternion.Euler(new Vector3(0, 0, -angle)) * Vector3.left * speed;}
        else {
            action.start_velocity = Quaternion.Euler(new Vector3(0, 0, angle)) * Vector3.right * speed;}
        return action;}

    public override void Update() {//垂直分速度
        time += Time.fixedDeltaTime;
        del_velocity.y = gravity * time;
        transform.position += (start_velocity + del_velocity) * Time.fixedDeltaTime;
        now_angle.z = Mathf.Atan((start_velocity.y + del_velocity.y) / start_velocity.x) * Mathf.Rad2Deg;
        transform.eulerAngles = now_angle;
        if (this.transform.position.y < -10) {
            this.enable = false;  
        }
    }

    
    private DiskFlyAction() { }

    public override void Start() { }
}
