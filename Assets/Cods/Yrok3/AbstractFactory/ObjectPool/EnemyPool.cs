using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Yrok3
{
    /// <summary>Пулл Объектов </summary>
    internal sealed class EnemyPool
    {
        private readonly Dictionary<string, HashSet<Enemy>> _enemyPool; //создаём словарь объектов Enemy
        private readonly int _capacityPool; //максимальный размер словаря
        private Transform _rootPool;        //Расположение пула в Иерархии
        private const string PREFAB_ASTEROID = "Enemy/Asteroid";    //убираем все строковые переменные в константы

        #region Конструктор
        public EnemyPool(int capacityPool)
        {
            _enemyPool = new Dictionary<string, HashSet<Enemy>>();
            _capacityPool = capacityPool;

            if (!_rootPool) //если пулл в иерархии не существует,
            {
                //то присвой в переменную новый ИО, у к-рого имя взято из NameManager
                _rootPool = new GameObject(NameManager.POOL_AMMUNITION).transform;
            }
        }
        #endregion

        #region Создание противника
        /// <summary>Создание противника</summary>
        /// <param name="type">Тип врага (Астеройд)</param>        
        public Enemy GetEnemy(string type)
        {
            Enemy result;
            switch (type)
            {
                case "Asteroid":
                    result = GetAsteroid(GetListEnemies(type));
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, "Не предусмотрен в программе");
            }
            return result;
        }
        #endregion

        private HashSet<Enemy> GetListEnemies(string type)
        {
            return _enemyPool.ContainsKey(type) ? _enemyPool[type] : _enemyPool[type] = new HashSet<Enemy>();
        }

        private Enemy GetAsteroid(HashSet<Enemy> enemies)
        {
            var enemy = enemies.FirstOrDefault(a => !a.gameObject.activeSelf);

            if (enemy == null)
            {
                var laser = Resources.Load<Asteroid>(PREFAB_ASTEROID);

                for (var i = 0; i < _capacityPool; i++)
                {
                    var instantiate = Object.Instantiate(laser);
                    ReturnToPool(instantiate.transform);
                    enemies.Add(instantiate);
                }
                GetAsteroid(enemies);
            }

            enemy = enemies.FirstOrDefault(a => !a.gameObject.activeSelf);
            return enemy;
        }

        #region Возвращение ИО обратно в пул
        /// <summary>Возвращение ИО обратно в пул</summary>
        private void ReturnToPool(Transform transform)
        {
            transform.localPosition = Vector3.zero;         //обнуляем текущее положение
            transform.localRotation = Quaternion.identity;  //обнуляем угол наклона и поворота
            transform.gameObject.SetActive(false);          //выкл. ИО
            transform.SetParent(_rootPool);                 //в иерархии, помещаем ИО в директорию
        }
        #endregion

        #region Удаление пула
        /// <summary>Удаление пула</summary>
        public void RemovePool()
        {
            Object.Destroy(_rootPool.gameObject);
        }
        #endregion
    }

    #region
    #endregion
}
