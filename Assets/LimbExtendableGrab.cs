using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LimbExtendableGrab : LimbAnimator {

    [Range(0f, 20f)]
    public float extensionLength;

    [Range(0f, 179f)]
    public float chompAngle;

    [Range(0f, 1f)]
    public float buildUpTime;

    [Range(0f, 1f)]
    public float attackTime;

    [Range(0f, 1f)]
    public float returnTime;

    public Transform upperJaw;
    public Transform lowerJaw;

    public override void Animate()
    {

        limbBehaviour.spriteRootTransform.DOScale(new Vector3(1.75f, 0.65f, 0f), 0.15f)
                .OnComplete(() =>
                {
                    limbBehaviour.spriteRootTransform.DOScale(new Vector3(0.5f, 2f, 0f), 0.25f)
                        .OnComplete(() =>
                        {
                            limbBehaviour.spriteRootTransform.DOScale(Vector3.one, 0.25f);
                        });
                });
    }
}
