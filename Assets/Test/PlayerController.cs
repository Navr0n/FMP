using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Camera cam; 
    Rigidbody myRigidbody;


    [SerializeField] private float speed = 10.0f;
    [SerializeField] private float strafeSpeed = 3.0f;
    [SerializeField] private float rotationSpeed = 5.0f;

    float forwardMovement, sideMovement, rotationDeltaY, rotationDeltaX, rotX, rotY;

    
    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
        cam = GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        forwardMovement = Input.GetAxis("Vertical");
        sideMovement = Input.GetAxis("Horizontal");
        rotationDeltaY = Input.GetAxis("Mouse Y");
        rotationDeltaX = Input.GetAxis("Mouse X");

        rotX = rotX + rotationDeltaX;
        rotY = rotY + rotationDeltaY;


        transform.position = transform.position + (transform.forward * forwardMovement * speed * Time.deltaTime);
        transform.position = transform.position + (transform.right * sideMovement * strafeSpeed * Time.deltaTime); 

        transform.localRotation = Quaternion.Euler(new Vector3(0.0f, rotX, 0.0f));
        cam.transform.localRotation = Quaternion.Euler(new Vector3(-rotY, 0.0f, 0.0f)); 
    }
}
