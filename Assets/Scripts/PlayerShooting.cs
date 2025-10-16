using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject projectilePrefab; 
    public Transform firePoint;         
    public float fireRate = 0.5f;       
    private float nextFireTime;
    private Rigidbody2D rb;
    [SerializeField] float bulletSpeed;
    public ParticleSystem muzzleFlash;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        //if (Input.GetMouseButtonDown(1))
        //{
        //    TryShoot();
        //    nextFireTime = Time.time + fireRate;
        //    if (muzzleFlash)
        //    {

        //        muzzleFlash.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        //        muzzleFlash.Play();
        //    }
        //}



    }
    public void MobileFireButton()
    {
        TryShoot();
        nextFireTime = Time.time + fireRate;
        if (muzzleFlash)
        {

            muzzleFlash.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
            muzzleFlash.Play();
        }


    }
    public void TryShoot()
    {
        if (Time.time < nextFireTime)
            return;

        nextFireTime = Time.time + fireRate;

        
        GameObject bullet = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);

        
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        if (bulletRb == null)
            bulletRb = bullet.AddComponent<Rigidbody2D>();

       
        bulletRb.bodyType = RigidbodyType2D.Dynamic;
        bulletRb.gravityScale = 0f;
        bulletRb.drag = 0f;
        bulletRb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;

        
        bulletRb.velocity = firePoint.right * bulletSpeed; 

        
        
    }
}


