using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DrawCard : MonoBehaviour
{
    public static DrawCard instance;
   // public GameObject PlayerArea, EnemyArea, Card1, Card2;
    [SerializeField]
    private List<GameObject> cardImag;
   
    [SerializeField]
    private GameObject PlayerArea,EnemyArea, Card2, Card1, ParentHolder, JokerHolader, JokerCard;
    //private int k;

   private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
   /* private void Start()
    {
        cardImag.Add(Card1);
        cardImag.Add(Card2);
        cardImag.Add(JokerCard);
    }*/
    void SpawnCard()
    {
        for (int i = 0; i < 13; i++)
        {
            GameObject PlayerCard = Instantiate(cardImag[Random.Range(0, cardImag.Count)], new Vector3(0, 0, 0), Quaternion.identity);
            //PlayerCard.name = "card" + k;
            PlayerCard.transform.SetParent(PlayerArea.transform, false);

            GameObject EnemyCard = Instantiate(cardImag[Random.Range(0, cardImag.Count)], new Vector3(0, 0, 0), Quaternion.identity);
            EnemyCard.transform.SetParent(EnemyArea.transform, false);

        }
        GameObject joker = Instantiate(cardImag[Random.Range(0, cardImag.Count)], new Vector3(0, 0, 0), Quaternion.identity);
        joker.transform.SetParent(JokerHolader.transform, false);
        /* GameObject card = Instantiate(cardSprits[Random.Range(0, cardSprits.Count)], new Vector3(0, 0, 0), Quaternion.identity);
         card.name = "card" + k;
         card.transform.SetParent(PlayerArea.transform);
         card.GetComponent<cardView>().SetImg(cardSprits[k]);*/
       
        /*GameObject card = Instantiate(Card1);
        card.name = "card" + k;
        card.transform.SetParent(PlayerArea.transform);
        card.GetComponent<cardView>().SetImg(cardSprits[k]);*/
    }
    public void OnClick()
    {
        {
            SpawnCard();
        }
    }
    public void Reset()
    {
        SceneManager.LoadScene("play Zone");
    }


}
