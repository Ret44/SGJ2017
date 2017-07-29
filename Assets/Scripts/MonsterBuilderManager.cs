using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;

public class MonsterBuilderManager : MonoBehaviour {

    public Player currentSelector;
    public GameObject cardPrefab;

    public Transform cardContainer;
    public List<UICard> cards;
    public List<UICard> claimedCards;

    public PlayerBase player1Base;
    public PlayerBase player2Base;

    public List<LimbDefinition> player1Limbs;
    public List<LimbDefinition> player2Limbs;

    public int selectedCard;

    void GetNewCards()
    {
        for(int i=0;i<8;i++)
        {
            LimbDefinition newDef = LimbManager.limbDefinitions[Random.Range(0, LimbManager.limbDefinitions.Count)];
            GameObject newCard = Instantiate(cardPrefab, cardContainer);
            UICard uiCard = newCard.GetComponent<UICard>();
            uiCard.SetDefinition(newDef);
            cards.Add(uiCard);
        }
    }


	// Use this for initialization
	void Start () {
        GetNewCards();
        Debug.Log(InputManager.Devices.Count);
	}

    public void SelectCard(int id)
    {
        if (id < 0)
            id = cards.Count - 1;
        else if (id >= cards.Count)
            id = 0;

        if(selectedCard<cards.Count)
            cards[selectedCard].Deselect();
        selectedCard = id;
        cards[selectedCard].Select(currentSelector);
    }
	
    
    public void ClaimCard(int id)
    {
        UICard claim = cards[id];
        cards.RemoveAt(id);
        claimedCards.Add(claim);
        claim.Claim(currentSelector);
        if (currentSelector == Player.One)
            player1Base.RegisterLimb(claim.definition);
        else
            player2Base.RegisterLimb(claim.definition);
        if(cards.Count>0)
        {
            currentSelector = (currentSelector == Player.One ? Player.Two : Player.One);
            SelectCard(0);
        }
    }
	// Update is called once per frame
	void Update () {
        int devId = (currentSelector == Player.One?0:1);
        if (InputManager.Devices[devId].LeftStickLeft.WasPressed)
        {
            SelectCard(selectedCard - 1);
        }
        if (InputManager.Devices[devId].LeftStickRight.WasPressed)
        {
            SelectCard(selectedCard + 1);
        }
        if (InputManager.Devices[devId].Action1.WasPressed)
        {
            ClaimCard(selectedCard);
        }
	}
}
