using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;   
    public Transform firePoint;       
    public float bulletSpeed = 10f;   

    public ParticleSystem muzzleFlash;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            Shoot();
            if (muzzleFlash)
            {
                muzzleFlash.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
                muzzleFlash.Play();
            }
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
