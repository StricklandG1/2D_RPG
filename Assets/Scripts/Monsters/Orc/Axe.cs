using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : Weapon
{
    [SerializeField] float damage;
    PolygonCollider2D weapon;
    // Start is called before the first frame update
    private void Start()
    {
        weapon = GetComponent<PolygonCollider2D>();
    }
    public override void StartAttack()
    {
        weapon.enabled = true;
    }

    public override void StopAttack()
    {
        weapon.enabled = false;
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerStatus player = collision.GetComponent<PlayerStatus>();
            if (player != null)
            {
                player.TakeDamage(damage);
            }
        }
    }
}
