
using LibreriaListaCompra.VistaModelo;

namespace LibreriaListaCompra.Vistas;

public partial class ListaCompra : ContentPage
{
	private VMListaCompra comprados = new VMListaCompra();
	private int Elegido { get; set; }

	public ListaCompra()
	{
		InitializeComponent();

		AsignarTexto();
		vistaLista.BindingContext = comprados;
	}

	private void ItemElegido(object sender, SelectedItemChangedEventArgs e)
	{
		comprados.IndiceSeleccionado = e.SelectedItemIndex;
		AsignarTexto();
	}

	private void AsignarTexto()
	{
		Elegido = comprados.IndiceSeleccionado;
		labelElegido.Text = $"{Elegido}";
	}
}