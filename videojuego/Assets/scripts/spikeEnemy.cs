using UnityEngine;

public class spikeEnemy : MonoBehaviour
{
   [Header("Movimiento vertical (flotación)")]
    public bool moveVertical = true;
    public float floatAmplitude = 0.5f; // Altura máxima del movimiento
    public float floatSpeed = 1f;       // Velocidad del movimiento vertical

    [Header("Movimiento horizontal")]
    public bool moveHorizontal = false;
    public float horizontalAmplitude = 1f; // Distancia horizontal máxima
    public float horizontalSpeed = 1f;     // Velocidad del movimiento horizontal
    public playerController player;
    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float newY = startPos.y;
        float newX = startPos.x;

        // Movimiento vertical
        if (moveVertical)
            newY += Mathf.Sin(Time.time * floatSpeed) * floatAmplitude;

        // Movimiento horizontal
        if (moveHorizontal)
            newX += Mathf.Sin(Time.time * horizontalSpeed) * horizontalAmplitude;

        // Aplicar nueva posición
        transform.position = new Vector3(newX, newY, startPos.z);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            Debug.Log("Daño al jugador");
            player.hearts--;
            Debug.Log("Corazones restantes: " + player.hearts);
            player.textHearts.text = player.hearts.ToString();
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        if (moveVertical)
            Gizmos.DrawLine(transform.position + Vector3.up * floatAmplitude, transform.position - Vector3.up * floatAmplitude);
        if (moveHorizontal)
            Gizmos.DrawLine(transform.position + Vector3.right * horizontalAmplitude, transform.position - Vector3.right * horizontalAmplitude);
    }


}
