using UnityEngine;

//The most Basic Character Controller

public class CharacterController1 : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    CharacterController controller;


    void Start()
    {
        controller = GetComponent<CharacterController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));  //Stores the direction in which the player will be moving based on the arrow keys or WASD keys pressed
        direction = direction * speed;  // gives the desired speed to the player
        direction = transform.TransformDirection(direction);    // converts local Space to Global Space
        controller.Move(direction * Time.deltaTime);
    }            
}      
