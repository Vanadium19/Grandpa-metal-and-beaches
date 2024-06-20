using System.Collections;
using GMB.Settings;
using UnityEngine;

namespace GMB.GamePlay.PlayerEnvironment
{
    [RequireComponent(typeof(PlayerMover))]
    internal class Player : MonoBehaviour
    {
        private readonly float _minPositionY = -7f;

        private Transform _transform;
        private Vector3 _startPoint;
        private PlayerMover _playerMover;
        private Coroutine _heightTracking;

        private void Awake()
        {
            _transform = transform;
            _startPoint = _transform.position;
            _playerMover = GetComponent<PlayerMover>();
        }

        public void StopMove()
        {
            _playerMover.StopPlayer();
        }

        public void ContinueMove()
        {
            _playerMover.SetSpeed(GameSaver.Speed);
        }

        public void StartHeightTracking()
        {
            StopHeightTracking();
            _heightTracking = StartCoroutine(TrackHeight());
        }

        public void StopHeightTracking()
        {
            if (_heightTracking != null)
                StopCoroutine(_heightTracking);
        }

        private IEnumerator TrackHeight()
        {
            while (_transform.position.y > _minPositionY)
                yield return null;

            _transform.position = _startPoint;
        }
    }
}