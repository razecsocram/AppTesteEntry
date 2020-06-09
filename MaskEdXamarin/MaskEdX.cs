using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Schema;
using Xamarin.Forms;

namespace MaskEdXamarin
{
    public class MaskEdX
    {
        #region Ctor
        public MaskEdX(Entry entry, 
                        string mascaraedicao, 
                        byte numerocasasdecimais, 
                        byte tamanho,
                        TextAlignment alignment)
        {
            this.nomeEntry = entry;
            nomeEntry.Text = "";
            this.mascaraEdicao = mascaraedicao;
            this.numeroCasasDecimais = numerocasasdecimais;
            this.tamanho = tamanho;
            this.alignment = alignment;
            this.nomeEntry.HorizontalTextAlignment = alignment;

            Pattern = new List<string>
            {
                "/",
                "-",
                "+",
                ".",
                "(",
                ")",
                ":",
                ";",
                "!",
                "@",
                "#",
                "$",
                "%",
                "¨",
                "&",
                "*",
                "`",
                "´",
                "^",
                "~",
                "=",
                "?",
                "|",
                "{",
                "}",
                "[",
                "]",
                ","
            };
        }
        #endregion

        #region Properties

        private readonly Entry nomeEntry;

        private readonly string mascaraEdicao;

        private readonly byte numeroCasasDecimais;

        private readonly byte tamanho;

        private readonly TextAlignment alignment;

        private List<string> Pattern { get; set; }

        #endregion

        #region Metodos
        public void MaskCPF(string bufferDigitado, ref bool ischanged)
        {
            try
            {
                if (!ischanged && !string.IsNullOrEmpty(bufferDigitado))
                {
                    if (Convert.ToInt64(bufferDigitado.Replace(".", "").Replace("-", "")).ToString().Length <= 11)
                    {
                        nomeEntry.Text = string.Format(@"{0:000\.000\.000\-00}", Convert.ToInt64(bufferDigitado.Replace(".", "").Replace("-", "")));
                    }
                    else
                    {
                        nomeEntry.Text = nomeEntry.Text.Substring(0, nomeEntry.Text.Length - 1);
                    }
                    ischanged = true;
                }
                else
                {
                    ischanged = false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void MaskCNPJ(string bufferDigitado, ref bool ischanged)
        {
            try
            {
                if (!ischanged && !string.IsNullOrEmpty(bufferDigitado))
                {
                    if (Convert.ToInt64(bufferDigitado.Replace(".", "").Replace("/", "").Replace("-", "")).ToString().Length <= 14)
                    {
                        nomeEntry.Text = string.Format(@"{0:00\.000\.000\/0000\-00}", Convert.ToInt64(bufferDigitado.Replace(".", "").Replace("/", "").Replace("-", "")));
                    }
                    else
                    {
                        nomeEntry.Text = nomeEntry.Text.Substring(0, nomeEntry.Text.Length - 1);
                    }
                    ischanged = true;
                }
                else
                {
                    ischanged = false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void MaskDate(string bufferDigitado, ref bool ischanged)
        {
            try
            {
                if (!ischanged && !string.IsNullOrEmpty(bufferDigitado))
                {
                    if (Convert.ToInt64(bufferDigitado.Replace("/", "")).ToString().Length <= 8)
                    {
                        nomeEntry.Text = string.Format("{0:00/00/0000}", Convert.ToInt64(bufferDigitado.Replace("/", "")));
                    }
                    else
                    {
                        nomeEntry.Text = nomeEntry.Text.Substring(0, nomeEntry.Text.Length - 1);
                    }

                    ischanged = true;
                }
                else
                {
                    ischanged = false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void MaskInteiroSemMilhar(string bufferDigitado, ref bool ischanged)
        {
            try
            {
                if (!ischanged && !string.IsNullOrEmpty(bufferDigitado) && !bufferDigitado.Equals(","))
                {
                    if (Convert.ToInt64(bufferDigitado.Replace(",","").Replace(".","")).ToString().Length <= tamanho)
                    {
                        nomeEntry.Text = string.Format("{0:0}", Convert.ToInt64(bufferDigitado.Replace(",", "").Replace(".", "")));
                    }
                    else
                    {
                        nomeEntry.Text = nomeEntry.Text.Substring(0, nomeEntry.Text.Length - 1);
                    }

                    ischanged = true;
                }
                else
                {

                    if (bufferDigitado.Equals(","))
                        nomeEntry.Text = nomeEntry.Text.Substring(0, nomeEntry.Text.Length - 1);

                    ischanged = false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void MaskInteiroComMilhar(string bufferDigitado, ref bool ischanged)
        {
            try
            {
                if (!ischanged && !string.IsNullOrEmpty(bufferDigitado) && !bufferDigitado.Equals(","))
                {
                    if (Convert.ToInt64(bufferDigitado.Replace(".", "").Replace(",","")).ToString().Length <= tamanho)
                    {
                        string mascara = MontarMascaraInteiroComMilhar((bufferDigitado.Replace(".", "").Replace(",", "")));
                        nomeEntry.Text = string.Format(mascara, Convert.ToInt64((bufferDigitado.Replace(".", "").Replace(",", ""))));
                    }
                    else
                    {
                        nomeEntry.Text = nomeEntry.Text.Substring(0, nomeEntry.Text.Length - 1);
                    }

                    ischanged = true;
                }
                else
                {

                    if (bufferDigitado.Equals(","))
                        nomeEntry.Text = nomeEntry.Text.Substring(0, nomeEntry.Text.Length - 1);

                    ischanged = false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void MaskDecimalSemMilhar(string bufferDigitado, ref bool ischanged)
        {
            try
            {
                if (!ischanged && !string.IsNullOrEmpty(bufferDigitado))
                {
                    if (Convert.ToInt64(bufferDigitado.Replace(",", "")).ToString().Length <= tamanho)
                    {
                        switch (numeroCasasDecimais)
                        {
                            case 1:
                                nomeEntry.Text = string.Format(@"{0:0\,0}", Convert.ToInt64(bufferDigitado.Replace(",", "")));
                                break;

                            case 2:
                                nomeEntry.Text = string.Format(@"{0:0\,00}", Convert.ToInt64(bufferDigitado.Replace(",", "")));
                                break;

                            case 3:
                                nomeEntry.Text = string.Format(@"{0:0\,000}", Convert.ToInt64(bufferDigitado.Replace(",", "")));
                                break;

                            default:
                                nomeEntry.Text = string.Format(@"{0:0\,0000}", Convert.ToInt64(bufferDigitado.Replace(",", "")));
                                break;
                        }
                    }
                    else
                    {
                        nomeEntry.Text = nomeEntry.Text.Substring(0, nomeEntry.Text.Length - 1);
                    }
                    ischanged = true;
                }
                else
                {
                    ischanged = false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void MaskDecimalComMilhar(string bufferDigitado, ref bool ischanged)
        {
            try
            {
                if (!ischanged && !string.IsNullOrEmpty(bufferDigitado))
                {

                    if (Convert.ToInt64(bufferDigitado.Replace(".","").Replace(",","")).ToString().Length <= tamanho)
                    {
                        string mascara = MontarMascaraDecComMilhar(bufferDigitado.Replace(".", "").Replace(",", ""));
                        nomeEntry.Text = string.Format(mascara, Convert.ToInt64(bufferDigitado.Replace(".", "").Replace(",", "")));
                    }
                    else
                    {
                        nomeEntry.Text = nomeEntry.Text.Substring(0, nomeEntry.Text.Length - 1);
                    }
                    ischanged = true;
                }
                else
                {
                    ischanged = false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void MaskTel(string bufferDigitado, ref bool ischanged)
        {
            try
            {
                if (!ischanged && !string.IsNullOrEmpty(bufferDigitado))
                {
                    Task.Run(() =>
                    {
                        bufferDigitado = LimpaPattern(bufferDigitado);

                    }).Wait();

                    if (Convert.ToInt64(bufferDigitado).ToString().Length <= 12)
                    {
                        nomeEntry.Text = string.Format(@"{0:\(000\)00000\-0000}", Convert.ToInt64(bufferDigitado.Replace(",", "")));
                    }
                    else
                    {
                        nomeEntry.Text = nomeEntry.Text.Substring(0, nomeEntry.Text.Length - 1);
                    }

                    ischanged = true;
                }
                else
                {
                    ischanged = false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void MaskFree(string bufferDigitado, ref bool ischanged)
        {
            try
            {
                if (!string.IsNullOrEmpty(bufferDigitado))
                {
                    Task.Run(() =>
                    {
                        bufferDigitado = LimpaPattern(bufferDigitado);

                    }).Wait();

                    if (Convert.ToInt64(bufferDigitado).ToString().Length <= tamanho)
                    {

                        if (!ischanged)
                        {
                            nomeEntry.Text = string.Format(mascaraEdicao, Convert.ToInt64(bufferDigitado));
                            ischanged = true;
                        }
                        else
                        {
                            ischanged = false;
                        }
                    }
                    else
                    {
                        nomeEntry.Text = nomeEntry.Text.Substring(0, nomeEntry.Text.Length - 1);
                        ischanged = true;
                    }
                }
                else
                {
                    ischanged = false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<string> ClipText(string mascara)
        {
            return await LimpaPatternAsync(mascara);
        }

        private string LimpaPattern(string buffer)
        {
            foreach (var item in Pattern)
            {
                buffer = buffer.Replace(item, "");
            }

            return buffer;
        }

        private async Task<string> LimpaPatternAsync(string buffer)
        {
            await Task.Run(() =>
            {
                foreach (var item in Pattern)
                {
                    buffer = buffer.Replace(item, "");
                }
            });

            return buffer;
        }

        private string MontarMascaraDecComMilhar(string buffer)
        {
            //876.543,21 = 8
            //109.876.543,21 = 11
            //432.109.876.543,21 = 14
            //765.432.109.876.543,21 = 17

            switch (buffer.Length)
            {
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                    return @"{0:0\,00}";
                case 6:
                case 7:
                case 8:
                    return @"{0:###\.##0\,00}";
                case 9:
                case 10:
                case 11:
                    return @"{0:###\.###\.##0\,00}";
                case 12:
                case 13:
                case 14:
                    return @"{0:###\.###\.###\.##0\,00}";
                case 15:
                case 16:
                case 17:
                    return @"{0:###\.###\.###\.###\.##0\,00}";
                default:
                    return @"{0:###\.###\.###\.###\.###\.##0\,00}";
            }
        }

        private string MontarMascaraInteiroComMilhar(string buffer)
        {
            //654.321 = 6
            //987.654.321 = 9
            //210.987.654.321 = 12
            //543.210.987.654.321 = 15

            switch (buffer.Length)
            {
                case 1:
                case 2:
                case 3:
                    return @"{0:0}";
                case 4:
                case 5:
                case 6:
                    return @"{0:###\.##0}";
                case 7:
                case 8:
                case 9:
                    return @"{0:###\.###\.##0}";
                case 10:
                case 11:
                case 12:
                    return @"{0:###\.###\.###\.##0}";
                case 13:
                case 14:
                case 15:
                    return @"{0:###\.###\.###\.###\.##0}";
                default:
                    return @"{0:###\.###\.###\.###\.###\.##0}";
            }
        }
        #endregion
    }
}
