using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StripValues : MonoBehaviour
{
    private string _stripName;
    private int _stripIndex;
    private float _reverb;
    private float _delay;
    private float _pan;
    private float _EQ;
    private float _volume;

    public GameObject TitleBox;
    public string StripName
    {
        get { return _stripName; }
        set { 
            _stripName = value;
            TitleBox.GetComponent<Text>().text = StripName;
        }
    }
    public int StripIndex
    {
        get { return _stripIndex; }
        set { _stripIndex = value;}
          
    }
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
    void Start()
    {
        Reverb = 0;
        Delay = 0;
        Pan = 0;
        EQ = 0;
        Volume = 0;
    }
}
