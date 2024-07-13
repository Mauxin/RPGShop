using UnityEngine;
using UnityEngine.SceneManagement;

namespace Common
{
    public class GameInitializer : MonoBehaviour
    {
        private void Start()
        {
            var sceneName = PlayerPrefs.HasKey(CommonStrings.SAVE_DATA_CHARACTER_KEY) ? CommonStrings.SHOP_SCENE : CommonStrings.CHARACTER_SELECTOR_SCENE;
            SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
        }
    }
}
