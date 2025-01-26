using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private SpawnMenu spawnMenu;
    [SerializeField] private PlayerMainScript playerScript;
    public GameObject player;
    private float mouseSensitivity = 250f;
    private float distanceFromPlayer = 5f; 

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
        
            if (playerScript.isGunEquipped) distanceFromPlayer = 0f;
            if (!playerScript.isGunEquipped) distanceFromPlayer = 5f;
        
            if (playerScript.isLocked)
            {
                float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
                float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
                Vector3 height = new Vector3(0f, 2f, 0f);

                if (distanceFromPlayer > 0f)
                {
                    player.transform.Rotate(0f, mouseX, 0f);

                    xRotation -= mouseY;
                    xRotation = Mathf.Clamp(xRotation, -40f, 30f);

                    yRotation += mouseX;

                    Vector3 direction = new Vector3(0, 0, -distanceFromPlayer);
                    Quaternion rotation = Quaternion.Euler(xRotation + 20f, yRotation, 0);

                    transform.position = (player.transform.position + height) + rotation * direction;
                    transform.LookAt(player.transform.position + height);
                }
                else if (distanceFromPlayer == 0f)
                {
                    height = new Vector3(0f, 3.2f, 0f);
                    transform.parent = player.transform;
                    transform.position = player.transform.position + height;
                    player.transform.Rotate(0f, mouseX, 0f);

                    xRotation -= mouseY;
                    xRotation = Mathf.Clamp(xRotation, 0f, 25f);

                    yRotation += mouseX;
                    transform.rotation = Quaternion.Euler(xRotation, yRotation, 0f);
                    //GameObject gun = GameObject.FindWithTag("Gun");
                    //gun.transform.rotation = Quaternion.Euler(0f, yRotation, 0f);
                }
            }
        }
    }
}

