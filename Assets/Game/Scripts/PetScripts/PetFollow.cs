using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetFollow : MonoBehaviour
{
    public Transform player;
    private float followDistance = 1;
    private float followSpeed = 5;
    //public float deceleration;

    internal SpriteRenderer spriteRenderer;

    PlayerMovement playerMovement;
    Rigidbody2D rb;

    private void Awake()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        SpriteDirectionChecker();

        Vector3 targetPosition = player.position - player.forward * followDistance;

        // Calculate the distance between the pet and the player
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer > followDistance)
        {
            // Move the pet towards the target position using Rigidbody velocity
            Vector2 direction = (targetPosition - transform.position).normalized;
            rb.velocity = direction * followSpeed;
        }
        else
        {
            //Smoothly stop the pet wirh lerp
            rb.velocity = Vector2.Lerp(rb.velocity, Vector2.zero, 0.1f);
        }
    }

    void SpriteDirectionChecker()
    {
        if (playerMovement.lastHorizontalVector < 0) // x < 0 left 
        {
            spriteRenderer.flipX = false;
        }
        else
        {
            spriteRenderer.flipX = true; // x > 0 right
        }
    }
}
