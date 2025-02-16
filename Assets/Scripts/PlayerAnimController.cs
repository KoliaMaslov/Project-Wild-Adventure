using UnityEngine;

public class PlayerAnimController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private PlayerMainScript playerMainScript;
    [SerializeField] private PlayerMovement playerMovement;
    void Start()
    {
        if (playerMainScript == null) playerMainScript = gameObject.GetComponent<PlayerMainScript>();
        if (playerMovement == null) playerMovement = gameObject.GetComponent<PlayerMovement>();
    }

    void Update()
    {
        if (playerMovement.isWalking) animator.SetTrigger("IsWalking");
        if (!playerMovement.isWalking) animator.SetTrigger("IsIdle");
    }
}
