using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SE_Controller : MonoBehaviour
{
    public AudioSource audio;

    public AudioClip ability, phase, life_break, draw, stand, hirou,click;
    // Start is called before the first frame update
    void Start()
    {
        Ability_SE();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            audio.PlayOneShot(click);
        }
    }

    public void Ability_SE()
    {
        audio.PlayOneShot(ability);
    }
    public void phase_SE()
    {
        audio.PlayOneShot(phase);
    }

    public void life_break_SE()
    {
        audio.PlayOneShot(life_break);
    }

    public void draw_SE()
    {
        audio.PlayOneShot(draw);
    }
    public void stand_SE()
    {
        audio.PlayOneShot(stand);
    }

    public void hirou_SE()
    {
        audio.PlayOneShot(hirou);
    }
    public void click_SE()
    {
        audio.PlayOneShot(click);
    }


}
