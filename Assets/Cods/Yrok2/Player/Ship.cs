using UnityEngine;

namespace Yrok2
{
    /// <summary>Корабль</summary>
    internal sealed class Ship : IMove, IRotation
    {
        private readonly IMove _moveImplementation;         //перемещение
        private readonly IRotation _rotationImplementation; //вращение
        public float Speed => _moveImplementation.Speed;    //скорость

        #region Конструктор
        public Ship(IMove moveImplementation, IRotation rotationImplementation)
        {
            _moveImplementation = moveImplementation;
            _rotationImplementation = rotationImplementation;
        }
        #endregion

        #region Методы
        /// <summary>Перемещение объекта</summary>
        public void Move(float horizontal, float vertical)
        {
            _moveImplementation.Move(horizontal, vertical);
        }

        /// <summary>Вращение корабля</summary>
        public void Rotation(Vector3 direction)
        {
            _rotationImplementation.Rotation(direction);
        }

        /// <summary>Увеличение скорости</summary>
        public void AddAcceleration()
        {
            if (_moveImplementation is AccelerationMove accelerationMove)
            {
                accelerationMove.AddAcceleration();
            }
        }

        /// <summary>Уменьшение скорости</summary>
        public void RemoveAcceleration()
        {
            if (_moveImplementation is AccelerationMove accelerationMove)
            {
                accelerationMove.RemoveAcceleration();
            }
        }
        #endregion

        #region
        #endregion
    }
}
