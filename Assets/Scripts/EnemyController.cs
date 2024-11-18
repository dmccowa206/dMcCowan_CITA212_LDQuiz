using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] float fireDelay;
    [SerializeField] float bulletSpd;
    [SerializeField] float bulletLifetime;
    Coroutine fireCoroutine;

    void Update()
    {
        if (fireCoroutine == null)
        {
            fireCoroutine = StartCoroutine(FireContinuously());
        }
    }
    IEnumerator FireContinuously()
    {
        while (true)
        {
            GameObject instance = Instantiate(bullet, transform.position, Quaternion.identity);Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();
            if(rb != null)
            {
                rb.velocity = transform.up * bulletSpd;
            }
            Destroy(instance, bulletLifetime);
            yield return new WaitForSeconds(fireDelay);
        }
    }
}
