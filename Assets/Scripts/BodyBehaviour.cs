using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyBehaviour : MonoBehaviour {

    [SerializeField]
    public LegBehaviour[] legs;


    [SerializeField]
    public List<Transform> joints;


    [SerializeField]
    public List<Transform> leftLegsJoints;

    [SerializeField]
    public List<Transform> rightLegsJoints;

    public void RegisterTo(PlayerBase pb)
    {
        transform.parent = pb.transform;
        pb.body = this;

        int legsPairCount = leftLegsJoints.Count;
        int randomLegId = Random.Range(0, LimbManager.leftLegPrefabs.Count);
        int legsIt = 0;
        for(int i=0;i<legsPairCount;i++)
        {
            GameObject newObj = Instantiate(LimbManager.leftLegPrefabs[randomLegId], leftLegsJoints[i]);
            newObj.transform.localPosition = Vector3.zero;
            legs[legsIt++] = newObj.GetComponent<LegBehaviour>();
            newObj = Instantiate(LimbManager.rightLegPrefabs[randomLegId], rightLegsJoints[i]);
            newObj.transform.localPosition = Vector3.zero;
            legs[legsIt++] = newObj.GetComponent<LegBehaviour>();
        }
    }
}
