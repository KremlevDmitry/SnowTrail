using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField]
    private GameObject _first = default;
    [SerializeField]
    private GameObject _second = default;

    public void OpenFirst()
    {
        if (PlayerPrefs.GetInt("TutorialFirst", 0) == 0)
        {
            PlayerPrefs.SetInt("TutorialFirst", 1);
            _first.SetActive(true);
        }
    }

    public void OpenSecond()
    {
        if (PlayerPrefs.GetInt("TutorialSecond", 0) == 0)
        {
            PlayerPrefs.SetInt("TutorialSecond", 1);
            _second.SetActive(true);
        }
    }
}
