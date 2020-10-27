using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cardsfromcardholder : MonoBehaviour
{
    public static Cardsfromcardholder instance;
    [SerializeField]
    private List<GameObject> cardImag;

    [SerializeField]
    private GameObject CardHolder, Card;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    public void OnClick()
    {
        GameObject card = Instantiate(cardImag[Random.Range(0, cardImag.Count)], new Vector3(0, 0, 0), Quaternion.identity);
        card.transform.SetParent(CardHolder.transform, false);
    }
}
