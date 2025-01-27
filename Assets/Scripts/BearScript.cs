using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Animations;
using UnityEngine.Rendering;

public class BearScript : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;
    [SerializeField] private BasicPanelControl basicPanel;
    [SerializeField] private NavMeshAgent agent;
    private float gravityCoef = -9.78f;
    private float walkSpeed = 2f;
    private float runSpeed = 5f;
    private float cooldown = 3f;
    public int health = 300;
    private int damage = 40;
    private GameObject target;
    private bool isOnCooldown = false;
    private Transform spawnPos;
    void Start()
    {
        
    }

    void Update()
    {
        if (spawnPos == null)
        {
            spawnPos = GetComponentInParent<Transform>();
        }
        /*isGrounded = characterController.isGrounded;
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
        if (target != null && isGrounded && !isOnCooldown && Vector3.Distance(transform.position, target.transform.position) <= 5f) StartCoroutine(AttackPlayer(damage, cooldown));*/
        if (target)
        {
            Movement();
            if (agent.remainingDistance <= 5f && target != null && !isOnCooldown) StartCoroutine(AttackPlayer(damage, cooldown));
        }
    }

    private void Movement()
    {
        agent.destination = target.transform.position;
        if (agent.remainingDistance > 5f) agent.speed = runSpeed;
        else if (agent.remainingDistance <= 5f) agent.speed = 0f;
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            target = other.gameObject;
        }
    }

    public void ReactToHit(int damageTaken)
    {
        Debug.Log("Hit");
        health -= damageTaken;
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
