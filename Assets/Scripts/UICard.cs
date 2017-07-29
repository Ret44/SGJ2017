using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICard : MonoBehaviour {

    [SerializeField]
    private Image cardContent;
    [SerializeField]
    private Image cardIcon;

    public LimbDefinition definition;

    public Image[] selection;

    public Image[] claimed;

    public void Select(Player byWho)
    {
        selection[(byWho == Player.One ? 0 : 1)].gameObject.SetActive(true);
    }

    public void Deselect()
    {
        selection[0].gameObject.SetActive(false);
        selection[1].gameObject.SetActive(false);
    }

    public void Claim(Player byWho)
    {
        claimed[(byWho == Player.One ? 0 : 1)].gameObject.SetActive(true);
    }

    public void SetDefinition(LimbDefinition newDef)
    {
        definition = newDef;
        cardContent.sprite = definition.cardContent;
        cardIcon.sprite = definition.cardIcon;
        cardIcon.SetNativeSize();
    }
	// Use this for initialization

}
