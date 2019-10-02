using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteLevel : MonoBehaviour {

    public string menuSceceName = "MainMenu";

    public string nextLevel = "Level02";
    public int levelToUnlock = 2;

    public SceneFaded sceneFaded;



    public void Continue()
    {
        PlayerPrefs.SetInt("levelReached", levelToUnlock);
        sceneFaded.FadeTo(nextLevel);
    }

    public void Menu()
    {
        sceneFaded.FadeTo(menuSceceName);
    }
}
