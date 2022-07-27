using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ChangeValue : MonoBehaviour
{
    public TextMeshProUGUI dBValue;
    public GameObject Slider;
    public float currentVol;

    public void Start()
    {
        dBValue = GetComponent<TextMeshProUGUI>();
        dBValue.color = new Color(255, 255, 255, 0);
    }

    public void Update()
    {
        currentVol = Slider.GetComponent<Slider>().value;
        dBValue.text = currentVol.ToString("f2") + " dB";
        dBValue.color = new Color(255, 255, 255, 255);
    }
}
