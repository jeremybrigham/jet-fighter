using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public Transform firePoint;
    public GameObject projectilePrefab;

    public string fireKeyCode = "Fire1";

    public float projectileForce = 10f;
    public float fireRate = 1f;
    public float shotDelay = 1f;

    float timer = 0f;

    void Update()
    {
        if (Input.GetKey(fireKeyCode) && (timer <= 0))
        {
            StartCoroutine(Shoot());
            timer = fireRate;
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }

    public IEnumerator Shoot()
    {
        Vector2 direction = firePoint.up;
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);

        yield return new WaitForSeconds(shotDelay);

        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        rb.AddForce(direction * projectileForce, ForceMode2D.Impulse);
    }
}
