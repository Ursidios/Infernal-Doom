using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeCollect : MonoBehaviour
{
    public int cureValue;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<HealthManager>().Cure(cureValue);
            Destroy(gameObject);
        }
    }
}
