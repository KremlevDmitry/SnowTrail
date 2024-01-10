using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    private int _id = default;
    [SerializeField]
    private Button _button = default;
    [SerializeField]
    private GameObject[] _buttons = default;
    [SerializeField]
    private Text _text = default;


    private void Awake()
    {
        _button.onClick.AddListener(OpenGame);
    }

    public void Set(int id)
    {
        _id = id;

        bool isEnable = Levels.Max >= id;
        bool isCurrent = Levels.Max == id;

        _button.interactable = isEnable;
        foreach (var button in _buttons)
        {
            button.SetActive(false);
        }
        _buttons[isEnable ? isCurrent ? 1 : 2 : 0].SetActive(true);
        _text.text = $"{id + 1}";
        _text.enabled = isEnable;
    }

    private void OpenGame()
    {
        Levels.Current = _id;
        SceneManager.LoadScene("Game");
    }
}
