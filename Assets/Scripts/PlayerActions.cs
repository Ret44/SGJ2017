using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : InControl.PlayerActionSet {
    public InControl.PlayerAction Action1;
    public InControl.PlayerAction Action2;
    public InControl.PlayerAction Action3;
    public InControl.PlayerAction Action4;
    public InControl.PlayerAction Left;
    public InControl.PlayerAction Right;
    public InControl.PlayerAction Up;
    public InControl.PlayerAction Down;
    public InControl.PlayerTwoAxisAction Move;

    public PlayerActions()
    {
        Action1 = CreatePlayerAction("Action1");
        Action2 = CreatePlayerAction("Action2");
        Action3 = CreatePlayerAction("Action3");
        Action4 = CreatePlayerAction("Action4");
        Left = CreatePlayerAction("Left");
        Right = CreatePlayerAction("Right");
        Up = CreatePlayerAction("Up");
        Down = CreatePlayerAction("Down");
        Move = CreateTwoAxisPlayerAction(Left, Right, Down, Up);
    }
}
