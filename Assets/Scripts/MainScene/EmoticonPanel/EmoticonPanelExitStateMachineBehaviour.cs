using UnityEngine;

namespace TimiTracking.MainScene {
    public class EmoticonPanelExitStateMachineBehaviour : StateMachineBehaviour {

        public EmoticonPanel EmoticonPanel {
            get; set;
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
            this.EmoticonPanel.OnExitHideComplete();
        }
    }
}