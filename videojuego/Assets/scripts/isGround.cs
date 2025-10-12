using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class isGround : MonoBehaviour
{
    public static bool isGrounded;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter2D(Collider2D collision)
    {
        isGrounded = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isGrounded = false;
    }
}
