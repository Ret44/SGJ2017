using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Particles
{
    BloodSplat
}
public class ParticleManager : SingletonBehaviour<ParticleManager> {

    [SerializeField]
    private GameObject _bloodSplat;

    private Dictionary<Particles,GameObject> particlePrefabs;
    public void Awake()
    {
        base.Awake();

        particlePrefabs = new Dictionary<Particles,GameObject>();

        particlePrefabs.Add(Particles.BloodSplat, instance._bloodSplat);
    }

    public static void SpawnParticles(Particles system, Vector3 position)
    {
        GameObject parSys = Instantiate(instance.particlePrefabs[system], position, Quaternion.identity);
        Destroy(parSys, 5f);
    }
}
