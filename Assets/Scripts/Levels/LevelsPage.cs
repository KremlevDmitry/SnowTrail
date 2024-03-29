using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelsPage : MonoBehaviour
{
    private const int PAGE_NUMBER = 3;
    [SerializeField]
    private GameObject[] _selectors = default;
    [SerializeField]
    private LevelButton[] _levels = default;
    [SerializeField]
    private Button _leftButton = default;
    [SerializeField]
    private Button _rightButton = default;

    private int currentPage = default;


    private void Awake()
    {
        _leftButton.onClick.AddListener(() => { Set(--currentPage); });
        _rightButton.onClick.AddListener(() => { Set(++currentPage); });
    }

    private void OnEnable()
    {
        Set(0);
    }


    private void Set(int pageId)
    {
        currentPage = pageId;

        _leftButton.interactable = (currentPage > 0);
        _rightButton.interactable = (currentPage < PAGE_NUMBER - 1);

        for (int i = 0; i < _levels.Length; i++)
        {
            _levels[i].Set(currentPage * _levels.Length + i);
        }

        foreach (var selector in _selectors)
        {
            selector.SetActive(false);
        }
        _selectors[pageId].SetActive(true);
    }
}
