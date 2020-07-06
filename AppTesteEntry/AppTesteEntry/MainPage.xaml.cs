using AppTesteEntry.ViewModels;
using CLUteisX.MaskEd;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Xamarin.Forms;

namespace AppTesteEntry
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        #region Propriedades
        MaskEdX MaskEdX;
        readonly MainPageViewModel vm;
        #endregion

        #region Ctor
        public MainPage()
        {
            InitializeComponent();

            this.TxtData.Focused += TxtData_Focused;
            this.TxtData.TextChanged += TxtData_TextChanged;

            this.TxtCnpj.Focused += TxtCnpj_Focused;
            this.TxtCnpj.TextChanged += TxtCnpj_TextChanged;
            this.TxtCnpj.Completed += TxtCnpj_Completed;

            this.TxtCpf.Focused += TxtCpf_Focused;
            this.TxtCpf.TextChanged += TxtCpf_TextChanged;
            this.TxtCpf.Completed += TxtCpf_Completed;

            this.TxtTel.Focused += TxtTel_Focused;
            this.TxtTel.TextChanged += TxtTel_TextChanged;

            this.TxtFree.Focused += TxtFree_Focused;
            this.TxtFree.TextChanged += TxtFree_TextChanged;

            this.TxtDecSemMilar.TextChanged += TxtDecSemMilar_TextChanged;
            this.TxtDecSemMilar.Focused += TxtDecSemMilar_Focused;

            this.TxtDecComMilar.TextChanged += TxtDecComMilar_TextChanged;
            this.TxtDecComMilar.Focused += TxtDecComMilar_Focused;

            this.TxtInteiroComMilhar.TextChanged += TxtInteiroComMilhar_TextChanged;
            this.TxtInteiroComMilhar.Focused += TxtInteiroComMilhar_Focused;

            this.TxtIE.TextChanged += TxtIE_TextChanged;
            this.TxtIE.Focused += TxtIE_Focused;

            MaskEdX = new MaskEdX(new Entry(), Keyboard.Default);
            
            vm = new MainPageViewModel();
            
            BindingContext = vm;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            vm.ErrorsChanged += Vm_ErrorsChanged;

        }

        private void Vm_ErrorsChanged(object sender, DataErrorsChangedEventArgs e)
        {
            //if (Ischanged)
            //{
            var propErrors = (vm.GetErrors(e.PropertyName) as List<string>)?.Any() == true;

            var messages = (vm.GetErrors(e.PropertyName) as List<string>);

            string propTex = string.Join("\n", messages);

            switch (e.PropertyName)
            {
                case nameof(vm.CNPJ):
                    lblcnpjerror.IsVisible = propErrors;
                    lblcnpjerror.Text = propTex;
                    break;

                case nameof(vm.CPF):
                    lblcpferror.IsVisible = propErrors;
                    lblcpferror.Text = propTex;
                    break;

                case nameof(vm.IE):
                    lblieerror.IsVisible = propErrors;
                    lblieerror.Text = propTex;
                    break;

                default:
                    break;
            }
            //}
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            vm.ErrorsChanged -= Vm_ErrorsChanged;
        }
        #endregion

        #region Metodos
        private void TxtInteiroComMilhar_Focused(object sender, FocusEventArgs e)
        {
            MaskEdX = new MaskEdX((Entry)sender, Keyboard.Numeric);
        }

        private async void TxtInteiroComMilhar_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                MaskEdX.MaskInteiroComMilhar((Entry)sender, 15, TextAlignment.End, e.NewTextValue);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro", ex.Message, "OK");
            }
        }

        private void TxtDecComMilar_Focused(object sender, FocusEventArgs e)
        {
            MaskEdX = new MaskEdX((Entry)sender, Keyboard.Numeric);
        }

        private async void TxtDecComMilar_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                MaskEdX.MaskDecimalComMilhar((Entry)sender, 2, 15, TextAlignment.End, e.NewTextValue);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro", ex.Message, "OK");
            }
        }

        private void TxtDecSemMilar_Focused(object sender, FocusEventArgs e)
        {
            MaskEdX = new MaskEdX((Entry)sender, Keyboard.Numeric);
        }

        private async void TxtDecSemMilar_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                MaskEdX.MaskDecimalSemMilhar((Entry)sender, 2, 15, TextAlignment.End, e.NewTextValue);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro", ex.Message, "OK");
            }
        }

        private void TxtFree_Focused(object sender, FocusEventArgs e)
        {
            MaskEdX = new MaskEdX((Entry)sender, Keyboard.Numeric);
        }

        private async void TxtFree_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                MaskEdX.MaskFree((Entry)sender, @"{0:0000000000}", 10, TextAlignment.Center, e.NewTextValue);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro", ex.Message, "OK");
            }
        }

        private void TxtTel_Focused(object sender, FocusEventArgs e)
        {
            MaskEdX = new MaskEdX((Entry)sender, Keyboard.Numeric);
        }

        private async void TxtTel_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                MaskEdX.MaskTel((Entry)sender, TextAlignment.Center, e.NewTextValue);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro", ex.Message, "OK");
            }
        }

        private void TxtCpf_Focused(object sender, FocusEventArgs e)
        {
            MaskEdX = new MaskEdX((Entry)sender, Keyboard.Numeric);
        }

        private async void TxtCpf_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                MaskEdX.MaskCPF((Entry)sender, TextAlignment.End, e.NewTextValue);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro", ex.Message, "OK");
            }
        }

        private void TxtCpf_Completed(object sender, EventArgs e)
        {
            this.TxtTel.Focus();
        }

        private void TxtCnpj_Focused(object sender, FocusEventArgs e)
        {
            MaskEdX = new MaskEdX((Entry)sender, Keyboard.Numeric);
            //((Entry)sender).Text = "02468872000104";
            //DisplayAlert("ClipText", MaskEdX.ClipText(((Entry)sender).Text), "Ok");
        }

        private async void TxtCnpj_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                MaskEdX.MaskCNPJ((Entry)sender, TextAlignment.End, e.NewTextValue);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro", ex.Message, "OK");
            }
        }

        private void TxtCnpj_Completed(object sender, EventArgs e)
        {
            this.TxtCpf.Focus();
        }

        private void TxtData_Focused(object sender, FocusEventArgs e)
        {
            MaskEdX = new MaskEdX((Entry)sender, Keyboard.Numeric);
        }

        private async void TxtData_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                MaskEdX.MaskDate((Entry)sender, TextAlignment.Center, e.NewTextValue);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro", ex.Message, "OK");
            }
        }

        private void TxtIE_Focused(object sender, FocusEventArgs e)
        {
            //((Entry)sender).Text = "isento";
            MaskEdX = new MaskEdX((Entry)sender, Keyboard.Default);
            //((Entry)sender).Text = "110042490114";
        }

        private async void TxtIE_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                MaskEdX.MaskIE((Entry)sender, TextAlignment.Start, e.NewTextValue);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro", ex.Message, "OK");
            }
        }
        #endregion
    }
}
