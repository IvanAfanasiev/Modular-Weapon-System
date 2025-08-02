using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public SpriteRenderer icon;

    [SerializeField]
    Rigidbody2D _rb;

    int _damage;
    
    [SerializeField]
    List<WeaponModule> modules;
    
    [SerializeField]
    float lifeTime;
    
   
    int _pierceCount = 0;
    
    Sequence _animation;


    public void Initialize(Vector2 direction, float speed, int damage, int pierceCount, Sprite sprite)
    {
        _damage = damage;
        _pierceCount = pierceCount;

        icon.sprite = sprite;

        _rb.AddForce(direction * speed, ForceMode2D.Impulse);

        if (lifeTime > 0)
        {
            _animation = DOTween.Sequence();
            _animation.Append(
                        icon.DOFade(0, lifeTime).
                        SetEase(Ease.InCirc)
                        .OnComplete(() => Destroy(gameObject))
                    );
            _animation.SetAutoKill(false).Pause();
            _animation.Restart();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<IDamageable>(out IDamageable entity))
        {
            _pierceCount--;
            entity.TakeDamage(_damage);

            ModuleContext context = new ModuleContext();
            context.damage = _damage;
            context.Set("transform", transform);

            foreach (var module in modules)
                module.Activate(context);

            if (_pierceCount-- < 0)
                Destroy(gameObject);
        }
    }
    private void OnDestroy()
    {
        _animation.Kill();
    }
}
