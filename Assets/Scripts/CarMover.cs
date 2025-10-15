using UnityEngine;

public class CarMover : MonoBehaviour
{
    public float speed = 5f;       // soldan sağa ya da sağdan sola hareket
    public float lifeTime = 10f;   // emniyet için otomatik yok et
    public GameObject redLight;    // üstteki kırmızı ışık objesi

    void Start()
    {
        // %25 ihtimalle kırmızı ışığı aktif et
        if (redLight != null)
            redLight.SetActive(Random.value < 0.25f);

        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
}
