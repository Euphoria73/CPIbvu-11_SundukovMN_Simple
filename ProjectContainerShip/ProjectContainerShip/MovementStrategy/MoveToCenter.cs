namespace ProjectContainerShip.MovementStrategy;

/// <summary>
/// Класс отвечающий за стратегию перемещения в центр формы
/// </summary>
public class MoveToCenter : AbstractStrategy
{
    protected override bool IsTargetDestination()
    {
        ObjectParameters? objParams = GetObjectParameters;

        if (objParams == null)
        {
            return false;
        }

        return objParams.ObjectMiddleHorizontal - GetStep() <= FieldWidth / 2 && objParams.ObjectMiddleHorizontal + GetStep() >= FieldWidth / 2 &&
            objParams.OblectMiddleVertical - GetStep() <= FieldHeight / 2 && objParams.OblectMiddleVertical + GetStep() >= FieldHeight / 2;
    }

    protected override void MoveToTarget()
    {
        ObjectParameters? objParams = GetObjectParameters;

        if (objParams == null)
        {
            return;
        }
        
        int diffX = objParams.ObjectMiddleHorizontal - FieldWidth / 2;
        if(Math.Abs(diffX) > GetStep())
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

        int diffY = objParams.OblectMiddleVertical - FieldHeight / 2;
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
