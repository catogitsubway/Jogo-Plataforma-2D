using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public int totalScore;
    public GameObject text;

    public static GameController instance;

    void Start()
    {
        instance = this;
    }

}
