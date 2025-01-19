using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Rendering;

public class BearScript : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;
    [SerializeField] private BasicPanelControl basicPanel;
    private float gravityCoef = -9.78f;
    private float walkSpeed = 2f;
    private float runSpeed = 5f;
    private float cooldown = 3f;
    private int damage = 20;
    private GameObject target;
    private bool isGrounded;
    private bool isOnCooldown = false;
    void Start()
    {
        
    }

    void Update()
    {
        isGrounded = characterController.isGrounded;
        Vector3 movement = new Vector3(0, 0, 0);
        if (!isGrounded)
        {
            movement.y += gravityCoef * Time.deltaTime;
            movement = transform.TransformDirection(movement);
            characterController.Move(movement);
        }
        if (target != null && isGrounded && Vector3.Distance(transform.position, target.transform.position) >= 5f)
        {
            transform.LookAt(target.transform);
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, walkSpeed * Time.deltaTime);
        }
        if (target != null && isGrounded && !isOnCooldown && Vector3.Distance(transform.position, target.transform.position) <= 5f) StartCoroutine(AttackPlayer(damage, cooldown));
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            target = other.gameObject;
        }
    }

    IEnumerator AttackPlayer(int damage, float cooldown)
    {
        if (basicPanel == null)
        {
            GameObject temp = GameObject.Find("BasicPanel (Panel)");
            temp.TryGetComponent<BasicPanelControl>(out basicPanel);
        }
        isOnCooldown = true;
        basicPanel.health -= damage;
        basicPanel.HealthTextUpdate(basicPanel.health);
        yield return new WaitForSeconds(cooldown);
        isOnCooldown = false;
    }
}
