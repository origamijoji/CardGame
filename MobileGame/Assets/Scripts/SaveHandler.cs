using System.IO;
using UnityEngine;

public class SaveHandler : MonoBehaviour
{

    private void Awake() {
        Load();
    }

    private void OnApplicationQuit() {
        Save();
    }

    public void Save() {
        string playerSaveData = JsonUtility.ToJson(new PlayerData());
        File.WriteAllText(Application.dataPath + "/playerData.json", playerSaveData);
    }

    public void Load() {
        string loadedSaveData = File.ReadAllText(Application.dataPath + "/playerData.json");
        PlayerData playerData = JsonUtility.FromJson<PlayerData>(loadedSaveData);
        playerData.LoadData();
    }

    private class PlayerData {
        [SerializeField] private bool valid;
        [SerializeField] private int funny;

        public PlayerData() {
            valid = false;
            funny = 40;
            //import data to class
        }

        public void LoadData() {
            //load data into current session
        }


    }

}