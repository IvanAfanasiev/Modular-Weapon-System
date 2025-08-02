using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapon/Animation/Melee_rotate")]
public class Rotate_animation : WeaponAnimation
{
    public float radius;

    public override Sequence SetUp(Transform hand, float range)
    {
        Sequence animation = DOTween.Sequence();
        animation.
            Append(
            hand.DOLocalRotate(Vector3.back * radius / 2, speed, RotateMode.FastBeyond360).
            From(Vector3.forward * radius / 2).
            SetEase(Ease.OutQuad));
        animation.SetAutoKill(false).Pause();
        return animation;
    }
}
