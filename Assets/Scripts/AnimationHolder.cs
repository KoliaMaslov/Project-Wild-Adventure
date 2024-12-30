using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHolder : MonoBehaviour
{
    //this script holds animations for prefabs that cannot be applied in inspector
    public Animator pickaxeHitAnimator;

    private void Start()
    {
        pickaxeHitAnimator = gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            pickaxeHitAnimator.SetTrigger("LMB Trigger");
        }
    }
}
