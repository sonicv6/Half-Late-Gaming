using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool groundedPlayer;
    private Vector3 playerVelocity;
    private int playerSpeed = 10;
    private CharacterController controller;
    private int jumpHeight = 2;
    private float gravityValue = -9.81f;
    private float sensitivity = 2.0f;

    private Animation anim;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        controller = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animation>();
        anim["Armature_Run"].speed = 2.5f;
        anim["Armature_RunWithGun"].speed = 2.5f;
    }

    // Update is called once per frame
    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 move = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            move += transform.forward;
        }

        if (Input.GetKey(KeyCode.S))
        {
            move -= transform.forward;
        }

        if (Input.GetKey(KeyCode.A))
        {
            move -= transform.right;
        }

        if (Input.GetKey(KeyCode.D))
        {
            move += transform.right;
        }
        if (groundedPlayer)
        {
            if (move != Vector3.zero)
            {
                anim.CrossFade(Input.GetMouseButton(1) ? "Armature_RunWithGun" : "Armature_Run");
            }
            else
            {
                anim.CrossFade(Input.GetMouseButton(1) ? "Armature_IdleWithGun" : "Armature_Idle");
            }
        }
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (Input.GetKey(KeyCode.Space) && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            anim.CrossFade("Armature_Flutter");
        }
        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
        CameraRotation();
    }

    private void CameraRotation()
    {
        Camera camera = GetComponentInChildren<Camera>();
        float horizontal = Input.GetAxis("Mouse X") * sensitivity;
        transform.Rotate(0, horizontal, 0);
    }
}
