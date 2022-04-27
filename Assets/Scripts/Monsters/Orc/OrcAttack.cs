using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcAttack : MonoBehaviour
{
    [SerializeField] Axe axe;
    [SerializeField] float attackCD;
    float attackTimer;
    bool canAttack = false;
    Animator monsterAnimator;
    // Start is called before the first frame update
    private void Start()
    {
        monsterAnimator = GetComponent<Animator>();
        attackTimer = attackCD;
    }

    private void Update()
    {
        if (!canAttack)
        {
            attackTimer -= Time.deltaTime;
            if (attackTimer <= 0.0f)
            {
                attackTimer = attackCD;
                canAttack = true;
            }
        }
    }
    public void Attack()
    {
        if (canAttack)
        {
            canAttack = false;
            monsterAnimator.SetTrigger("isAttacking");
        }
    }

    void StartAttack()
    {
        axe.StartAttack();
    }

    void StopAttack()
    {
        axe.StopAttack();
    }
}
