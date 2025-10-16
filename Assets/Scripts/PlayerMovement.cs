using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 6f;
    public Camera cam;

    Vector3 targetPos;
    bool hasPointerTarget;

    void Awake()
    {
        if (!cam) cam = Camera.main;
    }

    void Update()
    {
        // --- TOUCH: ekrana basılı tutulan noktayı hedef yap ---
        if (Input.touchCount > 0)
        {
            Touch t = Input.GetTouch(0);
            if (t.phase == TouchPhase.Began || t.phase == TouchPhase.Moved || t.phase == TouchPhase.Stationary)
            {
                targetPos = cam.ScreenToWorldPoint(new Vector3(t.position.x, t.position.y, 0f));
                targetPos.z = transform.position.z;
                hasPointerTarget = true;
            }
            else if (t.phase == TouchPhase.Ended || t.phase == TouchPhase.Canceled)
            {
                hasPointerTarget = false;
            }
        }

        // --- MOUSE: sol tuş basılıyken imleci hedef yap ---
        if (Input.GetMouseButton(0))
        {
            targetPos = cam.ScreenToWorldPoint(Input.mousePosition);
            targetPos.z = transform.position.z;
            hasPointerTarget = true;
        }
        if (Input.GetMouseButtonUp(0)) hasPointerTarget = false;

        // --- WASD fallback (istersen bırak) ---
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        if (h != 0 || v != 0)
        {
            hasPointerTarget = false; // manuel kontrol
            Vector3 move = new Vector3(h, v, 0f).normalized;
            transform.position += move * moveSpeed * Time.deltaTime;
            return;
        }

        // --- Hedefe doğru hareket ---
        if (hasPointerTarget)
        {
            Vector3 dir = targetPos - transform.position;
            float dist = dir.magnitude;
            if (dist > 0.01f)
            {
                Vector3 step = dir.normalized * moveSpeed * Time.deltaTime;
                transform.position += (step.sqrMagnitude > dir.sqrMagnitude) ? dir : step; // hedefi aşma
            }
        }
    }
}
