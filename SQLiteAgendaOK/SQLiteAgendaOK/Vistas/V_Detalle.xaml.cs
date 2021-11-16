using System;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLiteAgendaOK.Tablas;
using SQLiteAgendaOK.Datos;
using SQLite;
using System.IO;
namespace SQLiteAgendaOK.Vistas

{
[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class V_Detalle : ContentPage
{
    public int IdSeleccionado;
    public string NomSeleccionado, ApSeleccionado, TelSeleccionado;
    private SQLiteAsyncConnection conexion;
    IEnumerable<T_Contacto> ResultadoDelete;
    IEnumerable<T_Contacto> ResultadoUpdate;
    public V_Detalle(int id, string nom, string ap, string tel)
    {
        InitializeComponent();
        conexion = DependencyService.Get<ISQLiteDB>().GetConnection();
        IdSeleccionado = id;
        NomSeleccionado = nom;
        ApSeleccionado = ap;
        TelSeleccionado = tel;
        btn_actualizar.Clicked += Btn_actualizar_Clicked;
        btn_eliminar.Clicked += Btn_eliminar_Clicked;
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        lblMensaje.Text = " ID :" + IdSeleccionado;
        txtNombre.Text = NomSeleccionado;
        txtApellidos.Text = ApSeleccionado;
        txtTelefono.Text = TelSeleccionado;
    }
    private void Btn_eliminar_Clicked(object sender, EventArgs e)
    {
        var rutaBD = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
        "AgendaSQLite.db3");
        var db = new SQLiteConnection(rutaBD);
        ResultadoDelete = Delete(db, IdSeleccionado);
        DisplayAlert("Confirmación", "El contacto se eliminó correctamente", "OK");
        Limpiar();
    }
    private void Btn_actualizar_Clicked(object sender, EventArgs e)
    {
        var rutaBD = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
        "AgendaSQLite.db3");
        var db = new SQLiteConnection(rutaBD);
        ResultadoUpdate = Update(db, txtNombre.Text, txtApellidos.Text, txtTelefono.Text,
        IdSeleccionado);
        DisplayAlert("Confirmación", "El contacto se actualizó correctamente", "OK");
    }
    public static IEnumerable<T_Contacto> Delete(SQLiteConnection db, int id)
    {
        return db.Query<T_Contacto>("DELETE FROM T_Contacto where Id = ?", id);
    }
    public static IEnumerable<T_Contacto> Update(SQLiteConnection db, string nombre, string
    apellidos, string telefono, int id)
    {
        return db.Query<T_Contacto>("UPDATE T_Contacto SET Nombre = ?, Apellidos = ?, Telefono = ?where Id = ? ", nombre, apellidos, telefono, id);
    }
    public void Limpiar()
    {
        lblMensaje.Text = "";
        txtNombre.Text = "";

        txtApellidos.Text = "";
        txtTelefono.Text = "";
        }
    }
}
