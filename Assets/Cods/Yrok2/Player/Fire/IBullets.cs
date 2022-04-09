using UnityEngine;

namespace Yrok2
{
    internal interface IBullets
    {
        /// <summary>Жёсткое Тело снаряда</summary>
        Rigidbody2D Bullet { get; }

        /// <summary>Скорость полёта снаряда</summary>
        float Force { get; }
    }

    #region
    #endregion
}