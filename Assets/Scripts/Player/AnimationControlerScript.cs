using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControlerScript : MonoBehaviour
{
    public PlayerMoviment playerMoviment;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerMoviment.isMoviment)
        {
            if(playerMoviment.GetXDirection() != 0)
            {
                anim.SetBool("Run", true);
            }
            else
            {
                anim.SetBool("Run", false);
            }

        }
        else
        {
            anim.SetBool("Run", false);
        }

        if(playerMoviment.GetXDirection() > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        if(playerMoviment.GetXDirection() < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }

        anim.SetBool("Jump", !playerMoviment.isOnFloor);
        anim.SetFloat("Velocity", playerMoviment.rb.velocity.normalized.x);
        
    }

    public void PlayAnimation(string name)
    {
        anim.Play(name);
    }
}
