using UnityEngine;

namespace Yrok2
{
    /// <summary>Перемещение персонажа</summary>
    internal class MoveTransform : IMove
    {
        private readonly Transform _transform;  //местораспоположение персонажа        
        private Vector3 _move;                  //вектор перемещения
        private Rigidbody _player;            //Жёсткое Тело Персонажа

        public float Speed { get; protected set; }  //скорость

        #region Конструктор
        public MoveTransform(Transform transform, Rigidbody player, float speed)
        {
            _transform = transform;
            _player = player;
            Speed = speed;
        }
        #endregion

        #region Методы
        /// <summary>Перемещение объекта</summary>
        public void Move(float horizontal, float vertical)
        {            
            _move.Set(horizontal, vertical, 0.0f);

            _player.AddForce(_move * Speed, ForceMode.Impulse);
        }
        #endregion
    }

    #region
    #endregion
}