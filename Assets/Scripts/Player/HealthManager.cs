using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public int life;
    public AudioSource painAudio;
    public AudioSource cureAudio;

    public Slider sliderLife;
    public UnityEvent onDie;
    void Awake()
    {
        sliderLife.maxValue = life;
    }
    public void TakeDamage(int Damage)
    {
        life -= Damage;
        painAudio.Play();
    }
    public void Cure(int value)
    {
        life += value;
        cureAudio.Play();
    }

    public void Update()
    {
        if(life <= 0)
        {
            Die();
        }
        sliderLife.value = life;
    }

    public void Die()
    {
        Destroy(gameObject);
        onDie?.Invoke();
    }
}
