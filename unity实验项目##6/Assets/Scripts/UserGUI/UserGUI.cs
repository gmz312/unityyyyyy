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

            GUI.Label(new Rect(100, 5, 50, 50), "回合：" + action.GetRound().ToString(), text_style);
            GUI.Label(new Rect(180, 5, 50, 50), "判断：" + action.GetTrial().ToString(), text_style);
            GUI.Label(new Rect(260, 5, 50, 50), "得分："+ action.GetScore().ToString(), text_style);

            if (action.isEnd()) {
                GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 180, 100, 100), "挑战失败!", header_style);
                GUI.Label(new Rect(Screen.width / 2 - 30, Screen.height / 2 - 80, 50, 50), "你的总得分是:" + action.GetScore().ToString(), text_style);
                if (GUI.Button(new Rect(Screen.width / 2 - 20, Screen.height / 2, 100, 50), "重新开始")) {
                    action.Restart();
                    return;
                }
                action.GameOver();
            }
            else{
                if (GUI.Button(new Rect(0, 50, 100, 50), "物理运动")) {
                    action.setPhysic(true);
                }
                if (GUI.Button(new Rect(0, 100, 100, 50), "变换运动")) {
                    action.setPhysic(false);
                }
            }
        }
        else {
            GUI.Label(new Rect(Screen.width / 2 - 50, 100, 100, 100), "Hit UFO", header_style);
            GUI.Label(new Rect(Screen.width / 2 - 100, 150, 100, 100), "Click the capsule by mouse1", text_style);
            if (GUI.Button(new Rect(Screen.width / 2 - 50, 200, 100, 50), "开始")) {
                started = true;
                action.Restart();
            }
        }
    }
   
}
