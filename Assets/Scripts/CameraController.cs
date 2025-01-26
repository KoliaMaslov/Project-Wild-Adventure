using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private SpawnMenu spawnMenu;
    [SerializeField] private PlayerMainScript playerScript;
    public GameObject player;
    public float mouseSensitivity = 100f;
    public float distanceFromPlayer = 10f; 

    private float xRotation = 0f;
    private float yRotation = 0f;
    void Start()
    {

    }

    void Update()
    {
        if (spawnMenu.isSpawned)
        {
            if (player == null) player = GameObject.FindGameObjectWithTag("Player");
            if (playerScript == null) playerScript = player.GetComponent<PlayerMainScript>();
        }
        if (playerScript)
        {
            if (playerScript.isLocked)
            {
                float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
                float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

                player.transform.Rotate(0f, mouseX, 0f);

                xRotation -= mouseY;
                xRotation = Mathf.Clamp(xRotation, 0f, 80f);

                yRotation += mouseX;

                Vector3 direction = new Vector3(0, 0, -distanceFromPlayer);
                Quaternion rotation = Quaternion.Euler(xRotation, yRotation, 0);

                transform.position = player.transform.position + rotation * direction;
                transform.LookAt(player.transform.position);
            }
        }
    }
}

