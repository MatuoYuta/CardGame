using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameDirecter directer_script;
    void Start()
    {
        directer_script = GameObject.Find("GameDirecter").GetComponent<GameDirecter>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Push()
    {
        directer_script.NextPhase();
    }
}
