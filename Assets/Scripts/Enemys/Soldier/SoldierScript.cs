using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SoldierScript : MonoBehaviour
{    
    public float circleEyeRadius;
    public LayerMask playerMask;
    public bool isInRight;
    public bool seePlayer;
    public SpriteRenderer SoldierRenderer;
    public float timerReloadMax;
    private float timerReload;
    public bool canShoot;
    public float timerOfShootMax;
    private float timerOfShoot;
    public float timerBetweenBulletsMax;
    private float timerBetweenBullets;

    public GameObject EnemyBullet;
    public Transform Aim;
    public Transform Player;

    public UnityEvent onShoot;

    void Start()
    {
        Player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        SoldierRenderer.flipX = !isInRight;
        RightEye();
        LeftEye();
        LookAtPlayer();
        
        if(timerReload <= 0)
        {
            canShoot = true;
            timerReload = timerReloadMax;
        }

        if(canShoot)
        {
            Shoot();
        }
        else
        {
            timerReload -= Time.deltaTime;
        }
    }

    private void LookAtPlayer()
    {
        if (Player != null)
        {
            // Calcula a direção do Player em relação ao Aim
            Vector2 direction = Player.position - Aim.position;

            // Calcula o ângulo em relação ao eixo X
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            // Aplica a rotação ao Aim
            Aim.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }
    }
    public void Shoot()
    {
        timerOfShoot -= Time.deltaTime;
        if(timerOfShoot <= 0)
        {
            canShoot = false;
            timerOfShoot = timerOfShootMax;
        }
        timerBetweenBullets -= Time.deltaTime;

        if(timerBetweenBullets <= 0)
        {
            Instantiate(EnemyBullet, Aim.transform.position, Aim.transform.rotation);
            onShoot?.Invoke();
            timerBetweenBullets = timerBetweenBulletsMax;
        }

    }

    public void RightEye()
    {
        Vector2 position = (Vector2)transform.position + new Vector2(circleEyeRadius, 0);;
        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(position, circleEyeRadius, playerMask);
        foreach (Collider2D hitCollider in hitPlayer)
        {
            isInRight = true;
        }
    }

    public void LeftEye()
    {
        Vector2 position = (Vector2)transform.position + new Vector2(-circleEyeRadius, 0);
        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(position, circleEyeRadius, playerMask);
        foreach (Collider2D hitCollider in hitPlayer)
        {
            isInRight = false;
        }
    }
    
    void OnDrawGizmos()
    {
        // Define a cor do Gizmo
        Gizmos.color = Color.red;

        // Desenha o wireframe do círculo de colisão
        Vector2 positionR = (Vector2)transform.position + new Vector2(circleEyeRadius, 0);
        Gizmos.DrawWireSphere(positionR, circleEyeRadius);

        Vector2 positionL = (Vector2)transform.position + new Vector2(-circleEyeRadius, 0);
        Gizmos.DrawWireSphere(positionL, circleEyeRadius);

    }
}
