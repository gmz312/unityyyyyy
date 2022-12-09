using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    void Start()
    {
        
        this.transform.position = new Vector3(-8, 10, 0);
        this.transform.rotation = Quaternion.Euler(new Vector3(30, 90, 0));
    }

}
