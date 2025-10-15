using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public float moveSpeed;
    [SerializeField] public float padding;

    public bool faceTurntoDirection =true;


    private Rigidbody2D rb;
    Camera cam;


    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    private void FixedUpdate()
    {
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

        Vector2 nextPos = rb.position + input*moveSpeed*Time.fixedDeltaTime;


        Vector2 min = cam.ViewportToWorldPoint(new Vector3(0, 0));
        Vector2 max = cam.ViewportToWorldPoint(new Vector3(1, 1));
        nextPos.x = Mathf.Clamp(nextPos.x, min.x + padding, max.x - padding);
        nextPos.y = Mathf.Clamp(nextPos.y, min.y + padding, max.y - padding);

        rb.MovePosition(nextPos);

        
        if (faceTurntoDirection && input.sqrMagnitude > 0.0001f)
        {
            float angle = Mathf.Atan2(input.y, input.x) * Mathf.Rad2Deg;
            rb.MoveRotation(angle); 
        }
    }
}
