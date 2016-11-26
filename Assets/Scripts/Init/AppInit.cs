using TimiShared.Init;
using UnityEngine;

namespace TimiTracking.Init {
    public class AppInit : MonoBehaviour, IInitializable {

        #region Events
        public static System.Action OnAppInitComplete = delegate {};
        #endregion

        #region IInitializable
        public void StartInitialize() {
            this.IsFullyInitialized = true;
            OnAppInitComplete.Invoke();
        }

        public bool IsFullyInitialized {
            get; private set;
        }
        #endregion
    }
}