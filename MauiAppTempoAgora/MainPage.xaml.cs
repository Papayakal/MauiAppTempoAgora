using MauiAppTempoAgora.Models;
using MauiAppTempoAgora.Services;
using System.ComponentModel.Design;

namespace MauiAppTempoAgora
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txt_cidade.Text))
                {
                    
                    Tempo t = await DataService.GetPrevisao(txt_cidade.Text);

                    if (t != null)
                    {
                        string dados_previsao = "";

                        dados_previsao = $"Latidude: {t.lat} \n" +
                                         $"Longitude: {t.lon} \n" +
                                         $"Nascer do Sol: {t.sunrise} \n" +
                                         $"Por do Sol: {t.sunset} \n" +
                                         $"Temp Máx: {t.temp_max} \n" +
                                         $"Temp Min: {t.temp_min} \n" +
                                         $"Descricao: {t.description} \n" +   //1.Fiz uma leve adicao do código, adicionando as informacoes: descricao, velocidade e visibilidade
                                         $"Velocidade do vento: {t.speed} \n" +
                                         $"Visibilidade: {t.visibility} \n";
                                         

                        lbl_res.Text = dados_previsao;
                    }
                    else
                    {  //2.alteracao da string, para uma mensagem mais sofistificada
                        lbl_res.Text = "Cidade não encontrada! Por favor, insira uma cidade válida no campo acima";
                      
                    }
                    
                } else
                {
                    lbl_res.Text = "Preencha a cidade.";
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Ops", ex.Message, "OK");
            }
        }
    }
}
