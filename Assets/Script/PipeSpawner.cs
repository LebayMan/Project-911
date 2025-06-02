using UnityEngine;





public class UniversalSpawner : MonoBehaviour
{
    public enum SpawnType
    {
        Pipe,
        Sun,
        Background,
        Custom
    }
    public SpawnType spawnType;
    public GameObject prefabToSpawn;
    public float spawnInterval = 1.5f;
    public float minY = -1f;
    public float maxY = 2f;
    public float moveSpeed = 2f;
    public float destroyX = -150f;
    public bool isleft;

    private float timer;
    void Start()
    {
        if (spawnType == SpawnType.Sun)
        {
            SpawnObject();
            Debug.Log("Sun spawned");
        }
    }
    void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;

        if (timer >= spawnInterval)
        {
            SpawnObject();
            timer = 0f;
        }
    }

    void SpawnObject()
    {
        Vector3 spawnPos = new Vector3(transform.position.x, Random.Range(minY, maxY), transform.position.z);
        GameObject obj = Instantiate(prefabToSpawn, spawnPos, Quaternion.identity, transform.parent);

        // Add behavior depending on type
        switch (spawnType)
        {
            case SpawnType.Pipe:
            case SpawnType.Sun:
            case SpawnType.Background:
                UniversalMover mover = obj.AddComponent<UniversalMover>();
                mover.moveSpeed = moveSpeed;
                mover.destroyX = destroyX;
                mover.isleft = isleft;
                break;

            case SpawnType.Custom:
                // No behavior, up to user
                break;
        }
    }

}
public class UniversalMover : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float destroyX = -150f;
    public bool isleft;

    void Update()
    {
        if (isleft)
        {
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        }
        else
        {
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;
        }

        if (transform.position.x < destroyX)
            Destroy(gameObject);
    }
}

