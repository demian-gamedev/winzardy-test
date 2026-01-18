using UnityEngine;

namespace Services
{
    public interface ICameraService {
        Vector3 GetPositionOutsideCamera(float padding);
    }
}