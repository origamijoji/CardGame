using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonScript : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private Image _buttonImage;
    [SerializeField] private TextMeshProUGUI _buttonText;
    public void OnClickEndTurn()
    {
        GameManager.Instance.CmdEndTurn();
        DragAttack.CurrentAttacker = null;
        Invoke("UpdateUI", 0.05f);
    }
    public void UpdateUI()
    {
        EntitySubject.Notify();
    }
    private void Update()
    {
        if(Player.LocalPlayer == null) { return; }
        if (Player.LocalPlayer.isServer)
        {
            if(GameManager.Instance.IsFirstHalf)
            {
                EnableButton();
                Player.LocalPlayer.IsTurn = true;
            }
            else
            {
                DisableButton();
                Player.LocalPlayer.IsTurn = false;
            }
        }
        if(Player.LocalPlayer.isClientOnly)
        {
            if(!GameManager.Instance.IsFirstHalf)
            {
                EnableButton();
                Player.LocalPlayer.IsTurn = true;
            }
            else
            {
                DisableButton();
                Player.LocalPlayer.IsTurn = false;
            }
        }
    }

    private void EnableButton()
    {
        _button.enabled = true;
        _buttonImage.enabled = true;
        _buttonText.enabled = true;
    }
    private void DisableButton()
    {
        _button.enabled = false;
        _buttonImage.enabled = false;
        _buttonText.enabled = false;
    }
}
