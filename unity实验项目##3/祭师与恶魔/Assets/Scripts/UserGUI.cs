using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserGUI : MonoBehaviour, IUserAction {

    private int state;
    public UserGUI(){
        state = -1;
    }
    public void setLose(){
        state = 0;
    }
    public void setWin(){
        state = 1;
    }

    public void display(){
        OnGUI();
    }
    void OnGUI(){
        //初始化UI
        GUIStyle style = new GUIStyle{
            fontSize = 45,
        };
        GUIStyle style1 = new GUIStyle
        {
            fontSize = 20,
        };
        style.normal.textColor = new Color(200 / 255f, 200 / 255f, 150 / 255f);    
        GUI.Label(new Rect(UnityEngine.Screen.width/4, UnityEngine.Screen.height/10, 180, 70), "绿色代表天使，红色代表恶魔", style1);

        //三种状态下UI提示的设置
        if (GUI.Button(new Rect(UnityEngine.Screen.width / 10, UnityEngine.Screen.height / 10, 100, 50), "重置所有对象")){
            Director.GetInstance().scene.Reset();
        }
        if (state == 0){
            style.normal.textColor = new Color(255 / 255f, 0 / 255f, 0 / 255f);
            GUI.Label(new Rect(UnityEngine.Screen.width / 3, UnityEngine.Screen.height/1.3f, 180, 70), "您违背了游戏规则，失败了", style);
        }
        if (state == 1){
            style.normal.textColor = new Color(255 / 255f, 0 / 255f, 0 / 255f);
            GUI.Label(new Rect(UnityEngine.Screen.width/3, UnityEngine.Screen.height / 1.3f, 180, 70), "您取得了胜利", style);
        }
    }
}