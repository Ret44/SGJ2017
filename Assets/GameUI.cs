using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
public class GameUI : SingletonBehaviour<GameUI> {

    public bool gameStarted = false;

    public static string winnerName;

    [SerializeField]
    private Text _player1Name;    
    public static Text player1Name
    {
        get { return instance._player1Name; }
    }

    [SerializeField]
    private Text _player2Name;
    public static Text player2Name
    {
        get { return instance._player2Name; }
    }

    [SerializeField]
    private GameObject _canvasRoot;
    public static GameObject canvasRoot
    {
        get { return instance._canvasRoot; }
    }

    [SerializeField]
    private RectTransform _namesMask;
    public static RectTransform namesMask
    {
        get { return instance._namesMask; }
    }

    [SerializeField]
    private RectTransform _HUDRoot;
    public static RectTransform HUDRoot
    {
        get { return instance._HUDRoot; }
    }

    [SerializeField]
    private Image _commence;
    public static Image commence
    {
        get { return instance._commence; }
    }

    [SerializeField]
    private Image _background;
    public static Image background
    {
        get { return instance._background; }
    }


    [SerializeField]
    private Camera _monsterBuilderCamera;
    public static Camera monsterBuilderCamera
    {
        get { return instance._monsterBuilderCamera; }
    }

    [SerializeField]
    private Image _p1HP;
    public static Image p1HP
    {
        get { return instance._p1HP; }
    }

    [SerializeField]
    private Image _p2HP;
    public static Image p2HP
    {
        get { return instance._p2HP; }
    }

    [SerializeField]
    private Image[] _p1Weapons;
    public static Image[] p1Weapons
    {
        get { return instance._p1Weapons; }
    }

    [SerializeField]
    private Image[] _p2Weapons;
    public static Image[] p2Weapons
    {
        get { return instance._p2Weapons; }
    }


    [SerializeField]
    private Image _Fade;
    public static Image fade
    {
        get { return instance._Fade; }
    }

    public static void GameOver()
    {
        SoundManager.FadeOutBattleTrack();
        fade.DOColor(new Color(0.84f, 0.733f, 0.55f, 1f),1.5f).OnComplete(() => {
            SceneManager.LoadScene("gameEnd");
        });

    }

    public static void ShowGameHUD()
    {
        Sequence seq = DOTween.Sequence();
        SoundManager.FadeOutBuilderTrack();
        for (int i = 0; i < PlayerBase.player1.limbs.Length; i++)
        {
            p1Weapons[i].sprite = PlayerBase.player1.limbs[i].definition.cardIcon;
            p1Weapons[i].SetNativeSize();
            p1Weapons[i].gameObject.SetActive(true);
            p2Weapons[i].sprite = PlayerBase.player2.limbs[i].definition.cardIcon;
            p2Weapons[i].SetNativeSize();
            p2Weapons[i].gameObject.SetActive(true);
        }
        seq.Append(HUDRoot.DOAnchorPos(Vector2.zero, 2f).OnComplete(ShowNamesMask));
        seq.AppendInterval(2.0f);
        seq.Append(commence.DOColor(new Color(1f, 1f, 1f, 0f), 2f).OnComplete(HideNameMask));
        seq.Append(background.DOFade(0f, 1f));
    }
    public static void ShowNamesMask()
    {
        namesMask.DOAnchorPosX(0, 1f);
        namesMask.DOSizeDelta(new Vector3(1920, 540), 1f);
    }

    public static void HideNameMask()
    {
        namesMask.DOAnchorPosX(-960f, 1f);
        PlayerBase.player1.transform.DOScale(0.75f, 1f);
        PlayerBase.player2.transform.DOScale(0.75f, 1f);
        namesMask.DOSizeDelta(new Vector3(0, 540), 1f).OnComplete(() =>
        {
            PlayerBase.player1.GetComponent<PlayerControls>().enabled = true;
            PlayerBase.player2.GetComponent<PlayerControls>().enabled = true;
        });
        monsterBuilderCamera.gameObject.SetActive(false);        
        instance.gameStarted = true;
        SoundManager.PlayBattleTrack();
    }
  
    void Update()
    {
        if(gameStarted)
        {
            p1HP.fillAmount = PlayerBase.player1.GetHealth();
            p2HP.fillAmount = PlayerBase.player2.GetHealth();
        }
    }
	
}
