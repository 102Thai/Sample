using System.Collections;
using System.Threading;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public float horizontal;
    public bool isJump;
    public bool isShoot;

    private void GetMovementInput()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
    }

    void GetJumpInput()
    {
        if (Input.GetButtonDown("Jump"))
        {
            isJump = true;
        }
        else
        {
            isJump = false;
        }
    }

    public void GetShootInput()
    {
        if (Input.GetKey(KeyCode.F))
        {
            isShoot = true;
        }
        else
        {
            isShoot = false;
        }
    }
    private void Update()
    {
        GetMovementInput();
        GetJumpInput();
        GetShootInput();
    }
}