using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewModule", menuName = "Weapon/Modules/Randomize")]
public class RandomModule : WeaponModule
{
    [SerializeField]
    float minMultiplier;
    [SerializeField]
    float maxMultiplier;

    public override void Activate(ModuleContext context)
    {
        float randomValue = (Random.Range(minMultiplier, maxMultiplier));
        int newDamage = (int)(context.damage * randomValue);
        context.damage = newDamage;
    }
}
