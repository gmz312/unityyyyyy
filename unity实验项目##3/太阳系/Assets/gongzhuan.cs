using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gongzhuan : MonoBehaviour
{   
    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        GameObject.Find("shuixing").transform.RotateAround(Vector3.zero, new Vector3(0.1f, 1, 0), 60 * Time.deltaTime);

        GameObject.Find("diqiu").transform.RotateAround(Vector3.zero, new Vector3(0.1f, 1, 0), 50 * Time.deltaTime);

        GameObject.Find("muxing").transform.RotateAround(Vector3.zero, new Vector3(0.1f, 1, 0), 80 * Time.deltaTime);

        GameObject.Find("haiwangxing").transform.RotateAround(Vector3.zero, new Vector3(0.1f, 1, 0), 30 * Time.deltaTime);

    }
}
