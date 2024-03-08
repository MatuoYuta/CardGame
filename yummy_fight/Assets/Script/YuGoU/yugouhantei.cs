using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class yugouhantei : MonoBehaviour
{
    public GameManager manage_script;
    public GameDirecter directer;
    public GameObject popup;
    public Transform playerField;

    public Bagamu bagam;
    // Start is called before the first frame update
    void Start()
    {
        manage_script = GameObject.Find("GameManager").GetComponent<GameManager>();
        directer = GameObject.Find("GameDirecter").GetComponent<GameDirecter>();
        bagam = GameObject.Find("bagamute").GetComponent<Bagamu>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

  
}
