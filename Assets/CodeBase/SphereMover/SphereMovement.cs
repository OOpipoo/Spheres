using System;
using System.Collections.Generic;
using CodeBase.GameSphere;
using UnityEngine;

namespace CodeBase.SphereMover
{
    public class SphereMovement : MonoBehaviour
    {
        // Fields for path
        private readonly Queue<Vector3> path = new();
        private Vector3 ? head;
        // Fields for movement
        private Vector3 ? destination;
        // Fields for FullDistance
        private Vector3 ? previousPosition;
    
        [SerializeField] private float pathSegmentDelta = 1f;
        [SerializeField] private float destinationReachedThreshold = 0.2f;
        [SerializeField] private float speed = 5f;

        [SerializeField] private float fullDistance;

        private Camera _camera;

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
        if (previousPosition.HasValue)
        {
            fullDistance += Vector3.Distance(transform.position, previousPosition.Value);
        }
        previousPosition = transform.position;
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
        var moveDirection = Vector3.Normalize(destination.Value - transform.position);
        transform.position += moveDirection * (speed * Time.deltaTime);
    }

    private bool TryFindDestinationPoint()
    {
        if (!destination.HasValue)
        {
            if (path.Count > 0)
            {
                destination = path.Dequeue();
            }
            else
            {
                return false;
            }
        }

        while (true)
        {
            if (DoesDestinationReached(destination.Value))
            {
                // Set next destination or complete path
                if (path.Count > 0)
                {
                    destination = path.Dequeue();
                }
                else
                {
                    destination = null;
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
        return distanceToDestination < destinationReachedThreshold;
    }

    private void StorePathOnMouseClick()
    {
        if (!Input.GetMouseButton(0))
        {
            return;
        } 
        var ray = _camera.ScreenPointToRay(Input.mousePosition); 
        
        if (Physics.Raycast(ray, out var hit))
        {
            if (head.HasValue)
            {
                var distance = Vector3.Distance(head.Value, hit.point);
                if (distance >= pathSegmentDelta)
                {
                    UpdatePath(hit.point);
                }
            }
            else
            {
                UpdatePath(hit.point);
            }
            StopMoveByClickedOnSphere(hit);
        }
    }

    private void StopMoveByClickedOnSphere(RaycastHit hit)
    {
        if (hit.collider.TryGetComponent(out Sphere _))
        {
            path.Clear();
        }
    }

    private void UpdatePath(Vector3 point)
    {
        var newPoint = new Vector3(
            Mathf.Clamp(point.x, -2.3f, 2.3f),
            Mathf.Clamp(point.y, -3.5f, 5.5f), 
            0);
        path.Enqueue(newPoint);
        head = newPoint;
    }

    #region DrawPatheDebug
    
    private void OnDrawGizmos()
    {
        DrawDebugPath();
        DrawDebugDestination();
    }
    private void DrawDebugDestination()
    {
        if (!destination.HasValue)
        {
            return;
        }
        
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(destination.Value, destinationReachedThreshold);
        Gizmos.DrawLine(transform.position, destination.Value);
    }
    
    private void DrawDebugPath()
    {
        Gizmos.color = Color.magenta;
        Vector3? previous = null;
        foreach (var point in path)
        {
            if (previous.HasValue)
            {
                Gizmos.DrawLine(previous.Value, point);
            }

            previous = point;
            Gizmos.DrawWireSphere(point, destinationReachedThreshold);
        }
    }
    
    #endregion
    
    }
}