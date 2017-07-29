using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Player
{
    One = 8,
    Two = 9
}
public class PlayerBase : MonoBehaviour {

    [SerializeField]
    public LegBehaviour[] legs;
    
    [SerializeField]
    public Transform baseSprite;

    [SerializeField]
    private List<Transform> joints;

    public Player player;
    public LimbBehaviour[] limbs
    {
        get { return _limbs; }
    }
    [SerializeField]
    private LimbBehaviour[] _limbs;
    
    private int GetFreeJointID()
    {
        for (int i = 0; i < _limbs.Length; i++)
        {
            if (_limbs[i] == null)
                return i;
        }        
        return -1;
    }

    public void UnregisterAllLimbs()
    {
        for(int i=0;i<_limbs.Length; i++)
        {
            Destroy(_limbs[i].gameObject);
            _limbs[i] = null;
        }
    }

    public void RegisterLimb(LimbDefinition limbObject)
    {
        Debug.Log("Registering " + limbObject.name);
        int jointId = GetFreeJointID();
        if(jointId > -1)
        {
            Transform jointTransform = joints[jointId];
            GameObject limb = Instantiate(limbObject.prefab, jointTransform.position, Quaternion.identity);
            limb.transform.parent = jointTransform;
            limb.transform.localEulerAngles = Vector3.zero;
            _limbs[jointId] = limb.GetComponent<LimbBehaviour>();
            limb.layer = LayerMask.NameToLayer(player == Player.One ? "Player1" : "Player2");
            _limbs[jointId].SetCollidersLayer(LayerMask.NameToLayer(player == Player.One ? "Player1" : "Player2"));
            if (jointTransform.localEulerAngles.z > 180)
                limb.transform.localScale = new Vector3(-1, 1, 1);
            else
                limb.transform.localScale = Vector3.one;
        }
        else
            Debug.LogWarning("No free joints! :(");
    }

    public void SetLegsAnimationSpeed(float val, int direction)
    {
        for(int i=0;i<legs.Length;i++)
        {
            legs[i].SetLegAnimationSpeed(val, direction);
        }
    }
	// Use this for initialization
	void Start () {
   
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
