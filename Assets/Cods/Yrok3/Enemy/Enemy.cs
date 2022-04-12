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
        public Health Health { get; private set; }
        private const string PREFAB_ASTEROID = "Enemy/Asteroid";    //убираем все строковые переменные в константы

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
    }

    #region
    #endregion

}
