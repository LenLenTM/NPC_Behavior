using UnityEngine;

public class EnemyInRange : Node
{
        private static int _enemyLayerMask = 1 << 7;
        private Transform _transform;

        public EnemyInRange(Transform transform)
        {
                _transform = transform;
        }

        public override NodeState Evaluate()
        {
                object enemy = GetData("enemy");
                Transform enemyPosition = CalculateDistance(_transform);
                
                if (enemy == null)
                {
                        if (enemyPosition != null)
                        {
                                parent.parent.SetData("enemy", enemyPosition);
                                parent.parent.SetData("target", CalculateTargetVector(_transform, enemyPosition) );
                                
                                Debug.Log(enemyPosition.position);
                                state = NodeState.Success;
                                return state;
                        }
                        state = NodeState.Failure;
                        return state;
                }

                if (enemyPosition == null)
                {
                        SetData("enemy", null);
                        state = NodeState.Failure;
                        return state;
                }
                
                parent.parent.SetData("target", CalculateTargetVector(_transform, enemyPosition));
                
                state = NodeState.Success;
                return state;
        }

        private Transform CalculateDistance(Transform transform)
        {
                foreach (Enemy enemy in World.Enemies)
                {
                        Debug.Log(enemy.transform.position);
                        if (Vector2.Distance(transform.position, enemy.transform.position) < 6.1f)
                        {
                                return enemy.transform;
                        }
                        
                }
                return null;
        }

        private Vector3 CalculateTargetVector(Transform entityPosition, Transform enemyPosition)
        {
                return ((_transform.position - enemyPosition.position).normalized * BT_Entity.viewRange) + enemyPosition.position;
        }
}