using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;

[RequireComponent(typeof(PlayerBase))]
public class PlayerControls : MonoBehaviour {

    public PlayerActions inputActions;
    private PlayerBase baseComponent;
    private Transform baseTransform;

    void MovementUpdate()
    {
        //if(device.LeftStick.Value)
        //{
      
        baseTransform.Translate(new Vector3(inputActions.Move.X * GameRules.movementSpeed * Time.deltaTime, inputActions.Move.Y * GameRules.movementSpeed * Time.deltaTime, 0f));
        //}
    }

    void LimbUpdate()
    {
     //   for(int i=0;i<baseComponent.limbs.Length; i++)
        {
           if(inputActions.Action1.WasPressed && baseComponent.limbs[0] != null)
           {
               baseComponent.limbs[0].Animate();
               baseComponent.limbs[0].Action();
           }
           if (inputActions.Action2.WasPressed && baseComponent.limbs[1] != null)
           {
               baseComponent.limbs[1].Animate();
               baseComponent.limbs[1].Action();
           }
           if (inputActions.Action3.WasPressed && baseComponent.limbs[2] != null)
           {
               baseComponent.limbs[2].Animate();
               baseComponent.limbs[2].Action();
           }
           if (inputActions.Action4.WasPressed && baseComponent.limbs[3] != null)
           {
               baseComponent.limbs[3].Animate();
               baseComponent.limbs[3].Action();
           }
        }
    }

    void BindControls()
    {
        inputActions = new PlayerActions();

        inputActions.Left.AddDefaultBinding(Key.LeftArrow);
        inputActions.Right.AddDefaultBinding(Key.RightArrow);
        inputActions.Up.AddDefaultBinding(Key.UpArrow);
        inputActions.Down.AddDefaultBinding(Key.DownArrow);
        inputActions.Action1.AddDefaultBinding(Key.A);
        inputActions.Action2.AddDefaultBinding(Key.S);
        inputActions.Action3.AddDefaultBinding(Key.D);
        inputActions.Action4.AddDefaultBinding(Key.F);
    }

	// Use this for initialization
	void Awake () {
        baseComponent = GetComponent<PlayerBase>();
        baseTransform = GetComponent<Transform>();
        BindControls();
	}
	
	// Update is called once per frame
	void Update () {
     //   device = InputManager.ActiveDevice;
        MovementUpdate();
        LimbUpdate();
	}
}
