using UnityEngine;

public class DestroyIfSunTag : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (CompareTag("Sun"))
        {
            Destroy(gameObject);
        }
    }
}
