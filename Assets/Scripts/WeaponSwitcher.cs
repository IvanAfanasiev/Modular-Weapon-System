using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    [SerializeField]
    WeaponHandler weaponHandler;
    [SerializeField]
    WeaponData[] weapons;

    private void Start()
    {
        ChangeWeapon(0);
    }
    void Update()
    {
        CheckButtons();
    }
    void CheckButtons()
    {
        for (int i = 0; i < weapons.Length; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + i))
            {
                ChangeWeapon(i);
                break;
            }
        }
    }
    void ChangeWeapon(int indx)
    {
        weaponHandler.weapon = weapons[indx];
        weaponHandler.SetUp();
    }
}
