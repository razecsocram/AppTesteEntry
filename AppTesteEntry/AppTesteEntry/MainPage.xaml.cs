using MaskEdXamarin;
using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace AppTesteEntry
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        #region Ctor
        public MainPage()
        {
            InitializeComponent();

            this.TxtData.Focused += TxtData_Focused;
            this.TxtData.TextChanged += TxtData_TextChanged;

            this.TxtCnpj.Focused += TxtCnpj_Focused;
            this.TxtCnpj.TextChanged += TxtCnpj_TextChanged;

            this.TxtCpf.Focused += TxtCpf_Focused;
            this.TxtCpf.TextChanged += TxtCpf_TextChanged;

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

            MaskEd = new MaskEdX(new Entry(), "", 0, 0, TextAlignment.End);
        }
        #endregion

        #region Propriedades
        private MaskEdX MaskEd;

        private bool Ischanged;
        #endregion

        #region Metodos
        private void TxtInteiroComMilhar_Focused(object sender, FocusEventArgs e)
        {
            Ischanged = false;
            MaskEd = new MaskEdX((Entry)sender, 15, TextAlignment.End);
        }

        private void TxtInteiroComMilhar_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                MaskEd.MaskInteiroComMilhar(e.NewTextValue, ref Ischanged);
            }
            catch (Exception ex)
            {
                DisplayAlert("Erro", ex.Message, "OK");
            }
        }

        private void TxtDecComMilar_Focused(object sender, FocusEventArgs e)
        {
            Ischanged = false;
            MaskEd = new MaskEdX((Entry)sender, 2, 15, TextAlignment.End);
        }

        private void TxtDecComMilar_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                MaskEd.MaskDecimalComMilhar(e.NewTextValue, ref Ischanged);
            }
            catch (Exception ex)
            {
                DisplayAlert("Erro", ex.Message, "OK");
            }
        }

        private void TxtDecSemMilar_Focused(object sender, FocusEventArgs e)
        {
            Ischanged = false;
            MaskEd = new MaskEdX((Entry)sender, 2, 15, TextAlignment.End);
        }

        private void TxtDecSemMilar_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                MaskEd.MaskDecimalSemMilhar(e.NewTextValue, ref Ischanged);
            }
            catch (Exception ex)
            {
                DisplayAlert("Erro", ex.Message, "OK");
            }
        }

        private void TxtFree_Focused(object sender, FocusEventArgs e)
        {
            Ischanged = false;
            MaskEd = new MaskEdX((Entry)sender, @"{0:0000000000}", 10, TextAlignment.Center);
        }

        private void TxtFree_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                MaskEd.MaskFree(e.NewTextValue, ref Ischanged);
            }
            catch (Exception ex)
            {
                DisplayAlert("Erro", ex.Message, "OK");
            }
        }

        private void TxtTel_Focused(object sender, FocusEventArgs e)
        {
            Ischanged = false;
            MaskEd = new MaskEdX((Entry)sender, TextAlignment.Center);
        }

        private void TxtTel_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                MaskEd.MaskTel(e.NewTextValue, ref Ischanged);
            }
            catch (Exception ex)
            {
                DisplayAlert("Erro", ex.Message, "OK");
            }
        }

        private void TxtCpf_Focused(object sender, FocusEventArgs e)
        {
            Ischanged = false;
            MaskEd = new MaskEdX((Entry)sender, TextAlignment.End);
        }

        private void TxtCpf_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                MaskEd.MaskCPF(e.NewTextValue, ref Ischanged);
            }
            catch (Exception ex)
            {
                DisplayAlert("Erro", ex.Message, "OK");
            }
        }

        private void TxtCnpj_Focused(object sender, FocusEventArgs e)
        {
            Ischanged = false;
            MaskEd = new MaskEdX((Entry)sender, TextAlignment.End);
            ((Entry)sender).Text = "02468872000104";
            DisplayAlert("ClipText", MaskEd.ClipText(((Entry)sender).Text), "Ok");
        }

        private void TxtCnpj_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                MaskEd.MaskCNPJ(e.NewTextValue, ref Ischanged);
            }
            catch (Exception ex)
            {
                DisplayAlert("Erro", ex.Message, "OK");
            }
        }

        private void TxtData_Focused(object sender, FocusEventArgs e)
        {
            Ischanged = false;
            MaskEd = new MaskEdX((Entry)sender, TextAlignment.Center);
            ((Entry)sender).Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        private void TxtData_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                MaskEd.MaskDate(e.NewTextValue, ref Ischanged);
            }
            catch (Exception ex)
            {
                DisplayAlert("Erro", ex.Message, "OK");
            }
        }

        private void TxtIE_Focused(object sender, FocusEventArgs e)
        {
            Ischanged = false;
            MaskEd = new MaskEdX((Entry)sender, TextAlignment.Start);
        }

        private void TxtIE_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                MaskEd.MaskIE(e.NewTextValue, ref Ischanged);
            }
            catch (Exception ex)
            {
                DisplayAlert("Erro", ex.Message, "OK");
            }
        }
        #endregion
    }
}
