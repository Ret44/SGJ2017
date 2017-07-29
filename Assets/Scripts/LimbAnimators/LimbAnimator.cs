using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LimbBehaviour))]
public class LimbAnimator : MonoBehaviour {

    protected LimbBehaviour limbBehaviour;

	public void Awake()
    {
        limbBehaviour = GetComponent<LimbBehaviour>();
        limbBehaviour.limbAnimator = this;
    }

    public virtual void Animate()
    {

    }
}
