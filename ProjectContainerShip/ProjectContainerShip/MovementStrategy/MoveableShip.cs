using ProjectContainerShip.Drawnings;

namespace ProjectContainerShip.MovementStrategy;

/// <summary>
/// Класс-реализация IMoveableObject с ипользованием DrawningShip
/// </summary>
public class MoveableShip : IMoveableObject
{
    /// <summary>
    /// Поле-обьект класса DrawningShip или его наследника
    /// </summary>
    private readonly DrawningShip? _ship;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="drawningShip">обьект класса DrawningShip</param>
    public MoveableShip(DrawningShip ship)
    {
        _ship = ship;
    }

    public ObjectParameters? GetObjectPosition
    {
        get
        {
            if (_ship == null || _ship.EntityShip == null || !_ship.GetPosX.HasValue || !_ship.GetPosY.HasValue)
            {
                return null;
            }
            return new ObjectParameters(_ship.GetPosX.Value, _ship.GetPosY.Value, _ship.GetWidth, _ship.GetHeight);
        }
    }

    public int GetStep => (int)(_ship?.EntityShip?.Step ?? 0);

    /// <summary>
    /// Конвертация MovementDirection в DirectionType
    /// </summary>
    /// <param name="direction">MovementDirection</param>
    /// <returns>DirectionType</returns>
    private static DirectionType GetDirectionType(MovementDirection direction)
    {
        return direction switch
        {
            MovementDirection.Left => DirectionType.Left,
            MovementDirection.Right => DirectionType.Right,
            MovementDirection.Up => DirectionType.Up,
            MovementDirection.Down => DirectionType.Down,
            _ => DirectionType.Unknown
        };
    }

    public bool TryMoveObject(MovementDirection direction)
    {
        if (_ship == null || _ship.EntityShip == null)
        {
            return false;
        }
        return _ship.MoveShip(GetDirectionType(direction));
    }
}
