using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected float health;
    protected Rigidbody2D rb;

    [SerializeField] protected float speed;

    [SerializeField] protected float damage;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    protected virtual void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public virtual void EnemyHit(float _damageDone)
    {
        health -= _damageDone;
    }

    protected void OnTriggerStay2D(Collider2D _other)
    {
        if (_other.CompareTag("Player") && !PlayerController.Instance.pState.invincible)
        {
            Attack();
        }
    }
    protected virtual void Attack()
    {
        PlayerController.Instance.TakeDamage(damage);
    }
}