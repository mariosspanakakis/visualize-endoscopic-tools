using System.Collections;
using UnityEngine;

public class ClickRecognizer : MonoBehaviour {

    public UnityEngine.Events.UnityEvent ue;
    UnityEngine.XR.WSA.Input.GestureRecognizer recognizer;

    public bool freeze_screen = false;

    void Awake() {
        // Set up a GestureRecognizer to detect Select gestures.
        recognizer = new UnityEngine.XR.WSA.Input.GestureRecognizer();
        recognizer.Tapped += (args) => {
            // toggle the freezing flag
            freeze_screen = !freeze_screen;

            if (ue != null) {
                ue.Invoke();
            }
        };
        recognizer.StartCapturingGestures();
    }
}