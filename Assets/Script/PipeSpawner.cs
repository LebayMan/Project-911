using UnityEngine;
using System.Collections.Generic;

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
    public List<GameObject> prefabList;

    public float spawnInterval = 1.5f;
    public float minY = -1f;
    public float maxY = 2f;

    // Shared destroy value
    public float destroyX = -850f;

    // Pipe defaults
    public float pipeMoveSpeed = 2f;
    public bool pipeIsLeft = true;

    // Sun-specific
    public float sunMoveSpeed = 1f;
    public float sunDestroyX = 450f;

    public bool sunIsLeft = false;

    // Background-specific
    public float backgroundMoveSpeed = 0.5f;
    public bool backgroundIsLeft = true;

    private float timer;

    void Start()
    {
        Time.timeScale = 1f; // Ensure time scale is set to normal
        if (spawnType == SpawnType.Sun)
        {
            SpawnObject();
            Debug.Log("Sun spawned");
        }
        if(spawnType == SpawnType.Background)
        {
            SpawnObject();
            Debug.Log("Background spawned");
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
        if (prefabList.Count == 0)
        {
            Debug.LogWarning("Prefab list is empty.");
            return;
        }

        Vector3 spawnPos = new Vector3(transform.position.x, Random.Range(minY, maxY), transform.position.z);
        GameObject randomPrefab = prefabList[Random.Range(0, prefabList.Count)];
        GameObject obj = Instantiate(randomPrefab, spawnPos, Quaternion.identity, transform.parent);

        switch (spawnType)
        {
            case SpawnType.Pipe:
                AddMover(obj, pipeMoveSpeed, pipeIsLeft);
                break;
            case SpawnType.Sun:
                AddMover(obj, sunMoveSpeed, sunIsLeft, false, sunDestroyX);
                break;
            case SpawnType.Background:
                AddMover(obj, backgroundMoveSpeed, backgroundIsLeft);
                break;
            case SpawnType.Custom:
                // Leave custom objects alone
                break;
        }
    }

    void AddMover(GameObject obj, float speed, bool isLeft ,bool destroyOnExit = true , float destroyX = -850f)
    {
        UniversalMover mover = obj.AddComponent<UniversalMover>();
        mover.moveSpeed = speed;
        mover.destroyX = destroyX;
        mover.isleft = isLeft;
        mover.destroyOnExit = destroyOnExit;
    }
}


public class UniversalMover : MonoBehaviour
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
