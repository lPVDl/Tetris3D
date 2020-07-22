using UnityEngine.SceneManagement;

namespace Game.Common.SceneManagement
{
    public class SceneSwitcher : ISceneSwitcher
    {
        public void Switch(ESceneType nextScene)
        {
            SceneManager.LoadScene(nextScene.ToString(), LoadSceneMode.Single);
        }
    }
}
