using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 7f;
    public CharacterController controller;
    public Rigidbody rb;
    private Vector3 movement;
    private float gravityCoef = -9.78f;
    public float jumpHeight = 1f;
    private bool isPlayerGrounded;
    private bool isStaminaOnCooldown = false;
    private bool canRun = false;
    private bool isRunning = false;
    private bool isHungerOnCooldown = false;
    private bool isJumpOnCooldown = false;
    [SerializeField] private BasicPanelControl basicPanel;

    void Start()
    {
        if (controller == null)
        {
            GetComponent<CharacterController>();
        }
        if (rb == null) GetComponent<Rigidbody>();
        if (basicPanel == null)
        {
            GameObject temp = GameObject.Find("BasicPanel (Panel)");
            temp.TryGetComponent<BasicPanelControl>(out basicPanel);
        }
    }

    // Update is called once per frame
    void Update()
    {
        isPlayerGrounded = controller.isGrounded;
        SpeedControl();
        StaminaControl();
        HungerControl();
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
        if (!isRunning && !isStaminaOnCooldown && basicPanel.stamina < 100 && basicPanel.hunger > 0) StartCoroutine(RegenerateStamina(0.5f, 2));
    }

    private void HungerControl()
    {
        if (!isRunning && !isHungerOnCooldown && basicPanel.hunger > 0 && basicPanel.stamina < 100) StartCoroutine(UseHunger(0.5f, 5));
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
