using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerUI : EntityObserver
{
    [SerializeField] private Player thisPlayer;
    [SerializeField] private TextMeshProUGUI _statsText;
    [SerializeField] private Image _bgImage;


    private void SetText()
    {
        _statsText.text = "Health: " + thisPlayer.Health.ToString() + "\n" 
            + "Mana: " + thisPlayer.Mana + "/" + thisPlayer.MaxMana;
        if (Player.LocalPlayer == thisPlayer) 
            _bgImage.color = Color.green;
        else 
            _bgImage.color = Color.green;
    }

    public override void OnNotification()
    {
        SetText();
    }
}
