using UnityEngine;

public class enemyController : MonoBehaviour
{
[Header("Movimiento")]
    public float speed = 2f;              // Velocidad del movimiento
    public float moveDistance = 5f;       // Distancia total que recorre
    private Vector3 startPos;             // Posición inicial
    private int direction = 1;            // 1 = derecha, -1 = izquierda
    public playerController player;
    [Header("Opcional: Sprite")]
    public SpriteRenderer spriteRenderer; // Para voltear el sprite

    void Start()
    {
        startPos = transform.position;
        if (spriteRenderer == null)
            spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Movimiento
        transform.Translate(Vector2.right * direction * speed * Time.deltaTime);

        // Verificar si llegó al límite
        float distanceFromStart = transform.position.x - startPos.x;

        if (Mathf.Abs(distanceFromStart) >= moveDistance)
        {
            direction *= -1; // Cambia de dirección
            Flip();          // Voltea sprite si aplica
        }
    }

    void Flip()
    {
        if (spriteRenderer != null)
            spriteRenderer.flipX = !spriteRenderer.flipX;
    }

    private void OnDrawGizmosSelected()
    {
        // Dibuja el rango de patrulla en la vista del editor
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position + Vector3.left * moveDistance, transform.position + Vector3.right * moveDistance);
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            Debug.Log("Daño al jugador");
            player.hearts--;
            Debug.Log("Corazones restantes: " + player.hearts);
            player.textHearts.text= player.hearts.ToString();
        }

    }
}
