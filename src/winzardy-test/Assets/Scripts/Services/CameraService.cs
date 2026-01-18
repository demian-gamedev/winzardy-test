using UnityEngine;

namespace Services
{
    public class CameraService : ICameraService {
        private readonly Camera _camera;
        private readonly Plane _groundPlane;

        public CameraService(Camera camera) {
            _camera = camera;
            _groundPlane = new Plane(Vector3.up, Vector3.zero);
        }

        public Vector3 GetPositionOutsideCamera(float padding) {
            float minX = float.MaxValue, maxX = float.MinValue;
            float minZ = float.MaxValue, maxZ = float.MinValue;

            Vector3[] viewportCorners = { 
                new Vector3(0, 0, 0), new Vector3(1, 0, 0), 
                new Vector3(0, 1, 0), new Vector3(1, 1, 0) 
            };

            foreach (var p in viewportCorners) {
                Ray ray = _camera.ViewportPointToRay(p);
                if (_groundPlane.Raycast(ray, out float enter)) {
                    Vector3 hit = ray.GetPoint(enter);
                    if (hit.x < minX) minX = hit.x;
                    if (hit.x > maxX) maxX = hit.x;
                    if (hit.z < minZ) minZ = hit.z;
                    if (hit.z > maxZ) maxZ = hit.z;
                }
            }

            int side = Random.Range(0, 4);
            float x = 0, z = 0;

            switch (side) {
                case 0:
                    x = Random.Range(minX - padding, maxX + padding);
                    z = maxZ + padding;
                    break;
                case 1:
                    x = Random.Range(minX - padding, maxX + padding);
                    z = minZ - padding;
                    break;
                case 2:
                    x = minX - padding;
                    z = Random.Range(minZ - padding, maxZ + padding);
                    break;
                case 3:
                    x = maxX + padding;
                    z = Random.Range(minZ - padding, maxZ + padding);
                    break;
            }

            return new Vector3(x, 0, z);
        }
    }
}