using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalManager : MonoBehaviour
{
    public LayerMask playerLayer;

    public bool startCount;
    public List<GameObject> enemysObjs;
    public GameObject portal;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(startCount)
        {
            for (int i = 0; i < enemysObjs.Count; i++)
            {
                if(enemysObjs[i] == null)
                {
                    enemysObjs.Remove(enemysObjs[i]);
                }
            }
        }

        if(enemysObjs.Count <= 0)
        {
            portal.SetActive(true);
        }
    }

    public void OnTriggerEnter2D(Collider2D collider2D)
    {
        if(collider2D.CompareTag("Player"))
        {
            startCount = true;
        }
    }
}
