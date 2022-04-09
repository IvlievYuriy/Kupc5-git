using UnityEngine;

namespace Yrok2
{
    /// <summary>
    /// Снаряд.
    /// Вешается на снаряд
    /// </summary>

    [RequireComponent(typeof(Rigidbody2D))]   //добавляем на объект Жёсткое Тело
    internal sealed class Bullets : MonoBehaviour, IBullets
    {
        [SerializeField] private Rigidbody2D _bullet;   //Жёсткое Тело снаряда
        [SerializeField] private float _force = 1;      //Скорость полёта снаряда

        #region Свойства
        public Rigidbody2D Bullet => _bullet;
        
        public float Force => _force;
        #endregion

        private void Start()
        {
            _bullet = GetComponent<Rigidbody2D>();
        }
    }

    #region
    #endregion
}