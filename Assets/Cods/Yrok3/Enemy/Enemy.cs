using UnityEngine;

namespace Yrok3
{
    /// <summary>
    /// Enemy, абстрактный класс
    /// Объект, к-рый нужно уничтожать
    /// </summary>
    internal abstract class Enemy : MonoBehaviour
    {        
        public static IEnemyFactory Factory;    //ссылка на фабрику
        private Transform _rotPool;
        private Health _health;
        private const string PREFAB_ASTEROID = "Enemy/Asteroid";    //убираем все строковые переменные в константы

        #region Свойства
        public Health Health
        {
            get
            {
                if (_health.Current <= 0.0f)
                {
                    ReturnToPool();
                }
                return _health;
            }
            protected set => _health = value;
        }

        public Transform RotPool
        {
            get
            {
                if (_rotPool == null)
                {
                    var find = GameObject.Find(NameManager.POOL_AMMUNITION);
                    _rotPool = find == null ? null : find.transform;
                }
                return _rotPool;
            }
        }    
        #endregion



        #region Создание объекта (Астеройд). Фабричный Метод
        /// <summary>Создание объекта (Астеройд)</summary>
        /// <param name="hp">Здоровье объекта</param>
        /// <returns></returns>
        public static Asteroid CreateAsteroidEnemy(Health hp)
        {
            var enemy = Instantiate(Resources.Load<Asteroid>(PREFAB_ASTEROID));
            enemy.Health = hp;

            return enemy;
        }
        #endregion

        #region Добавление Здоровья созданному объекту
        /// <summary>Добавление Здоровья созданному объекту</summary>        
        public void DependencyInjectHealth(Health hp)
        {
            Health = hp;
        }
        #endregion

        #region Вытаскивание ИО из пула
        /// <summary>Вытаскивание ИО из пула</summary>
        public void ActiveEnemy(Vector3 position, Quaternion rotation)
        {
            transform.localPosition = position; //задаём позицию ИО
            transform.localRotation = rotation; //задаём угол поворота ИО
            gameObject.SetActive(true);         //вкл. ИО
            transform.SetParent(null);          //Убираем из директории в пуле
        }
        #endregion

        #region Убираем ИО в пул
        /// <summary>Возвращение ИО обратно в пул</summary>
        protected void ReturnToPool()
        {
            transform.localPosition = Vector3.zero;         //обнуляем текущее положение
            transform.localRotation = Quaternion.identity;  //обнуляем угол наклона и поворота
            gameObject.SetActive(false);                    //выкл. ИО
            transform.SetParent(RotPool);                   //в иерархии, помещаем ИО в директорию

            //если пул не существует,
            if (!RotPool)
            {// то 
                Destroy(gameObject);    //уничтожаем ИО Enemy
            }
        }
        #endregion
    }

    #region
    #endregion

}
