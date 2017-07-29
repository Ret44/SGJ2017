using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LimbThrust : LimbAnimator {

    //public override void BeginAnimation()
    //{
    //    limbBehaviour.isStriking = true;
    //    animation[0].Append(       
    //    limbBehaviour.spriteRootTransform.DOScale(new Vector3(1.75f, 0.65f, 0f), 0.15f)
    //        .OnComplete(() =>
    //        {
    //             limbBehaviour.spriteRootTransform.DOScale(new Vector3(0.5f, 2f, 0f), 0.25f)
    //                .OnComplete(ReturnAnimation);
    //        })
    //    );
    //}

    //public override void ReturnAnimation()
    //{
    //    limbBehaviour.isStriking = false;
    //    animation[0].Kill();
    //    animation[0].Append(limbBehaviour.spriteRootTransform.DOScale(Vector3.one, 0.25f));        
    //}
}
