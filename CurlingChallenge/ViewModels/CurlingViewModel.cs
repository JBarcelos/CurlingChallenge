using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CurlingChallenge.Domain.Curling;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CurlingChallenge.ViewModels
{
    public partial class CurlingViewModel : ObservableValidator
    {
        private const string NumberRegex = @"^([1-9][0-9]+)?$";

        int? _shapes;
        int? _size;
        string _textOutput;
        Dictionary<string, string> _errors;
        ICurling _curling;

        public delegate void InvalidateGraphics();
        public event InvalidateGraphics InvalidateGraphicsEvent;
        
        public RelayCommand SimulateCommand
        {
            get;
            private set;
        }

        public ICurling Curling
        {
            get => _curling;
            set => SetProperty(ref _curling, value);
        }
        public ICurling[] CurlingOptions { get; }
        public CurlingRenderer Renderer { get; private set; }

        public string TextOutput
        {
            get => _textOutput;
            set => SetProperty(ref _textOutput, value);
        }

        [Required(ErrorMessage = "Please enter a valid number of shapes.")]
        [Range(1, 1000, ErrorMessage = "Number of shapes out of range.")]
        public int? Shapes
        {
            get => _shapes;
            set => SetProperty(ref _shapes, value);
        }

        [Required(ErrorMessage = "Please enter a valid shape size.")]
        [Range(1, 1000, ErrorMessage = "Shape size out of range.")]
        public int? Size
        {
            get => _size;
            set => SetProperty(ref _size, value);
        }

        public Dictionary<string, string> Errors
        {
            get => _errors;
            set => SetProperty(ref _errors, value);
        }

        public CurlingViewModel()
        {
            CurlingOptions = new ICurling[]
            {
                new CircleCurling(),
                new SquareCurling(),
                new TriangleCurling(),
            };

            Curling = CurlingOptions.First();
            Renderer = new CurlingRenderer(Curling);

            SimulateCommand = new RelayCommand(
                ExecuteSimulateCommand,
                () => true);
        }

        public void ExecuteSimulateCommand()
        {
            ValidateAllProperties();
            UpdateErrors();

            if (HasErrors)
            {
                return;
            }

            Curling.Simulate(Size.Value, Shapes.Value);
            Renderer.Curling = Curling;
            TextOutput = string.Join(",", Renderer.Curling.Shapes.Select(shape => Math.Round(shape.Y, 10)));
            InvalidateGraphicsEvent?.Invoke();
        }

        private void UpdateErrors()
        {
            if(HasErrors)
            {
                Errors = GetErrors().ToDictionary(error => error.MemberNames.Single(), error => error.ErrorMessage);
            }
            else
            {
                Errors = new Dictionary<string, string>();
            }
        }
    }
}
