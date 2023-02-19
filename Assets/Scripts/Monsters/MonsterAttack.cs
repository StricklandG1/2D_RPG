using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAttack : MonoBehaviour
{
    [SerializeField] Weapon weapon;
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
        weapon.StartAttack();
    }

    void StopAttack()
    {
        weapon.StopAttack();
    }
}
