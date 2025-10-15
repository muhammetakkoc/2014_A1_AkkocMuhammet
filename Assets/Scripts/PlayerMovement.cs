using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; 

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");   

        Vector3 move = new Vector3(h, v, 0f).normalized;
        transform.position += move * moveSpeed * Time.deltaTime;
    }
}
