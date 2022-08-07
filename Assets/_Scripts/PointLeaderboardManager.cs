using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointLeaderboardManager : MonoBehaviour
{
    public List<GameObject> Children = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform child in this.transform)
        {
            Children.Add(child.gameObject);
        }
    }
    /// <summary>
    /// Call this when new player joins
    /// should be called with firebase networking
    /// </summary>
    public void RefreshBoard()
    {
        Children.Clear();
        foreach (Transform child in this.transform)
        {
            Children.Add(child.gameObject);
        }
    }
    /// <summary>
    /// TODO #2925127468
    /// rearrange the boarderboard based on the player points
    /// </summary>
    public void LeaderBoardCheck()
    {
        Children.Sort(CompareScores);
        Children.Reverse();
        
        foreach (GameObject child in Children)
        {
            child.transform.parent = null;
            child.transform.parent = this.transform;
        }

        ////To set the poisition of the player points object
        //Children[0].transform.SetSiblingIndex(position);
    }
    private int CompareScores(GameObject p1, GameObject p2)
    {
        return p1.GetComponent<PlayerPoints>().Points.CompareTo(p2.GetComponent<PlayerPoints>().Points);
    }
}
