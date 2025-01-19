using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneControl
{
    public enum SCENE_NUM
    {
        None = -1,
        GameControl = 0,
        Test,
    }

    public static readonly string[] SceneNames = {
        "None",
        "GameControl",
        "Test",
    };
}
