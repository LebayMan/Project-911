using UnityEngine;  
public class Move : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float destroyX = -850f;
    public bool isleft;
    public bool destroyOnExit = true;

    [Header("Optional: Timed Destruction")]
    public int destroyAfterSeconds = 25; // 0 means don't auto destroy

    void Start()
    {
        if (destroyAfterSeconds > 0 && !destroyOnExit)
        {
            Destroy(gameObject, destroyAfterSeconds);
        }
    }

    void Update()
    {
        transform.position += (isleft ? Vector3.left : Vector3.right) * moveSpeed * Time.deltaTime;

        if (transform.position.x < destroyX && destroyOnExit)
        {
            Debug.Log(transform);
            Destroy(gameObject);
        }
    }
}
