using UnityEngine;

[CreateAssetMenu(fileName = "Counter", menuName = "ScriptableObjectAssets/Counter", order = 3)]
public class CounterScriptableObject : ScriptableObject
{
    public int DeathCounter;
    public bool QuitThrooughPause;

    public void Initialize()
    {
        DeathCounter = 0;
        QuitThrooughPause = false;
    }
}
