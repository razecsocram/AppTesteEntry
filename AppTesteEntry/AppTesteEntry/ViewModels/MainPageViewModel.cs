using CLUteisX.MaskEd;
using CLUteisX.VCnpj;
using CLUteisX.VCpf;
using CLUteisX.VForm;
using CLUteisX.VIE;
using System.ComponentModel.DataAnnotations;

namespace AppTesteEntry.ViewModels
{
    public class MainPageViewModel : BaseValidationViewModel
    {
        public bool IsChanged { get; set; }

        readonly MaskEdX MaskEdX;
        readonly ValidaCnpj ValidaCnpj;
        readonly ValidaCpf ValidaCpf;
        readonly ValidaIESP ValidaIESP;
        private string cNPJ;
        private string cPF;
        private string iE;

        [Required(ErrorMessage = "CNPJ obrigatorio.")]
        public string CNPJ
        {
            get => cNPJ;
            set
            {
                SetProperty(ref cNPJ, value);
                if (!string.IsNullOrEmpty(CNPJ))
                {
                    Validate(CNPJ, () => ValidaCnpj.CnpjEValido(long.Parse(MaskEdX.ClipText(CNPJ))), "CNPJ invalido.");
                }
            }
        }

        [Required(ErrorMessage = "CPF obrigatorio.")]
        public string CPF
        {
            get => cPF;
            set
            {
                SetProperty(ref cPF, value);
                if (!string.IsNullOrEmpty(CPF))
                {
                    Validate(CPF, () => ValidaCpf.CpfEValido(long.Parse(MaskEdX.ClipText(CPF))), "CPF invalido.");
                }
            }
        }

        [Required(ErrorMessage = "IE obrigatorio.")]
        public string IE
        {
            get => iE; 
            
            set
            {
                SetProperty(ref iE, value);
                if (!string.IsNullOrEmpty(IE))
                {
                    Validate(IE, () => ValidaIESP.IESPEValido(long.Parse(MaskEdX.ClipText(IE))), "IE invalido.");
                }
            }
        }

        public MainPageViewModel()
        {
            MaskEdX = new MaskEdX();
            ValidaCnpj = new ValidaCnpj();
            ValidaCpf = new ValidaCpf();
            ValidaIESP = new ValidaIESP();
            CNPJ = string.Empty;
            CPF = string.Empty;
            iE = string.Empty;
        }
    }
}
