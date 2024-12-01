using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeTimeScript : MonoBehaviour
{

    public float Timer;

    void Update()
    {
        Timer -= Time.deltaTime;

        if(Timer <= 0)
        {
            Destroy(gameObject);
        }
    }
}
