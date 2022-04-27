using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    [SerializeField] float maxHealth;
    private float currentHealth;
    BoxCollider2D playerCollider;
    Animator playerAnimator;
    SpriteRenderer playerRenderer;
    [SerializeField] UIStats health;

    bool guarding = false; // State for player taking recent damage. I-frames
    public bool isDead = false;
    void Start()
    {
        health.InitializeValues(maxHealth);
        currentHealth = maxHealth;
        playerAnimator = GetComponent<Animator>();
        playerCollider = GetComponent<BoxCollider2D>();
        playerRenderer = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(float damage)
    {
        if (!guarding && !isDead)
        {
            currentHealth -= damage;
            health.UpdateBar(maxHealth, (currentHealth<0) ? 0 : currentHealth);

            Debug.Log("Player Health: " + currentHealth);

            playerAnimator.SetBool("isDamaged", true);

            if (currentHealth <= 0)
            {
                isDead = true;
                playerAnimator.SetTrigger("isDead");
                Invoke("DespawnPlayer", 3.0f);
            }
        }
    }

    void StartGuarding()
    {
        guarding = true;
        playerAnimator.SetBool("isRunning", false);
    }

    void StopGuarding()
    {
        guarding = false;
        playerAnimator.SetBool("isDamaged", false);
    }

    void DespawnPlayer()
    {
        playerCollider.enabled = false;
        playerRenderer.enabled = false;
    }
}
