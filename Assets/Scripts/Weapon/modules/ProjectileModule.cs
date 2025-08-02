using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewModule", menuName = "Weapon/Modules/Projectile")]
public class ProjectileModule : WeaponModule
{
    public float timer;
    [NonSerialized]
    public bool canAttack = true;

    [SerializeField]
    GameObject projectile;
    [SerializeField]
    float projectileSpeed;

    [SerializeField]
    Sprite sprite;
    [SerializeField]
    int pierceCount = 0;

    public override void Activate(ModuleContext context = null)
    {
        if (!canAttack) return;
        canAttack = false;
        context.Get<MonoBehaviour>("host").StartCoroutine(Cooldown());
        if (projectile != null && context != null)
        {
            Transform parent = context.Get<Transform>("parent");
            GameObject newProjectile = Instantiate(projectile, parent.position, Quaternion.identity, parent);
            newProjectile.GetComponent<Projectile>().Initialize(parent.up, projectileSpeed, context.damage, pierceCount, sprite);
        }
    }
    public IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(timer);
        canAttack = true;
    }
}
