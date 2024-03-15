using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EX_Card_Ability : MonoBehaviour
{
    public GameDirecter directer_script;
    public GameObject select_area;
    public SearchArea search_script;
    public GameManager _manage;
    public GameObject scroll_view;
    public Animator panel_anim, kouka;
    // Start is called before the first frame update
    void Start()
    {
        search_script = GameObject.Find("Content").GetComponent<SearchArea>();
        directer_script = GameObject.Find("GameDirecter").GetComponent<GameDirecter>();
        _manage = GameObject.Find("GameManager").GetComponent<GameManager>();
        scroll_view = GameObject.Find("Search_Area");
        panel_anim = scroll_view.GetComponent<Animator>();
        switch (this.GetComponent<CardView>().cardID)
        {
            case 101:
                Debug.Log("ÉoÉKÉÄÅ[Ég");
                StartCoroutine("Bagamute");
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Bagamute()
    {
        _manage.bagamute = true;
        yield return new WaitForSeconds(1);
        kouka.SetTrigger("Kouka");
        Debug.Log(directer_script.EnemyFieldCardList.Length);
        for (int i = 0; i < directer_script.EnemyFieldCardList.Length; i++)
        {
            Debug.Log(directer_script.EnemyFieldCardList[i].gameObject);
            directer_script.EnemyFieldCardList[i].gameObject.GetComponent<CardController>().Destroy_me();
        }

        for(int t = 0; t<directer_script.playerFieldCardList.Length;t++)
        {
            Debug.Log(directer_script.playerFieldCardList[t].gameObject);
            if (directer_script.playerFieldCardList[t].gameObject.GetComponent<CardView>().cardID != 101)
            {
                directer_script.playerFieldCardList[t].gameObject.GetComponent<CardController>().Destroy_me();
            }
        }
    }

    public IEnumerator Egumahu()

    {
        yield return new WaitForSeconds(0);
        kouka.SetTrigger("Kouka");
    }

    public IEnumerator Torebaga()
    {
        yield return new WaitForSeconds(0);
        kouka.SetTrigger("Kouka");

    }

    public IEnumerator Chibaga()
    {
        yield return new WaitForSeconds(0);
        kouka.SetTrigger("Kouka");
        _manage.chibaga = true;
        SelectCard();
    }

    public void SelectCard()
    {
        for (int i = 0; i < directer_script.SearchImageList.Length; i++)
        {
            Destroy(directer_script.SearchImageList[i].gameObject);
        }

        search_script.CreatePrefab_field();
        panel_anim.SetTrigger("Up");
        scroll_view.SetActive(true);
    }

}
