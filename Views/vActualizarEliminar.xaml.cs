
namespace dcarrascoT6.Views;

public partial class vActualizarEliminar : ContentPage
{
	public vActualizarEliminar(Models.Estudiante datos)
	{
		InitializeComponent();
        txtCodigo.Text = datos.codigo.ToString();
        txtNombre.Text = datos.nombre.ToString();
        txtApellido.Text = datos.apellido.ToString();
        txtEdad.Text = datos.edad.ToString();
	}

    private async void btnActualizar_Clicked(object sender, EventArgs e)
    {
        try
        {
            string url =
                "http://192.168.56.1/ws_estudiante/post.php" +
                "?codigo=" + Uri.EscapeDataString(txtCodigo.Text ?? "") +
                "&nombre=" + Uri.EscapeDataString(txtNombre.Text ?? "") +
                "&apellido=" + Uri.EscapeDataString(txtApellido.Text ?? "") +
                "&edad=" + Uri.EscapeDataString(txtEdad.Text ?? "");

            using HttpClient cliente = new HttpClient();
            using var respuesta = await cliente.PutAsync(url, new StringContent(""));

            respuesta.EnsureSuccessStatusCode();

            await DisplayAlert("Aviso", "Estudiante actualizado.", "OK");
            await Navigation.PushAsync(new vEstudiante());
        }
        catch (Exception ex)
        {
            await DisplayAlertAsync("Alerta", "Error: " + ex.Message, "OK");
        }
    }

    private async void btnEliminar_Clicked(object sender, EventArgs e)
    {
        try
        {
            string url =
                "http://192.168.56.1/ws_estudiante/post.php" +
                "?codigo=" + Uri.EscapeDataString(txtCodigo.Text ?? "");

            using HttpClient cliente = new HttpClient();
            using var respuesta = await cliente.DeleteAsync(url);

            respuesta.EnsureSuccessStatusCode();

            await DisplayAlertAsync("Aviso", "Estudiante eliminado.", "OK");
            await Navigation.PushAsync(new vEstudiante());
        }
        catch (Exception ex)
        {
            await DisplayAlertAsync("Alerta", "Error: " + ex.Message, "OK");
        }
    }
}