using UnityEngine;

namespace TimiTracking.MainScene {
    public class MainSceneLoader : MonoBehaviour {

        #region Unity LifeCycle
        private void Start() {
            this.LoadMainPanelAsync();
        }
        #endregion

        private void LoadMainPanelAsync() {
            MainPanel.Present();
        }

    }
}