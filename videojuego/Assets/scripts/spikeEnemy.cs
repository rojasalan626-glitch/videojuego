using UnityEngine;

public class spikeEnemy : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
 private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            Debug.Log("Daño al jugador");
            Destroy(collision.gameObject);
        }

    }
}
