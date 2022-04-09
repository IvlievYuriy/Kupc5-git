using UnityEngine;

namespace Yrok2
{
    /// <summary>Стрельба</summary>
    internal sealed class Fire : MonoBehaviour, IFire
    {
        private IBullets _bullets;
        private Transform _transform;

        public Fire(IBullets bullets, Transform transform)
        {
            _bullets = bullets;
            _transform = transform;
        }


        /// <summary>Действие при нажатии ЛКМ </summary>
        public void Fire1()
        {
            var temAmmunition = Instantiate(_bullets.Bullet, _transform.position, _transform.rotation);
            temAmmunition.AddForce(_transform.up * _bullets.Force);
        }
    }

    #region
    #endregion
}