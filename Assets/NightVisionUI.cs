using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NightVisionUI : MonoBehaviour
{
    public Image nightVisionImage;
    public TMP_Text countDownText;
    public PowerUps powerUps;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        nightVisionImage.gameObject.SetActive(powerUps.nightVision);
        
        
        if(powerUps.canUse)
        {
            nightVisionImage.color = new Color(1, 1, 1, 1);
            countDownText.gameObject.SetActive(false);
        }
        else
        {
            nightVisionImage.color = new Color(1, 1, 1, 0.1f);
            countDownText.gameObject.SetActive(true);

            countDownText.text = powerUps.timerToNextUse.ToString("00");
        }
    }
}
