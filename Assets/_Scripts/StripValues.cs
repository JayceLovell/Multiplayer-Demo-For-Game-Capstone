using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StripValues : MonoBehaviour
{
    public string StripName;
    private float _reverb;
    private float _delay;
    private float _pan;
    private float _EQ;
    private float _volume;

    public GameObject TitleBox;
    public float Reverb
    {
        get { return _reverb; }
        set { _reverb = value; }
    }
    public float Delay
    {
        get { return _delay; }
        set { _delay = value; }
    }
    public float Pan
    {
        get { return _pan; }
        set { _pan = value; }
    }
    public float EQ
    {
      get { return _EQ; }
      set {_EQ = value;}
    }
    public float Volume
    {
        get { return _volume; }
        set { _volume = value; }
    }


    // Start is called before the first frame update
    void Start()
    {
        TitleBox.GetComponent<Text>().text = StripName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
