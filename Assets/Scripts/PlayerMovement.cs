using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // hareket hızı

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal"); // A-D veya Sol-Sağ ok
        float v = Input.GetAxisRaw("Vertical");   // W-S veya Yukarı-Aşağı ok

        Vector3 move = new Vector3(h, v, 0f).normalized;
        transform.position += move * moveSpeed * Time.deltaTime;
    }
}
