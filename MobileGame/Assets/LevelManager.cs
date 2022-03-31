using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class LevelManager : MonoBehaviour {
    private static LevelManager _instance;
    public static LevelManager Instance {
        get {
            if (_instance == null) {
                _instance = FindObjectOfType<LevelManager>();
            }
            return _instance;
        }
    }

    private float _speed;
    private float _levelLength;
    private float _obstacleWeight;


}
