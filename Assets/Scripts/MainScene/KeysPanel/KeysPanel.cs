using TimiShared.UI;

namespace TimiTracking.MainScene {
    public class KeysPanel : DialogBase {

        #region Static
        private const string kKeysPanelPrefabName = "Prefabs/UI/KeysPanel";
        public static void Present() {
            DialogBase.Present(kKeysPanelPrefabName);
        }
        #endregion

        #region Event Handling
        public void OnSaveButtonClicked() {
            this.Hide();
            MainPanel.Present();
        }
        #endregion

    }
}