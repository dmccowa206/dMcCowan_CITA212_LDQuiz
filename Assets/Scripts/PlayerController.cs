using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpd;
    [SerializeField] GameObject bullet;
    [SerializeField] float bulletSpd;
    [SerializeField] float bulletLifetime;
    private float moveValue;
    void Update()
    {
        Move();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }
    void Move()
    {
        moveValue = Input.GetAxis("Horizontal") * moveSpd;
        if (moveValue != 0)
        {
            transform.Translate(moveValue, 0, 0);
        }
    }
    void Shoot()
    {
        GameObject instance = Instantiate(bullet, transform.position, Quaternion.identity);Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();
        if(rb != null)
        {
            rb.velocity = transform.up * bulletSpd;
        }
        Destroy(instance, bulletLifetime);
    }
}
