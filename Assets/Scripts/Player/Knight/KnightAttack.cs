using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class KnightAttack : MonoBehaviour
{
    Animator playerAnimator;
    [SerializeField] Sword weapon;
    private void Start()
    {
        playerAnimator = GetComponent<Animator>();
    }
    void OnFire()
    {
        playerAnimator.SetTrigger("attack");
    }

    void startAttack()
    {
        weapon.StartAttack();
    }

    void stopAttack()
    {
        weapon.StopAttack();
    }
}
