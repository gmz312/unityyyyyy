using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flare : MonoBehaviour
{
    ParticleSystem particleSystem;
    ParticleSystem.ForceOverLifetimeModule forceMode;
    ParticleSystem.ColorOverLifetimeModule colorMode;
    int windPower;

    // Use this for initialization
    void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
        forceMode = particleSystem.forceOverLifetime;
        colorMode = particleSystem.colorOverLifetime;
    }

    public void LeftWind()
    {
        ParticleSystem.MinMaxCurve temp = forceMode.x;
        temp.constantMax += -0.3f;
        forceMode.x = temp;
    }

    public void RightWind()
    {
        ParticleSystem.MinMaxCurve temp = forceMode.x;
        temp.constantMax += 0.3f;
        forceMode.x = temp;
    }
}