using UnityEngine;

namespace Asteroids.Builder
{
    /// <summary>
    /// ����� ��� �������� ������� ����� ���������
    /// </summary>
    internal class GameObjectBuilder
    {
        protected GameObject _gameObject;

        #region ������������
        public GameObjectBuilder() => _gameObject = new GameObject();
        protected GameObjectBuilder(GameObject gameObject) => _gameObject = gameObject;
        #endregion

        #region ������������
        /// <summary>��� ������ Visual �������� ��, � �-��� ����� �������� ��������</summary>
        public GameObjectVisualBuilder Visual => new GameObjectVisualBuilder(_gameObject);

        /// <summary>��� ������ Physics �������� ��, �-��� ����� �������� � ������� (Ƹ���������, ���������)</summary>
        public GameObjectPhysicsBuilder Physics => new GameObjectPhysicsBuilder(_gameObject);
        #endregion

        public static implicit operator GameObject(GameObjectBuilder builder)
        {
            return builder._gameObject;
        }
    }
}
