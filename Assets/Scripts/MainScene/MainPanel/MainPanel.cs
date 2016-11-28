using TimiShared.UI;

namespace TimiTracking.MainScene {
    public class MainPanel : DialogBase {

        #region Static
        private const string kMainPanelPrefabName = "Prefabs/UI/MainPanel";
        public static void Present() {
            DialogBase.Present(kMainPanelPrefabName);
        }
        #endregion

        #region Event Handling
        public void OnCheckinButtonClicked() {
            this.Hide();
            EmoticonPanel.Present();
        }
        #endregion
    }
}