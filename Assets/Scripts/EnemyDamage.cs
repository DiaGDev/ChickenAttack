using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int damage;
    public float attackDelay; // the delay between enemy attacks
    private float lastAttackTime; // the time of the last enemy attack

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player1") || collision.collider.CompareTag("Player2"))
        {
            // check if enough time has passed since the last attack
            if (Time.time - lastAttackTime > attackDelay)
            {
                // deal damage and update the last attack time
                Bar bar = collision.collider.GetComponentInChildren<Bar>();
                bar.TakeDamage(damage);
                lastAttackTime = Time.time;
            }
        }
    }
}
