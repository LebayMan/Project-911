using UnityEngine;
using UnityEngine.UI;

public class BirdController : MonoBehaviour
{
    public Slider distanceSlider; // Slider to simulate ultrasonic distance (in cm)
    public float minDistance = 0f;    // Closest hand (e.g., 0 cm)
    public float maxDistance = 30f;   // Farthest hand (e.g., 30 cm)

    public float minY = -300f;  // Lowest Y position on UI (bottom of canvas)
    public float maxY = 300f;   // Highest Y position on UI (top of canvas)

    private RectTransform rectTransform;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        // Convert slider value to vertical position
        float normalized = Mathf.InverseLerp(minDistance, maxDistance, distanceSlider.value);
        float targetY = Mathf.Lerp(minY, maxY, 1 - normalized); // Invert: closer = higher

        Vector2 anchoredPos = rectTransform.anchoredPosition;
        anchoredPos.y = targetY;
        rectTransform.anchoredPosition = anchoredPos;
    }
}
