namespace ProjectContainerShip.Entities
{
    /// <summary>
    /// Класс-сущность "Корабль"
    /// </summary>
    public class EntityShip
    {
        /// <summary>
        /// Скорость корабля
        /// </summary>
        public int Speed { get; private set; }

        /// <summary>
        /// Вес корабля
        /// </summary>
        public double Weight { get; private set; }

        /// <summary>
        /// Цвет корабля
        /// </summary>
        public Color BodyColor { get; private set; }

        /// <summary>
        /// Перемещение сущности по карте
        /// </summary>
        public double Step => Speed * 100 / Weight;

        /// <summary>
        /// Конструктор сущности
        /// </summary>
        /// <param name="speed">Скорость корабля</param>
        /// <param name="weight">Вес корабля</param>
        /// <param name="bodyColor">Цвет корабля</param>
        public EntityShip(int speed, double weight, Color bodyColor)
        {
            Speed = speed;
            Weight = weight;
            BodyColor = bodyColor;
        }
    }
}
