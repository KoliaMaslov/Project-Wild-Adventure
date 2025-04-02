using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 7f;
    public CharacterController controller;
    public Rigidbody rb;
    private float gravityCoef = -9.78f;
    public float jumpHeight = 1f;
    private bool isPlayerGrounded;
    private bool isStaminaOnCooldown = false;
    private bool canRun = false;
    public bool isRunning = false;
    public bool isWalking = false;
    private bool isHungerOnCooldown = false;
    private bool isJumpOnCooldown = false;
    [SerializeField] private PlayerMainScript player;
    [SerializeField] private BasicPanelControl basicPanel;

    void Start()
    {
        if (controller == null) GetComponent<CharacterController>();
        if (rb == null) GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (basicPanel == null)
        {
            GameObject temp = GameObject.Find("BasicPanel (Panel)");
            temp.TryGetComponent<BasicPanelControl>(out basicPanel);
        }
        SpeedControl();
        StaminaControl();
        HungerControl();
        if (player.isLocked)
        {
            Movement();
        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            isWalking = true;
        }
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D) || !player.isLocked)
        {
            isWalking = false;
        }
    }

    private void Movement()
    {
        isPlayerGrounded = controller.isGrounded;
        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;
        Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        movement = Vector3.ClampMagnitude(movement, speed) * Time.deltaTime;
        if (Input.GetKey(KeyCode.Space) && isPlayerGrounded)
        {
            movement.y += Mathf.Sqrt(jumpHeight * -2.0f * gravityCoef);
            Jump();
        }
        movement.y += gravityCoef * Time.deltaTime;
        movement = transform.TransformDirection(movement);
        controller.Move(movement);
    }
    private void SpeedControl()
    {
        if (basicPanel.stamina >= 4 && basicPanel.hunger > 0) canRun = true;
        if (basicPanel.stamina < 4 && basicPanel.hunger == 0) canRun = false;
        if (!canRun) isRunning = false;
        if (Input.GetKey(KeyCode.LeftShift) && canRun)
        {
            speed = 12f;
            isRunning = true;
            if (basicPanel.stamina <= 0)
            {
                canRun = false;
                speed = 7f;
                isRunning = false;
            }
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = 7f;
            isRunning = false;
        }
    }

    private void StaminaControl()
    {
        if (isRunning && !isStaminaOnCooldown && basicPanel.stamina > 0) StartCoroutine(UseStamina(0.25f, 4));
        if (!isRunning && !isStaminaOnCooldown && basicPanel.stamina < 100 && basicPanel.hunger > 0) StartCoroutine(RegenerateStamina(0.5f, 4));
    }

    private void HungerControl()
    {
        if (!isRunning && !isHungerOnCooldown && basicPanel.hunger > 0 && basicPanel.stamina < 100) StartCoroutine(UseHunger(1f, 1));
    }

    private void Jump()
    {
        if (!isJumpOnCooldown && basicPanel.stamina >= 20)
        {
            StartCoroutine(JumpCooldown(5, 20));
        }
    }

    IEnumerator UseStamina(float cooldown, int consumption)
    {
        isStaminaOnCooldown = true;
        basicPanel.stamina -= consumption;
        basicPanel.StaminaTextUpdate(basicPanel.stamina);
        yield return new WaitForSeconds(cooldown);
        isStaminaOnCooldown = false;
    }

    IEnumerator RegenerateStamina(float cooldown, int regeneration)
    {
        isStaminaOnCooldown = true;
        basicPanel.stamina += regeneration;
        basicPanel.StaminaTextUpdate(basicPanel.stamina);
        yield return new WaitForSeconds(cooldown);
        isStaminaOnCooldown = false;
    }

    IEnumerator UseHunger(float cooldown, int consumption)
    {
        isHungerOnCooldown = true;
        basicPanel.hunger -= consumption;
        basicPanel.HungerTextUpdate(basicPanel.hunger);
        yield return new WaitForSeconds(cooldown);
        isHungerOnCooldown = false;
    }

    IEnumerator JumpCooldown(float cooldown, int consupmtion)
    {
        isJumpOnCooldown = true;
        basicPanel.stamina -= consupmtion;
        basicPanel.StaminaTextUpdate(basicPanel.stamina);
        yield return new WaitForSeconds(cooldown);
        isJumpOnCooldown = false;
    }
}
