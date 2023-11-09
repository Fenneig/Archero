using UnityEngine;

namespace Archero.Utils
{
    public static class ViewHelper
    {
        /// <summary>
        /// Throw sphere from unit position on high shoot toward player and check if no obstacle collided
        /// </summary>
        /// <param name="unit">unit transform that shoot</param>
        /// <param name="target">transform of unit aim</param>
        /// <param name="obstacleLayers">layers that should count as obstacles</param>
        /// <param name="projectileRadius">check sphere radius</param>
        /// <param name="attackSpawnTransform">position from which should start detecting colliders</param>
        /// <returns>Is target reachable for shoot</returns>
        public static bool IsTargetInUnitView(Transform unit, Transform target, LayerMask obstacleLayers, float projectileRadius, Transform attackSpawnTransform)
        {
            RaycastHit[] raycastResult = new RaycastHit[1];
            var unitPosition = unit.position;
            Vector3 direction = target.position - unitPosition;
            Vector3 checkSphereStartPosition = new Vector3(
                unitPosition.x,
                unitPosition.y + attackSpawnTransform.localPosition.y,
                unitPosition.z) + direction.normalized;
            Ray ray = new Ray(checkSphereStartPosition, direction);
            float maxRange = (direction - direction.normalized).magnitude;
            Physics.SphereCastNonAlloc(ray, projectileRadius, raycastResult, maxRange, obstacleLayers);
            bool isInView = raycastResult[0].transform == null;
            return isInView;
        }
    }
}