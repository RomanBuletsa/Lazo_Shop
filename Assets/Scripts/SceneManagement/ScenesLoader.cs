using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace SceneManagement
{
  public static class ScenesLoader
  {
    private static readonly Dictionary<string, bool> SetActives = new Dictionary<string, bool>();
    public static Action<AsyncOperation> showLoadingScreenAction;

    public static event Action<Scene, LoadSceneMode> SceneLoaded;

    public static event Action<Scene> SceneUnloaded;

    public static string CurrentSceneName
    {
      get
      {
        return SceneManager.GetActiveScene().name;
      }
    }

    public static int CurrentSceneIndex
    {
      get
      {
        return SceneManager.GetActiveScene().buildIndex;
      }
    }

    public static void LoadScene(int sceneIndex, bool setActive = true, bool loadAsync = true, bool additive = true)
    {
      ScenesLoader.SetActives.Add(sceneIndex.ToString(), setActive);
      LoadSceneMode mode = additive ? LoadSceneMode.Additive : LoadSceneMode.Single;
      ScenesLoader.LoadScene((Action) (() => SceneManager.LoadScene(sceneIndex, mode)), (Func<AsyncOperation>) (() => SceneManager.LoadSceneAsync(sceneIndex, mode)), setActive, loadAsync, additive);
    }

    public static void LoadScene(string sceneName, bool setActive = true, bool loadAsync = true, bool additive = true)
    {
      ScenesLoader.SetActives.Add(sceneName, setActive);
      SceneManager.sceneLoaded += new UnityAction<Scene, LoadSceneMode>(ScenesLoader.OnSceneLoaded);
      LoadSceneMode mode = additive ? LoadSceneMode.Additive : LoadSceneMode.Single;
      if (!loadAsync)
      {
        SceneManager.LoadScene(sceneName, mode);
      }
      else
      {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName, mode);
        Action<AsyncOperation> loadingScreenAction = ScenesLoader.showLoadingScreenAction;
        if (loadingScreenAction == null)
          return;
        loadingScreenAction(asyncOperation);
      }
    }

    public static void LoadScene(
      Action loadSceneMethod,
      Func<AsyncOperation> loadSceneAsyncMethod,
      bool setActive = true,
      bool loadAsync = true,
      bool additive = true)
    {
      SceneManager.sceneLoaded += new UnityAction<Scene, LoadSceneMode>(ScenesLoader.OnSceneLoaded);
      if (!loadAsync)
      {
        loadSceneMethod();
      }
      else
      {
        AsyncOperation asyncOperation = loadSceneAsyncMethod();
        Action<AsyncOperation> loadingScreenAction = ScenesLoader.showLoadingScreenAction;
        if (loadingScreenAction == null)
          return;
        loadingScreenAction(asyncOperation);
      }
    }

    private static void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
      SceneManager.sceneLoaded -= new UnityAction<Scene, LoadSceneMode>(ScenesLoader.OnSceneLoaded);
      bool flag = true;
      string key = (string) null;
      if (ScenesLoader.SetActives.ContainsKey(scene.name))
        key = scene.name;
      else if (ScenesLoader.SetActives.ContainsKey(scene.buildIndex.ToString()))
        key = scene.buildIndex.ToString();
      if (!string.IsNullOrEmpty(key))
      {
        flag = ScenesLoader.SetActives[key];
        ScenesLoader.SetActives.Remove(key);
      }
      if (flag)
        SceneManager.SetActiveScene(scene);
      ScenesLoader.SetActives.Remove(key ?? scene.name);
      Action<Scene, LoadSceneMode> sceneLoaded = ScenesLoader.SceneLoaded;
      if (sceneLoaded == null)
        return;
      sceneLoaded(scene, mode);
    }

    public static void SetActiveScene(int sceneIndex)
    {
      ScenesLoader.SetActiveScene(SceneManager.GetSceneByBuildIndex(sceneIndex).name);
    }

    public static void SetActiveScene(string sceneName)
    {
      SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneName));
    }

    public static void UnloadScene(int sceneIndex)
    {
      ScenesLoader.UnloadScene(SceneManager.GetSceneByBuildIndex(sceneIndex).name);
    }

    public static void UnloadScene(string sceneName)
    {
      SceneManager.sceneUnloaded += new UnityAction<Scene>(ScenesLoader.OnSceneUnloaded);
      SceneManager.UnloadSceneAsync(sceneName);
    }

    private static void OnSceneUnloaded(Scene scene)
    {
      SceneManager.sceneUnloaded -= new UnityAction<Scene>(ScenesLoader.OnSceneUnloaded);
      Action<Scene> sceneUnloaded = ScenesLoader.SceneUnloaded;
      if (sceneUnloaded == null)
        return;
      sceneUnloaded(scene);
    }

    public static void MoveObjectToScene(GameObject gameObject, int sceneIndex)
    {
      ScenesLoader.MoveObjectToScene(gameObject, SceneManager.GetSceneByBuildIndex(sceneIndex).name);
    }

    public static void MoveObjectToScene(GameObject gameObject, string sceneName)
    {
      SceneManager.MoveGameObjectToScene(gameObject, SceneManager.GetSceneByName(sceneName));
    }
  }
}
