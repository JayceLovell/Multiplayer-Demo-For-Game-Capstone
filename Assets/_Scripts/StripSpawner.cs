using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StripSpawner : MonoBehaviour
{
    public GameObject Prefab;

    //Preset for now
    //Vocal,Choir,Sample,Kick,Tops
    public List<string> Titles;

    // Start is called before the first frame update
    void Start()
    {
        foreach(string title in Titles)
        {
            GameObject Strip = Instantiate(Prefab, this.transform);
            Strip.GetComponent<StripValues>().StripName = title;
        }
    }

}
