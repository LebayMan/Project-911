using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        // Optional: check if it's the player
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Add score");
            GameMaster.Instances.AddScore(1);
            SerialReader.instance.Score();
            SerialReader.instance.Reset();
        }
    }
}
