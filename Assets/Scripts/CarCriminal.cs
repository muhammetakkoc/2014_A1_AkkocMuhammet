using UnityEngine;

public class CarCriminal : MonoBehaviour
{
    [Range(0f, 1f)] public float criminalChance = 0.25f; 
    public GameObject redLight; 
    public float blinkSpeed = 4f; 

    bool isCriminal;

    void Start()
    {
        isCriminal = Random.value < criminalChance;

        if (redLight != null)
            redLight.SetActive(isCriminal);
    }

    void Update()
    {
        if (isCriminal && redLight != null)
        {
            
            float t = (Mathf.Sin(Time.time * blinkSpeed) + 1f) * 0.5f;

            
            float scale = 0.2f + t * 0.05f;
            redLight.transform.localScale = new Vector3(scale, scale, 0.2f);
        }
    }
}
