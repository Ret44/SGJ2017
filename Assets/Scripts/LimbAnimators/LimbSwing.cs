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

    public override void Animate()
    {
        limbBehaviour.isStriking = true;
        limbBehaviour.spriteRootTransform.DOLocalRotate(new Vector3(0f,0f,swingRange),buildUpTime)
            .OnComplete(() =>
                {
                    limbBehaviour.isStriking = true;
                    limbBehaviour.spriteRootTransform.DOLocalRotate(new Vector3(0f, 0f, swingRange * -1), strikeTime)
                        .OnComplete(() =>
                        {
                            limbBehaviour.isStriking = false;
                            limbBehaviour.spriteRootTransform.DOLocalRotate(Vector3.zero, returnTime);
                        });
                });

    }
}
