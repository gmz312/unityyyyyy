using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserGUI : MonoBehaviour
{

    public flare flare1, flare2, flare3,flare4, flare5;

    void Start()
    {

    }

    void Update()
    {

    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(10, 150, 60, 30), "向左倾斜"))
        {
            flare1.LeftWind();
            flare2.LeftWind();
            flare3.LeftWind();
            flare4.LeftWind();
            flare5.LeftWind();
        }

        if (GUI.Button(new Rect(Screen.width-60, 150, 60, 30), "向右倾斜"))
        {
            flare1.RightWind();
            flare2.RightWind();
            flare3.RightWind();
            flare4.RightWind();
            flare5.RightWind();
        }
    }
}
