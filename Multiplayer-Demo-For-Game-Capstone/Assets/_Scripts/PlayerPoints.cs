﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class PlayerPoints : NetworkBehaviour
{
    /// <summary>
    /// text box to display username and points
    /// </summary>
    [SerializeField]
    private Text _displayPoints;

    private GameManager _gameManager;

    private int _points;

    public int Points
    {
        get { return _points; }
        set { _points = value; }
    }


    // Start is called before the first frame update
    void Start()
    {
        _displayPoints = GetComponent<Text>();
        _gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        Points = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //if (!isLocalPlayer)
        //{
        //    return;
        //}
        _displayPoints.text = _gameManager.UserID + ":" + Points;
    }
}
