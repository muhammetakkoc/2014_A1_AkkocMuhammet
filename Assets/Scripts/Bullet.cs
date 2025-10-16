using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifeTime = 2f;
    //public EnemyCounter enemyCounter;
   


    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        
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
