using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


[CreateAssetMenu(fileName = "NewAnimation", menuName = "Weapon/Animation")]
public abstract class WeaponAnimation : ScriptableObject
{
    public float speed;
    public abstract Sequence SetUp(Transform hand, float range);
}