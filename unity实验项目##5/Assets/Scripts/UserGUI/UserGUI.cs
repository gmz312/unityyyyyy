using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserGUI  : MonoBehaviour {
    private IUserAction action;
    private bool started = false;
    GUIStyle text_style;
    GUIStyle header_style;

    void Start () {
        action = SSDirector.GetInstance().CurrentScenceController as IUserAction;

        text_style = new GUIStyle();
        header_style = new GUIStyle();
        text_style.normal.textColor = new Color(105, 105, 105);
        text_style.fontSize = 18;
        header_style.normal.textColor = new Color(0, 0, 0);
        header_style.fontSize = 30;
    }
	void OnGUI () {
        if (started) {

            GUI.Label(new Rect(100, 5, 50, 50), "轮次:" + action.GetRound().ToString(), text_style);
            GUI.Label(new Rect(180, 5, 50, 50), "Trial:" + action.GetTrial().ToString(), text_style);
            GUI.Label(new Rect(260, 5, 50, 50), "总得分:"+ action.GetScore().ToString(), text_style);

            if (action.isEnd()) {
                GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 180, 100, 100), "游戏结束", header_style);
                GUI.Label(new Rect(Screen.width / 2 - 30, Screen.height / 2 - 80, 50, 50), "您的总得分:" + action.GetScore().ToString(), text_style);
                if (GUI.Button(new Rect(Screen.width / 2 - 20, Screen.height / 2, 100, 50), "再来一局"))
                {
                    
                    action.Restart();
                    return;

                }
                
                action.GameOver();
            }
        }
        else {
            GUI.Label(new Rect(Screen.width / 2 - 50, 100, 100, 100), "hit disk", header_style);
            GUI.Label(new Rect(Screen.width / 2 - 100, 150, 100, 100), "鼠标左键点击", text_style);
            if (GUI.Button(new Rect(Screen.width / 2 - 50, 200, 100, 50), "开始")) {
                started = true;
                action.Restart();
            }
        }
    }
   
}
