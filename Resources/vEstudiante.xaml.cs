using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace dcarrascoT6.Resources;

public partial class vEstudiante : ContentPage
{
    private const string Url = "http://192.168.56.1:80/ws_estudiante/estudiante_ws.php";
    private readonly HttpClient cliente = new HttpClient();
    private ObservableCollection<Models.Estudiante> estud;
    public vEstudiante()
    {
        InitializeComponent();
        Obtener();
    }

    public async void Obtener()
    {
        var content = await cliente.GetStringAsync(Url);
        List<Models.Estudiante> mostrarEst =
            JsonConvert.DeserializeObject<List<Models.Estudiante>>(content);

        estud = new ObservableCollection<Models.Estudiante>(mostrarEst);
        listaEstudiantes.ItemsSource = estud;
    }
}