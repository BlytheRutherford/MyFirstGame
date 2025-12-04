using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotateSpeed = 100f;
    void Update()
    {
        float rotate = Input.GetAxis("Horizontal");
        float move = Input.GetAxis("Vertical");
        transform.Rotate(0, rotate * rotateSpeed * Time.deltaTime, 0, Space.World);
        Vector3 movement = transform.forward * move * moveSpeed * Time.deltaTime;
        transform.Translate(movement, Space.World);
    }
}
