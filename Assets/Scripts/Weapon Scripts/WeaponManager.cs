using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField]
    private WeaponController [] weapons;

    private int currentWeapon;

    // Start is called before the first frame update
    void Start()
    {
        currentWeapon = 0;
        weapons[currentWeapon].gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            DrawSelectedWeapon(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            DrawSelectedWeapon(1);
        }
    }

    void DrawSelectedWeapon(int newWeapon)
    {
        if(currentWeapon == newWeapon)
        {
            return;
        }
        weapons[currentWeapon].gameObject.SetActive(false);
        weapons[newWeapon].gameObject.SetActive(true);
        currentWeapon = newWeapon;
    }

    public WeaponController GetSelectedWeapon()
    {
        return weapons[currentWeapon];
    }
}
