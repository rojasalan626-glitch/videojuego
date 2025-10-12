using UnityEngine;

public class damageObject : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            Debug.Log("Daño al jugador");
            Destroy(collision.gameObject);
        }

    }
}
