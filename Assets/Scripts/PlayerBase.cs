using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Player
{
    One = 8,
    Two = 9
}
public class PlayerBase : MonoBehaviour {

    public string name;

    public static PlayerBase player1;
    public static PlayerBase player2;

    public float maxHP;

    [SerializeField]
    public LegBehaviour[] legs
    {
        get { return body.legs;}
    }

    [SerializeField]
    private List<Transform> joints
    {
        get { return body.joints;}
    }
    public bool isDying = false;

    [SerializeField]
    private List<Transform> leftLegsJoints
    {
        get { return body.leftLegsJoints; }
    }

    [SerializeField]
    private List<Transform> rightLegsJoints
    {
        get { return body.rightLegsJoints; }
    }


    [SerializeField]
    public Transform baseSprite;

    public Player player;
    public LimbBehaviour[] limbs
    {
        get { return _limbs; }
    }
    [SerializeField]
    private LimbBehaviour[] _limbs;

    public BodyBehaviour body;
    
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

        name = "";
        maxHP = 0;
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

            maxHP += _limbs[jointId].definition.HP;

            if (jointId == 0)
                name += _limbs[jointId].definition.GetPrefix();
            else if (jointId == 1)
                name += " " + _limbs[jointId].definition.GetMid();
            else if (jointId == 2)
                name += "-" + _limbs[jointId].definition.GetMid();
            else
                name += " " + _limbs[jointId].definition.GetSuffix();
        }
        else
            Debug.LogWarning("No free joints! :(");
    }

    public void SetLegsAnimationSpeed(float val)
    {
        for(int i=0;i<legs.Length;i++)
        {
            legs[i].SetLegAnimationSpeed(val);
        }
    }

    void Awake()
    {
        if (player == Player.One)
            PlayerBase.player1 = this;
        else if (player == Player.Two)
            PlayerBase.player2 = this;
    }

    public float GetHealth()
    {
        float healthSum = 0;
        for(int i=0;i<limbs.Length;i++)
        {
            if(limbs[i] != null)
            {
                healthSum += limbs[i].HP;
            }
        }
        if (healthSum <= 0)
            Die();
        return healthSum / maxHP;
    }
    
    public void SpawnRandomizedBlood()
    {
        ParticleManager.SpawnParticles(Particles.BloodSplat, Random.insideUnitSphere + new Vector3(transform.position.x, transform.position.y, 5f));
    }

    public void Die()
    {
        if (!isDying)
        {
            isDying = true;
            SoundManager.instance.monsterDie.Play();
            for (int i = 0; i < 30; i++)
            {
                float delay = i * 0.05f;
                Invoke("SpawnRandomizedBlood", delay);
            }
            if (player == Player.One)
                GameUI.winnerName = PlayerBase.player2.name;
            else
                GameUI.winnerName = PlayerBase.player1.name;
            GameUI.GameOver();
        }
    }
	// Use this for initialization
	void Start () {
        GameObject bodyObj = Instantiate(LimbManager.bodyPrefabs[Random.Range(0, LimbManager.bodyPrefabs.Count)]);
        bodyObj.GetComponent<BodyBehaviour>().RegisterTo(this);
        bodyObj.transform.localPosition = Vector3.zero;

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
