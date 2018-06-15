using TimiShared.Debug;
using TimiShared.UI;

namespace TimiTracking.MainScene {
    public class EmoticonPanel : DialogBase {

        #region Static
        private const string kEmoticonPanelPrefabName = "Prefabs/UI/EmoticonPanel";
        public static void Present() {
            DialogBase.Present(kEmoticonPanelPrefabName);
        }
        #endregion

        #region Event Handling
        public void OnSaveButtonClicked() {
            this.Hide();
            KeysPanel.Present();
        }
        #endregion

    }
}