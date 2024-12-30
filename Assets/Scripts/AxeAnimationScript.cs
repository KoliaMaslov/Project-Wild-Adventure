using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeAnimationScript : MonoBehaviour
{
    //this script holds animations for prefabs that cannot be applied in inspector
    public Animator axeHitAnimator;

    private void Start()
    {
        axeHitAnimator = gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            axeHitAnimator.SetTrigger("LMB Trigger");
        }
    }
}
