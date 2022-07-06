using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

/// <summary>
/// This script is for any UI navigation
/// WARNING THIS IS STILL UNDER CONSTRUCTION NOT FINAL SCRIPT
/// </summary>
public class UiManager : MonoBehaviour
{
    private AccuracyBattleManager _accuacyBattleManager;
    private MusicPlayer _musicPlayer;
    private GameManager _gameManager;
    private NetworkManager networkmanager;

    public GameObject DisplaySong;
    /// <summary>
    /// is Called before Start
    /// </summary>
    void Awake()
    {
        _accuacyBattleManager = GameObject.Find("AccuracyBattleManager").GetComponent<AccuracyBattleManager>();
        _musicPlayer = GameObject.Find("Music Player").GetComponent<MusicPlayer>();
        networkmanager = GameObject.Find("NetworkManager").GetComponent<NetworkManager>();
        _gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void Ready()
    {
        _accuacyBattleManager.GameStart();
        DisplaySong.GetComponent<Text>().text = _musicPlayer.SongName;
    }
    public void Exit()
    {
        if (_gameManager.Status == "Hosting")
        {
            networkmanager.StopHost();
            Debug.Log("Ending Host");
        }
        else
        {
            networkmanager.StopClient();
            Debug.Log("Ending Client");
        }
    }
}
