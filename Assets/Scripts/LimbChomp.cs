using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LimbChomp : LimbAnimator {

    [Range(0f, 179f)]
    public float chompAngle;

    [Range(0f, 1f)]
    public float buildUpTime;

    [Range(0f, 1f)]
    public float chompTime;

    [Range(0f, 1f)]
    public float returnTime;

    public Transform upperJaw;
    public Transform lowerJaw;

    public bool isAttacking;

    public override void Animate()
    {
        if (!isAttacking)
        {
            isAttacking = true;
            limbBehaviour.isStriking = true;
            lowerJaw.DOLocalRotate(new Vector3(0f, 0f, 360 - chompAngle), buildUpTime)
            .OnComplete(() =>
                {
                  
                    lowerJaw.DOLocalRotate(Vector3.zero, chompTime);
                    lowerJaw.DOScale(new Vector3(0.75f, 1.25f, 1f), chompTime)
                        .OnComplete(() =>
                        {
                            limbBehaviour.isStriking = false;
                            lowerJaw.DOScale(Vector3.one, returnTime);
                        });
                });

            upperJaw.DOLocalRotate(new Vector3(0f, 0f, chompAngle), buildUpTime)
                .OnComplete(() =>
                {
                    limbBehaviour.isStriking = true;
                    upperJaw.DOLocalRotate(Vector3.zero, chompTime);
                    upperJaw.DOScale(new Vector3(0.75f, 1.25f, 1f), chompTime)
                        .OnComplete(() =>
                        {
                            limbBehaviour.isStriking = false;
                            upperJaw.DOScale(Vector3.one, returnTime).OnComplete(() => { isAttacking = false; });
                        });
                });
        }
    }
}
