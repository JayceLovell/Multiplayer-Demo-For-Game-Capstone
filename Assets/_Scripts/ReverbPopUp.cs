using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReverbPopUp : MonoBehaviour
{
    [SerializeField]
    private StripValues _stripValues;
    [SerializeField]
    private float _value;

    public StripValues StripValues
    {
        get { return _stripValues; }
        set { _stripValues = value; }
    }
    public float Value
    {
        get { return _value; }
        set { 
            _value = value;
            StripValues.Reverb = _value;
        }
    }
    public void Exit()
    {
        this.gameObject.SetActive(false);
    }
}
