using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OpenCurrentGameButton : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(Action);
    }

    private void Action()
    {
        Levels.Current = Levels.Max;
        SceneManager.LoadScene("Game");
    }
}
