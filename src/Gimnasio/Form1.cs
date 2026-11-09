using GimnasioController;
using GimnasioModels;

namespace Gimnasio;

public partial class Form1 : Form
{
    private readonly UsuarioController _controller;
    private readonly DataGridView _grid = new()
    {
        Dock = DockStyle.Fill,
        ReadOnly = true,
        AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
    };
    private readonly Button _btnCargar = new()
    {
        Text = "Cargar usuarios",
        Dock = DockStyle.Top,
        Height = 40
    };

    public Form1()
    {
        InitializeComponent();
        Text = "Gimnasio Fitness";

        string ruta = Path.Combine(AppContext.BaseDirectory, "Data", "usuarios.json");
        _controller = new UsuarioController(new FileHandler<UsuarioBasico>(), ruta);

        Controls.Add(_grid);
        Controls.Add(_btnCargar);
        _btnCargar.Click += BtnCargar_Click;
    }

    private void BtnCargar_Click(object? sender, EventArgs e)
    {
        try
        {
            _grid.DataSource = _controller.ObtenerUsuarios();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error");
        }
    }
}