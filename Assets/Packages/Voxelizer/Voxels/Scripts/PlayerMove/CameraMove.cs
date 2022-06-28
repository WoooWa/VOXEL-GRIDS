using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    // Опции поворота
    private enum Options
    { X, Y, XandY }

    // Выбранная опция поворота
    [SerializeField] private Options options;

    // Текущий поворот
    private Quaternion targetRot;

    private float cameraX;
    private float cameraY;
    public float _speed = 6.0f;
    public float _acceleration = 250.0f; //multiplied by how long shift is held.  Basically running
    public float _maxAcceleration = 20.0f; //Maximum speed when holdin gshift

    private float totalRun = 1.0f;
    public static Transform CameraTransform { get; set; }
    private bool flag;
    private void Start()
    {
        CameraTransform = transform;
    }
    
    

    private void ChangeType()
    {
        if(Input.GetKeyDown(KeyCode.X))
        {
            flag =! flag;
        }
    }
    private void Update()
    {
        ChangeType();
        
        CameraTransform = transform;

        CameraLook();
        GetComponent<MouseLooks>().enabled =! flag;
        if (flag)
        {
                      
            Vector3 movingForce = GetDirection();

            if (Input.GetKey(KeyCode.LeftShift))
            {
                totalRun += Time.fixedDeltaTime;
                movingForce = movingForce * totalRun * _acceleration;

                movingForce = new Vector3(Mathf.Clamp(movingForce.x, -_maxAcceleration, _maxAcceleration),
                                          Mathf.Clamp(movingForce.y, -_maxAcceleration, _maxAcceleration),
                                          Mathf.Clamp(movingForce.z, -_maxAcceleration, _maxAcceleration));
            }
            else
            {
                totalRun = Mathf.Clamp(totalRun * 0.5f, 1f, 1000f);
                movingForce = movingForce * _speed * totalRun;
            }

            transform.Translate(movingForce * Time.fixedDeltaTime);

        }   
        


    }

    /// <summary>
    /// Получени направления движения
    /// </summary>
    /// <returns></returns>
    private Vector3 GetDirection()
    {
        Vector3 direction = new Vector3();
        if (Input.GetKey(KeyCode.W))
        {
            direction += new Vector3(0, 0, 1);
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction += new Vector3(0, 0, -1);
        }
        if (Input.GetKey(KeyCode.A))
        {
            direction += new Vector3(-1, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction += new Vector3(1, 0, 0);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            direction += new Vector3(0, 1, 0);
        }
        if (Input.GetKey(KeyCode.LeftControl))
        {
            direction += new Vector3(0, -1, 0);
        }
        return direction;
    }

    private void CameraLook()
    {
        cameraX += Input.GetAxis("Mouse X");
        cameraY += Input.GetAxis("Mouse Y");

        transform.localRotation = Quaternion.Euler(-cameraY * 1.8f, cameraX * 1.8f, 0);
    }
}