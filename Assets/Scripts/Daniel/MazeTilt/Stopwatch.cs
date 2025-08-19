using UnityEngine;
using TMPro;


namespace Daniel
{

    public class Stopwatch : MonoBehaviour
    {
        public TextMeshProUGUI timer;
        public bool runOnStart = true;
        public int decimals = 2;
        float t = 0f;
        bool running = false;

        void Start()
        {
            running = runOnStart;
            UpdateLabel();
        }

        void Update()
        {
            if (!running) return;
            t += Time.deltaTime;
            UpdateLabel();
        }

        void UpdateLabel()
        {
            if (!timer) return;
            timer.text = t.ToString($"F{decimals}");
        }

        public void StartStopwatch() => running = true;
        public void StopStopwatch() => running = false;
        public void ResetStopwatch() { t = 0f; UpdateLabel(); }

        public float ElapsedSeconds => t;
    }

}
