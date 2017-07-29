using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimbControllerAnimator : LimbAnimator {

    public Animator animator;

    public override void Animate()
    {
        animator.Play("Attack");
    }

}
