using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _startPlatform;
    [SerializeField] private GameObject _endPlatform;
    [SerializeField] List<GameObject> _platformList = new List<GameObject>();
    private int _numberOfPlatforms;
    private int _previousPlatform;

    public void GenerateLevel(int levelLength) {
        _numberOfPlatforms = _platformList.Count;
        Debug.Log(_numberOfPlatforms);
        Stack<GameObject> currentLevel = new Stack<GameObject>();
        currentLevel.Push(_startPlatform);

        Debug.Log("Generating Platforms");
        for (int platformsRemaining = levelLength; platformsRemaining > 0; platformsRemaining--) {
            var newPlatform = Instantiate(_platformList[GetPlatform()]);
            newPlatform.transform.position = currentLevel.Peek().transform.GetChild(0).transform.position;
            currentLevel.Push(newPlatform);
        }
        Debug.Log("Adding Final Platform");
        var endPlatform = Instantiate(_endPlatform);
        endPlatform.transform.position = currentLevel.Peek().transform.GetChild(0).transform.position;
    }

    private int GetPlatform() {
        var randomNumber = Random.Range(0, _numberOfPlatforms);
        if (randomNumber != _previousPlatform) {
            _previousPlatform = randomNumber;
            return randomNumber;
        }
        GetPlatform();
        return 0;
    }
}
