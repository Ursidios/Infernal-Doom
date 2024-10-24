using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    private PlayerMoviment playerMoviment;
    public Vector2 directionAim;
    public GameObject aimPivot;
    public GameObject aimObj;
    public bool isAiming;

    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        playerMoviment = GetComponent<PlayerMoviment>();
    }

    // Update is called once per frame
    void Update()
    {
        directionAim.x = playerMoviment.GetXDirection();
        directionAim.y = playerMoviment.GetYDirection();

        aimPivot.transform.localPosition = new Vector3(directionAim.x, directionAim.y, 0);

        isAiming = Input.GetButton("Fire3");

        if(isAiming)
        {
            LookAt2D(aimObj.transform, aimPivot.transform);
        }
        else if(directionAim.x == -1)
        {
            aimObj.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 180));
        }
        else if(directionAim.x == 1)
        {
            aimObj.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }


        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    public void LookAt2D(Transform myObject, Transform target)
    {
        Vector3 direction = target.position - transform.position;
        
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        
        myObject.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    public void Shoot()
    {
        Instantiate(bullet, aimObj.transform.position, aimObj.transform.rotation);
    }
}
