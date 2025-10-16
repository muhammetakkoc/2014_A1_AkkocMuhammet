using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifeTime = 2f;
    //public EnemyCounter enemyCounter;
    private Rigidbody2D rb;


    void Start()
    {
        Destroy(gameObject, lifeTime);
        rb = GetComponent<Rigidbody2D>();
    }
   


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            Destroy(gameObject);
            Destroy(other.gameObject);

            if (GameSession.instance != null)
                GameSession.instance.AddEnemyKill();


        }
        if (other.tag != "Enemy")
        {
            Destroy(gameObject);
        }

    }
}