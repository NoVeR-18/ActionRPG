using System;
using UnityEngine;

public partial class OverlapAttack : MonoBehaviour
{
    [Header("Common")]
    [SerializeField, Min(0f)] private int _damage = 10;

    [Header("Masks")]
    [SerializeField] protected LayerMask _searchLayerMask;
    [SerializeField] private LayerMask _obstacleLayerMask;

    [Header("Overlap Area")]
    [SerializeField] private Transform _overlapStartPoint;
    [SerializeField] private OverlapType _overlapType;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private Vector3 _boxSize = Vector3.one;
    [SerializeField, Min(0f)] private float _sphereRadius = 1f;

    [Header("Obstacles")]
    [SerializeField] private bool _considerObstacles;

    [Header("Gizmos")]
    [SerializeField] private DrawGizmosType _drawGizmosType;
    [SerializeField] private Color _gizmosColor = Color.cyan;

    private readonly Collider2D[] _overlapResults = new Collider2D[32];
    private int _overlapResultsCount;

    public void PerformAttack()
    {
        if (TryFindEnemies())
        {
            TryAttackEnemies();
        }
    }

    private bool TryFindEnemies()
    {
        var position = _overlapStartPoint.TransformPoint(_offset);

        _overlapResultsCount = _overlapType switch
        {
            OverlapType.Box => OverlapBox(position),
            OverlapType.Sphere => OverlapSphere(position),

            _ => throw new ArgumentOutOfRangeException(nameof(_overlapType))
        };

        return _overlapResultsCount > 0;
    }

    private int OverlapBox(Vector3 position)
    {
        //return Physics.OverlapBoxNonAlloc(position, _boxSize / 2, _overlapResults,
        //    _overlapStartPoint.rotation, _searchLayerMask.value);
        return Physics2D.OverlapBoxNonAlloc(position, _boxSize / 2, 1,
            _overlapResults, _searchLayerMask.value);
    }

    private int OverlapSphere(Vector3 position)
    {

        //return Physics.OverlapSphereNonAlloc(position, _sphereRadius, _overlapResults, 8);
        return Physics2D.OverlapCircleNonAlloc(position, _sphereRadius, _overlapResults, _searchLayerMask); //.OverlapSphereNonAlloc(position, _sphereRadius, _overlapResults, 8);
    }

    private void TryAttackEnemies()
    {
        for (int i = 0; i < _overlapResultsCount; i++)
        {
            if (_overlapResults[i].TryGetComponent(out IDamageable damageable) == false)
            {
                continue;
            }

            if (_considerObstacles)
            {
                var startPointPosition = _overlapStartPoint.position;
                var colliderPosition = _overlapResults[i].transform.position;
                var hasObstacle = Physics.Linecast(startPointPosition, colliderPosition,
                    _obstacleLayerMask.value);

                if (hasObstacle)
                {
                    continue;
                }
            }

            damageable.ApplyDamage(_damage);
        }
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        TryDrawGizmos(DrawGizmosType.Always);
    }

    private void OnDrawGizmosSelected()
    {
        TryDrawGizmos(DrawGizmosType.OnSelected);
    }

    private void TryDrawGizmos(DrawGizmosType requiredType)
    {
        if (_drawGizmosType != requiredType)
            return;

        if (_overlapStartPoint == null)
            return;

        Gizmos.matrix = _overlapStartPoint.localToWorldMatrix;
        Gizmos.color = _gizmosColor;

        switch (_overlapType)
        {
            case OverlapType.Box: Gizmos.DrawCube(_offset, _boxSize); break;
            case OverlapType.Sphere: Gizmos.DrawSphere(_offset, _sphereRadius); break;

            default: throw new ArgumentOutOfRangeException(nameof(_overlapType));
        }
    }
#endif
}
