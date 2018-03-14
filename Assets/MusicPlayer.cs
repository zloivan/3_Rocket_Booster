using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {

    // Use this for initialization
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
}
