using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerControl : MonoBehaviour
{
    public Transform playerTransform;
    public GameObject rival;

    public GameObject deathEffect;
    public float deathEffectLifetime = 5f;

    public float speed = 5;
    public float angularSpeed = 7;

    public float playerAngle;
    Vector3 playerPosition;

    public int playerID;

    void Start()
    {
        playerPosition = playerTransform.position;
    }

    void FixedUpdate()
    {
        playerAngle += angularSpeed * GetSteerDirection();

        playerPosition.x += speed * Mathf.Cos(playerAngle * Mathf.PI / 180f) * Time.fixedDeltaTime;
        playerPosition.y += speed * Mathf.Sin(playerAngle * Mathf.PI / 180f) * Time.fixedDeltaTime;
    }

    void Update()
    {
        playerTransform.position = playerPosition;
        playerTransform.localRotation = Quaternion.Euler(0, 0, playerAngle);

        if (playerID == 1 && Score_2.score >= 5) { Die(1); }
        if (playerID == 2 && Score_1.score >= 5) { Die(2); }
    }

    float GetSteerDirection()
    {
        if (playerID == 1)
        {
            if (Input.GetKey(KeyCode.A))
            {
                return 1f;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                return -1f;
            }
            else
            {
                return 0;
            }
        }

        if (playerID == 2)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                return 1f;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                return -1f;
            }
            else
            {
                return 0;
            }
        }

        return 0;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Boundary")
        {
            if (playerID == 1) { Die(1); }
            if (playerID == 2) { Die(2); }
        }
    }

    void Die(int _playerID)
    {
        if (_playerID == 1) { GameManager.gameOverID = 1; }
        if (_playerID == 2) { GameManager.gameOverID = 2; }

        GameManager.ToggleScripts(rival, false);
        GameManager.isGameOver = true;

        GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, deathEffectLifetime);
        Destroy(gameObject);
    }
}