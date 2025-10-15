using UnityEngine;

public class BGFollow : MonoBehaviour
{

    [SerializeField] float speed;
    [SerializeField] Boundry verticalBoundry;


    void Start()
    {

    }


    void Update()
    {
        transform.position = transform.position + Vector3.left * Time.deltaTime;

        if (transform.position.x < verticalBoundry.min)
        {
            transform.position = new Vector3( verticalBoundry.max, transform.position.y, transform.position.z);
        }


    }
}

