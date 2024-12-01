using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameConfig : Singleton<GameConfig>
{

}

[System.Serializable]
public enum Scene
{
    Loading,
    Home,
    Game,
}
