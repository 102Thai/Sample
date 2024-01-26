using System.Collections;
using UnityEngine;

public class Jump : MonoBehaviour
{
    [SerializeField] float jumpForce = 1;
    Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Jumping(InputManager input)
    {
        if (!input.isJump) return;
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

}