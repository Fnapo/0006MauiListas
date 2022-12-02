
using LibreriaListaCompra.Modelos;
using LibreriaListaCompra.VistaModelo;

namespace LibreriaListaCompra.Vistas;

public partial class ListaCompra : ContentPage
{
	private VMListaCompra comprados = new VMListaCompra();
	private ArticuloComprado nuevoArticulo;
	public List<ArticuloComprado> ListaCompraPryca { get; private set; }
	private int indiceElegido = -1;

	public ListaCompra()
	{
		ListaCompraPryca = comprados.ListaCompraPryca;
		nuevoArticulo = null;
		InitializeComponent();
		vistaLista.SelectedItem = null;

		//AsignarTexto();
		//vistaLista.BindingContext = comprados;
	}

	protected override void OnAppearing()
	{
		base.OnAppearing();

		nuevoArticulo = ComprarArticulo.NuevoArticulo;
		if (nuevoArticulo != null)
		{
			int idArticulo = BuscarNuevoId();

			ComprarArticulo.NuevoArticulo = null;
			nuevoArticulo.IDArticulo = idArticulo;
			RefrescarVistaLista(AddNuevo, CentrarNuevo);
			//AsignarTexto();
		}
	}

	private void RefrescarVistaLista(Action AccionPrimera, Action AccionSegunda)
	{
		vistaLista.BeginRefresh();
		AccionPrimera();
		vistaLista.ItemsSource = null;
		vistaLista.ItemsSource = ListaCompraPryca;
		AccionSegunda();
		vistaLista.EndRefresh();
	}

	private void AddNuevo()
	{
		ListaCompraPryca.Add(nuevoArticulo);
	}

	private void CentrarNuevo()
	{
		vistaLista.SelectedItem = nuevoArticulo;
		vistaLista.ScrollTo(nuevoArticulo, ScrollToPosition.MakeVisible, true);
	}

	private int BuscarNuevoId()
	{
		if (ListaCompraPryca.Count == 0)
		{
			return 0;
		}

		return ListaCompraPryca[ListaCompraPryca.Count - 1].IDArticulo + 1;
	}

	private void ItemElegido(object sender, SelectedItemChangedEventArgs e)
	{
		indiceElegido = e.SelectedItemIndex;
		AsignarTexto();
	}

	private void AsignarTexto()
	{
		//Elegido = comprados.IndiceSeleccionado;
		labelElegido.Text = $"{indiceElegido}";
	}

	private void BorrarItem(object sender, EventArgs e)
	{
		if (indiceElegido >= 0)
		{
			RefrescarVistaLista(BorradoItem, AnularSeleccion);
		}
	}

	private void BorradoItem()
	{
		ListaCompraPryca.RemoveAt(indiceElegido);
	}

	private void AnularSeleccion()
	{
		vistaLista.SelectedItem = null;
	}

	private async void AbrirComprarArticulo(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new ComprarArticulo(), true);
	}
}