using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private SpawnMenu spawnMenu;
    [SerializeField] private PlayerMainScript _playerScript;
    [SerializeField] private GameObject playerObj;
    private float mouseSensitivity = 250f;
    private float distanceFromPlayer = 5f; 

    private float xRotation = 0f;
    private float yRotation = 0f;
    private Vector3 respawnRotation = new Vector3 (0f, -60f, 0f);
    void Start()
    {

    }

    void Update()
    {
        if (spawnMenu.isSpawned)
        {
        
            if ((_playerScript.isGunEquipped && !_playerScript.isPickaxeEquipped) || (_playerScript.isPickaxeEquipped && !_playerScript.isGunEquipped)) distanceFromPlayer = 0f;
            if (!_playerScript.isGunEquipped && !_playerScript.isPickaxeEquipped) distanceFromPlayer = 5f;
        
            if (_playerScript.isLocked)
            {
                float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
                float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
                Vector3 height = new Vector3(0f, 2f, 0f);

                if (distanceFromPlayer > 0f)
                {
                    playerObj.transform.Rotate(0f, mouseX, 0f);

                    xRotation -= mouseY;
                    xRotation = Mathf.Clamp(xRotation, -40f, 30f);

                    yRotation += mouseX;

                    Vector3 direction = new Vector3(0, 0, -distanceFromPlayer);
                    Quaternion rotation = Quaternion.Euler(xRotation + 20f, yRotation, 0);

                    transform.position = (playerObj.transform.position + height) + rotation * direction;
                    transform.LookAt(playerObj.transform.position + height);
                }
                else if (distanceFromPlayer == 0f)
                {
                    height = new Vector3(0f, 3.2f, 0f);
                    transform.parent = playerObj.transform;
                    transform.position = playerObj.transform.position + height;
                    playerObj.transform.Rotate(0f, mouseX, 0f);

                    xRotation -= mouseY;
                    xRotation = Mathf.Clamp(xRotation, 0f, 25f);

                    yRotation += mouseX;
                    transform.rotation = Quaternion.Euler(xRotation, yRotation, 0f);
                }
            }
        }
        else if (!spawnMenu.isSpawned)
        {
            transform.localEulerAngles = respawnRotation;
        }
    }
    public void InitializeMainPlayerScript(PlayerMainScript playerScript)
    {
        if (_playerScript == null)
        {
            _playerScript = playerScript;
        }
    }
    public void InitializePlayerObj(GameObject player)
    {
        if (playerObj == null)
        {
            playerObj = player;
        }
    }

    public void ResetXYRotation()
    {
        xRotation = 0;
        yRotation = 0;
    }
}

