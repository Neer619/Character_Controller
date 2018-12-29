using UnityEngine;

//Adds jump ability to the player

public class CharacterController2 : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    CharacterController controller;
    [SerializeField] float jumpForce = 5f;
    [SerializeField] float gravity = 10f;
    Vector3 direction;


    void Start()
    {
        controller = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        if (controller.isGrounded)
        {
            direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));  //Stores the direction in which the player will be moving based on the arrow keys or WASD keys pressed
            direction = direction * speed;  // gives the desired speed to the player
            direction = transform.TransformDirection(direction);    // converts local Space to Global Space

            if (Input.GetKeyDown(KeyCode.Space))
            {
                direction.y = jumpForce;
            }
        }

        direction.y -= gravity * Time.deltaTime;
        controller.Move(direction * Time.deltaTime);
    }
}
