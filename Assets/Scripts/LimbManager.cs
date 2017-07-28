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

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
