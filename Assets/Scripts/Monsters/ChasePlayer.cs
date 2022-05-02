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
        if (!playerStatus.isDead)
        {
            float distance = Vector2.Distance(transform.position, player.transform.position);
            if (distance <= maxRange && distance >= minRange)
            {
                transform.localScale = new Vector2(Mathf.Sign(player.transform.position.x - transform.position.x) * xScale, transform.localScale.y);
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);

                monsterAnimator.SetBool("isMoving", true);
            }
            else if (distance <= minRange)
            {
                attack.Attack();
                monsterAnimator.SetBool("isMoving", false);
            }
            else if (transform.position != startPosition)
            {
                transform.localScale = new Vector2(Mathf.Sign(startPosition.x - transform.position.x) * xScale, transform.localScale.y);
                transform.position = Vector3.MoveTowards(transform.position, startPosition, speed * Time.deltaTime);
            }
            else
            {
                monsterAnimator.SetBool("isMoving", false);
            }
        }
    }
}
