namespace suma4030349
{
    public partial class MainPage : ContentPage
    {
        private readonly LocalDbService _dbService;
        private int _editResultadoId;

        public MainPage(LocalDbService dbService)
        {
            InitializeComponent();
            _dbService = dbService;
            Task.Run(async () => listview.ItemsSource = await _dbService.GetResultado());
        }


        private async void sumarBtn_Clicked(object sender, EventArgs e)
        {
            if (_editResultadoId == 0)
            {

                int N1 = Convert.ToInt32(Entryprimernumero.Text);
                int N2 = Convert.ToInt32(Entrysegundonumero.Text);
                int resultado = N1 + N2;


                // Mostrar el resultado en el label
                labelresultado.Text = resultado.ToString();

                //agrega cliente
                await _dbService.Create(new Resultado
                {
                    Numero1 = Entryprimernumero.Text,
                    Numero2 = Entrysegundonumero.Text,
                    Suma = labelresultado.Text
                });
            }
            else
            {
                int N1 = Convert.ToInt32(Entryprimernumero.Text);
                int N2 = Convert.ToInt32(Entrysegundonumero.Text);
                int resultado = N1 + N2;


                // Mostrar el resultado en el label
                labelresultado.Text = resultado.ToString();

                //Edita cliente
                await _dbService.Update(new Resultado
                {
                    Id = _editResultadoId,
                    Numero1 = Entryprimernumero.Text,
                    Numero2 = Entrysegundonumero.Text,
                    Suma = labelresultado.Text
                });
                _editResultadoId = 0;
            }
            Entryprimernumero.Text = string.Empty;
            Entrysegundonumero.Text = string.Empty;
            labelresultado.Text = string.Empty;

            listview.ItemsSource = await _dbService.GetResultado();
        }

        private async void listview_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var resultado = (Resultado)e.Item;
            var action = await DisplayActionSheet("Action", "Cancel", null, "Edit", "Delete");

            switch (action)
            {
                case "Edit":
                    _editResultadoId = resultado.Id;
                    Entryprimernumero.Text = resultado.Numero1;
                    Entrysegundonumero.Text = resultado.Numero2;
                    labelresultado.Text = resultado.Suma;
                    break;

                case "Delete":
                    await _dbService.Delete(resultado);
                    listview.ItemsSource = await _dbService.GetResultado();
                    break;
            }
        }
    }

}
