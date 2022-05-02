using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBehavior : MonoBehaviour
{
    [SerializeField] float health;
    [SerializeField] ChasePlayer chase;
    
    bool canChase = true;
    Animator monsterAnimator;
    Rigidbody2D monsterRb;

    private void Start()
    {
        monsterAnimator = GetComponent<Animator>();
        monsterRb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (canChase)
        {
            chase.Chase();
        }
    }

    void Death()
    {
        Destroy(gameObject);
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        Debug.Log("Enemy Health: " + health);
        if (health <= 0)
        {
            Debug.Log("Enemy killed");
            monsterAnimator.SetBool("Dead", true);
            GetComponent<BoxCollider2D>().enabled = false;
            Invoke("Death", 3.0f);
        }
        monsterAnimator.SetBool("isMoving", false);
        monsterAnimator.SetTrigger("Damaged");
    }

    void EnableChase()
    {
        canChase = true;
    }

    void DisableChase()
    {
        canChase = false;
        monsterRb.velocity = Vector2.zero;
    }
}
