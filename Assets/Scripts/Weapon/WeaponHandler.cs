using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class WeaponHandler : MonoBehaviour
{
    public WeaponData weapon;

    bool inAnimation() => _animation != null && _animation.IsPlaying();
    
    Sequence _animation;
    
    public bool isAttacking = false;
    
    [SerializeField]
    Transform hand;

    private void Update()
    {
        CheckKeys();
    }
    public void CheckKeys()
    {
        if (isAttacking)
        {
            StartAttack();
        }
        if (Input.GetMouseButtonDown(0))
        {
            StartAttack();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            EndAttack();
        }
    }


    public void SetUp()
    {
        hand.rotation = Quaternion.identity;
        hand.localPosition = Vector3.zero;
        hand.localScale = Vector3.one;
        KillAnimation();
        
        if (hand.childCount != 0)
            Destroy(hand.GetChild(0).gameObject);
        weapon.SetUpWeapon(hand);

        var combatAnimation = weapon.SetUpAnimation(hand);

        _animation = combatAnimation;
    }
    public void StartAttack()
    {
        if (inAnimation()) return;
        hand.gameObject.SetActive(true);
        isAttacking = true;
        Attack();
    }

    public void EndAttack()
    {
        isAttacking = false;
    }

    public void Attack()
    {
        weapon.ActivateModules(this, transform);

        _animation.Restart();
    }
    public void KillAnimation()
    {
        _animation.Kill();
        _animation = null;
    }

    private void OnDestroy()
    {
        KillAnimation();
    }
}