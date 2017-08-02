using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LimbSwing : LimbAnimator {

    [Range(0f, 180f)]
    public float swingRange;

    [Range(0f, 1f)]
    public float buildUpTime;

    [Range(0f, 1f)]
    public float strikeTime;

    [Range(0f, 1f)]
    public float returnTime;
    public bool isAttacking;

    public override void Animate()
    {
        if (!isAttacking)
        {
            isAttacking = true;
            limbBehaviour.isStriking = true;
            limbBehaviour.spriteRootTransform.DOLocalRotate(new Vector3(0f, 0f, swingRange), buildUpTime)
                .OnComplete(() =>
                    {

                        limbBehaviour.spriteRootTransform.DOLocalRotate(new Vector3(0f, 0f, swingRange * -1), strikeTime)
                            .OnComplete(() =>
                            {
                                limbBehaviour.spriteRootTransform.DOLocalRotate(Vector3.zero, returnTime).OnComplete(() =>
                                {
                                    isAttacking = false;
                                    limbBehaviour.isStriking = false;
                                });
                            });
                    });
        }
    }
}
