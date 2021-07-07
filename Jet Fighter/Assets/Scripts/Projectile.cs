using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject collisionEffect;
    public float projectileLifetime = 5f;
    public float collisionEffectLifetime = 5f;
    public int target;

    void Start()
    {
        Destroy(gameObject, projectileLifetime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject effect = Instantiate(collisionEffect, transform.position, Quaternion.identity);
        Destroy(effect, collisionEffectLifetime);
        Destroy(gameObject);

        if (collision.gameObject.tag == "Player 1")
        {
            Score_2.score += 1;
        }
        if (collision.gameObject.tag == "Player 2")
        {
            Score_1.score += 1;
        }
    }
}
