using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof (CharacterController))]
public class RelativeMovement : MonoBehaviour {
    [SerializeField] private Transform target;

    public float rotSpeed = 15.0f;
    public float moveSpeed = 6.0f;

    public float jumpSpeed = 15.0f;
    public float gravity = -9.8f;
    public float terminalVelocity = -10.0f;
    public float minFall = -1.5f;

    private float _vertSpeed;

    private CharacterController _characterController;
    //private Rigidbody rb;

    void Start ()
    {
        Cursor.lockState = CursorLockMode.Locked;

        _characterController = GetComponent<CharacterController>();
        //rb = GetComponent<Rigidbody>();

        _vertSpeed = minFall;

    }

	// Update is called once per frame
	void Update () {
        Vector3 movement = Vector3.zero;

        float horInput = Input.GetAxis("Horizontal");
        float vertInput = Input.GetAxis("Vertical");

        if(horInput != 0 || vertInput != 0)
        {
            movement.x = horInput * moveSpeed;
            movement.z = vertInput * moveSpeed;
            movement = Vector3.ClampMagnitude(movement, moveSpeed);


            Quaternion tmp = target.rotation;
            target.eulerAngles = new Vector3(0, target.eulerAngles.y, 0);
            movement = target.TransformDirection(movement);
            target.rotation = tmp;

            Quaternion direction = Quaternion.LookRotation(movement);
            transform.rotation = Quaternion.Lerp(transform.rotation, direction, rotSpeed * Time.deltaTime);
        }

        if (_characterController.isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                _vertSpeed = jumpSpeed;
            }
            else
            {
                _vertSpeed = minFall;
            }
        } else { 
            _vertSpeed += gravity * 5 * Time.deltaTime;
            if (_vertSpeed < terminalVelocity)
             {
                _vertSpeed = terminalVelocity;
             }
        
        }
        //movement.y -= gravity * Time.deltaTime;
        movement.y = _vertSpeed;

        movement *= Time.deltaTime;
        _characterController.Move(movement);

        
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Deathzone"){
            //Debug.Log("died");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);       
        }

        if (other.gameObject.tag == "Game Starter")
        {
            SceneManager.LoadScene("The Pillers");
            //Debug.Log("Changing scene");
        }


        if (other.gameObject.tag == "The Clock")
        {
            SceneManager.LoadScene("Clock");
            //Debug.Log("Changing scene");
        }

        if (other.gameObject.tag == "Ender")
        {
            SceneManager.LoadScene("Lost");
            //Debug.Log("Changing scene");
        }


    }
}
