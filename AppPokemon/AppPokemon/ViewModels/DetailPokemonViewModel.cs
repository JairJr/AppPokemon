using AppPokemon.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;

namespace AppPokemon.ViewModels
{
    public class DetailPokemonViewModel : INotifyPropertyChanged
    {
        private StackLayout _mainStackLayout;
        private PokemonAttrib _attrib;
                
        public DetailPokemonViewModel(StackLayout mainStackLayout, PokemonAttrib attrib)
        {
            _mainStackLayout = mainStackLayout;
            _attrib = attrib;
            _mainStackLayout.Children.Add(MostraPokemon());
        }

        private View MostraPokemon()
        {
            var mainLayout = new StackLayout() { Padding = 10 };

            var rnd = new Random();            
            int teste = rnd.Next(0, 7);
            if (!string.IsNullOrEmpty(_attrib.name) && teste >= 1)
            {
                mainLayout.Children.Clear();
                var nome = teste == 5 ? $"{_attrib.name} (Shiny)" : $"{_attrib.name} (Normal)";
                GetNewLabel($"Nome: {nome}");
                string tipo = "";
                for (int b = 0; b < _attrib.types.Count; b++)
                {
                    tipo = b < (_attrib.types.Count - 1)
                        ? tipo + _attrib.types[b].type.name.ToString() + ", "
                        : tipo + _attrib.types[b].type.name.ToString() + ".";
                }
                GetNewLabel($"Tipo: {tipo}");

                var pkmImage = teste == 5 ? _attrib.sprites.front_shiny : _attrib.sprites.front_default ;

                GetNewImage(pkmImage);
                string habilidades = "";
                for (int b = 0; b < _attrib.abilities.Count; b++)
                {
                    habilidades = b < (_attrib.abilities.Count - 1)
                        ? habilidades + _attrib.abilities[b].ability.name.ToString() + ", "
                        : habilidades + _attrib.abilities[b].ability.name.ToString() + ".";
                }
                GetNewLabel($"Habilidades: {habilidades}");
                string movimentos = "";
                foreach (Move move in _attrib.moves) 
                {
                    movimentos = movimentos + move.move.name.ToString() + ", ";
                }
                GetNewLabel($"Movimentos possiveis: {movimentos}");

                return mainLayout;
            }
            else
            {
                var habilidade = rnd.Next(0, (_attrib.abilities.Count - 1));
                mainLayout.Children.Clear();
                GetNewLabel($"O Pokemon {_attrib.name} usou a habilidade {_attrib.abilities[habilidade].ability.name } e fugiu !!");
                GetNewImage(_attrib.sprites.back_default);
                return mainLayout;
            }
        }        

        private void GetNewLabel(string text)
        {
            Label label = new Label
            {
                Text = text.Trim(),
                HorizontalOptions = LayoutOptions.FillAndExpand,
                HorizontalTextAlignment = TextAlignment.Start
            };
            this._mainStackLayout.Children.Add(label);
        }
        private void GetNewImage(string front_default)
        {
            Image image = new Image
            {
                Source = front_default,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HeightRequest = 220,
                WidthRequest = 220,
                
                Aspect = Aspect.AspectFit
            };
            this._mainStackLayout.Children.Add(image);
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string PropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
    }
}
