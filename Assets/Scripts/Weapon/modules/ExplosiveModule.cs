using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ExplosiveModule", menuName = "Weapon/Modules/Explosive")]
public class ExplosiveModule : WeaponModule
{
    [SerializeField]
    LayerMask _layer;
    [SerializeField]
    GameObject explosionEffect;
    [SerializeField]
    float explosionRadius = 5f;

    public override void Activate(ModuleContext context)
    {
        Explode(context);
    }
    void Explode(ModuleContext context)
    {
        Transform _transform;
        context.TryGet("transform", out _transform);

        int _damage = context.damage;

        Collider2D[] hits = Physics2D.OverlapCircleAll(_transform.position, explosionRadius, _layer);

        foreach (Collider2D hit in hits)
        {
            IDamageable damageable = hit.GetComponent<IDamageable>();
            if (damageable != null)
            {
                damageable.TakeDamage(_damage);
            }
        }
        Instantiate(explosionEffect, _transform.position, Quaternion.identity);
    }
}
