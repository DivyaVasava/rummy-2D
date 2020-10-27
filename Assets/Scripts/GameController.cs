
using System.Collections;
using System.Collections.Generic;
//using System.Runtime.Hosting;
//using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject Cards;
    public Transform tf_BoxCard;
    public Transform[] arr_Tf_Player, arr_Tf_AI;
    public List<GameObject> listCard = new List<GameObject>();
    void Start()
    {
        InstanceCard();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void InstanceCard()
    {
        for(int i = 0; i < SpritGame.instance.arr_Sp_cards.Length; i++)
        {
            GameObject _card = Instantiate(Cards, tf_BoxCard.position, Quaternion.identity);
            _card.transform.SetParent(tf_BoxCard, true);
            _card.GetComponent<UICards>().img_Cards.sprite = SpritGame.instance.arr_Sp_cards[i];
            listCard.Add(_card);
        }
        StartCoroutine (SplitCards());
    }
    IEnumerator SplitCards()
    {
        
        for(int i = 0; i < 13; i++)
        {
            yield return new WaitForSeconds(0.5f);
            int rdPlayer = Random.Range(0, listCard.Count);
            listCard[rdPlayer].transform.SetParent(arr_Tf_Player[i], true);
           
            iTween.MoveTo(listCard[rdPlayer],
                iTween.Hash("position", arr_Tf_Player[i].position, "easeType", "Linear", "loopType", "none", "time", 0.4f));
            
            iTween.RotateBy(listCard[rdPlayer],
                iTween.Hash("y", 0.15f, "easeType", "Linear", "loopType", "none", "time", 0.4f));
            yield return new WaitForSeconds(0.25f);
            listCard[rdPlayer].GetComponent<UICards>().gob_FrontCard.SetActive(false);
            listCard.RemoveAt(rdPlayer);
            

            yield return new WaitForSeconds(0.5f);
            int rdAI = Random.Range(0, listCard.Count);
            listCard[rdAI].transform.SetParent(arr_Tf_AI[i], true);
            
            iTween.MoveTo(listCard[rdAI],
                iTween.Hash("position", arr_Tf_AI[i].position, "easeType", "Linear", "loopType", "none", "time", 0.4f));
            
            iTween.RotateBy(listCard[rdAI],
                iTween.Hash("y", 0.15f, "easeType", "Linear", "loopType", "none", "time", 0.4f));
            yield return new WaitForSeconds(0.25f);
            listCard[rdAI].GetComponent<UICards>().gob_FrontCard.SetActive(false);
            listCard.RemoveAt(rdAI);

        }
      
    }
    public void Reset()
    {
        SceneManager.LoadScene("playzone1");
    }
}
