using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestButton : MonoBehaviour
{
    [SerializeField]
    private Button _open = default;
    [SerializeField]
    private Button _close = default;

    [SerializeField]
    private Text _keysNumberText = default;

    [SerializeField]
    private Button _getRewardButton = default;


    private void Awake()
    {
        _getRewardButton.onClick.AddListener(GetReward);
    }


    private void OnEnable()
    {
        bool isOpen = Keys.Value >= 3;
        _open.gameObject.SetActive(isOpen);
        _close.gameObject.SetActive(!isOpen);

        _keysNumberText.text = $"{Keys.Value}/3";
    }

    private void GetReward()
    {
        Wallet.Value += 150;
        Keys.Value -= 3;
        OnEnable();
    }
}
