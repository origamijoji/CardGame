using UnityEngine;


// This script is for ease of creating new cards.

[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class ScriptableCard : ScriptableObject
{
    public new string name;
    public string description;
    public Sprite art;
    public int manaCost;
    public int health;
    public int attack;
    public bool isKingpin;
    public bool isFeint;
    public bool isQuick;
    public bool isLethal;
    public bool isDualWield;
}
