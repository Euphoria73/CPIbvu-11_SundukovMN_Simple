using ProjectContainerShip.Drawnings;

namespace ProjectContainerShip;

public partial class FormContainerShip : Form
{
    /// <summary>
    /// Вызов класса прорисовки сущности "Контейнеровоз"
    /// </summary>
    private DrawningShip? _drawningShip;
    public FormContainerShip()
    {
        InitializeComponent();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="type"></param>
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
    /// Отображение сущности на экране
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

    
}
