using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : Entity
{
    [SerializeField] private int damage;

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.TryGetComponent<Entity>(out var entity))
        {
            entity.TakeDamage(damage);
            Die();
        }
    }
}
