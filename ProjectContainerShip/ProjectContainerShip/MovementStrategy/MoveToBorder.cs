namespace ProjectContainerShip.MovementStrategy;

/// <summary>
/// Класс отвечающий за стратегию перемещения к краю формы
/// </summary>
public class MoveToBorder : AbstractStrategy
{
    protected override bool IsTargetDestination()
    {
        ObjectParameters? objParams = GetObjectParameters;

        if (objParams == null)
        {
            return false;
        }

        return objParams.RightBorder - GetStep() <= FieldWidth && objParams.RightBorder + GetStep() >= FieldWidth &&
            objParams.BottomBorder - GetStep() <= FieldHeight && objParams.BottomBorder + GetStep() >= FieldHeight;
    }

    protected override void MoveToTarget()
    {
        ObjectParameters? objParams = GetObjectParameters;

        if (objParams == null)
        {
            return;
        }

        int diffX = objParams.RightBorder - FieldWidth;
        if (Math.Abs(diffX) > GetStep())
        {
            if (diffX > 0)
            {
                MoveLeft();
            }
            else
            {
                MoveRight();
            }
        }

        int diffY = objParams.BottomBorder - FieldHeight;
        if (Math.Abs(diffY) > GetStep())
        {
            if (diffY > 0)
            {
                MoveUp();
            }
            else
            {
                MoveDown();
            }
        }
    }
}
