using UnityEngine;
using UnityEngine.Tilemaps;

public class cameraFollow : MonoBehaviour
{
    // public Transform target; // el personaje
    //     public float smoothSpeed = 0.125f;
    //     public Vector3 offset; // para ajustar la posición de la cámara
    //     //Ajustar offset direto aqui o en el inspector de Unity

    //     void LateUpdate()
    //     {
    //         if (target == null) return;

    //         Vector3 desiredPosition = target.position + offset;
    //         Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
    //         transform.position = smoothedPosition;
    //     }
    [Header("Seguimiento del jugador")]
    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset = new Vector3(0, 0, -10);

    [Header("Tilemap para límites automáticos")]
    public Tilemap map;

    private Vector3 minBounds;
    private Vector3 maxBounds;
    private float halfHeight;
    private float halfWidth;
    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
        halfHeight = cam.orthographicSize;
        halfWidth = halfHeight * cam.aspect;

        if (map != null)
        {
            // Usamos los bounds en coordenadas de celda y los convertimos a mundo
            Vector3Int minCell = map.cellBounds.min;
            Vector3Int maxCell = map.cellBounds.max;

            minBounds = map.CellToWorld(minCell);
            maxBounds = map.CellToWorld(maxCell);
        }
        else
        {
            Debug.LogWarning("No se asignó un Tilemap a la cámara.");
        }
    }

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 desiredPosition = target.position + offset;

        // Ajusta correctamente los límites, restando el tamaño de la cámara
        float clampedX = Mathf.Clamp(desiredPosition.x, minBounds.x + halfWidth, maxBounds.x - halfWidth);
        float clampedY = Mathf.Clamp(desiredPosition.y, minBounds.y + halfHeight, maxBounds.y - halfHeight);

        Vector3 clampedPosition = new Vector3(clampedX, clampedY, desiredPosition.z);

        Vector3 smoothedPosition = Vector3.Lerp(transform.position, clampedPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube((minBounds + maxBounds) / 2, maxBounds - minBounds);
    }
    
}

