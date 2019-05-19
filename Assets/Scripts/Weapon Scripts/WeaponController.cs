using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponAim
{
    NONE,
    SELF_AIM,
    AIM
}

public enum WeaponBullet
{
    BULLET,
    NONE
}
public class WeaponController : MonoBehaviour
{
    private Animator anim;

    public WeaponAim weaponAim;

    [SerializeField]
    private GameObject muzzleFlash;

    [SerializeField]
    private AudioSource shoot, reload;

    public WeaponBullet weaponBullet;

    public GameObject attackPoint;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void ShootAnimation()
    {
        anim.SetTrigger("Fire");
    }

    public void Aim( bool canAim)
    {
        anim.SetBool("Aim", canAim);
    }

    void TurnOnMuzzleFlash()
    {
        muzzleFlash.SetActive(true);
    }

    void TurnOffMuzzleFlash()
    {
        muzzleFlash.SetActive(false);
    }

    void TurnOnAttackPoint()
    {
        attackPoint.SetActive(true);
    }

    void TurnOffAttackPoint()
    {
        if (attackPoint.activeInHierarchy)
        {
            attackPoint.SetActive(false);
        }
    }

    void PlayShootClip()
    {
        shoot.Play();
    }

    void PlayReloadClip()
    {
        reload.Play();
    }


} // Class
