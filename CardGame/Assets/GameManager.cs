using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class GameManager : NetworkBehaviour
{
    static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();
            }
            return _instance;
        }
    }
    [SyncVar] public int RoundNumber;

    [Command(requiresAuthority = false)]
    public void SpawnCard(int cardID, int playerNum)
    {
        Debug.Log("Card spawned");
        var newCardPrefab = NetworkManager.singleton.spawnPrefabs.Find(prefab => prefab.name == "Field Card");
        var newCard = Instantiate(newCardPrefab);
        NetworkServer.Spawn(newCard);
        SetCardStats(newCard, playerNum, cardID);
    }
    [ClientRpc]
    public void SetCardStats(GameObject newCard, int playerNum, int cardID)
    {
        var newCardPrefab = NetworkManager.singleton.spawnPrefabs.Find(prefab => prefab.name == "Field Card");
        newCard.GetComponent<FieldCard>().SetCard(cardID);
        Debug.Log(playerNum + " " + Player.LocalPlayer.PlayerNum);
        if (Player.LocalPlayer.PlayerNum == playerNum)
        {
            newCard.transform.SetParent(ReferenceManager.Instance.PlayerField.transform);
        }
        else
        {
            newCard.transform.SetParent(ReferenceManager.Instance.EnemyField.transform);
        }

        newCard.transform.localScale = newCardPrefab.transform.localScale;
    }
}
