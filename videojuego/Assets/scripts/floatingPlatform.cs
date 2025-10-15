using UnityEngine;

public class floatingPlatform : MonoBehaviour
{
    [Header("Movimiento")]
    public bool moveVertical = true;      // True = sube/baja | False = izquierda/derecha
    public float amplitude = 1f;          // Distancia máxima de movimiento
    public float speed = 1f;              // Velocidad de movimiento

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float movement = Mathf.PingPong(Time.time * speed, amplitude);
        Vector3 newPos = startPos;

        if (moveVertical)
            newPos.y += movement;          // sube y baja hasta "distance"
        else
            newPos.x += movement;          // izquierda-derecha hasta "distance"

        transform.position = newPos;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        if (moveVertical)
            Gizmos.DrawLine(transform.position + Vector3.up * amplitude, transform.position - Vector3.up * amplitude);
        else
            Gizmos.DrawLine(transform.position + Vector3.right * amplitude, transform.position - Vector3.right * amplitude);
    }
    void OnCollisionEnter2D(Collision2D collision)
{
    if (collision.transform.CompareTag("Player"))
        collision.transform.SetParent(transform);
}

void OnCollisionExit2D(Collision2D collision)
{
    if (collision.transform.CompareTag("Player"))
        collision.transform.SetParent(null);
}
}
