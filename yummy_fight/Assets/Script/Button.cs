using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameDirecter _directer;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Push()
    {
        _directer.NextPhase();
    }

    public void Select()
    {

    }
}
