using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking.Types;

public class Entity : MonoBehaviour
{
    public event Action OnDied;

    [SerializeField] protected int healthPoints;

    protected int startHealthPoints;
    protected Player player;

    public int HealtPoints => healthPoints;

    private void Start()
    {
        startHealthPoints = healthPoints;
    }

    public void TakeDamage(int damage)
    {
        healthPoints -= damage;
        if (healthPoints <= 0)
        {
            Die();
        }
    }

    public void Init(Player player)
    {
        this.player = player;
    }

    protected void Die()
    {
        OnDied?.Invoke();
        Destroy(gameObject);
    }

    protected void Die(TimeSpan timeSpan)
    {
        OnDied?.Invoke();
        Destroy(gameObject);
    }
}
