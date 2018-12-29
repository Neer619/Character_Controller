using UnityEngine;

//Rotate the camera in the vertical direction

public class CharacterController4 : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    CharacterController controller;
    [SerializeField] float jumpForce = 5f;
    [SerializeField] float gravity = 10f;
    Vector3 direction;
    [SerializeField] float mouseSensitivity = 20f;
    [SerializeField] GameObject camera;


    void Start()
    {
        controller = GetComponent<CharacterController>();
        camera = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        
        float mouseX = Input.GetAxis("Mouse X");
        mouseX *= mouseSensitivity;
        Vector3 newRotation = transform.localEulerAngles;
        newRotation.y += mouseX * Time.deltaTime;
        transform.localEulerAngles = newRotation;

        //Controlling the vertical direction of mouse
        float mouseY = Input.GetAxis("Mouse Y");
        mouseY *= -mouseSensitivity;
        Vector3 camRotate = camera.transform.localEulerAngles;
        camRotate.x += mouseY * Time.deltaTime;
        camera.transform.localEulerAngles = camRotate;


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
