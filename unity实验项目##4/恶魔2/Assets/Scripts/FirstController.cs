using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//PART 2
public class FirstController : MonoBehaviour, SceneController{

    private int state;  
    private Role[] Priests;//定义天使
    private Role[] Devils;//定义魔鬼
    private GameObject GroundFrom;//河岸
    private GameObject GroundTo;
    private GameObject River;//河流
    private Boat boat;//船
    private int fromNum_devil;//两个河岸魔鬼数量
    private int toNum_devil;
    private int fromNum_priest;//两个河岸牧师数量
    private int toNum_priest;
    private UserGUI gui;
    private ActionController actionController;//调用action

    FirstController()
    {
        Priests = new Role[3];//创建三个天使
        Devils = new Role[3];//创建三个恶魔
    }

    void Start() {
        Director director = Director.GetInstance();
        director.scene = this;                     
        this.LoadResources();  
        actionController = new ActionController();////                     
    }



   void Update () {
        if(boat.movestate > 0){
            actionController.MoveBoat(boat, Priests, Devils);
        }
//caipan
        if ((fromNum_priest != 0 && fromNum_devil > fromNum_priest) || (toNum_priest != 0 && toNum_devil > toNum_priest)){
            state = 0;
            gui.setLose();
        }
        if (toNum_devil == 3 && toNum_priest == 3 && boat.num == 0){
            state = 1;
            gui.setWin();
        }
	}
   /* void Update () {
        if(boat.movestate > 0){
            //船移动
            Vector3 currentPos = boat.boat_obj.transform.position;
            Vector3[] boat_park = { new Vector3(0, -4, -5), new Vector3(0, -4, 5) };
            Vector3 park_now = boat_park[boat.movestate - 1];
            int boat_pos= boat.movestate - 1;
            if (currentPos == park_now){
                boat.movestate = 0;
            }
            boat.boat_obj.transform.position = Vector3.MoveTowards(currentPos, park_now, 7f * Time.deltaTime);
            //角色随船运动
            Vector3[,] seats = { 
                { new Vector3(0, -3, -6), new Vector3(0, -3, -5) },
                { new Vector3(0, -3, 5), new Vector3(0, -3, 6) }
            };
            for (int i = 0;i < 2;i++){
                int seat_pos = i;
                Role role_t = MapNumToRole(boat.BoatState[i]);
                if (role_t != null)
                {
                    Vector3 cur = role_t.obj.transform.position;
                    role_t.obj.transform.position = Vector3.MoveTowards(cur, seats[boat_pos,seat_pos], 7f * Time.deltaTime);
                }
            }
            
        }
        if ((fromNum_priest != 0 && fromNum_devil > fromNum_priest) || (toNum_priest != 0 && toNum_devil > toNum_priest)){
            state = 0;
            gui.setLose();
        }
        if (toNum_devil == 3 && toNum_priest == 3 && boat.num == 0){
            state = 1;
            gui.setWin();
        }
	}*/

    void OnGUI()
    {
        gui.display();
    }

    public void LoadResources()
    {
        state = -1;
        gui = new UserGUI();
        GroundFrom = Object.Instantiate(Resources.Load("Objects/Ground", typeof(GameObject)), new Vector3(0, -5, 15), Quaternion.identity, null) as GameObject;
        GroundFrom.name = "groundfrom";
        GroundTo = Object.Instantiate(Resources.Load("Objects/Ground", typeof(GameObject)), new Vector3(0, -5, -15), Quaternion.identity, null) as GameObject;
        GroundTo.name = "groundto";
        River = Object.Instantiate(Resources.Load("Objects/River", typeof(GameObject)), new Vector3(0, -6, 0), Quaternion.identity, null) as GameObject;
        River.name = "river";
        boat = new Boat();
        fromNum_priest = 3;
        toNum_priest = 0;
        for (int i = 0;i < 3; i++){
            Role role_temp = new Role("Objects/Priest");
            role_temp.setName("Priest"+ i);
            Priests[i] = role_temp;
            float p_z = (float)(9 + i * 1.5);
            Priests[i].setFromPos(new Vector3(0, -1, p_z));
            Priests[i].setToPos(new Vector3(0, -1, -p_z));
        }
        fromNum_devil = 3;
        toNum_devil = 0;
        for (int i = 0; i < 3; i++){
            Role role_temp = new Role("Objects/Devil");
            role_temp.setName("Devil" + i);
            Devils[i] = role_temp;
            float p_z = (float)(14 + i * 1.5);
            Devils[i].setFromPos(new Vector3(0, -1, p_z));
            Devils[i].setToPos(new Vector3(0, -1, -p_z));
        }

    }

    public void moveObjTo(string name)
    {
        // 不能操作的条件：
        //船正在运动
        //提示游戏胜利后
        //提示违反规则后
        //可以通过重置按钮返回初始形式
        //空船时船也不能行驶
        if(boat.movestate != 0||state != -1)
        {
            return;
        }
        if(name == "boat"){
            if(boat.position == 0 && boat.num > 0){
                boat.position = 1;
                boat.movestate = 1;

                foreach(int num in boat.BoatState){
                    if(num > 0 && num < 4){
                        fromNum_priest--;
                        toNum_priest++;
                    }
                    else if(num >= 4){
                        fromNum_devil--;
                        toNum_devil++;
                    }
                } 
            }
            else if(boat.position == 1 && boat.num > 0){
                boat.position = 0;
                boat.movestate = 2;

                foreach (int num in boat.BoatState){
                    if (num > 0 && num < 4){
                        toNum_priest--;
                        fromNum_priest++;
                    }
                    else if (num >= 4){
                        toNum_devil--;
                        fromNum_devil++;
                    }
                }
            }
        }
        //点击角色
        else{
            Role obj = findObjRole(name);
            if(obj.position == 0 && obj.position == boat.position && boat.num < 2){
                boat.num++;
                if(boat.BoatState[0] == 0){
                    obj.MoveToBoat(1);//1,2,3,4代表船的两个停泊位的各两个座位
                    boat.BoatState[0] = findObjOrder(name);
                }
                else{
                    obj.MoveToBoat(2);
                    boat.BoatState[1] = findObjOrder(name);
                }
            }
            else if(obj.position == 1 && obj.position == boat.position && boat.num < 2){
                boat.num++;
                if (boat.BoatState[0] == 0){
                    obj.MoveToBoat(4);
                    boat.BoatState[0] = findObjOrder(name);
                }
                else{
                    obj.MoveToBoat(3);
                    boat.BoatState[1] = findObjOrder(name);
                }
            }
            // 角色在船上，下船
            else if(obj.position == 2){
                if(boat.position == 0){
                    boat.num--;
                    boat.BoatState[obj.boatPos] = 0;
                    obj.MoveGroundFrom();
                }
                else{
                    boat.num--;
                    boat.BoatState[obj.boatPos] = 0;
                    obj.MoveGroundTo();
                }
            }
        }
    }

    public void Reset()
    {
        for(int i = 0;i < 3;i ++)
        {
            Destroy(Priests[i].obj);
            Destroy(Devils[i].obj);
            Destroy(boat.boat_obj);
            Destroy(GroundFrom);
            Destroy(GroundTo);
            Destroy(River);
        }
        LoadResources();
    }

    public Role findObjRole(string name)
    {
        Role obj = null;
        for (int i = 0; i < 3; i++){
            if (name == ("Priest" + i)){
                obj = Priests[i];
                break;
            }
        }
        for (int i = 0; i < 3; i++){
            if (name == ("Devil" + i)){
                obj = Devils[i];
                break;
            }
        }
        if(obj == null){
        }
        return obj;
    }

    public int findObjOrder(string name)
    {
        int obj = 0;
        for (int i = 0; i < 3; i++){
            if (name == ("Priest" + i)){
                obj = i + 1;
                break;
            }
        }
        for (int i = 0; i < 3; i++){
            if (name == ("Devil" + i)){
                obj = i + 4;
                break;
            }
        }
        if(obj == 0){
        }
        return obj;
    }

    public int getObjPos(string name)
    {
        if(name == "boat"){
            return boat.position;
        }
        else{
            return findObjRole(name).position;
        }
    }


    Role MapNumToRole(int num)
    {
        Role role_temp = null;
        if(num < 4 && num > 0){
            role_temp = Priests[num - 1];
        }
        else if(num >= 4 && num <= 6){
            role_temp = Devils[num - 4];
        }
        if(role_temp == null){
        }
        return role_temp;
    }

}