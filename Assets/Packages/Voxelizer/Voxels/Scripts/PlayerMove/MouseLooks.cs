using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLooks : MonoBehaviour
{
    [SerializeField] private Transform PlayerCamera;
    [SerializeField] private CharacterController PlayerController;
    [SerializeField] private float MouseSensitivity = 5f;
    [SerializeField] private float MovementSpeed = 4f;
    [SerializeField] private float JumpForce = 12f;
    [SerializeField] private float Gravity = -9.81f;
    
    private Vector3 Velosity;
    private Vector3 PlayerMovementInput;
    private Vector2 PlayerMouseInput;
    private float CamXRotation;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        PlayerMovementInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        PlayerMouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        Move();
        //Look();
    }
    void Move(){
        Vector3 MoveVector = transform.forward * PlayerMovementInput.z + transform.right * PlayerMovementInput.x;
        if(PlayerController.isGrounded){
            Velosity.y = -3f;
            if(Input.GetKeyDown(KeyCode.Space))
            {
                Velosity.y = JumpForce;
            }
        }
        else{
            Velosity.y -= Gravity * -2f * Time.deltaTime;
        }
        PlayerController.Move(MoveVector * MovementSpeed * Time.deltaTime);
        PlayerController.Move(Velosity * Time.deltaTime);
    }
    void Look(){
        CamXRotation = Mathf.Clamp(CamXRotation, -80f, 80f);
        CamXRotation -= PlayerMouseInput.y * MouseSensitivity;
        transform.Rotate(0f, PlayerMouseInput.x * MouseSensitivity, 0f);
        PlayerCamera.localRotation = Quaternion.Euler(CamXRotation, 0f, 0f);
    }
}
