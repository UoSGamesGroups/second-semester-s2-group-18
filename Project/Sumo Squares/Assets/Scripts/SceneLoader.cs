using UnityEngine;
using UnityEngine.SceneManagement;

/// TODO: Only load scene if it exists in build settings. Look at SceneManager.GetSceneByName for ref.
/// <summary>
/// Manages loading and unloading of scenes.
/// See: https://docs.unity3d.com/ScriptReference/SceneManagement.SceneManager.html
/// </summary>
public class SceneLoader : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }

    public void LoadScene(int index)
    {
        SceneManager.LoadScene(index, LoadSceneMode.Single);
    }

    public void AddScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
    }

    public void AddScene(int index)
    {
        SceneManager.LoadScene(index, LoadSceneMode.Additive);
    }

    public void LoadSceneAsync(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
    }

    public void LoadSceneLoadSceneAsync(int index)
    {
        SceneManager.LoadSceneAsync(index, LoadSceneMode.Single);
    }

    public void AddSceneAsync(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
    }

    public void AddSceneAsync(int index)
    {
        SceneManager.LoadSceneAsync(index, LoadSceneMode.Additive);
    }

    public bool UnloadSceneAsync(string sceneName)
    {
        return SceneManager.UnloadSceneAsync(sceneName).isDone;
    }

    public bool UnloadSceneAsync(int index)
    {
        return SceneManager.UnloadSceneAsync(index).isDone;
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game");
        Application.Quit();
    }
}