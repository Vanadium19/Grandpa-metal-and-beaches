using UnityEngine;

namespace GMB.GamePlay.Level.UI
{
    internal class DelayedObjectCloser : MonoBehaviour
    {
        [SerializeField] private float _delay = 3f;

        private float _elapsedTime = 0;

        private void OnEnable()
        {
            _elapsedTime = 0;
        }

        private void Update()
        {
            if (_elapsedTime >= _delay)
                gameObject.SetActive(false);

            _elapsedTime += Time.deltaTime;
        }
    }
}