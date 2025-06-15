using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLigthController : MonoBehaviour
{
    public GameObject RedLight;
    public GameObject YellowLight;
    public GameObject GreenLight;

    public float TimerChangeLight;
    public float TimerChangeLightStart;

    public int LightSelector;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TimerChangeLight -= Time.deltaTime;
        if (TimerChangeLight < 0) 
        {
            LightSelector++;
            if (LightSelector > 3)
            {
                LightSelector = 0;
            }
            if (LightSelector == 1)
            {
                TimerChangeLight = TimerChangeLightStart / 2;
            }
            else
            {
                TimerChangeLight = TimerChangeLightStart;
            }
            if (LightSelector == 0)
            {
                RedLight.SetActive(true);
                YellowLight.SetActive(false);
                GreenLight.SetActive(false);
            }
            if (LightSelector == 1)
            {
                RedLight.SetActive(false);
                YellowLight.SetActive(true);
                GreenLight.SetActive(false);
            }
            if (LightSelector == 2)
            {
                RedLight.SetActive(false);
                YellowLight.SetActive(false);
                GreenLight.SetActive(true);
            }
        }

       
            
        
    }
}
