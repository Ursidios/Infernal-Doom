using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed;

    public float lifeTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(speed,0,0);

        lifeTime -= Time.deltaTime;

        if(lifeTime <= 0)
            Destroy(gameObject);
    }
}
