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
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
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
            move.z += 1;
        }

        if (Input.GetKey(KeyCode.S))
        {
            move.z -= 1;
        }

        if (Input.GetKey(KeyCode.A))
        {
            move.x -= 1;
        }

        if (Input.GetKey(KeyCode.D))
        {
            move.x += 1;
        }

        controller.Move(move * Time.deltaTime * playerSpeed);

        if (Input.GetKey(KeyCode.Space) && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }
        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
}
