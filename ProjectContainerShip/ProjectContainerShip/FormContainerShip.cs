using ProjectContainerShip.Drawnings;
using ProjectContainerShip.MovementStrategy;

namespace ProjectContainerShip;

public partial class FormContainerShip : Form
{
    /// <summary>
    /// Вызов класса прорисовки сущности "Контейнеровоз"
    /// </summary>
    private DrawningShip? _drawningShip;

    /// <summary>
    /// Стратегия перемещения
    /// </summary>
    private AbstractStrategy? _strategy;

    /// <summary>
    /// Инициализация формы
    /// </summary>
    public FormContainerShip()
    {
        InitializeComponent();
        _strategy = null;
    }

    /// <summary>
    /// Создание обьекта
    /// </summary>
    /// <param name="type">DrawningShip или DrawningContainerShip</param>
    private void CreateObject(string type)
    {
        Random rnd = new();
        switch (type)
        {
            case nameof(DrawningShip):
                _drawningShip = new DrawningShip(rnd.Next(100, 300), rnd.Next(1000, 3000),
            Color.FromArgb(rnd.Next(0, 256), rnd.Next(0, 256), rnd.Next(0, 256)));
                break;
            case nameof(DrawningContainerShip):
                _drawningShip = new DrawningContainerShip(rnd.Next(100, 300), rnd.Next(1000, 3000),
           Color.FromArgb(rnd.Next(0, 256), rnd.Next(0, 256), rnd.Next(0, 256)),
           Color.FromArgb(rnd.Next(0, 256), rnd.Next(0, 256), rnd.Next(0, 256)),
           Convert.ToBoolean(rnd.Next(0, 2)), Convert.ToBoolean(rnd.Next(0, 2)), Convert.ToBoolean(rnd.Next(0, 2)));
                break;
            default:
                return;
        }

        _drawningShip.SetPictureSize(pictureBoxContainerShip.Width, pictureBoxContainerShip.Height);
        _drawningShip.SetPosition(rnd.Next(10, 100), rnd.Next(10, 100));
        _strategy = null;
        comboBoxStrategy.Enabled = true;

        Draw();
    }
    /// <summary>
    /// Работа кнопки "Создать контейнеровоз"
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ButtonCreateContainerShip_Click(object sender, EventArgs e) => CreateObject(nameof(DrawningContainerShip));

    /// <summary>
    /// Работа кнопки "Создать корабль"
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ButtonCreateShip_Click(object sender, EventArgs e) => CreateObject(nameof(DrawningShip));

    /// <summary>
    /// Действие при нажатии кнопки перемещения
    /// </summary>
    /// <param name="sender">кнопка перемещения</param>
    /// <param name="e"></param>
    private void ButtonMove_Click(object sender, EventArgs e)
    {
        if (_drawningShip == null)
        {
            return;
        }
        string buttonName = ((Button)sender)?.Name ?? string.Empty;
        bool result = false;
        switch (buttonName)
        {
            case "buttonUp":
                result = _drawningShip.MoveShip(DirectionType.Up);
                break;
            case "buttonDown":
                result = _drawningShip.MoveShip(DirectionType.Down);
                break;
            case "buttonLeft":
                result = _drawningShip.MoveShip(DirectionType.Left);
                break;
            case "buttonRight":
                result = _drawningShip.MoveShip(DirectionType.Right);
                break;
        }

        if (result)
        {
            Draw();
        }
    }
    /// <summary>
    /// Прорисовка обьекта на экране
    /// </summary>
    private void Draw()
    {
        if (_drawningShip == null)
        {
            return;
        }

        Bitmap bmp = new(pictureBoxContainerShip.Width, pictureBoxContainerShip.Height);
        Graphics gr = Graphics.FromImage(bmp);
        _drawningShip.DrawShip(gr);
        pictureBoxContainerShip.Image = bmp;
    }

    /// <summary>
    /// Шаг обьекта
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ButtonStrategyStep_Click(object sender, EventArgs e)
    {
        if (_drawningShip == null)
        {
            return;
        }

        if (comboBoxStrategy.Enabled)
        {
            _strategy = comboBoxStrategy.SelectedItem switch
            {
                "К центру" => new MoveToCenter(),
                "К краю" => new MoveToBorder(),
                _ => null
            };
            if (_strategy == null)
            {
                return;
            }
            _strategy.SetData(new MoveableShip(_drawningShip), pictureBoxContainerShip.Width, pictureBoxContainerShip.Height);
        }

        if (_strategy == null)
        {
            return;
        }
        comboBoxStrategy.Enabled = false;
        _strategy.MakeStep();
        Draw();

        if (_strategy.GetStatus() == StrategyStatus.Finish)
        {
            comboBoxStrategy.Enabled = true;
            _strategy = null;
        }
    }   
}
