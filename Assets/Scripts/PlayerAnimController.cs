using UnityEngine;

public class PlayerAnimController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private PlayerMainScript playerMainScript;
    [SerializeField] private PlayerMovement playerMovement;
    private string isWalkingState = "IsWalking";
    private string isIdleState = "IsIdle";
    void Start()
    {
        if (playerMainScript == null) playerMainScript = gameObject.GetComponent<PlayerMainScript>();
        if (playerMovement == null) playerMovement = gameObject.GetComponent<PlayerMovement>();
    }

    void Update()
    {
        if (playerMovement.isWalking)
        {
            animator.SetBool(isIdleState, false);
            animator.SetBool(isWalkingState, true);
        }
        if (!playerMovement.isWalking)
        {
            animator.SetBool(isWalkingState, false);
            animator.SetBool(isIdleState, true);
        }
    }
}
