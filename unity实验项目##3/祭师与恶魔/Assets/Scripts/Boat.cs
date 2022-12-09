using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat{
    public GameObject boat_obj;
    public Move move;
    public int movestate;   // 船的移动状态，0表示静止，1表示从from到to，2表示从to到from
    public int[] BoatState;  // 两个位置的状态，0代表无，1-3代表Priest1-Priest3,4-6代表Devil1-Devil3
    public int num;         // 船上人数
    public int position;        // 船的位置,0代表from，1代表to

    public Boat()
    {
        //初始化船的object
        boat_obj = Object.Instantiate(Resources.Load("Objects/Boat", typeof(GameObject)), new Vector3(0, -4, 5), Quaternion.identity, null) as GameObject;
        boat_obj.name = "boat";
        var addComp = boat_obj.AddComponent(typeof(Move)) as Move;
        boat_obj.AddComponent<BoxCollider>();
        boat_obj.transform.rotation = Quaternion.Euler(-90, 0, 0);
        //设置状态
        movestate = 0;
        num = 0;
        position = 0;
        BoatState = new int[2];
        BoatState[0] = 0;
        BoatState[1] = 0;
    }

}