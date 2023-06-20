using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    private AsyncOperation _level;

    public int SceneCount => SceneManager.sceneCountInBuildSettings - 1;
    public int CurrentSceneIndex => SceneManager.GetActiveScene().buildIndex;

    private const int _rotatingScene = 0;
    private const int _carScene = 1;
    private const int _humanoidScene = 2;

    public void OpenRotationgObjectScene() => LoadLevel(_rotatingScene);
    public void OpenCarScene() => LoadLevel(_carScene);
    public void OpenHumanoidScene() => LoadLevel(_humanoidScene);

    private void LoadLevel(int levelID)
    {
        _level = SceneManager.LoadSceneAsync(levelID);
        OpenLoadScreen();
    }

    private void OpenLoadScreen()
    {
        StartCoroutine(AsyncLoadLevel());
    }

    private IEnumerator AsyncLoadLevel()
    {
        var waitForSeconds = new WaitForSeconds(1f);

        _level.allowSceneActivation = false;

        while (_level.isDone == false)
        {
            yield return waitForSeconds;

            if (_level.progress >= 0.9f)
                _level.allowSceneActivation = true;
        }
        StopCoroutine(AsyncLoadLevel());
    }
}
