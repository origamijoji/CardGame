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
    [SyncVar(hook = nameof(OnRoundChange))] public bool IsFirstHalf;

    public void OnRoundChange(bool oldFirstHalf, bool newFirstHalf)
    {
        if(isServer && newFirstHalf == true)
        {
            Player.LocalPlayer.StartRound();
        }
        else if(isClientOnly && newFirstHalf == false)
        {
            Player.LocalPlayer.StartRound();
        }
    }

    [Command(requiresAuthority = false)] 
    public void CmdEndTurn()
    {
        if(IsFirstHalf)
        {
            IsFirstHalf = false;
        }
        else
        {
            RoundNumber++;
            IsFirstHalf = true;
        }
    }

    [Command(requiresAuthority = false)]
    public void SpawnCard(int cardID, int playerNum)
    {
        var newCardPrefab = NetworkManager.singleton.spawnPrefabs.Find(prefab => prefab.name == "Field Card");
        var newCard = Instantiate(newCardPrefab);
        NetworkServer.Spawn(newCard);

        SetCardStats(newCard, playerNum, cardID);

    }
    [ClientRpc]
    public void SetCardStats(GameObject newCard, int playerNum, int cardID)
    {
        var newCardPrefab = NetworkManager.singleton.spawnPrefabs.Find(prefab => prefab.name == "Field Card");
        var newFieldCard = newCard.GetComponent<FieldCard>();
        newFieldCard.SetCard(cardID);
        //newCard.GetComponent<FieldCard>().CanAttack = true; // DEBUG **********
        if (Player.LocalPlayer.PlayerNum == playerNum)
        {
            newCard.transform.SetParent(ReferenceManager.Instance.PlayerField.transform);
            newCard.GetComponent<FieldCard>().ThisTarget = Targets.PlayerMinions;
        }
        else
        {
            newCard.transform.SetParent(ReferenceManager.Instance.EnemyField.transform);
            newCard.GetComponent<FieldCard>().ThisTarget = Targets.EnemyMinions;
            Destroy(newCard.GetComponent<CardPreview>());
        }

        newCard.transform.localScale = newCardPrefab.transform.localScale;

        EntitySubject.Notify();
    }

    [Command(requiresAuthority = false)]
    public void CmdAttackEntity(Entity attacker, Entity target)
    {
        if(attacker.IsLethal)
        {
            target.TakeDamage(999);
        }
        else
        {
            target.TakeDamage(attacker.Damage);
        }
        if(target.IsLethal)
        {
            attacker.TakeDamage(999);
        }
        else
        {
            attacker.TakeDamage(target.Damage);
        }
    }
    public override void OnStartServer()
    {
        IsFirstHalf = true;
        RoundNumber = 1;
    }
}
