using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OpenXGameButton : MonoBehaviour
{
    [SerializeField]
    private int _id = default;

    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(Action);
    }

    private void Action()
    {
        Levels.Current = _id;
        SceneManager.LoadScene("Game");
    }
}
