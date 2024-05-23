using Quiz.Gui.ViewModels;

namespace Quiz.Gui;

public partial class MainPage : ContentPage
{
    

    public MainPage(MainViewModel vw)
    {
        InitializeComponent();
        this.BindingContext = vw;
    }

    


}