﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegBehaviour : MonoBehaviour {

    public Animator animator;
    public Transform rootTransform;

    public void Awake()
    {
        rootTransform = GetComponent<Transform>();
    }
    public void SetLegAnimationSpeed(float val, int direction)
    {
        animator.speed = Mathf.Clamp(val, 0.0f, 1.0f);
        if (direction != 0) 
            rootTransform.localScale = new Vector3(direction, 1, 1);
    }
  
}