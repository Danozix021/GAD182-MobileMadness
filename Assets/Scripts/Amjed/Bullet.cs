using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int ownerPlayerNumber; // 1 or 2

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Don't hit yourself
            Movement player = collision.GetComponent<Movement>();
            if (player != null && player.playerNumber != ownerPlayerNumber)
            {
                ScoreManager.Instance.AddScore(ownerPlayerNumber);
                Destroy(gameObject); // Remove bullet
            }
        }
    }
}
