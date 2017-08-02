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
    public bool isDefended;


    [HideInInspector]
    public LimbAnimator limbAnimator = null;

    public Transform spriteRootTransform;
    public SpriteRenderer[] sprites;


    public void EnableStriking()
    {
        isStriking = true;
    }

    public void DisableStriking()
    {
        isStriking = false;
    }

    public void DisableDefense()
    {
        isDefended = false;
    }
    public void OnTriggerEnter(Collider collision)
    {
        
        LimbBehaviour other = collision.attachedRigidbody.GetComponent<LimbBehaviour>();
        if (other != null)
        {
            Debug.Log(other.definition.name + "  koliduje z " + definition.name);
            if (!isDefended && other.isStriking)
            {
                isDefended = true;
                Invoke("DisableDefense", 1f);
                other.isStriking = false;
                OnHit(other.definition.DMG);
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


    public void OnHit(float DMG)
    {
        HP -= DMG;
        if (HP < 0)
            Die();
        else
        {
            SoundManager.PlayChop();
            ParticleManager.SpawnParticles(Particles.Stars, new Vector3(spriteRootTransform.position.x, spriteRootTransform.position.y, 0f));
            for(int i=0;i<sprites.Length;i++)
            {
                sprites[i].color = Color.red;
                sprites[i].DOColor(Color.white, 1f).SetEase(Ease.InExpo);
            }
        }
    }
    public void Die()
    {
        ParticleManager.SpawnParticles(Particles.BloodSplat, spriteRootTransform.position);
        Destroy(this.gameObject);
    }

    public virtual void Animate()
    {
        if (limbAnimator != null)
            limbAnimator.Animate();
        else if(!isStriking)
        {
            SoundManager.PlayPunch();
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
    }

    public virtual void Action() { }
}
