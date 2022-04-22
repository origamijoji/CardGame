using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _statsText;

    private void SetText()
    {
        if (Player.LocalPlayer != null)
        {
            _statsText.text = "Health: " + Player.LocalPlayer.Health.ToString() +"\n" + "Mana: " + Player.LocalPlayer.Mana + "/" + Player.LocalPlayer.MaxMana;
        }
    }

    private void Update()
    {
        SetText();
    }
}
