using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHitbox : MonoBehaviour
{
    public SpriteRenderer sprite;
    [SerializeField]
    CapsuleCollider2D hitbox;
    int _damage;

    public void Initialize(int damage, Vector2 size)
    {
        _damage = damage;
        hitbox.size = size;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<IDamageable>(out IDamageable entity))
        {
            entity.TakeDamage(_damage);
        }
    }
}
