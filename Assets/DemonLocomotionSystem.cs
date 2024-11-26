using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Pathfinding;
using UnityEngine;

public class DemonLocomotionSystem : MonoBehaviour
{
    public Transform[] WayPoint;
    private int actualWayPoint;
    public Transform Player;
    public AIDestinationSetter aIDestinationSetter;
    public AIPath aIPath;
    public bool isPlayerVisible;
    public bool test;
    public SpriteRenderer SpriteObj;
    public Animator anim;

    public float circleEyeRadius = 2.0f;  // Raio do círculo de colisão
    public Vector2 circleOffset = Vector2.zero;  // Deslocamento do círculo em relação ao objeto
    public LayerMask playerMask;  // Máscara de camadas para verificar colisões

    private Collider2D[] hitPlayer;

    public bool normalState;
    // Start is called before the first frame update
    void Awake()
    {
        actualWayPoint = Random.Range(0, WayPoint.Length);

        aIDestinationSetter.target = WayPoint[actualWayPoint];
    }

    // Update is called once per frame
    void Update()
    {
        Eye();

        
        if(isPlayerVisible)
        {
            FollowPlayer();
            normalState = false;
        }
        else
        {
            if(normalState)
            {
                if(aIPath.reachedEndOfPath)
                {
                    if(!isPlayerVisible)
                    {
                        ChangeWay();
                    }
                }
            }
            else
            {
                aIDestinationSetter.target = gameObject.transform;
                normalState = true;
            }
        }


        if(aIPath.velocity.x == 0)
        {
            SpriteObj.flipX = SpriteObj.flipX;
        }
        else if(aIPath.velocity.x > 0)
        {
            SpriteObj.flipX = true;
        }
        else
        {
            SpriteObj.flipX = false;
        }

        if(aIPath.velocity.magnitude > 0)
        {
            anim.SetBool("Walk", true);
        }
        else
        {
            anim.SetBool("Walk", false);
        }

        if(hitPlayer.Length > 0)
        {
            isPlayerVisible = true;
        }
        else
        {
            isPlayerVisible = false;
        }
        
    }

    public void ChangeWay()
    {
        actualWayPoint ++;

        if(actualWayPoint >= WayPoint.Length)
        {
            actualWayPoint = 0;
        }

        aIDestinationSetter.target = WayPoint[actualWayPoint];
    }

    public void FollowPlayer()
    {
        aIDestinationSetter.target = Player;
    }

    public void Eye()
    {
        // Usamos Physics2D.OverlapCircle para verificar colisões com um círculo

        
        Vector2 position = (Vector2)transform.position + circleOffset;
        hitPlayer = Physics2D.OverlapCircleAll(position, circleEyeRadius, playerMask);

        // Exemplo: Verifica se houve colisão e mostra no console
        foreach (Collider2D hitCollider in hitPlayer)
        {
            Debug.Log("Colidiu com: " + hitCollider.gameObject.name);
        }
    }
    void OnDrawGizmos()
    {
        // Define a cor do Gizmo
        Gizmos.color = Color.green;

        // Desenha o wireframe do círculo de colisão
        Vector2 position = (Vector2)transform.position + circleOffset;
        Gizmos.DrawWireSphere(position, circleEyeRadius);

        // Se colidiu, desenha os objetos colididos em vermelho
        if (hitPlayer != null)
        {
            Gizmos.color = Color.red;
            foreach (Collider2D hitCollider in hitPlayer)
            {
                // Desenha uma linha até o objeto colidido para visualização
                Gizmos.DrawLine(position, hitCollider.transform.position);
            }
        }
    }
}
