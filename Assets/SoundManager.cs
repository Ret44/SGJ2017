using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SoundManager : SingletonBehaviour<SoundManager> {

    [SerializeField]
    private AudioSource builderTrack;

    [SerializeField]
    private AudioSource titleTrack;

    [SerializeField]
    private AudioSource battleTrack;

    [SerializeField]
    private GameObject[] screams;

    public AudioSource monsterDie;
    public AudioSource chop;
    public AudioSource punch;

    public static void PlayPunch()
    {
        instance.punch.pitch = Random.Range(0.85f, 1.25f);
        instance.punch.Play();
    }

    public static void PlayChop()
    {
        instance.chop.pitch = Random.Range(0.85f, 1.25f);
        instance.chop.Play();
    }
    public static void PlayScream()
    {
       GameObject sfx =  Instantiate(instance.screams[Random.Range(0, instance.screams.Length - 1)], Vector3.zero, Quaternion.identity);
       Destroy(sfx, 5f);
    }

    public static void PlayBuilderTrack()
    {
        instance.builderTrack.Play();
        //i//nstance.builderTrack.volume = 0;
    }

    public static void PlayBattleTrack()
    {
        instance.battleTrack.volume = 1;
        instance.battleTrack.Play();
        //i//nstance.builderTrack.volume = 0;
    }
    public static void FadeOutBattleTrack()
    {
        instance.battleTrack.DOFade(0f, 1.5f);
    }

    public static void FadeOutBuilderTrack()
    {
        instance.builderTrack.DOFade(0f, 1.5f);
    }


	public void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this);
    }
}
