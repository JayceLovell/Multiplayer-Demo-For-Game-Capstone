﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    private AudioSource _musicPlayer;
    [SerializeField]
    private string _songName;
    private UiManager _uiManager;


    public List<AudioClip> Music= new List<AudioClip>();
    public string SongName { 
        get { return _songName; } 
        set { _songName = value; }
    }
   
    // Start is called before the first frame update
    void Start()
    { 
        _musicPlayer = GetComponent<AudioSource>();
        _uiManager = GameObject.Find("UI Manager").GetComponent<UiManager>();
        
        string[] assetNames = AssetDatabase.FindAssets("full", new[] { "Assets/Music" });
        Music.Clear();
        foreach(string Asset in assetNames)
        {
            string path = AssetDatabase.GUIDToAssetPath(Asset);
            AudioClip clip = AssetDatabase.LoadAssetAtPath<AudioClip>(path);
            Music.Add(clip);
        }
    }
    /// <summary>
    /// Grabs song randomly from Music List.
    /// With the use of substring gets the name of the song before the first - in the file name
    /// </summary>
    public void Play()
    {
        int index = Random.Range(0, Music.Count);
        SongName = Music[index].ToString();
        int dash = SongName.IndexOf("-");
        SongName = SongName.Substring(0, dash);

        _musicPlayer.clip = Music[index];
        _musicPlayer.Play();
        _musicPlayer.loop = true;

        _uiManager.IsSongPlaying = true;
        StartCoroutine(PlayForSeconds(30));
    }
    /// <summary>
    /// Stops playing music
    /// </summary>
    public void Stop()
    {
        _musicPlayer.Stop();
        _uiManager.IsSongPlaying = false;
    }
    /// <summary>
    /// stops music after playing for amount of time in seconds
    /// </summary>
    /// <param name="Seconds">time in seconds</param>
    /// <returns></returns>
    private IEnumerator PlayForSeconds(float Seconds)
    {
        yield return new WaitForSeconds(Seconds);
        Stop();
    }
}
