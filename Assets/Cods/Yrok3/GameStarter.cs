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
            Enemy.CreateAsteroidEnemy(new Health(100.0f, 100.0f));  //фабричный метод

            //делаем вызов фабрики астеройдов
            IEnemyFactory factory = new AsteroidFactory();          //"фабричный" класс
            factory.Create(new Health(100.0f, 100.0f));
            Enemy.Factory = factory;

            Enemy.Factory.Create(new Health(100.0f, 100.0f));

            #region Создание элементов управления для конкретной платформы одной командой, не задумываясь об реализации
            var platform = new PlatformFactory().Create(Application.platform);
            #endregion
            
            #region Пул объектов для группы врагов
            EnemyPool enemyPool = new EnemyPool(5);
            var enemy = enemyPool.GetEnemy("Asteroid");
            enemy.transform.position = Vector3.one;
            enemy.gameObject.SetActive(true);
            #endregion
        }
    }

    #region
    #endregion
}
