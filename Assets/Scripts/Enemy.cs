using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody rigidbody;
    [SerializeField] private int damage;

    void Start()
    {
        GameManager.instance.OnEnd += Die;
    }

    private void FixedUpdate()
    {
        Vector3 targetPos = new Vector3(player.gameObject.transform.position.x, transform.position.y, player.gameObject.transform.position.z);
        transform.LookAt(targetPos);
        rigidbody.MovePosition(Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.gameObject.TryGetComponent<Player>(out var player))
        {
            player.TakeDamage(damage);
        }
    }

    private void OnDestroy()
    {
        GameManager.instance.OnEnd -= Die;
    }
}
