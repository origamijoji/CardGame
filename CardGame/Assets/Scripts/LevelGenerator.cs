using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour {
    [SerializeField] private GameObject _startPlatform;
    [SerializeField] private GameObject _endPlatform;
    [SerializeField] List<GameObject> _platformList = new List<GameObject>();
    Stack<GameObject> currentLevel = new Stack<GameObject>();
    private int _numberOfPlatforms;
    private int _previousPlatform;

    public void GenerateLevel(int levelLength) {
        _numberOfPlatforms = _platformList.Count;
        var startPlatform = Instantiate(_startPlatform);
        startPlatform.transform.position = Vector3.zero;
        startPlatform.transform.rotation = Quaternion.identity;

        currentLevel.Push(startPlatform);

        Debug.Log("Generating Platforms");
        for (int platformsRemaining = levelLength; platformsRemaining > 0; platformsRemaining--) {
            var newPlatform = Instantiate(_platformList[GetPlatform()]);
            newPlatform.transform.position = currentLevel.Peek().transform.GetChild(0).GetChild(0).position;
            currentLevel.Push(newPlatform);
        }
        Debug.Log("Adding Final Platform");
        var endPlatform = Instantiate(_endPlatform);
        endPlatform.transform.position = currentLevel.Peek().transform.GetChild(0).GetChild(0).position;
        currentLevel.Push(endPlatform);
    }

    public void DegenerateLevel() {
        foreach (GameObject platform in currentLevel) {
            Destroy(platform);
        }
        currentLevel.Clear();
    }

    private int GetPlatform() {
        var randomNumber = Random.Range(0, _numberOfPlatforms);
        if (randomNumber != _previousPlatform) {
            _previousPlatform = randomNumber;
            return randomNumber;
        }
        return GetPlatform();
    }
}
