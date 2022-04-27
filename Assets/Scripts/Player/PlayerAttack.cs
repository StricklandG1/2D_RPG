using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    Animator playerAnimator;
    [SerializeField] Weapon weapon;
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
