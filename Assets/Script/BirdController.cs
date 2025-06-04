using UnityEngine;

public class BirdController : MonoBehaviour
{
    public float minDistance = 0f;    // Closest (cm)
    public float maxDistance = 30f;   // Farthest (cm)

    public float minY = -300f;        // Bottom Y (canvas space)
    public float maxY = 300f;         // Top Y (canvas space)

    public float smoothSpeed = 5f;    // Higher = faster smoothing

    private RectTransform rectTransform;
    private Vector2 currentPosition;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        currentPosition = rectTransform.anchoredPosition;
    }

    void Update()
    {
        float distance = SerialReader.distanceCm;

        // Normalize and invert distance (closer = higher)
        float normalized = Mathf.InverseLerp(minDistance, maxDistance, distance);
        float targetY = Mathf.Lerp(minY, maxY, 1 - normalized);

        // Smoothly move current Y toward targetY
        currentPosition.y = Mathf.Lerp(currentPosition.y, targetY, Time.deltaTime * smoothSpeed);

        // Apply position
        rectTransform.anchoredPosition = currentPosition;
    }
}
