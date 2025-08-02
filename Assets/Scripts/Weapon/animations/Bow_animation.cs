using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapon/Animation/Bow")]
public class Bow_animation : WeaponAnimation
{
    public override Sequence SetUp(Transform hand, float range)
    {
        Sequence animation = DOTween.Sequence();
        animation.Append(
                    hand.DOPunchScale(Vector3.up/2, speed, 1, 0.1f).
                    SetEase(Ease.InOutQuint)
                );
        animation.SetAutoKill(false).Pause();
        return animation;
    }
}