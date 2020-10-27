using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CardManager : MonoBehaviour
{
    public static CardManager instance;

    [SerializeField]
    private List<Sprite> cardSprits;

    [SerializeField]
    private GameObject PlayerArea , CardPref, DummyCard, ParentHolder;

    private int k, childCount;
    private cardView selectedCard, previusCard, nextCard;
    private GameObject dummyobj;

    public cardView SelectedCard
    {
        get => selectedCard;
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    private void Start()
    {
        for (int i = 0; i < 13; i++)
        {
            k = i;
            SpawnCard();
        }
    }
    public void SetSelectedCard(cardView card)
    {
        int selectedCardIndex = card.transform.GetSiblingIndex();
        selectedCard = card;
        selectedCard.childIndex = selectedCardIndex;
        GetDummyCard().SetActive(true);
        GetDummyCard().transform.SetSiblingIndex(selectedCardIndex);
        selectedCard.transform.SetParent(ParentHolder.transform);

        childCount = PlayerArea.transform.childCount;
        if(selectedCardIndex +1 < childCount)
        {
            nextCard = PlayerArea.transform.GetChild(selectedCardIndex + 1).GetComponent<cardView>();
        }
        if (selectedCardIndex - 1 >= 0)
        {
            previusCard = PlayerArea.transform.GetChild(selectedCardIndex - 1).GetComponent<cardView>();
        }
       
    }
    public void MoveCard(Vector2 position)
    {
        if (selectedCard != null)
        {
            selectedCard.transform.position = position;
            CheckWithNextCard();
            CheckWithPreviousCard();
        }
    }
    public void ReleseCard()
    {
        if (selectedCard != null)
        {
            GetDummyCard().SetActive(false);
            selectedCard.transform.SetParent(PlayerArea.transform);
            if (Mathf.Abs(selectedCard.transform.position.y - dummyobj.transform.position.y) > 80)
            {
                GetDummyCard().transform.SetParent(ParentHolder.transform);
                selectedCard.transform.SetSiblingIndex(selectedCard.childIndex);
            }
            else
            {
                selectedCard.transform.SetSiblingIndex(GetDummyCard().transform.GetSiblingIndex());
                GetDummyCard().transform.SetParent(ParentHolder.transform);
            }
            selectedCard = null;
        }
        
    }
    void CheckWithNextCard()
    {
        if (nextCard != null)
        {
            if (selectedCard.transform.position.x > nextCard.transform.position.x)
            {
                int index = nextCard.transform.GetSiblingIndex();
                nextCard.transform.SetSiblingIndex(dummyobj.transform.GetSiblingIndex());
                dummyobj.transform.SetSiblingIndex(index);
                previusCard = nextCard;
                if(index + 1 < childCount)
                {
                    nextCard = PlayerArea.transform.GetChild(index + 1).GetComponent<cardView>();
                }
                else
                {
                    nextCard = null;
                }
            }
        }
    }
    void CheckWithPreviousCard()
    {
        if (previusCard != null)
        {
            if (selectedCard.transform.position.x < previusCard.transform.position.x)
            {
                int index = previusCard.transform.GetSiblingIndex();
                previusCard.transform.SetSiblingIndex(dummyobj.transform.GetSiblingIndex());
                dummyobj.transform.SetSiblingIndex(index);
                nextCard = previusCard;
                if (index + 1 >=0)
                {
                    previusCard = PlayerArea.transform.GetChild(index - 1).GetComponent<cardView>();
                }
                else
                {
                    previusCard = null;
                }
            }
        }

    }
    void SpawnCard()
    {
        GameObject card = Instantiate(CardPref);
        card.name = "card" + k;
        card.transform.SetParent(PlayerArea.transform);
        card.GetComponent<cardView>().SetImg(cardSprits[k]);
    }
    GameObject GetDummyCard()
    {
        if (dummyobj != null)
        {
            if(dummyobj.transform.parent!= PlayerArea.transform)
            {
                dummyobj.transform.SetParent(PlayerArea.transform);
            }
            return dummyobj;
        }
        else
        {
            dummyobj = Instantiate(DummyCard);
            dummyobj.name = "dummyCard";
            dummyobj.transform.SetParent(PlayerArea.transform);
        }
        return dummyobj;
    }
}
