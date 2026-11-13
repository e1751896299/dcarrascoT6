using System.Net;

namespace dcarrascoT6.Views;

public partial class vAgregarEstudiante : ContentPage
{
	public vAgregarEstudiante()
	{
		InitializeComponent();
	}

    private void btnAgregar_Clicked(object sender, EventArgs e)
    {
        try
        {
            WebClient cliente = new WebClient(); //
            var parametros = new System.Collections.Specialized.NameValueCollection();//
            parametros.Add("nombre", txtNombre.Text);
            parametros.Add("apellido", txtApellido.Text);
            parametros.Add("edad", txtEdad.Text);

            cliente.UploadValues("http://192.168.56.1/ws_estudiante/post.php", "POST", parametros);
            Navigation.PushAsync(new vEstudiante());
        }
        catch (Exception ex)
        {
            DisplayAlertAsync("Alerta", "Error " + ex.Message, "OK");
        }
    }

    private void btnCancelar_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new vEstudiante());
    }
}