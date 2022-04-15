using UnityEngine;

namespace Yrok3
{
    /// <summary>
    /// ������� ����� ����� � ���������
    /// </summary>
    internal sealed class GameStarter : MonoBehaviour
    {
        private void Start()
        {
            //������ ����� �� ���������� �������
            Enemy.CreateAsteroidEnemy(new Health(100.0f, 100.0f));  //��������� �����

            //������ ����� ������� ����������
            IEnemyFactory factory = new AsteroidFactory();          //"���������" �����
            factory.Create(new Health(100.0f, 100.0f));
            Enemy.Factory = factory;

            Enemy.Factory.Create(new Health(100.0f, 100.0f));

            #region �������� ��������� ���������� ��� ���������� ��������� ����� ��������, �� ����������� �� ����������
            var platform = new PlatformFactory().Create(Application.platform);
            #endregion
            
            #region ��� �������� ��� ������ ������
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
