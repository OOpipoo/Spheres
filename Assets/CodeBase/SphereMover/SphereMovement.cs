using System.Collections.Generic;
using CodeBase.GameSphere;
using CodeBase.Infrastructure.Services.GameStats;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace CodeBase.SphereMover
{
    public class SphereMovement : MonoBehaviour
    {
        [SerializeField] private float _pathSegmentDelta = 0.5f;
        [SerializeField] private float _destinationReachedThreshold = 0.3f;
        [SerializeField] private float _speed = 7f;
        
        // Fields for path
        private readonly Queue<Vector3> _path = new();
        private Vector3 ? _head;
        // Fields for movement
        private Vector3 ? _destination;
        // Fields for FullDistance
        private Vector3 ? _previousPosition;
        
        private Camera _camera;
        private GameStatsService _gameStatsService;
        private float _fullDistance;

        
        [Inject]
        private void Construct(GameStatsService gameStatsService)
        {
            _gameStatsService = gameStatsService; 
        }
        
        private void Start()
        {
            _camera = Camera.main;
        }

        private void Update()
        {
            StorePathOnMouseClick();
            MoveAlongPath();
            UpdatePassedDistance();
        }

        private void UpdatePassedDistance()
        {
            if (_previousPosition.HasValue)
            {
                _fullDistance += Vector3.Distance(transform.position, _previousPosition.Value);
                _gameStatsService.Distance.Value = _fullDistance;
            }
            _previousPosition = transform.position;
        }

        private void MoveAlongPath()
        {
            if (!TryFindDestinationPoint())
            {
                return;
            } 
            MoveToDestination();
        }

        private void MoveToDestination()
        {
            var distanceToDestination = Vector3.Distance(transform.position, _destination.Value);
            var decelerationDistance = _speed * Time.deltaTime;
            var moveDirection = Vector3.Normalize(_destination.Value - transform.position);
            if (distanceToDestination <= decelerationDistance)
            {
                transform.position = _destination.Value;
            }
            else
            {
                var speed = _speed;
                if (distanceToDestination <= decelerationDistance * 2)
                {
                    speed = _speed * distanceToDestination / (decelerationDistance * 2);
                }
                transform.position += moveDirection * (speed * Time.deltaTime);
            }
        }

        private bool TryFindDestinationPoint()
        {
            if (!_destination.HasValue)
            {
                if (_path.Count > 0)
                {
                    _destination = _path.Dequeue();
                }
                else
                {
                    return false;
                }
            }

            while (true)
            {
                if (DoesDestinationReached(_destination.Value))
                {
                    // Set next destination or complete path
                    if (_path.Count > 0)
                    {
                        _destination = _path.Dequeue();
                    }
                    else
                    {
                        _destination = null;
                        return false;
                    }
                }
                else
                {
                    return true;
                }
            }
        }

        private bool DoesDestinationReached(Vector3 destination)
        {
            var distanceToDestination = Vector3.Distance(destination, transform.position);
            return distanceToDestination < _destinationReachedThreshold;
        }

        private void StorePathOnMouseClick()
        {
            if (!Input.GetMouseButton(0)) return;
            
            var ray = _camera.ScreenPointToRay(Input.mousePosition);  
            
            if (!Physics.Raycast(ray, out var hit)) return;
            
            if (!_head.HasValue || Vector3.Distance(_head.Value, hit.point) >= _pathSegmentDelta)
            {
                UpdatePath(hit.point); 
            }
            
            StopMoveByClickedOnSphere(hit); 
        }

        private void StopMoveByClickedOnSphere(RaycastHit hit)
        {
            if (hit.collider.TryGetComponent(out Sphere _))
            {
                _path.Clear();
            }
        }

        private void UpdatePath(Vector3 point)
        {
            point.x = Mathf.Clamp(point.x, -2.3f, 2.3f);
            point.y = Mathf.Clamp(point.y, -3.5f, 5.5f);
            point.z = 0;
            _path.Enqueue(point);
            _head = point;
        }
        
        #region DrawPatheDebug
        
        private void OnDrawGizmos()
        {
            DrawDebugPath();
            DrawDebugDestination();
        }
        
        private void DrawDebugDestination()
        {
            if (!_destination.HasValue)
            {
                return;
            }
            
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(_destination.Value, _destinationReachedThreshold);
            Gizmos.DrawLine(transform.position, _destination.Value);
        }
        
        private void DrawDebugPath()
        {
            Gizmos.color = Color.magenta;
            Vector3? previous = null;
            foreach (var point in _path)
            {
                if (previous.HasValue)
                {
                    Gizmos.DrawLine(previous.Value, point);
                }

                previous = point;
                Gizmos.DrawWireSphere(point, _destinationReachedThreshold);
            }
        }
        
        #endregion 
    }
}