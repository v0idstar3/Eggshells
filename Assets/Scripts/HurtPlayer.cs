using System;
using UnityEngine;

public class HurtPlayer : MonoBehaviour
{
    public float duration = 0.5F;
    private float timer = 0;

    public Rigidbody2D rb;
    public Health health;

    private bool isBeingHurt = false;
    
    private void Update()
    {
        if (!isBeingHurt) return; // not being hurt, stop here
        
        if (rb.linearVelocity.magnitude > 0.1f) // if the character is moving
        {
            timer = 0;
            return; // moving so no hurt
        }

        if (timer < duration)
        {
            timer += Time.deltaTime; // count up
            return; // not being hurt yet
        }

        health.TakeDamage(1);
        timer = 0;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isBeingHurt = true;
            rb = other.attachedRigidbody;
            health = other.GetComponent<Health>();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isBeingHurt = false;
            rb = null;
            health = null;
        }
    }
}
