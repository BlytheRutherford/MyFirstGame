using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotateSpeed = 100f;
    private float gravity = -9.81f;
    private float verticalVelocity = 0f;
    private CharacterController controller;
    private Animator animator;
    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        float rotate = Input.GetAxis("Horizontal");
        float move = Input.GetAxis("Vertical");
        transform.Rotate(0, rotate * rotateSpeed * Time.deltaTime, 0);
        Vector3 moveDirection = transform.forward * move * moveSpeed;
        if (controller.isGrounded)
        {
            verticalVelocity = -2f;
        }
        else
        {
            verticalVelocity += gravity * Time.deltaTime;
        }

        moveDirection.y = verticalVelocity;
        controller.Move(moveDirection * Time.deltaTime);

        float currentSpeed = new Vector3(controller.velocity.x, 0, controller.velocity.z).magnitude;
        animator.SetFloat("Speed", currentSpeed);
        Debug.Log("Speed: " + currentSpeed);
    }
}
