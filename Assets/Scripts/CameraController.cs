using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
    public RotationAxes axes = RotationAxes.MouseXAndY;
    public float sensevityH = 9f;
    public float sensevityV = 4f;
    private float maxYRotation = 20f;
    private float minYRotation = -20f;
    private float rotationX = 0f;
    [SerializeField] private PlayerMainScript playerScript;
    void Start()
    {

    }

    void Update()
    {
        if (playerScript.isLocked || Input.GetMouseButton(1))
        {
            if (axes == RotationAxes.MouseX)
            {
                transform.Rotate(0, Input.GetAxis("Mouse X") * sensevityH, 0);
            }
            else if (axes == RotationAxes.MouseY)
            {
                rotationX = rotationX - Input.GetAxis("Mouse Y") * sensevityV;
                rotationX = Mathf.Clamp(rotationX, minYRotation, maxYRotation);
                float rotationY = transform.localEulerAngles.y;
                transform.localEulerAngles = new Vector3(rotationX, rotationY, 0);
            }
            else
            {
                rotationX = rotationX - Input.GetAxis("Mouse Y") * sensevityV;
                rotationX = Mathf.Clamp(rotationX, minYRotation, maxYRotation);
                float delta = Input.GetAxis("Mouse X") * sensevityH;
                float rotationY = transform.localEulerAngles.y + delta;
                transform.localEulerAngles = new Vector3(rotationX, rotationY, 0);
            }
        }
    }
}

