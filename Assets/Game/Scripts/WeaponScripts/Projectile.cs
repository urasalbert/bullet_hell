using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    private Vector2 moveDirection;
    private Rigidbody2D rb;

    public void Initialize(Vector2 direction)
    {
        moveDirection = direction;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 2f); // Destroy the bullet after 2 seconds
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position += (Vector3)moveDirection * speed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the projectile hits an enemy
        if (other.CompareTag("Enemy") && PierceSkill.Instance.isClicked == false)
        {
            // Destroy the projectile
            Destroy(gameObject);
        }
        else
        {
            return;
        }
            
    }
}
