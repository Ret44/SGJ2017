using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Particles
{
    BloodSplat,
    Stars
}
public class ParticleManager : SingletonBehaviour<ParticleManager> {

    [SerializeField]
    private GameObject _bloodSplat;

    [SerializeField]
    private GameObject _stars;

    private Dictionary<Particles,GameObject> particlePrefabs;
    public void Awake()
    {
        base.Awake();

        particlePrefabs = new Dictionary<Particles,GameObject>();

        particlePrefabs.Add(Particles.BloodSplat, instance._bloodSplat);
        particlePrefabs.Add(Particles.Stars, instance._stars);
    }

    public static void SpawnParticles(Particles system, Vector3 position)
    {
        GameObject parSys = Instantiate(instance.particlePrefabs[system], new Vector3(position.x, position.y, 5f), Quaternion.identity);
        Destroy(parSys, 5f);
    }
}
