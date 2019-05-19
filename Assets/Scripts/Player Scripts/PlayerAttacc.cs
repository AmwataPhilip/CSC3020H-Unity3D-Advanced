using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacc : MonoBehaviour
{
    public WeaponManager weaponManager;

    public float fireRate = 15.0f;
    public float damageDealt = 20.0f;
    // Start is called before the first frame update
    void Start()
    {
        weaponManager = GetComponent<WeaponManager>();
    }

    // Update is called once per frame
    void Update()
    {
        FireWeapon();
    }

    void FireWeapon()
    {
        if(Input.GetMouseButtonDown(1))
        {
            if(weaponManager.GetSelectedWeapon().tag == "Axe")
            {
                weaponManager.GetSelectedWeapon().ShootAnimation();
            }
            if(weaponManager.GetSelectedWeapon().weaponBullet == WeaponBullet.BULLET)
            {
                weaponManager.GetSelectedWeapon().ShootAnimation();

                BulletFired();
            }
        }
    }

    void BulletFired()
    {
        return;
    }
}
