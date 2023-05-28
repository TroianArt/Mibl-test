using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking.Types;

public class Entity : MonoBehaviour
{
    public event Action OnDied;

    [SerializeField] protected int healthPoints;
    [SerializeField] protected ParticleSystem effect;
    [SerializeField] protected bool spawnEffectOnDie;

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

        if (spawnEffectOnDie)
        {
            Instantiate(effect, transform.position, Quaternion.identity);
        }

        Destroy(gameObject);
    }

    protected void Die(TimeSpan timeSpan)
    {
        Die();
    }
}
