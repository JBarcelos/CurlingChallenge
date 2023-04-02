using CurlingChallenge.Domain.Curling;
using CurlingChallenge.Domain.Shapes;
using CurlingChallenge.ViewModels;

namespace CurlingChallenge;

public partial class MainPage : ContentPage
{
    public MainPage()
	{
        InitializeComponent();

        (BindingContext as CurlingViewModel).InvalidateGraphicsEvent += () => graphicalOutput.Invalidate();
    }
}

