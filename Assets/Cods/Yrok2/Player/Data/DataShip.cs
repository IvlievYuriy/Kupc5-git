using UnityEngine;

namespace Yrok2
{
    /// <summary>Характеристики корабля</summary>
    internal sealed class DataShip : IDataShip
    {
        [SerializeField] private float _speed = 1;          //скорость
        [SerializeField] private float _acceleration = 1;   //ускорение
        [SerializeField] private float _hp = 10;            //здоровье

        #region Свойства
        /// <summary>Скорость корабля</summary>
        public float Speed => _speed;

        /// <summary>Ускорение корабля</summary>
        public float Acceleration => _acceleration;

        /// <summary>Здоровье корабля</summary>
        public float HP => _hp;
        #endregion
        
    }
    #region
    #endregion
}