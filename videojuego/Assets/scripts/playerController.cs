
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class playerController : MonoBehaviour
{
    public float runSpeed = 20;
    public float jumpSpeed = 30;
    public int hearts;
    public int pinias;
    public TMP_Text textHearts;
    public TMP_Text textPinias;

    //agregar audio
    public AudioSource damageSound;
    public float doubleJumpSpeed = 25;
    private bool canDoubleJump = false;
    
    Rigidbody2D rb2D;
    public SpriteRenderer spriteRenderer;
    public Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        textHearts.text = hearts.ToString();
        textPinias.text = pinias.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        //mover a la derecha
        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            rb2D.linearVelocity = new Vector2(runSpeed, rb2D.linearVelocity.y);
            spriteRenderer.flipX = false;
            animator.SetBool("isRunning", true);
        }
        else if (Input.GetKey("a") || Input.GetKey("left"))
        {
            rb2D.linearVelocity = new Vector2(-runSpeed, rb2D.linearVelocity.y);
            spriteRenderer.flipX = true;
            animator.SetBool("isRunning", true);
        }
        else
        {
            rb2D.linearVelocity = new Vector2(0, rb2D.linearVelocity.y);
            animator.SetBool("isRunning", false);
        }
        if (Input.GetKey("space") )
        {
            if (isGround.isGrounded)
            {
                //Debug.Log("Saltando"); // Mensaje normal
                canDoubleJump = true;
                rb2D.linearVelocity = new Vector2(rb2D.linearVelocity.x, jumpSpeed);
            }
            else
            {
                if (Input.GetKeyDown("space"))
                {
                    if (canDoubleJump)
                    {
                        //Debug.Log("Doble salto"); // Mensaje normal   
                        Debug.Log("Doble salto"); // Mensaje normal
                        canDoubleJump = false;
                        rb2D.linearVelocity = new Vector2(rb2D.linearVelocity.x, doubleJumpSpeed);
                    }
                }
            }  
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("corazon"))
        {
            Destroy(collision.gameObject);
            hearts++;
            textHearts.text = hearts.ToString();
        }
        else if (collision.transform.CompareTag("pinia"))
        {
            Debug.Log("Pinia recogida");
            
            collision.gameObject.transform.GetChild(0).gameObject.SetActive(true);
            Destroy(collision.gameObject, 0.5f);
            pinias++;
            textPinias.text = pinias.ToString();
                    // Prueba de cambio de escena con 3 piñas

            
            if (FindObjectOfType<fruitManager>().allFruitsCollected())
                    {
                pinias = 0;
                hearts = 3;
                textHearts.text = hearts.ToString();
                textPinias.text = pinias.ToString();
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }  
        if (hearts <= 0)
        {
            Debug.Log("Game Over");
            QuitGame();
        }
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }
}
