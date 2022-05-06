using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Weapon
{
    [SerializeField] float damage;
    PolygonCollider2D weaponCollider;
    // Start is called before the first frame update
    void Start()
    {
        weaponCollider = GetComponent<PolygonCollider2D>();
    }

    public override void StartAttack()
    {
        weaponCollider.enabled = true;
    }

    public override void StopAttack()
    {
        weaponCollider.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Monster enemy = collision.GetComponent<Monster>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }
    }
}
