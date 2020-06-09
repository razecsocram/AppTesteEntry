using MaskEdXamarin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppTesteEntry
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
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

            this.TxtInteiroSemMilhar.TextChanged += TxtInteiroSemMilhar_TextChanged;
            this.TxtInteiroSemMilhar.Focused += TxtInteiroSemMilhar_Focused;

            this.TxtInteiroComMilhar.TextChanged += TxtInteiroComMilhar_TextChanged;
            this.TxtInteiroComMilhar.Focused += TxtInteiroComMilhar_Focused;

            MaskEd = new MaskEdX(new Entry(), "", 0, 0, TextAlignment.End);
        }

        private MaskEdX MaskEd;

        private bool Ischanged;

        private void TxtDecComMilar_Focused(object sender, FocusEventArgs e)
        {
            Ischanged = false;
            MaskEd = new MaskEdX((Entry)sender, "", 2, 15, TextAlignment.End);
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

        private void TxtInteiroSemMilhar_Focused(object sender, FocusEventArgs e)
        {
            Ischanged = false;
            MaskEd = new MaskEdX((Entry)sender, null, 0, 15, TextAlignment.End);
        }

        private void TxtInteiroSemMilhar_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                MaskEd.MaskInteiroSemMilhar(e.NewTextValue, ref Ischanged);
            }
            catch (Exception ex)
            {
                DisplayAlert("Erro", ex.Message, "OK");
            }
        }

        private void TxtInteiroComMilhar_Focused(object sender, FocusEventArgs e)
        {
            Ischanged = false;
            MaskEd = new MaskEdX((Entry)sender, null, 0, 15, TextAlignment.End);
        }

        private void TxtInteiroComMilhar_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (!e.NewTextValue.Equals(","))
                    MaskEd.MaskInteiroComMilhar(e.NewTextValue, ref Ischanged);
            }
            catch (Exception ex)
            {
                DisplayAlert("Erro", ex.Message, "OK");
            }
        }

        private void TxtDecSemMilar_Focused(object sender, FocusEventArgs e)
        {
            Ischanged = false;
            MaskEd = new MaskEdX((Entry)sender, null, 2, 15,TextAlignment.End);
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
            MaskEd = new MaskEdX((Entry)sender, @"{0:0000000000}", 0, 10, TextAlignment.Start);
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
            MaskEd = new MaskEdX((Entry)sender, null, 0, 0, TextAlignment.Start);
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
            MaskEd = new MaskEdX((Entry)sender, null, 0, 0, TextAlignment.Start);
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
            MaskEd = new MaskEdX((Entry)sender, null, 0, 0, TextAlignment.Start);
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
            MaskEd = new MaskEdX((Entry)sender, null, 0, 0, TextAlignment.Start);
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
    }
}
