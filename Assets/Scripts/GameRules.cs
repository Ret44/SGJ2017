using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRules : SingletonBehaviour<GameRules>
{

    [SerializeField]
    private float _movementSpeed;
    public static float movementSpeed
    {
        get { return instance._movementSpeed; }
    }
}