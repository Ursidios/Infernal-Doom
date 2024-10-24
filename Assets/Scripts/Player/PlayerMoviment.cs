using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerMoviment : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private Rigidbody2D rb;
    public bool isOnFloor;
    private WeaponController weaponController;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Move();

        weaponController = GetComponent<WeaponController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(!weaponController.isAiming)
            Move();
    }
    void Update()
    {
        if(Input.GetButtonDown("Jump"))
            Jump();
    }

    public float GetXDirection()
    {
        float x = Input.GetAxisRaw("Horizontal");    

        return x;
    }
    public float GetYDirection()
    {
        float y = Input.GetAxisRaw("Vertical");

        return y;
    }

    public void Move()
    {
        rb.AddForce(Vector2.right * GetXDirection()  * speed, ForceMode2D.Force);
    }
    
    public void Jump()
    {
        if(isOnFloor)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Force) ;
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        Vector2 pontoDeContato = collision.contacts[0].point;

        Vector2 posicaoDoObjeto = transform.position;

        if (pontoDeContato.y < posicaoDoObjeto.y)
        {
           isOnFloor = true;
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        isOnFloor = false;
    }
}
