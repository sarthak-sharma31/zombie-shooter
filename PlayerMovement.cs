using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float rotationSpeed = 700.0f;
    public Animator Animator;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Animator.SetTrigger("Fire");
            Animator.SetBool("Firing", true);
        }
        else{
            Animator.SetBool("Firing", false);
        }

        // Get input for movement
        float moveForwardBackward = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        float moveLeftRight = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;

        // Move the player
        Vector3 movement = new Vector3(moveLeftRight, 0, moveForwardBackward);
        transform.Translate(movement);

        // Update animation states
        if (movement != Vector3.zero)
        {
            Animator.SetBool("walk", true);
        }
        else
        {
            Animator.SetBool("walk", false);
            Animator.SetBool("Idle", true);
        }
    }
}
