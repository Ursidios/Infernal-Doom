using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int life;
    public AudioSource painAudio;
    public void TakeDamage(int Damage)
    {
        life -= Damage;
        painAudio.Play();
    }
}
