using UnityEngine;

public class cameraFollow : MonoBehaviour
{
public Transform target; // el personaje
    public float smoothSpeed = 0.125f;
    public Vector3 offset; // para ajustar la posición de la cámara
    //Ajustar offset direto aqui o en el inspector de Unity

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
