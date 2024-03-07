using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchArea : MonoBehaviour
{
    public GameObject[] image;
    [SerializeField]
    private GameObject scroll;
    // Start is called before the first frame update
    void Start()
    {
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
}
