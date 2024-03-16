﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bunit;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor;
using MyPokedex.Data;
using MyPokedex.Pages;
using MudBlazor.Services;
using Microsoft.JSInterop;

namespace TestMyPokedex 
{
    public class IntegrationTest
    {
        [Fact]
        public async Task TestSelectPoke()
        {
            var ctx = new TestContext();

            //Arrange
            ctx.Services.AddSingleton<Pokedex>();
            ctx.Services.AddMudServices();
            ctx.JSInterop.Mode = JSRuntimeMode.Loose;
            var cut = ctx.RenderComponent<Home>();
            //Act
            //Remplir l'input
            cut.Instance.selectedPokemon = new PokemonBase { Name = "bulbasaur", Url = "htrees" };
            //Click tu le bouton
            var buttonComponent = cut.FindComponent<MudButton>();
            buttonComponent.Find("button").Click();
            await Task.Delay(5000);
            cut.Render();
            //get the correct div
            var selectedComponent = cut.FindComponent<MudCard>();
            //Assert
            Assert.Equal("<div class=\"mud-paper mud-elevation-1 mud-card\" style=\"width:25%;\"><div class=\"d-flex align-items-center justify-content-center\"><h4 id=\"selectedName\" class=\"mud-typography mud-typography-h4 mud-success-text\">bulbasaur</h4></div>\r\n        <div style=\"display: flex; justify-content: space-between;\"><div><img src=\"https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/1.png\" alt=\"Sprite\" class=\"mud-image object-fill object-center\" /></div>\r\n            <div><img src=\"https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/shiny/1.png\" alt=\"Shiny Sprite\" class=\"mud-image object-fill object-center\" /></div></div>\r\n        <p id=\"selectedId\" class=\"mud-typography mud-typography-body1 cardText\">Number: 1</p>\r\n        <p class=\"mud-typography mud-typography-body1 cardText\">Level: 1</p>\r\n        <p class=\"mud-typography mud-typography-body1 cardText\">Type: grass/poison</p>\r\n        <p class=\"mud-typography mud-typography-body1 cardText\">Heigth: 0,7 m </p>\r\n        <p class=\"mud-typography mud-typography-body1 cardText\">Weigth: 6,9 kg</p>\r\n        <h6 class=\"mud-typography mud-typography-h6 cardText\">Stats:</h6>\r\n        <ul><li><p class=\"mud-typography mud-typography-body1 cardText\">hp : 45</p></li><li><p class=\"mud-typography mud-typography-body1 cardText\">attack : 49</p></li><li><p class=\"mud-typography mud-typography-body1 cardText\">defense : 49</p></li><li><p class=\"mud-typography mud-typography-body1 cardText\">special-attack : 65</p></li><li><p class=\"mud-typography mud-typography-body1 cardText\">special-defense : 65</p></li><li><p class=\"mud-typography mud-typography-body1 cardText\">speed : 45</p></li></ul>\r\n        <div class=\"mud-card-actions\"><button blazor:onclick=\"10\" type=\"button\" class=\"mud-button-root mud-button mud-button-text mud-button-text-primary mud-button-text-size-medium mud-ripple\" blazor:onclick:stopPropagation blazor:elementReference=\"\"><span class=\"mud-button-label\">Add to favorites</span></button>\r\n            <button blazor:onclick=\"11\" type=\"button\" class=\"mud-button-root mud-button mud-button-text mud-button-text-primary mud-button-text-size-medium mud-ripple\" blazor:onclick:stopPropagation blazor:elementReference=\"\"><span class=\"mud-button-label\">Get encounters</span></button></div></div>", selectedComponent.Markup);
        }
        
    }
}
