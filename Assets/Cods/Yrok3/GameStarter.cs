using UnityEngine;

namespace Yrok3
{
    /// <summary>
    /// Главная точка входа в программу
    /// </summary>
    internal sealed class GameStarter : MonoBehaviour
    {
        private void Start()
        {
            //делаем вызов на построение объекта
            Enemy.CreateAsteroidEnemy(new Health(100.0f, 100.0f));

            //делаем вызов фабрики астеройдов
            IEnemyFactory factory = new AsteroidFactory();
            factory.Create(new Health(100.0f, 100.0f));

            Enemy.Factory = factory;
            Enemy.Factory.Create(new Health(100.0f, 100.0f));
        }
    }
}
