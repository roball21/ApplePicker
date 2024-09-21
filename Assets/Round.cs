using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Round : MonoBehaviour
{
    public Text Rounds;
    private int currentRound = 1;

    void Start()
    {
        UpdateRound();
    }

    public void NextRound()
    {
        currentRound++;
        UpdateRound();
    }

    void UpdateRound()
    {
        Rounds.text = "Round: " + currentRound;
    }
}
