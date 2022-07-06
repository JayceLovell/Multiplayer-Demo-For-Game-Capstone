﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    private AudioSource _musicPlayer;
    [SerializeField]
    private string _songName;


    public List<AudioClip> Music= new List<AudioClip>();
    public string SongName { 
        get { return _songName; } 
        set { _songName = value; }
    }
   
    // Start is called before the first frame update
    void Start()
    {
        _musicPlayer = GetComponent<AudioSource>();
        
        string[] assetNames = AssetDatabase.FindAssets("full", new[] { "Assets/Music" });
        Music.Clear();
        foreach(string Asset in assetNames)
        {
            string path = AssetDatabase.GUIDToAssetPath(Asset);
            AudioClip clip = AssetDatabase.LoadAssetAtPath<AudioClip>(path);
            Music.Add(clip);
        }
    }
    public void Play()
    {
        int index = Random.Range(0, Music.Count);
        SongName = Music[index].ToString();
        int dash = SongName.IndexOf("-");
        SongName = SongName.Substring(0, dash);

        _musicPlayer.clip = Music[index];
        _musicPlayer.Play();
    }
}