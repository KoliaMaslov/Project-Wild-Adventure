using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Animations;
using UnityEngine.Rendering;

public class BearScript : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;
    [SerializeField] private BasicPanelControl _basicPanel;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Animator animator;
    [SerializeField] private AudioClip roarSoundClip;
    [SerializeField] private AudioClip deathSoundClip;
    //private float gravityCoef = -9.78f;
    //private float walkSpeed = 2f;
    private float runSpeed = 8f;
    private float cooldown = 3f;
    public int health = 300;
    private int damage = 40;
    private bool isOnCooldown = false;
    private GameObject target;
    private Transform spawnPos;

    private string animationRunForwardState = "Run Forward";
    private string animationIdleState = "Idle";
    private string animationAttackState = "Attack1";
    void Start()
    {
        
    }

    void Update()
    {
        if (spawnPos == null)
        {
            spawnPos = GetComponentInParent<Transform>();
        }
        if (target)
        {
            Movement();
            if (agent.remainingDistance <= 5f && agent.remainingDistance != 0 && !isOnCooldown)
            {
                animator.SetBool(animationRunForwardState, false);
                StartCoroutine(AttackPlayer(damage, cooldown));
            }
        }
        if (target == null) PlayIdleAnimation();
    }

    private void Movement()
    {
        agent.destination = target.transform.position;
        if (agent.remainingDistance > 6f)
        {
            PlayRunForwardAnimation();
        }
        if (agent.remainingDistance <= 6f) animator.SetBool(animationRunForwardState, false);
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

    public void ReactToHit(int damageTaken, GameObject target)
    {
        TargetAtHit(target);
        MakeSound(roarSoundClip);
        health -= damageTaken;
    }

    public void ResetTarget()
    {
        target = null;
    }

    private void TargetAtHit(GameObject targetObject)
    {
        target = targetObject.gameObject;
    }

    private void PlayIdleAnimation()
    {
        animator.SetBool(animationRunForwardState, false);
        animator.SetBool(animationIdleState, true);
    }
    
    private void PlayRunForwardAnimation()
    {
        animator.SetBool(animationIdleState, false);
        animator.SetBool(animationRunForwardState, true);
    }

    public void InitializeBasicPanelScript(BasicPanelControl basicPanel)
    {
        if (_basicPanel == null)
        {
            _basicPanel = basicPanel;
        }
    }
    
    private void MakeSound(AudioClip audioClip)
    {
        if (audioSource && audioClip)
        {
            audioSource.clip = audioClip;
            audioSource.Play();
        }
    }
    IEnumerator AttackPlayer(int damage, float cooldown)
    {
        animator.SetTrigger(animationAttackState);
        isOnCooldown = true;
        _basicPanel.health -= damage;
        _basicPanel.HealthTextUpdate(_basicPanel.health);
        yield return new WaitForSeconds(cooldown);
        isOnCooldown = false;
    }
}
