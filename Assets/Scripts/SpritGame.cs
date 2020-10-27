using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpritGame : MonoBehaviour
{
    public static SpritGame instance;
    public Sprite[] arr_Sp_cards;
    // Start is called before the first frame update
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            DestroyImmediate(gameObject);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
