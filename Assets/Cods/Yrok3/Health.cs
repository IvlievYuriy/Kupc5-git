namespace Yrok3
{
    /// <summary>
    /// Класс для здоровья персонажа
    /// </summary>
    internal sealed class Health
    {
        #region Свойства
        public float Max { get; }                   //Здоровье максимальное
        public float Current { get; private set; }  //Здоровье текущее
        #endregion

        #region Конструктор
        public Health(float max, float current)
        {
            Max = max;
            Current = current;
        }
        #endregion

        #region Присвоение текущего значения Здоровья
        public void ChangeCurrentHealth(float hp)
        {
            Current = hp;
        }
        #endregion
    }

    #region
    #endregion

}
