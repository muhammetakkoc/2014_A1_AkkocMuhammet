using UnityEngine;

public class CarMover : MonoBehaviour
{
    public float speed = 5f;      // hız
    public float lifeTime = 10f;  // kaç saniye sonra yok edilsin

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
}
