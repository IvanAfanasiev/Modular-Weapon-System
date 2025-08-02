using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewWeapon", menuName = "Weapon/new weapon")]
public class WeaponData : ScriptableObject
{
    public Sprite icon;
    public int damage;

    [SerializeField]
    List<WeaponModule> modules;

    [SerializeField]
    WeaponAnimation animation;

    [SerializeField]
    float width;
    [SerializeField]
    float range;

    [SerializeField]
    GameObject weapon_obj;

    WeaponHitbox _hitbox;

    public Sequence SetUpAnimation(Transform hand)
    {
        return animation.SetUp(hand, range);
    }

    public void SetUpWeapon(Transform hand)
    {
        GameObject newWeapon = Instantiate(weapon_obj, hand);
        _hitbox = newWeapon.GetComponent<WeaponHitbox>();
        _hitbox.sprite.sprite = icon;
        _hitbox.Initialize(damage, new Vector2(width, range));
    }

    public void ActivateModules(MonoBehaviour monoBehaviour, Transform parent)
    {
        ModuleContext context = new ModuleContext();
        context.damage = damage;
        context.Set("sprite", _hitbox.sprite);
        context.Set("host", monoBehaviour);
        context.Set("parent", parent);

        for (int i = 0; i < modules.Count; i++)
        {
            modules[i].Activate(context);
        }
        _hitbox.Initialize(context.damage, new Vector2(width, range));
    }
}
