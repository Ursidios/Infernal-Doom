using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonDamageSystem : MonoBehaviour
{
    public int damage;

    public float circleEyeRadius = 2.0f;  // Raio do círculo de colisão
    public Vector2 circleOffset = Vector2.zero;  // Deslocamento do círculo em relação ao objeto
    public LayerMask playerMask;  // Máscara de camadas para verificar colisões

    private Collider2D[] hitPlayer;

    private float AtackCountDown;
    public float AtackCountDownMax;
    public Animator anim;
    public AudioSource punchSound;


    void Update()
    {
        DamageArea();

        AtackCountDown -= Time.deltaTime;

        if(AtackCountDown <= 0 && hitPlayer.Length > 0)
        {
            anim.Play("DemonAtack");
            DoDamage();
            AtackCountDown = AtackCountDownMax;
        }
    }
    public void DamageArea()
    {
        Vector2 position = (Vector2)transform.position + circleOffset;
        hitPlayer = Physics2D.OverlapCircleAll(position, circleEyeRadius, playerMask);
    }
    public void DoDamage()
    {
        foreach (Collider2D hitCollider in hitPlayer)
        {
            Debug.Log("Colidiu com: " + hitCollider.gameObject.name);
            hitCollider.gameObject.GetComponent<HealthManager>().TakeDamage(damage);
            punchSound.Play();
        }
       
    }



    void OnDrawGizmos()
    {
        // Define a cor do Gizmo
        Gizmos.color = Color.red;

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
