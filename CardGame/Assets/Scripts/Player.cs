using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Player : Entity
{
    [SerializeField] private PlayerDeck _deck;
    public PlayerDeck GetDeck() => _deck;
    public static Player LocalPlayer { get; private set; }
    [field: SerializeField] public int PlayerNum { get; private set; }
    public GameObject enemyPlayer;


    public int MaxMana
    {
        get { return Mathf.Min(CurrentMaxMana, _totalMaxMana); }
    }
    [SyncVar(hook = nameof(EditOpponentCards))] public int CardsHeld;
    [SyncVar] public int Mana;
    [Command] private void RemoveMana(int value) => Mana -= value;
    [Command] private void AddMana(int value) => Mana += value;
    [SyncVar] public int CurrentMaxMana;
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
        CmdResetValues();
    }

    [Command]
    public void CmdResetValues()
    {
        Mana = 100;
        CurrentMaxMana = 1;
        MaxHealth = 30;
        Health = 30;
    }

    public void EditOpponentCards(int oldValue, int newValue)
    {
    }

    public void PlayMinion(int cardID, int cost)
    {
        DoEffect(cardID, CardType.Minion);
        GameManager.Instance.SpawnCard(cardID, PlayerNum);
        RemoveMana(cost);
    }
    public void PlaySpell(int cardID, int cost)
    {
        DoEffect(cardID, CardType.Spell);
    }


    public void DoEffect(int CardID, CardType type)
    {
        List<Ability> abilityList;
        List<Entity> targets;

        if (type == CardType.Minion)
        {
            var thisMinion = CardList.GetMinion(CardID);
            if (!thisMinion.hasOnPlaceAbility) { return; }
            abilityList = thisMinion.OnPlaceAbility;
        }
        else
        {
            abilityList = CardList.GetSpell(CardID).OnPlaceAbility;
        }


        foreach (Ability ability in abilityList)
        {
            Debug.Log("CASTING ABILITY");
            if (ability.scriptableAbility is HealAbility heal)
            {
                foreach (Targets target in heal.targets)
                {
                    if (target == Targets.PlayerMinions)
                    {
                        foreach (Transform child in ReferenceManager.Instance.PlayerField.transform)
                        {
                            child.GetComponent<FieldCard>().HealHealth(heal.heal);
                        }
                    }
                }
            }
            else if (ability.scriptableAbility is BuffAbility buff)
            {

            }
            else if (ability.scriptableAbility is DrawAbility draw)
            {
                _deck.DrawCard(draw.draw);
            }
        }
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            _deck.DrawCard();
        }
    }


    [Command]
    public void DecreaseHealth(int health)
    {
        Health -= health;
    }
}
