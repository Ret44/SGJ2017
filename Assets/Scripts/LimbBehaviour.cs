using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class LimbBehaviour : MonoBehaviour {

    public LimbDefinition definition;
    public float HP;
    protected Sequence actionAnimation;
    private Transform objTransform;
    public Collider[] colliders;
    public bool isStriking;

    public Transform spriteRootTransform;

    public void OnTriggerEnter(Collider collision)
    {
        LimbBehaviour other = collision.attachedRigidbody.GetComponent<LimbBehaviour>();
        if (other != null)
        {
            if (other.isStriking)
            {
                other.isStriking = false;
                HP -= other.definition.DMG;
                if (HP <= 0)
                    Die();
            }
        }
    }
    public void SetCollidersIgnore(bool value, LimbBehaviour otherLimb)
    {
        for (int i = 0; i < colliders.Length; i++)
        {
            for (int j = 0; j < otherLimb.colliders.Length; j++)
            {
                Physics.IgnoreCollision(colliders[i], otherLimb.colliders[j], value);
            }
        }
    }

    public void SetCollidersLayer(int layer)
    {
        for(int i=0;i<colliders.Length;i++)
        {
            colliders[i].gameObject.layer = layer;
        }
    }

    public void Awake()
    {
        HP = definition.HP;
        actionAnimation = DOTween.Sequence();
        objTransform = GetComponent<Transform>();
        for(int i=0;i<colliders.Length;i++)
        {
         //   colliders[i].GetComponent<LimbColliderController>().triggerEvent += OnTriggerEnter2D;
        }
    }

    public void Die()
    {
        ParticleManager.SpawnParticles(Particles.BloodSplat, spriteRootTransform.position);
        Destroy(this.gameObject);
    }
    public virtual void Animate()
    {
        isStriking = true;
        spriteRootTransform.DOScale(new Vector3(1.75f, 0.65f, 0f), 0.15f)
            .OnComplete(() =>
            {
                spriteRootTransform.DOScale(new Vector3(0.5f, 2f, 0f), 0.25f)
                    .OnComplete(() =>
                    { 
                        spriteRootTransform.DOScale(Vector3.one, 0.25f);
                        isStriking = false;
                    });                
            });
    }

    public virtual void Action() { }
}
