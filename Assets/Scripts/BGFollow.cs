using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class BGFollow : MonoBehaviour
{
    [SerializeField] float speed = 2f;
    [SerializeField] float leftEdgeX = -20f;  // sol sınır (dünya koordinatı)
    [SerializeField] int tileCount = 2;       // aynı hattaki BG parça sayısı (genelde 2)

    float width;

    void Awake()
    {
        var sr = GetComponent<SpriteRenderer>();
        width = sr.bounds.size.x;  // bu BG'nin dünya genişliği
    }

    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

        // Nesne ekranın solundan tamamen çıktıysa, kendi toplam uzunluğu kadar sağa taşı
        if (transform.position.x < leftEdgeX - width * 0.5f)
        {
            transform.position += new Vector3(width * tileCount, 0f, 0f);
        }
    }
}




//using UnityEngine;

//public class BGFollow : MonoBehaviour
//{

//    [SerializeField] float speed;
//    [SerializeField] Boundry verticalBoundry;


//    void Start()
//    {

//    }


//    void Update()
//    {
//        transform.position = transform.position + Vector3.left* 10f* Time.deltaTime;

//        if (transform.position.x < verticalBoundry.min)
//        {
//            transform.position = new Vector3( verticalBoundry.max, transform.position.y, transform.position.z);
//        }


//    }
//}

