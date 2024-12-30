using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 7f;
    public CharacterController controller;
    private float gravityCoef = -9.78f;
    public float weight;

    void Start()
    {
        if (controller == null)
        {
            GetComponent<CharacterController>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;
        Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        movement = Vector3.ClampMagnitude(movement, speed) * Time.deltaTime;
        movement.y = gravityCoef;
        movement = transform.TransformDirection(movement);
        controller.Move(movement);
    }
}
