using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Player : Entity
{
    [SerializeField] private PlayerDeck _deck;
    public PlayerDeck GetDeck() => _deck;
    public static Player LocalPlayer { get; private set; }
    public static Player EnemyPlayer { get; private set; }
    public void SetEnemy(Player enemy) => EnemyPlayer = enemy;
    [field: SerializeField] public int PlayerNum { get; private set; }
    public GameObject enemyPlayer;
    [field: SerializeField] public bool IsTurn { get; set; }

    public int MaxMana
    {
        get { return Mathf.Min(CurrentMaxMana, _totalMaxMana); }
    }
    [SyncVar] public int CardsHeld;

    [SyncVar(hook = nameof(UpdateUI))] public int Mana;
    [Command] private void RemoveMana(int value) => Mana -= value;
    [Command] private void AddMana(int value) => Mana += value;
    [Command] private void SetMana(int value) => Mana = value;
    [SyncVar(hook = nameof(UpdateUI))] public int CurrentMaxMana;
    [Command] private void AddCurrentMaxMana(int value) => CurrentMaxMana += value;
    private int _totalMaxMana = 10;

    public override void OnDeath()
    {
        // opposing player wins !
    }

    public override void OnStartLocalPlayer()
    {
        LocalPlayer = this;
        PlayerNum = (int)netId;
        gameObject.transform.SetParent(ReferenceManager.Instance.PlayerSpawn);
        gameObject.transform.localPosition = Vector3.zero;
        gameObject.transform.localScale = NetworkManager.singleton.playerPrefab.transform.localScale;
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject player in players)
        {
            if (isServer) { break; }
            Debug.Log(player.name);
            Player playerPlayer = player.GetComponent<Player>();
            if (playerPlayer.PlayerNum == 0)
            {
                SetEnemy(playerPlayer);
                playerPlayer.ThisTarget = Targets.EnemyChampion;
                player.transform.SetParent(ReferenceManager.Instance.OpponentSpawn);
                player.transform.localPosition = Vector3.zero;
                player.transform.localScale = NetworkManager.singleton.playerPrefab.transform.localScale;
            }
        }
        CmdResetValues();
        _deck.Shuffle();
        StartCoroutine(DrawStartCards(3));
    }

    [Command]
    public void CmdResetValues()
    {
        CurrentMaxMana = 1;
        Mana = 1;
        MaxHealth = 30;
        Health = 30;
    }

    IEnumerator DrawStartCards(int amount)
    {
        for (int i = amount; i > 0; i--)
        {
            yield return new WaitForSeconds(0.25f);
            _deck.DrawCard();
        }
    }

    public void PlayMinion(int cardID, int cost)
    {
        if (IsTurn)
        {
            DoEffect(cardID, CardType.Minion);
            GameManager.Instance.SpawnCard(cardID, PlayerNum);
            RemoveMana(cost);
        }
    }
    public void PlaySpell(int cardID, int cost)
    {
        DoEffect(cardID, CardType.Spell);
        RemoveMana(cost);
    }


    public void DoEffect(int CardID, CardType type)
    {
        List<Ability> abilityList = new List<Ability>();
        List<Entity> targetsList = new List<Entity>();

        if (type == CardType.Minion)
        {
            var thisMinion = CardList.GetMinion(CardID);
            if (thisMinion.hasOnPlaceAbility)
            {
                abilityList = thisMinion.OnPlaceAbility;
            }
            else if(thisMinion.hasOnDeathEffect)
            {
                abilityList = thisMinion.onDeathAbility;
            }
        }
        else
        {
            abilityList = CardList.GetSpell(CardID).OnPlaceAbility;
        }


        foreach (Ability ability in abilityList)
        {
            Debug.Log(ability);
            foreach (Targets target in ability.targets)
            {
                if (target == Targets.EnemyChampion)
                {
                    targetsList.Add(EnemyPlayer);
                }
                if (target == Targets.EnemyMinions)
                {
                    foreach (Transform child in ReferenceManager.Instance.EnemyField.transform)
                    {
                        targetsList.Add(child.GetComponent<Entity>());
                    }
                }
                if (target == Targets.PlayerMinions)
                {
                    foreach (Transform child in ReferenceManager.Instance.PlayerField.transform)
                    {
                        targetsList.Add(child.GetComponent<Entity>());
                    }
                }
            }

            if (ability.scriptableAbility is HealAbility heal)
            {
                foreach (Entity entity in targetsList)
                {
                    entity.HealHealth(heal.heal);
                    entity.TakeDamage(heal.damage);
                }
            }
            else if (ability.scriptableAbility is BuffAbility buff)
            {
                foreach (Entity entity in targetsList)
                {
                    entity.BuffDamage(buff.strength);
                    entity.BuffHealth(buff.health);
                }
            }
            else if (ability.scriptableAbility is DrawAbility draw)
            {
                _deck.DrawCard(draw.draw);
            }
        }
        EntitySubject.Notify();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            _deck.DrawCard();
        }
    }

    public void StartRound()
    {
        AddCurrentMaxMana(1);
        if(isClientOnly) { CurrentMaxMana++; }
        SetMana(MaxMana);
        _deck.DrawCard();
        ResetBoard();
    }

    private void ResetBoard()
    {
        foreach (Transform child in ReferenceManager.Instance.PlayerField.transform)
        {
            child.GetComponent<FieldCard>().ResetEntity();
        }
        EntitySubject.Notify();
    }

    public void UpdateUI(int oldVar, int newVar)
    {
        EntitySubject.Notify();
    }



    [Command]
    public void DecreaseHealth(int health)
    {
        Health -= health;
    }
}
