namespace TDMPW_411_3P_PR01;

using System.ComponentModel;

public partial class MainPage : ContentPage, INotifyPropertyChanged
{
    string question = "";
    string answer = "";
    int index ;
    private string spotlight = "----";
    private string message = "MENSAJE";
    int mistakes = 0;
    int tries = 0;
    int puntaje = 0;
    int puntajeParaGanar = 3;
    int maxWrong = 3;
    private string gameStatus = "INICIADO";
    private string txtPuntaje = "0";
    private string currentImage = "https://s1.significados.com/foto/earth-11015-1920-41.jpg";

    public string Spotlight
    {
        get => spotlight; set
        {
            spotlight = value;
            OnPropertyChanged();
        }
    }
    public string GameStatus
    {
        get => gameStatus; set
        {
            gameStatus = value;
            OnPropertyChanged();
        }
    }
    public string TxtPuntaje
    {
        get => txtPuntaje; set
        {
            txtPuntaje = value;
            OnPropertyChanged();
        }
    }
    public string Message
    {
        get => message; set
        {
            message = value;
            OnPropertyChanged();
        }
    }
    public string CurrentImage
    {
        get => currentImage; set
        {
            currentImage = value;
            OnPropertyChanged();
        }
    }

    List<string> preguntas = new List<string>()
    {
        "¿Cuál es el océano más grande del mundo?",
        "¿Cuál es el metal más abundante en la corteza terrestre?",
        "¿Cuál es el país más poblado del mundo?",
        "¿Cuál es el elemento químico con el símbolo Hg?",
        "¿Cuál es la capital de Italia?",
        "¿Cuál es el río más largo del mundo?",
        "¿Cuál es el animal más grande del planeta?",
        "¿Cuál es el símbolo químico del oro?",
        "¿Cuál es el planeta más cercano al Sol?",
        "¿Cuál es el país más grande del mundo?"
    };
    List<string> respuestas = new List<string>()
    {
        "pacifico",
        "aluminio",
        "china",
        "mercurio",
        "roma",
        "amazonas",
        "ballena azul",
        "au",
        "mercurio",
        "rusia"
    };
    List<string> imagenes = new List<string>()
    {
        "https://www.fundacionaquae.org/wp-content/uploads/2014/08/oceanos2-1024x683.jpg.webp",
        "https://federalmetals.ca/wp-content/uploads/2022/04/Assorted-metal-1.jpg",
        "https://www.cepal.org/sites/default/files/news/images/poblacion.png?timestamp=1668449492",
        "https://dequimica.com//imagenes/teoria/quimica-general.jpg",
        "https://blog.hoteleus.com/wp-content/uploads/2022/07/caleb-miller-0Bs3et8FYyg-unsplash-scaled.jpg",
        "https://www.iagua.es/sites/default/files/rio_portada.jpg",
        "https://cdn0.ecologiaverde.com/es/posts/7/7/4/animales_que_viven_en_el_campo_3477_orig.jpg",
        "https://concepto.de/wp-content/uploads/2023/01/oro-mineral-metal-elemento.jpg",
        "https://upload.wikimedia.org/wikipedia/commons/thumb/b/b4/The_Sun_by_the_Atmospheric_Imaging_Assembly_of_NASA%27s_Solar_Dynamics_Observatory_-_20100819.jpg/312px-The_Sun_by_the_Atmospheric_Imaging_Assembly_of_NASA%27s_Solar_Dynamics_Observatory_-_20100819.jpg",
        "https://s1.significados.com/foto/earth-11015-1920-41.jpg"
    };
    List<string> preguntasRepaldo = new List<string>()
    {
        "¿Cuál es el océano más grande del mundo?",
        "¿Cuál es el metal más abundante en la corteza terrestre?",
        "¿Cuál es el país más poblado del mundo?",
        "¿Cuál es el elemento químico con el símbolo Hg?",
        "¿Cuál es la capital de Italia?",
        "¿Cuál es el río más largo del mundo?",
        "¿Cuál es el animal más grande del planeta?",
        "¿Cuál es el símbolo químico del oro?",
        "¿Cuál es el planeta más cercano al Sol?",
        "¿Cuál es el país más grande del mundo?"
    };
    List<string> respuestasRepaldo = new List<string>()
    {
        "pacifico",
        "aluminio",
        "china",
        "mercurio",
        "roma",
        "amazonas",
        "ballena azul",
        "au",
        "mercurio",
        "rusia"
    };
    List<string> imagenesRepaldo = new List<string>()
    {
        "https://www.fundacionaquae.org/wp-content/uploads/2014/08/oceanos2-1024x683.jpg.webp",
        "https://federalmetals.ca/wp-content/uploads/2022/04/Assorted-metal-1.jpg",
        "https://www.cepal.org/sites/default/files/news/images/poblacion.png?timestamp=1668449492",
        "https://dequimica.com//imagenes/teoria/quimica-general.jpg",
        "https://blog.hoteleus.com/wp-content/uploads/2022/07/caleb-miller-0Bs3et8FYyg-unsplash-scaled.jpg",
        "https://www.iagua.es/sites/default/files/rio_portada.jpg",
        "https://cdn0.ecologiaverde.com/es/posts/7/7/4/animales_que_viven_en_el_campo_3477_orig.jpg",
        "https://concepto.de/wp-content/uploads/2023/01/oro-mineral-metal-elemento.jpg",
        "https://upload.wikimedia.org/wikipedia/commons/thumb/b/b4/The_Sun_by_the_Atmospheric_Imaging_Assembly_of_NASA%27s_Solar_Dynamics_Observatory_-_20100819.jpg/312px-The_Sun_by_the_Atmospheric_Imaging_Assembly_of_NASA%27s_Solar_Dynamics_Observatory_-_20100819.jpg",
        "https://s1.significados.com/foto/earth-11015-1920-41.jpg"
    };

    public MainPage()
    {
        InitializeComponent();
        BindingContext = this;
        UpdateScreen();
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        mistakes = 0;
        puntaje = 0;

        Message = "";
        preguntas = preguntasRepaldo;
        respuestas = respuestasRepaldo;
        imagenes = imagenesRepaldo;
        txtAnswer.IsEnabled = true;
        juan.IsEnabled = true;
        pickQuestion();
        UpdateStatus();
        
    }
    private void pickQuestion()
    {
        index = new Random().Next(0, preguntas.Count);
        question = preguntas[index];
        answer = respuestas[index];
        CurrentImage = imagenes[index];
        Spotlight = question;
    }

    private void CheckIfLost()
    {
        if (mistakes == maxWrong)
        {
            Message = "Perdiste";
            disableLetters();
        }
    }
    private void disableLetters()
    {
        txtAnswer.IsEnabled = false;
        juan.IsEnabled = false;
        CurrentImage = "https://i.pinimg.com/236x/26/19/4c/26194c00e9e3cb6b02c357cae56df413.jpg";

    }
    private void enableLetters()
    {
        txtAnswer.IsEnabled = false;
        juan.IsEnabled = false;
        CurrentImage = "https://ak.picdn.net/contributors/498865/avatars/thumb.jpg?t=5617058";
    }
    private void CheckIfGameWon()
    {
        if (puntaje == puntajeParaGanar)
        {
            Message = "Ganaste";
            enableLetters();
        }
    }
    private void UpdateStatus()
    {
        GameStatus = $"Errores: {mistakes} de {maxWrong}";
        TxtPuntaje = $"Puntaje: {puntaje}";
        CheckIfGameWon();
        CheckIfLost();
    }

    private void UpdateScreen()
    {
        UpdateStatus();
        if (txtAnswer.IsEnabled)
        {
            Message = "";
            pickQuestion();
        }
        else
        {
            Spotlight = "";
        }
    }

    private void Button_Clicked_1(object sender, EventArgs e)
    {
        var temp = txtAnswer.Text;
        if (temp == null)
        {
            temp = "null";
        }
        if (tries < 1)
        {
            if(temp.ToLower() == answer)
            {
                puntaje++;
                Message = "Correcto";
                txtAnswer.Text = "";
                RemoveQuestion();
                UpdateScreen();
                this.DisplayAlert("", "Correcto", "ok");
                return;
                
            }
            else
            {
                tries++;
                Message = "Incorrecto";
                this.DisplayAlert("", "Incorrecto", "ok");
                return;
                
            }
        }
        mistakes++;
        RemoveQuestion();
        txtAnswer.Text = "";
        UpdateScreen();
        this.DisplayAlert("", "Incorrecto", "ok");
        return;
    }
    private void RemoveQuestion()
    {
        tries = 0;
        preguntas.RemoveAt(index);
        respuestas.RemoveAt(index);
        imagenes.RemoveAt(index);
    }
}

