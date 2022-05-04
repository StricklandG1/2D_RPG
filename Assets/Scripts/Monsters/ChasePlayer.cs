using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasePlayer : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float maxRange;
    [SerializeField] float minRange;
    [SerializeField] float xScale;
    [SerializeField] MonsterAttack attack;
    GameObject player;
    PlayerStatus playerStatus;
    Animator monsterAnimator;
    Rigidbody2D monsterRb; 

    Vector3 startPosition;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerStatus = player.GetComponent<PlayerStatus>();
        monsterAnimator = GetComponent<Animator>();
        monsterRb = GetComponent<Rigidbody2D>();
        startPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    public void Chase()
    {
        if (!playerStatus.IsDead())
        {
            float distance = Vector2.Distance(transform.position, player.transform.position);
            if (distance <= maxRange && distance >= minRange)
            {
                MoveTowardsPlayer();
            }
            else if (distance <= minRange)
            {
                monsterRb.velocity = Vector2.zero;
                attack.Attack();
                monsterAnimator.SetBool("isMoving", false);
            }
            else if (Vector2.Distance(transform.position, startPosition) > 1.0f)
            {
                GoHome();
            }
            else
            {
                monsterRb.velocity = Vector2.zero;
                monsterAnimator.SetBool("isMoving", false);
            }
        }
        else
        {
            monsterRb.velocity = Vector2.zero;
        }
    }

    private void MoveTowardsPlayer()
    {   
        Vector2 direction = player.transform.position - transform.position;
        monsterRb.velocity = direction.normalized * speed;

        transform.localScale = new Vector2(Mathf.Sign(monsterRb.velocity.x) * xScale, transform.localScale.y);

        monsterAnimator.SetBool("isMoving", true);
    }

    // Monster returns to starting position
    private void GoHome()
    {
        Vector2 direction = startPosition - transform.position;
        monsterRb.velocity = direction.normalized * speed;

        transform.localScale = new Vector2(Mathf.Sign(monsterRb.velocity.x) * xScale, transform.localScale.y);
    }
}