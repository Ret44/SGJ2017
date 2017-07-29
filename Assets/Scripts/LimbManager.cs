using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimbManager : SingletonBehaviour<LimbManager> {

    public static List<LimbDefinition> limbDefinitions
    {
        get { return instance._definitions; }
    }
    [SerializeField]
    private List<LimbDefinition> _definitions;

    public static List<GameObject> leftLegPrefabs
    {
        get { return instance._leftLegPrefabs; }
    }
    [SerializeField]
    private List<GameObject> _leftLegPrefabs;

    public static List<GameObject> rightLegPrefabs
    {
        get { return instance._rightLegPrefabs; }
    }
    [SerializeField]
    private List<GameObject> _rightLegPrefabs;

    public static List<GameObject> bodyPrefabs
    {
        get { return instance._bodyPrefabs; }
    }
    [SerializeField]
    private List<GameObject> _bodyPrefabs;

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(this);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
