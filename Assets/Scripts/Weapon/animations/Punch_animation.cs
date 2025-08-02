using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapon/Animation/Melee_punch")]
public class Punch_animation : WeaponAnimation
{
    public override Sequence SetUp(Transform hand, float range)
    {
        Sequence animation = DOTween.Sequence();
        animation.Append(
                    hand.DOLocalMoveY(range, speed / 2).
                    From(0).
                    SetEase(Ease.InOutQuint)
                )
                .Append(
                    hand.DOLocalMoveY(-range, speed / 2).
                    SetRelative().
                    SetEase(Ease.OutBack)
                );
        animation.SetAutoKill(false).Pause();
        return animation;
    }
}
