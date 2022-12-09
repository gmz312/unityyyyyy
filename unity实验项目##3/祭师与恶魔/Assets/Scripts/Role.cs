using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Role {
    public GameObject obj;
    public int position;//对象 ，0代表左侧，1代表右侧，2代表boat
    public int boatPos;//船
    private Move move;
    private Vector3 PosFrom;//左河岸
    private Vector3 PosTo;//右河岸
    public Role(string name)
    {
        obj = Object.Instantiate(Resources.Load(name, typeof(GameObject)), Vector3.zero, Quaternion.identity, null) as GameObject;
        position = 0;
        move = obj.AddComponent(typeof(Move)) as Move;
    }

    public void setName(string name)
    {
        obj.name = name;
    }
    //设置角色在河岸上的位置
    public void setFromPos(Vector3 vec)
    {
        obj.transform.position = vec;
        PosFrom = vec;
    }
    public void setToPos(Vector3 vec)
    {
        PosTo = vec;
    }
    //点击河岸上的对象
    //将角色移动至船上
    public void MoveToBoat(int i)
    {
        position = 2;
        if (i == 1){
            boatPos = 0;
            obj.transform.position = new Vector3(0, -3, 4);
        }
        else if(i == 2){
            boatPos = 1;
            obj.transform.position = new Vector3(0, -3, 6);
        }
        else if(i == 3){
            boatPos = 1;
            obj.transform.position = new Vector3(0, -3, -4);
        }
        else{
            boatPos = 0;
            obj.transform.position = new Vector3(0, -3, -6);
        }
    }
    //点击船上的对象
    //将角色移动回河岸
    public void MoveGroundFrom()
    {
        obj.transform.position = PosFrom;
        position = 0;
    }

    public void MoveGroundTo()
    {
        obj.transform.position = PosTo;
        position = 1;
    }

}