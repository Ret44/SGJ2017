using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class UITitle : MonoBehaviour {

    public Text name;
    public Image sprite;
    public Button start;

	// Use this for initialization
	void Start () {
        if (name != null)
            name.text = GameUI.winnerName;
        if (sprite != null)
            sprite.DOFade(0f, 1.5f);
        start.Select();
	}

    public void OnStart()
    {
        SceneManager.LoadScene("monsterBuilder");
    }

    public void OnExit()
    {
        Application.Quit();
    }
}
