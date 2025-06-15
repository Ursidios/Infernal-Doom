using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class BossDamageSystem : MonoBehaviour
{
    public int damageShoot;
    public int damagePunch;
    public int AtackChooser;
    public float ShootRange;
    public float PunchRange;
    public Vector2 circleOffset = Vector2.zero;  // Deslocamento do círculo em relação ao objeto
    public LayerMask playerMask;  // Máscara de camadas para verificar colisões

    private Collider2D[] hitPlayer;

    private float AtackCountDown;
    public float AtackCountDownMax;
    public Animator anim;
    public AudioSource punchSound;
    public AudioSource shootSound;
    public float timerNextAtack;
    public float timerNextAtackStart;


    void Update()
    {

        AtackCountDown -= Time.deltaTime;
        timerNextAtack -= Time.deltaTime;

        if (timerNextAtack <= 0)
        {
            AtackChooser = Random.Range(0, 2);
            timerNextAtack = timerNextAtackStart;
        }

        if (AtackChooser == 0)
        {
            DamageArea(PunchRange);

            if (AtackCountDown <= 0 && hitPlayer.Length > 0)
            {
                AtackCountDown = AtackCountDownMax;
                anim.Play("Punch");
                DoDamage(damagePunch);
                punchSound.Play();
            }
        }

        if (AtackChooser == 1)
        {
            DamageArea(ShootRange);

            if (AtackCountDown <= 0 && hitPlayer.Length > 0)
            {
                AtackCountDown = AtackCountDownMax;
                anim.Play("shoot");
                DoDamage(damageShoot);
                shootSound.Play();
            }
        }
        

    }
    public void DamageArea(float Range)
    {
        Vector2 position = (Vector2)transform.position + circleOffset;
        hitPlayer = Physics2D.OverlapCircleAll(position, Range, playerMask);
    }
    public void DoDamage(int damage)
    {
        foreach (Collider2D hitCollider in hitPlayer)
        {
            Debug.Log("Colidiu com: " + hitCollider.gameObject.name);
            hitCollider.gameObject.GetComponent<HealthManager>().TakeDamage(damage);
        }
    }



    void OnDrawGizmos()
    {
        // Define a cor do Gizmo
        Gizmos.color = Color.red;

        // Desenha o wireframe do círculo de colisão
        Vector2 position = (Vector2)transform.position + circleOffset;
        Gizmos.DrawWireSphere(position, PunchRange);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(position, ShootRange);

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
