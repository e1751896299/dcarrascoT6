using dcarrascoT6.Models;
using dcarrascoT6.Views;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace dcarrascoT6.Views;

public partial class vEstudiante : ContentPage
{
    private const string Url = "http://192.168.56.1/ws_estudiante/post.php";
    private readonly HttpClient cliente = new HttpClient();
    private ObservableCollection<Models.Estudiante> _estudiante;
    public vEstudiante()
    {
        InitializeComponent();
        MostrarEstudiante();
    }

    public async void MostrarEstudiante()
    {
        var content = await cliente.GetStringAsync(Url);
        List<Models.Estudiante> _mostrar =
            JsonConvert.DeserializeObject<List<Models.Estudiante>>(content);

        _estudiante = new ObservableCollection<Models.Estudiante>(_mostrar);
        listaEstudiantes.ItemsSource = _estudiante;
    }

    private void listaEstudiantes_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem is not Estudiante estudiante)
            return;

        Navigation.PushAsync(new vActualizarEliminar(estudiante));
        listaEstudiantes.SelectedItem = null;
    }
}