using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 10f;

    public ParticleSystem muzzleFlash;

    [Header("Cooldown")]
    public float fireCooldown = 0.15f; // 
    float nextFireTime = 0f;

    void Update()
    {
        
        if (Input.GetMouseButton(0) && Time.time >= nextFireTime)
        {
            Shoot();
            if (muzzleFlash)
            {
                
                muzzleFlash.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
                muzzleFlash.Play();
            }

            nextFireTime = Time.time + fireCooldown;
        }
    }

    void Shoot()
    {
        if (bulletPrefab == null || firePoint == null) return;

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = firePoint.up * bulletSpeed;
        }
    }
}
