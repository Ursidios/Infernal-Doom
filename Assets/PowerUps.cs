using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    [Header ("NightVision")]
    public bool nightVision;
    public float timerToNextUseMax;
    private float timerToNextUse;
    public GameObject NightVisionLight;
    public bool visionOn;
    public float timeOfUseMax;
    private float timeOfUse;

    // Start is called before the first frame update
    void Start()
    {
        timeOfUse = timeOfUseMax;
    }

    // Update is called once per frame
    void Update()
    {
        if(nightVision)
        {
            NightVision();
        }
    }

    public void NightVision()
    {
        NightVisionLight.SetActive(visionOn); 

        if(visionOn)
        {
            timeOfUse -= Time.deltaTime;
            if(timeOfUse <= 0)
            {
                timeOfUse = timeOfUseMax;
                visionOn = false;
            }
        }
        else
        {
            timerToNextUse -= Time.deltaTime;       
            if(timerToNextUse <= 0)
            {
                if(Input.GetKeyDown(KeyCode.Tab))
                {
                    visionOn = true;
                    timerToNextUse = timerToNextUseMax;
                }
            }

        }
    }

    public void OnTriggerEnter2D(Collider2D collider2D)
    {
        if(collider2D.CompareTag("NightVision"))
        {
            nightVision = true;
            Destroy(collider2D.gameObject);
        }
    }
}
