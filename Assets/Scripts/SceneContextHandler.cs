using System.Collections.Generic;
using UnityEngine;

public class SceneContextHandler : MonoBehaviour
{
    public static SceneContextHandler Instance {get; private set;}
    private readonly Dictionary<string, int> sceneNameDictionary = new Dictionary<string, int>()
    {
        {"MainMenu", 0},
        {"Game", 1}
    };

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public int GetIndexOfScene(string sceneName)
    {
        return sceneNameDictionary[sceneName];
    }
}