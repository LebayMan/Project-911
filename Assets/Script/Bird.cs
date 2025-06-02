using UnityEngine;

public class Bird : MonoBehaviour
{
    public GameObject pesawat;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Tower"))
        {
            Destroy(gameObject); // Destroy the bird when it hits the tower
            pesawat.SetActive(true); // Deactivate the plane
            Time.timeScale = 0f; // Stop the game
        }
    }
}
