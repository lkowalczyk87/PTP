using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    // ENCAPSULATION
    public static StateManager Instance { get; private set; }

    public int playerType { get; private set; }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    public void SetPlayer(int newPlayerType)
    {
        if (newPlayerType < 0 || newPlayerType > 1) return;
        Instance.playerType = newPlayerType;
    }
}
