using UnityEngine;

namespace Yrok2
{
    /// <summary>Перемещение персонажа при ускорении</summary>
    internal sealed class AccelerationMove : MoveTransform
    {
        private readonly float _acceleration;   //ускорение

        #region Конструктор
        public AccelerationMove(Transform transform, Rigidbody player, float speed, float acceleration) : base(transform, player, speed)
        {
            _acceleration = acceleration;
        }
        #endregion

        /// <summary>Увеличение скорости</summary>
        public void AddAcceleration()
        {
            Speed += _acceleration;
        }

        /// <summary>Уменьшение скорости</summary>
        public void RemoveAcceleration()
        {
            Speed -= _acceleration;
        }
    }
}
