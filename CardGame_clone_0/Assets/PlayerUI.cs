using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _manaText;
    [SerializeField] private TextMeshProUGUI _healthText;

    private void SetText()
    {
        if (Player.LocalPlayer != null)
        {
            //Debug.Log(Player.LocalPlayer.netId);
            //Debug.Log(Player.LocalPlayer.Health.ToString());
            //_manaText.text = Player.LocalPlayer.Mana.ToString();
        }
    }

    private void Update()
    {
        SetText();
    }
}
