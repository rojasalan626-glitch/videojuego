using System;
using UnityEngine;

public class fruitManager : MonoBehaviour
{
    public Boolean allFruitsCollected()
    {
        if(transform.childCount == 1)

        {
            Debug.Log("Has ganado");
            return true;
        }
        return false;
        // Aquí puedes agregar lógica adicional, como cargar una nueva escena o mostrar un mensaje de victoria.
    }
}
