using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpDelay: MonoBehaviour
{
    public GameObject PopUpPrefab;

    public void Popup(StripValues stripValueScript)
    {
        PopUpPrefab.SetActive(true);
        PopUpPrefab.GetComponent<DelayPopUpScript>().StripValues = stripValueScript;
    }
}
