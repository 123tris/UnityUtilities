using UnityEngine.SceneManagement;
using static CooldownManager;

public class SceneManagerExtensions : SceneManager
{
    public static Scene[] GetActiveScenes()
    {
        int countLoaded = sceneCount;
        Scene[] loadedScenes = new Scene[countLoaded];

        for (int i = 0; i < countLoaded; i++)
        {
            loadedScenes[i] = GetSceneAt(i);
        }

        return loadedScenes;
    }

    public static void LoadScenes(Scene[] scenes)
    {
        for (int i = 0; i < scenes.Length; i++)
        {
            LoadScene(scenes[i].name, i == 0 ? LoadSceneMode.Single : LoadSceneMode.Additive);
        }
    }

    /// <summary> Adds scene to the runtime if it hasn't been loaded in yet</summary>
    public static void AddSceneIfNotLoaded(string sceneName)
    {
        Scene playerScene = GetSceneByName(sceneName);
        if (!playerScene.IsValid())
        {
            LoadScene(sceneName, LoadSceneMode.Additive);
        }
    }

    public static void AddSceneIfNotLoaded(int buildIndex)
    {
        Scene playerScene = GetSceneByBuildIndex(buildIndex);
        if (!playerScene.IsValid())
        {
            LoadScene(buildIndex, LoadSceneMode.Additive);
        }
    }

    public static void LoadLevel(int buildIndex)
    {
        UnloadSceneAsync(GetActiveScene());
        LoadScene(buildIndex, LoadSceneMode.Additive);
        OnNextFrame(() => SetActiveScene(GetSceneByBuildIndex(buildIndex)));
    }
    public static void LoadLevel(string sceneName)
    {
        UnloadSceneAsync(GetActiveScene());
        LoadScene(sceneName, LoadSceneMode.Additive);
        OnNextFrame(() => SetActiveScene(GetSceneByName(sceneName)));
    }
}
