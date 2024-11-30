using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed;

    public float lifeTime;
    public int damage;
    public float circleEyeRadius = 2.0f;  // Raio do círculo de colisão
    public Vector2 circleOffset = Vector2.zero;  // Deslocamento do círculo em relação ao objeto
    public LayerMask playerMask;  // Máscara de camadas para verificar colisões
    public LayerMask groundMask;  // Máscara de camadas para verificar colisões

    private Collider2D[] hitPlayer;
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

        Vector2 position = (Vector2)transform.position + circleOffset;
        hitPlayer = Physics2D.OverlapCircleAll(position, circleEyeRadius, playerMask);
        foreach (Collider2D hitCollider in hitPlayer)
        {
            Debug.Log("Colidiu com: " + hitCollider.gameObject.name);
            hitCollider.gameObject.GetComponent<EnemyHealthmanager>().TakeDamage(damage);
            Destroy(gameObject);
        }
       
        Collider2D[] hitDestroy = Physics2D.OverlapCircleAll(position, circleEyeRadius, groundMask);
        foreach (Collider2D hitCollider in hitDestroy)
        {
            Destroy(gameObject);
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
