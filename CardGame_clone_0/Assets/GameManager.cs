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
            newCard.GetComponent<FieldCard>().IsLocal = true;
        }
        else
        {
            newCard.transform.SetParent(ReferenceManager.Instance.EnemyField.transform);
            newCard.GetComponent<FieldCard>().IsLocal = false;
        }

        newCard.transform.localScale = newCardPrefab.transform.localScale;
    }

    [Command(requiresAuthority = false)]
    public void CmdAttackEntity(Entity attacker, Entity target)
    {
        target.TakeDamage(attacker.Damage);
        attacker.TakeDamage(target.Damage);
    }
    [ClientRpc]
    public void RPCDoDamage(Entity attacker, Entity target)
    {

    }
}
