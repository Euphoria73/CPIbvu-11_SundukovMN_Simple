namespace ProjectContainerShip.MovementStrategy;

/// <summary>
/// Интерфейс для перемещения обьекта
/// </summary>
public interface IMoveableObject
{
    /// <summary>
    /// Получение координаты обьекта
    /// </summary>
    ObjectParameters? GetObjectPosition {  get; }

    /// <summary>
    /// Шаг обьекта
    /// </summary>
    int GetStep {  get; }

    /// <summary>
    /// Попытка переместить обьект в указанном напрвлении
    /// </summary>
    /// <param name="direction">Направление</param>
    /// <returns>true - обьект перемещен, false - перемещение невозможно</returns>
    bool TryMoveObject(MovementDirection direction);
}
