namespace ProjectContainerShip.Entities;

/// <summary>
/// Класс-сущность "Контейнеровоз"
/// </summary>
public class EntityConteinerShip : EntityShip
{
    /// <summary>
    /// Цвет дополнительных элементов
    /// </summary>
    public Color AdditionalColor { get; private set; }

    /// <summary>
    /// Наличие контейнеров (опция)
    /// </summary>
    public bool Containers { get; private set; }

    /// <summary>
    /// Наличие 2 ряда контейнеров (опция)
    /// </summary>
    public bool FloorContainers { get; private set; }

    /// <summary>
    /// Наличие крана (опция)
    /// </summary>
    public bool Crane { get; private set; }

    /// <summary>
    /// Инициализация  полей обьекта-класса контейнеровоза
    /// </summary>
    /// <param name="speed">Скорость контейнеровоза</param>
    /// <param name="weight">Вес контейнеровоза</param>
    /// <param name="bodyColor">Цвет контейнеровоза</param>
    /// <param name="additionalColor">Цвет дополнительных элементов</param>
    /// <param name="containers">Наличие контейнеров (опция)</param>
    /// <param name="floorContainers">Наличие 2 ряда контейнеров (опция)</param>
    /// <param name="crane">Наличие крана (опция)</param>
    public EntityConteinerShip(int speed, double weight, Color bodyColor, Color additionalColor, bool containers, bool floorContainers, bool crane) : base(speed, weight, bodyColor)
    {
        AdditionalColor = additionalColor;
        Containers = containers;
        FloorContainers = floorContainers;
        Crane = crane;
    }
}
