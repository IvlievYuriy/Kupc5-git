namespace Yrok3
{
    /// <summary>Интерфейс для фабрики Enemy</summary>
    internal interface IEnemyFactory
    {
        /// <summary>Создание объекта Enemy</summary>
        Enemy Create(Health hp);
    }
}
