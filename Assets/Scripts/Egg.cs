using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Egg : MonoBehaviour
{
    public float speed = 10;
    public float duration = 2;
    public float damageAmount;
    public float healAmount;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb=GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        Debug.Log(collision.collider.tag);
        if (collision.collider.tag == "Enemy")
        {
            Bar bar = collision.collider.GetComponentInChildren<Bar>();
            bar.TakeDamage(damageAmount);
            Destroy(gameObject);
        }
        if (collision.collider.tag == "Player1" || collision.collider.tag == "Player2")
        {
            Bar bar = collision.collider.GetComponentInChildren<Bar>();
            bar.Heal(healAmount);
            Debug.Log("Healed for:" + healAmount);
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        Invoke("DestroyEgg", duration);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(transform.position+transform.right*speed*Time.fixedDeltaTime);
    }

    void DestroyEgg()
    {
        Destroy(gameObject);
    }
}
