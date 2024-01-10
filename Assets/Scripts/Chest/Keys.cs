using UnityEngine;
using UnityEngine.Events;

public static class Keys
{
    public static UnityEvent<int> OnSet = new UnityEvent<int>();

    public static int Value
    {
        get
        {
            if (!PlayerPrefs.HasKey("KeysValue"))
            {
                Value = 0;
            }
            return PlayerPrefs.GetInt("KeysValue");
        }
        set
        {
            PlayerPrefs.SetInt("KeysValue", value);
            OnSet.Invoke(value);
        }
    }
}
