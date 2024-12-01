using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    [Header ("NightVision")]
    public bool nightVision;
    public float timerToNextUseMax;
    [HideInInspector] public float timerToNextUse;
    public GameObject NightVisionLight;
    public bool visionOn;
    public bool canUse;
    public float timeOfUseMax;
    private float timeOfUse;
    public AudioSource nightVisionAudio;

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
                canUse = false;
            }
        }
        else
        {
            timerToNextUse -= Time.deltaTime;       
            if(timerToNextUse <= 0)
            {
                canUse = true;
                if(Input.GetKeyDown(KeyCode.Tab))
                {
                    visionOn = true;
                    nightVisionAudio.Play();
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
