using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchArea : MonoBehaviour
{
    public GameObject[] image;
    [SerializeField]
    private GameObject scroll;
    public GameManager manage;
    // Start is called before the first frame update
    void Start()
    {
        manage = GameObject.Find("GameManager").GetComponent<GameManager>();
        //scroll.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreatePrefab(int id)
    {
        Instantiate(image[id-1], this.transform);
    }

    public void CreatePrefab_plan(int id)
    {
        int cardID;
        if (manage.deck[id] > 200)
        {
            cardID = manage.deck[id] - 192;
        }
        else
        {
            cardID = manage.deck[id];
        }

        Instantiate(image[cardID -1 ], this.transform);
    }
}
