using System.Collections;
using UnityEngine;

public class PlayerMainScript : MonoBehaviour
{
    [SerializeField] private Camera camera;
    [SerializeField] private AudioSource shotSound;
    public bool isLocked = true;
    public bool isHandfree = true;
    public bool isPickaxeEquipped = false;
    public bool isAxeEquipped = false;
    public bool isGunEquipped = false;
    private bool isOnCooldown = false;
    public GameObject player;
    public GameObject pickaxePrefab;
    private GameObject pickaxe;
    public GameObject axePrefab;
    private GameObject axe;
    public Transform itemHolder;
    public GameObject gunPrefab;
    private GameObject gun;
    private float cooldown = 1f;
    private int gunDamage = 60;
    void Start()
    {
        LockCursor();
        itemHolder = player.transform.Find("ItemHolder");
        var temp = GameObject.FindWithTag("MainCamera");
        temp.TryGetComponent<Camera>(out camera);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            if (isLocked)
            {
                UnlockCursor();
            }
            else if (!isLocked)
            {
                LockCursor();
            }
        }
        if (Input.GetMouseButtonDown(0) && isGunEquipped && !isOnCooldown) Shoot();
    }

    public void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        isLocked = true;
    }

    public void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        isLocked = false;
    }

    public void TakePickaxe()
    {
        if(itemHolder == null) itemHolder = player.transform.Find("ItemHolder");
        if (itemHolder)
        {
            if (isHandfree && !isPickaxeEquipped)
            {
                Vector3 pos = itemHolder.position;
                pickaxe = Instantiate(pickaxePrefab, pos, player.transform.rotation, player.transform);
                isHandfree = false;
                isPickaxeEquipped = true;
            }
            else if (isPickaxeEquipped)
            {
                Destroy(pickaxe);
                isHandfree = true;
                isPickaxeEquipped = false;
            }
        }
    }

    public void TakeAxe()
    {
        if (itemHolder)
        {
            if (isHandfree && !isAxeEquipped)
            {
                Vector3 pos = itemHolder.position;
                axe = Instantiate(axePrefab, pos, transform.rotation, player.transform);
                axe.transform.Rotate(0f, 0f, 0f);
                isHandfree = false;
                isAxeEquipped = true;
            }
            else if (isAxeEquipped)
            {
                Destroy(axe);
                isHandfree = true;
                isAxeEquipped = false;
            }
        }
    }

    public void TakeGun()
    {
        if (itemHolder)
        {
            if (isHandfree && !isGunEquipped)
            {
                Vector3 pos = itemHolder.position;
                gun = Instantiate(gunPrefab, pos, transform.rotation, player.transform);
                gun.transform.Rotate(0f, 180f, 0f);
                isHandfree = false;
                isGunEquipped = true;
            }
            else if (isGunEquipped)
            {
                Destroy(gun);
                isHandfree = true;
                isGunEquipped = false;
            }
        }
    }

    private void Shoot()
    {
        Vector3 point = new Vector3(camera.pixelWidth / 2, (camera.pixelHeight / 2) + 300f, 0);
        Ray ray = camera.ScreenPointToRay(point);
        RaycastHit hit;
        ShotSound();
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.CompareTag("Bear"))
            {
                GameObject hitObject = hit.transform.gameObject;
                BearScript bear = hitObject.GetComponent<BearScript>();
                if (bear != null)
                {
                    bear.ReactToHit(gunDamage, gameObject);
                }
            }
            else
            {
                StartCoroutine(SphereIndicator(hit.point));
            }
            StartCoroutine(ShootCooldown(cooldown));
        }
    }

    private void ShotSound()
    {
        if(shotSound && shotSound.clip) shotSound.Play();
    }

    private IEnumerator SphereIndicator(Vector3 pos)
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = pos;
        yield return new WaitForSeconds(3);
        Destroy(sphere);
    }

    private IEnumerator ShootCooldown(float cooldown)
    {
        isOnCooldown = true;
        yield return new WaitForSeconds(cooldown);
        isOnCooldown = false;
    }
}
