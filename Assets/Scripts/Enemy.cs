using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Enemy : MonoBehaviour, IDamageable
{
    Sequence _animation;
    [SerializeField]
    Transform skin;
    [SerializeField]
    float animationSpeed;

    [SerializeField]
    GameObject damageView;

    void Start()
    {
        _animation = DOTween.Sequence();
        _animation.Append(
                    skin.DOPunchScale(Vector3.up / 3, animationSpeed, 1, 0.1f).
                    SetEase(Ease.InOutQuint)
                );
        _animation.SetAutoKill(false).Pause();
    }

    public void Heal(int value)
    {
        throw new System.NotImplementedException();
    }

    public void TakeDamage(int damage)
    {
        _animation.Restart();

        GameObject newView = Instantiate(damageView.gameObject, transform);
        newView.GetComponent<DamageView>().Initialize(damage);
    }
}
