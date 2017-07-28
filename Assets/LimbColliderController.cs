using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimbColliderController : MonoBehaviour {

    public delegate void TriggerEvent(Collider2D collider);

    public TriggerEvent triggerEvent;

	public void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("ROZSIERDZONY");
        if (triggerEvent != null)
            triggerEvent.Invoke(collider);
    }
}
