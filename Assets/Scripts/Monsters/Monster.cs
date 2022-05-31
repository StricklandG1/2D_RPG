using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField] float maxHealth;
    [SerializeField] ChasePlayer chase;
    float health;
    bool canChase = true;

    Animator monsterAnimator;
    Rigidbody2D monsterRb;
    BoxCollider2D monsterBoxCollider;

    Vector3 startPos;
    private void Start()
    {
        health = maxHealth;
        startPos = transform.position;
        monsterAnimator = GetComponent<Animator>();
        monsterRb = GetComponent<Rigidbody2D>();
        monsterBoxCollider = GetComponent<BoxCollider2D>();
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
        gameObject.SetActive(false);
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        Debug.Log("Enemy Health: " + health);
        if (health <= 0)
        {
            DisableChase();
            Debug.Log("Enemy killed");
            monsterAnimator.SetBool("Dead", true);
            monsterBoxCollider.enabled = false;
            Invoke("Death", 3.0f);
        }
        else
        {
            monsterAnimator.SetBool("isMoving", false);
            monsterAnimator.SetTrigger("Damaged");
        }
    }

    void EnableChase()
    {
        monsterAnimator.SetBool("isMoving", false);
        canChase = true;
        Debug.Log("Chase enabled");
    }

    void DisableChase()
    {
        canChase = false;
        monsterRb.velocity = Vector2.zero;
        Debug.Log("Chase disabled");
    }

    // Called by Room script when player enters a room
    public void Activate()
    {
        health = maxHealth;
        canChase = true;
        monsterBoxCollider.enabled = true;
        gameObject.SetActive(true);
    }

    // Called by Room script when player leaves a room
    public void Deactivate()
    {
        transform.position = new Vector3(startPos.x, startPos.y, startPos.z);
        monsterRb.velocity = Vector2.zero;
        monsterAnimator.SetBool("isMoving", false);
        gameObject.SetActive(false);
    }
}
