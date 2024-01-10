using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField]
    private Level[] _levels = default;
    private Level _level = default;
    [SerializeField]
    private Control _control = default;

    [SerializeField]
    private GameObject _winPage = default;
    [SerializeField]
    private GameObject _keysObject = default;
    [SerializeField]
    private GameObject _coinsObject = default;

    [SerializeField]
    private GameObject _loseObject = default;
    [SerializeField]
    private Tutorial _tutorial = default;

    private bool _isEnd = false;


    private void Awake()
    {
        //Debug.Log(Levels.Current);
        //Debug.Log(Levels.Current % _levels.Length);

        if (Levels.Current == 0)
        {
            _tutorial.OpenFirst();
        }
        else if (Levels.Current == 1)
        {
            _tutorial.OpenSecond();
        }

        _level = _levels[Levels.Current % _levels.Length];
        _level = Instantiate(_level, transform);
        _level.Init(this, _control);
    }

    private void Start()
    {
        _level.StandObjects();
    }

    public void Win()
    {
        if (_isEnd) { return; }
        _isEnd = true;
        _keysObject.SetActive(Levels.Current == Levels.Max);
        _coinsObject.SetActive(Levels.Current != Levels.Max);
        if (Levels.Current == Levels.Max)
        {
            Keys.Value++;
            Levels.Max++;
        }
        Wallet.Value += 10;
        _winPage.SetActive(true);
    }

    public void Lose()
    {
        if (_isEnd) { return; }
        _isEnd = true;
        Wallet.Value += 10;
        _loseObject.SetActive(true);
    }
}
