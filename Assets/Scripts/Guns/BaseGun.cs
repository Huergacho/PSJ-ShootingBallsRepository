using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseGun : MonoBehaviour
{
    [SerializeField] protected GunStats weaponStats;

    public Transform FirePoint => firePoint;
    [SerializeField] protected Transform firePoint;
    public float CurrentReloadTime => currentReloadTime;
    protected float currentReloadTime;
    public bool CanShoot => canShoot;
    protected bool canShoot;
    public int BulletsAmount => bulletsAmount;
    protected int bulletsAmount;
    private int currentMaxBullets;
    public float WeaponFireRate => weaponFireRate;
    private float weaponFireRate;

    private bool hasShooted;

    [SerializeField] private ParticleSystem particleSystem;
    private GenericPool genericPool;

    public virtual void Start()
    {
        genericPool = GenericPool.Instance;
        currentMaxBullets = weaponStats.MaxBullets;
        bulletsAmount = weaponStats.MaxBullets;
        canShoot = true;
    }

    public virtual void Shoot()
    {
        if (canShoot)
        {
            particleSystem.Play();
            var bulletObject = genericPool.SpawnFromPool("bullet", firePoint.position, firePoint.rotation);
            var bulletComponent = bulletObject.GetComponent<Bullet>();
            bulletComponent.OnSetValues(weaponStats);
            bulletsAmount--;
            hasShooted = true;
        }
    }

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        FireCooldown();
        Reload();
  
    }
    public virtual void SetBullets(int bulletsToSet, bool increaseBullets)
    {
        if (increaseBullets)
            currentMaxBullets += bulletsToSet;
        else currentMaxBullets = bulletsToSet;
    }
    private void FireCooldown()
    {
        if (hasShooted)
        {
            weaponFireRate = weaponFireRate - Time.deltaTime;
            canShoot = false;
            if (!particleSystem.isPlaying)
            {
                particleSystem.Stop();
            }
            if (weaponFireRate <= 0)
            {
                weaponFireRate = weaponStats.FireCooldown;
                canShoot = true;
                hasShooted = false;
            }
        }
    }
    private void Reload()
    {
        if (bulletsAmount <= 0)
        {
            canShoot = false;
            currentReloadTime = currentReloadTime - Time.deltaTime;
            if (currentReloadTime <= 0)
            {
                canShoot = true;
                bulletsAmount = currentMaxBullets;
                currentReloadTime = weaponStats.ReloadCooldown;
            }
        }
    }
}
