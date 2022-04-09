using UnityEngine;

namespace Yrok2
{
    /// <summary>Вращение корабля</summary>
    /// вращаем по оси Z
    internal sealed class RotationShip : IRotation
    {
        private readonly Transform _transform;

        #region Конструктор
        public RotationShip(Transform transform)
        {
            _transform = transform;
        }
        #endregion

        /// <summary>Вращение объекта</summary>
        public void Rotation(Vector3 direction)
        {
            var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            _transform.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}