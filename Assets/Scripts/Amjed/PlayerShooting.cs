using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform shootPoint;
    public int playerNumber; // 1 or 2

    void Update()
    {
        if ((playerNumber == 1 && Input.GetKeyDown(KeyCode.Space)) ||
            (playerNumber == 2 && Input.GetKeyDown(KeyCode.Return)))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, Quaternion.identity);
        Bullet bulletScript = bullet.GetComponent<Bullet>();
        bulletScript.ownerPlayerNumber = playerNumber;

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        Vector2 direction = playerNumber == 1 ? Vector2.right : Vector2.left;
        rb.velocity = direction * 10f;  // Set bullet speed here
    }
}