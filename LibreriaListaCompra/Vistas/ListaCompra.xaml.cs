
using LibreriaListaCompra.Modelos;
using LibreriaListaCompra.VistaModelo;

namespace LibreriaListaCompra.Vistas;

public partial class ListaCompra : ContentPage
{
	private VMListaCompra comprados = new VMListaCompra();
	public List<ArticuloComprado> ListaCompraPryca { get; private set; } 
	//private int Elegido { get; set; }

	public ListaCompra()
	{
		ListaCompraPryca = comprados.ListaCompraPryca;
		InitializeComponent();

		AsignarTexto();
		//vistaLista.BindingContext = comprados;
	}

	private void ItemElegido(object sender, SelectedItemChangedEventArgs e)
	{
		comprados.IndiceSeleccionado = e.SelectedItemIndex;
		AsignarTexto();
	}

	private void AsignarTexto()
	{
		//Elegido = comprados.IndiceSeleccionado;
		labelElegido.Text = $"{comprados.IndiceSeleccionado}";
	}

	private void BorrarItem(object sender, EventArgs e)
	{
		if (comprados.IndiceSeleccionado >= 0)
		{
			vistaLista.BeginRefresh();
			comprados.BorrarItem();
			vistaLista.ItemsSource = null;
			vistaLista.ItemsSource = comprados.ListaCompraPryca;
			vistaLista.EndRefresh();
			AsignarTexto();
		}
	}
}