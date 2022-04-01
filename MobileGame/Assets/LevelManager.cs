using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    [SerializeField] private LevelGenerator _levelGenerator;
    [SerializeField] private float _speed;
    [SerializeField] private int _levelLength;
    [SerializeField] private float _obstacleWeight;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.F1)) {
            _levelGenerator.DegenerateLevel();
        }
        if (Input.GetKeyDown(KeyCode.F2)) {
            _levelGenerator.GenerateLevel(_levelLength);
        }
        if (Input.GetKeyDown(KeyCode.F3)) {
            _levelGenerator.DegenerateLevel();
            _levelGenerator.GenerateLevel(_levelLength);
        }
    }

    private void Awake() {
        SceneManager.sceneLoaded += OnLoad;
    }
    private void OnLoad(Scene scene, LoadSceneMode mode) {
        _levelGenerator.GenerateLevel(_levelLength);
        Debug.Log(scene.buildIndex);
    }


}
