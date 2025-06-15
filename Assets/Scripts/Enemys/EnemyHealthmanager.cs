using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthmanager : MonoBehaviour
{    
    public int life;

    public bool useSlider;
    public Slider sliderVida;

    // Start is called before the first frame update
    void Start()
    {
        if (useSlider)
        {
            sliderVida.maxValue = life;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (life <= 0)
        {
            Destroy(gameObject);
        }
        if (useSlider)
        {
            sliderVida.value = life;   
        }
    }

    public void TakeDamage(int Damage)
    {
        life -= Damage;
    }
}
