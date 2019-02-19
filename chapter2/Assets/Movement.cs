using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Mouse Look/Keyboard Movement")]
public class Movement : MonoBehaviour
{
    private CharacterController _player;

    public float speed = 5.0f;
    public float gravity = -9.8f;
    // Start is called before the first frame update
    void Start()
    {
        _player = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;

        Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        movement = Vector3.ClampMagnitude(movement, speed);

        movement.y = gravity;
        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);

        _player.Move(movement);
    }
}
