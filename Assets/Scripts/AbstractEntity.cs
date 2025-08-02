using UnityEngine;
using UnityEngine.UI;

public abstract class AbstractEntity : MonoBehaviour, IDamageable
{
    [SerializeField]
    protected
    int _health;

    [SerializeField]
    protected
    int _maxHealth;

    [SerializeField]
    protected
    Image _health_image;

    public virtual void Heal(int value)
    {
        if (_health > _maxHealth)
            _health = _maxHealth;

        UpdateHealth();
    }

    public virtual void TakeDamage(int damage)
    {
        _health -= damage;
        UpdateHealth();
        if (_health <= 0)
            Die();
    }

    public virtual void UpdateHealth()
    {
        _health_image.fillAmount = (float)_health / _maxHealth;
    }

    protected virtual void Die()
    {
        Destroy(gameObject);
    }
}