using UnityEngine;

public class damageObject : MonoBehaviour
{

    public playerController player;
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
