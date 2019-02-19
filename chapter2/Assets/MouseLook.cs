using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public enum RotationAxes
    {
        XY = 0,
        X = 1,
        Y = 2
    }

    public RotationAxes rotationAxe = RotationAxes.XY;

    public float horizontalSensivity = 7.0f;
    public float verticalSensivity = 7.0f;

    public float minVerticalRotation = -45.0f;
    public float maxVerticalRotation = 45.0f;

    private float _rotationY = 0;

    // Start is called before the first frame update
    void Start()
    {
       Rigidbody body = GetComponent<Rigidbody>();

        if(body)
        {
            body.freezeRotation = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float rotationX;

        switch(rotationAxe)
        {
            case RotationAxes.X:
                float delta = Input.GetAxis("Mouse X") * horizontalSensivity;
                rotationX = transform.localEulerAngles.y + delta;

                transform.localEulerAngles = new Vector3(0, rotationX, 0);
                break;

            case RotationAxes.Y:
                _rotationY -= Input.GetAxis("Mouse Y") * verticalSensivity;
                _rotationY = Mathf.Clamp(
                    _rotationY,
                    minVerticalRotation,
                    maxVerticalRotation
                );

                rotationX = transform.localEulerAngles.y; //adjust look only for vertical axe

                transform.localEulerAngles = new Vector3(_rotationY, rotationX, 0);
                break;
            default:
                break;
        }
    }
}
