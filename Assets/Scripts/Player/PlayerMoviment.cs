using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMoviment : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public Transform groundDetector;
    [HideInInspector] public Rigidbody2D rb;
    public float gravityMultiplayer;
    public float maxGravity;
    private float initialGravity;
    public bool isOnFloor;
    public bool isMoviment;
    public LayerMask GroundLayer;
    public float groundDetectorRadius;
    private WeaponController weaponController;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        initialGravity = rb.gravityScale;

        Move();

        weaponController = GetComponent<WeaponController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {        
        if(OpenMenu.isMenuOpen)
            return;
            
        if(!weaponController.isAiming)
        {
            Move();
            isMoviment = true;
        }
        else
        {
            rb.velocity = new Vector2(0, 0);
            isMoviment = false;
        }
    }
    void Update()
    {
        if(OpenMenu.isMenuOpen)
            return;
            
        if(Input.GetButtonDown("Jump"))
            Jump();
        GroundDetector();
        if(!isOnFloor)
        {
            rb.gravityScale += Time.deltaTime * gravityMultiplayer;

            if(rb.gravityScale >= maxGravity)
            {
                rb.gravityScale = maxGravity;
            }
        }
        else
        {
            rb.gravityScale = initialGravity;
        }


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
        rb.velocity = new Vector2(GetXDirection()  * speed, rb.velocity.y);
    }
    
    public void Jump()
    {
        if(isOnFloor)
        {
           // rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Force) ;
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            
        }
    }

    public void GroundDetector()
    {
        isOnFloor = Physics2D.OverlapCircle(groundDetector.position, groundDetectorRadius, GroundLayer);
    }
}
