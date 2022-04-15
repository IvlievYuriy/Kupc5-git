using UnityEngine;

namespace Yrok3
{
    /// <summary>Фабрика Астеройдов</summary>
    internal sealed class AsteroidFactory : IEnemyFactory
    {
        private const string PREFAB_ASTEROID = "Enemy/Asteroid";    //убираем все строковые переменные в константы

        /// <summary>Создание объекта Enemy</summary>
        public Enemy Create(Health hp)
        {
            var enemy = Object.Instantiate(Resources.Load<Asteroid>(PREFAB_ASTEROID));

            enemy.DependencyInjectHealth(hp);   //Добавление Здоровья созданному астеройду

            return enemy;
        }
    }
}
