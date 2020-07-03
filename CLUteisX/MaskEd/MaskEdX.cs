using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace CLUteisX.MaskEd
{
    public class MaskEdX
    {

        #region Propriedades
        readonly IDictionary<long, bool> ischanged;
        readonly Entry GetEntry;
        #endregion

        #region Ctor
        public MaskEdX(Entry getEntry)
        {
            GetEntry = getEntry;
            GetEntry.Keyboard = Keyboard.Numeric;
            ischanged = new Dictionary<long, bool>();
        }
        #endregion

        #region Metodos
        public void MaskCPF(Entry nomeEntry, TextAlignment alignment, string bufferDigitado)
        {
            nomeEntry.HorizontalTextAlignment = alignment;
            nomeEntry.Keyboard = Keyboard.Numeric;
            long buffer = string.IsNullOrEmpty(bufferDigitado) ? 0 : long.Parse(LimpaPattern(bufferDigitado));

            try
            {
                if (!string.IsNullOrEmpty(bufferDigitado))
                {
                    bufferDigitado = LimpaPattern(bufferDigitado);

                    if (!ischanged.ContainsKey(buffer))
                    {
                        if (buffer.ToString().Length <= 11)
                        {
                            nomeEntry.Text = string.Format(@"{0:000\.000\.000\-00}", buffer);
                        }
                        else
                        {
                            nomeEntry.Text = string.Format(@"{0:000\.000\.000\-00}", Convert.ToInt64(bufferDigitado.Substring(0, bufferDigitado.Length - 1)));
                        }

                        ischanged.Add(buffer, false);
                    }
                    else
                    {
                        FinalizaSeExisteKey(buffer, bufferDigitado, ischanged, nomeEntry);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void MaskCNPJ(Entry nomeEntry, TextAlignment alignment, string bufferDigitado)
        {
            nomeEntry.HorizontalTextAlignment = alignment;
            nomeEntry.Keyboard = Keyboard.Numeric;
            long buffer = string.IsNullOrEmpty(bufferDigitado) ? 0 : long.Parse(LimpaPattern(bufferDigitado));

            try
            {
                if (!string.IsNullOrEmpty(bufferDigitado))
                {
                    bufferDigitado = LimpaPattern(bufferDigitado);

                    if (!ischanged.ContainsKey(buffer))
                    {
                        ischanged.Clear();

                        if (Convert.ToInt64(bufferDigitado).ToString().Length <= 14)
                        {
                            nomeEntry.Text = string.Format(@"{0:00\.000\.000\/0000\-00}", buffer);
                        }
                        else
                        {
                            nomeEntry.Text = string.Format(@"{0:00\.000\.000\/0000\-00}", Convert.ToInt64(bufferDigitado.Substring(0, bufferDigitado.Length - 1)));
                        }

                        ischanged.Add(buffer, false);
                    }
                    else
                    {
                        FinalizaSeExisteKey(buffer, bufferDigitado, ischanged, nomeEntry);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void MaskIE(Entry nomeEntry, TextAlignment alignment, string bufferDigitado)
        {
            nomeEntry.HorizontalTextAlignment = alignment;
            nomeEntry.Keyboard = Keyboard.Numeric;
            long buffer = string.IsNullOrEmpty(bufferDigitado) ? 0 : long.Parse(LimpaPattern(bufferDigitado));

            try
            {
                if (!string.IsNullOrEmpty(bufferDigitado))
                {
                    if (!bufferDigitado.ToUpper().Contains("ISENTO"))
                    {
                        bufferDigitado = LimpaPattern(bufferDigitado);

                        if (!ischanged.ContainsKey(buffer))
                        {
                            ischanged.Clear();

                            if (buffer.ToString().Length <= 12)
                            {
                                nomeEntry.Text = string.Format(@"{0:000\.000\.000\.000}", buffer);
                            }
                            else
                            {
                                nomeEntry.Text = string.Format(@"{0:000\.000\.000\.000}", Convert.ToInt64(bufferDigitado.Substring(0, bufferDigitado.Length - 1)));
                            }

                            ischanged.Add(buffer, false);
                        }
                        else
                        {
                            FinalizaSeExisteKey(buffer, bufferDigitado, ischanged, nomeEntry);
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void MaskDate(Entry nomeEntry, TextAlignment alignment, string bufferDigitado)
        {
            nomeEntry.HorizontalTextAlignment = alignment;
            nomeEntry.Keyboard = Keyboard.Numeric;
            long buffer = string.IsNullOrEmpty(bufferDigitado) ? 0 : long.Parse(LimpaPattern(bufferDigitado));

            try
            {
                if (!string.IsNullOrEmpty(bufferDigitado))
                {
                    bufferDigitado = LimpaPattern(bufferDigitado);

                    if (bufferDigitado.Length >= 10)
                        bufferDigitado = bufferDigitado.Substring(0, 8);

                    if (!ischanged.ContainsKey(buffer) && !string.IsNullOrEmpty(bufferDigitado))
                    {
                        ischanged.Clear();

                        if (Convert.ToInt64(bufferDigitado).ToString().Length <= 8)
                        {
                            nomeEntry.Text = string.Format("{0:00/00/0000}", Convert.ToInt64(bufferDigitado));
                        }
                        else
                        {
                            nomeEntry.Text = string.Format("{0:00/00/0000}", Convert.ToInt64(bufferDigitado.Substring(0, bufferDigitado.Length - 1)));
                        }

                        ischanged.Add(buffer, false);
                    }
                    else
                    {
                        FinalizaSeExisteKey(buffer, bufferDigitado, ischanged, nomeEntry);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void MaskInteiroComMilhar(Entry nomeEntry, byte tamanho, TextAlignment alignment, string bufferDigitado)
        {
            nomeEntry.HorizontalTextAlignment = alignment;
            nomeEntry.Keyboard = Keyboard.Numeric;
            long buffer = string.IsNullOrEmpty(bufferDigitado) ? 0 : long.Parse(LimpaPattern(bufferDigitado));

            try
            {
                if (!string.IsNullOrEmpty(bufferDigitado))
                {
                    bufferDigitado = LimpaPattern(bufferDigitado);

                    if (!ischanged.ContainsKey(buffer) && !string.IsNullOrEmpty(bufferDigitado))
                    {
                        ischanged.Clear();

                        string mascara = MontarMascaraInteiroComMilhar(bufferDigitado);

                        if (Convert.ToInt64(bufferDigitado).ToString().Length <= tamanho)
                        {
                            nomeEntry.Text = string.Format(mascara, Convert.ToInt64((bufferDigitado)));
                        }
                        else
                        {
                            nomeEntry.Text = string.Format(mascara, Convert.ToInt64(bufferDigitado.Substring(0, bufferDigitado.Length - 1)));
                        }

                        if (bufferDigitado.Length > 3)
                            ischanged.Add(buffer, false);
                    }
                    else
                    {
                        FinalizaSeExisteKey(buffer, bufferDigitado, ischanged, nomeEntry);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void MaskDecimalSemMilhar(Entry nomeEntry, byte numeroCasasDecimais, byte tamanho,
                                        TextAlignment alignment, string bufferDigitado)
        {
            nomeEntry.HorizontalTextAlignment = alignment;
            nomeEntry.Keyboard = Keyboard.Numeric;
            long buffer = string.IsNullOrEmpty(bufferDigitado) ? 0 : long.Parse(LimpaPattern(bufferDigitado));

            try
            {
                if (!string.IsNullOrEmpty(bufferDigitado))
                {
                    bufferDigitado = LimpaPattern(bufferDigitado);

                    if (!ischanged.ContainsKey(buffer) && !string.IsNullOrEmpty(bufferDigitado))
                    {
                        ischanged.Clear();

                        if (Convert.ToInt64(bufferDigitado).ToString().Length <= tamanho)
                        {
                            switch (numeroCasasDecimais)
                            {
                                case 1:
                                    nomeEntry.Text = string.Format(@"{0:0\,0}", buffer);
                                    break;

                                case 2:
                                    nomeEntry.Text = string.Format(@"{0:0\,00}", buffer);
                                    break;

                                case 3:
                                    nomeEntry.Text = string.Format(@"{0:0\,000}", buffer);
                                    break;

                                default:
                                    nomeEntry.Text = string.Format(@"{0:0\,0000}", buffer);
                                    break;
                            }
                        }
                        else
                        {
                            nomeEntry.Text = nomeEntry.Text.Substring(0, nomeEntry.Text.Length - 1);
                        }

                        ischanged.Add(buffer, false);
                    }
                    else
                    {
                        FinalizaSeExisteKey(buffer, bufferDigitado, ischanged, nomeEntry);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void MaskDecimalComMilhar(Entry nomeEntry, byte numeroCasasDecimais, byte tamanho, 
                                        TextAlignment alignment, string bufferDigitado)
        {
            nomeEntry.HorizontalTextAlignment = alignment;
            nomeEntry.Keyboard = Keyboard.Numeric;
            long buffer = string.IsNullOrEmpty(bufferDigitado) ? 0 : long.Parse(LimpaPattern(bufferDigitado));

            try
            {
                if (!string.IsNullOrEmpty(bufferDigitado))
                {
                    bufferDigitado = LimpaPattern(bufferDigitado);

                    if (!ischanged.ContainsKey(buffer) && !string.IsNullOrEmpty(bufferDigitado))
                    {
                        ischanged.Clear();

                        string mascara = MontarMascaraDecComMilhar(numeroCasasDecimais, bufferDigitado);

                        if (Convert.ToInt64(bufferDigitado).ToString().Length <= tamanho)
                        {
                            nomeEntry.Text = string.Format(mascara, Convert.ToInt64(bufferDigitado));
                        }
                        else
                        {
                            nomeEntry.Text = string.Format(mascara, Convert.ToInt64(bufferDigitado.Substring(0, bufferDigitado.Length - 1)));
                        }

                        ischanged.Add(buffer, false);
                    }
                    else
                    {
                        FinalizaSeExisteKey(buffer, bufferDigitado, ischanged, nomeEntry);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void MaskTel(Entry nomeEntry, TextAlignment alignment, string bufferDigitado)
        {
            nomeEntry.HorizontalTextAlignment = alignment;
            nomeEntry.Keyboard = Keyboard.Numeric;
            long buffer = string.IsNullOrEmpty(bufferDigitado) ? 0 : long.Parse(LimpaPattern(bufferDigitado));

            try
            {
                if (!string.IsNullOrEmpty(bufferDigitado))
                {
                    bufferDigitado = LimpaPattern(bufferDigitado);

                    if (!ischanged.ContainsKey(buffer) && !string.IsNullOrEmpty(bufferDigitado))
                    {
                        ischanged.Clear();

                        if (Convert.ToInt64(bufferDigitado).ToString().Length <= 12)
                        {
                            nomeEntry.Text = string.Format(@"{0:\(000\)00000\-0000}", Convert.ToInt64(bufferDigitado));
                        }
                        else
                        {
                            nomeEntry.Text = string.Format(@"{0:\(000\)00000\-0000}", Convert.ToInt64(bufferDigitado.Substring(0, bufferDigitado.Length - 1)));
                        }

                        ischanged.Add(buffer, false);
                    }
                    else
                    {
                        FinalizaSeExisteKey(buffer, bufferDigitado, ischanged, nomeEntry);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void MaskFree(Entry nomeEntry, string mascaraedicao,
                            byte tamanho, TextAlignment alignment,
                            string bufferDigitado)
        {
            nomeEntry.Keyboard = Keyboard.Numeric;
            nomeEntry.HorizontalTextAlignment = alignment;
            long buffer = string.IsNullOrEmpty(bufferDigitado) ? 0 : long.Parse(LimpaPattern(bufferDigitado));

            try
            {
                if (!string.IsNullOrEmpty(bufferDigitado))
                {
                    bufferDigitado = LimpaPattern(bufferDigitado);

                    if (!ischanged.ContainsKey(buffer) && !string.IsNullOrEmpty(bufferDigitado))
                    {
                        ischanged.Clear();

                        if (Convert.ToInt64(bufferDigitado).ToString().Length <= tamanho)
                        {
                            nomeEntry.Text = string.Format(mascaraedicao, buffer);
                        }
                        else
                        {
                            nomeEntry.Text = string.Format(mascaraedicao, Convert.ToInt64(bufferDigitado.Substring(0, bufferDigitado.Length - 1)));
                        }

                        ischanged.Add(buffer, false);
                    }
                    else
                    {
                        FinalizaSeExisteKey(buffer, bufferDigitado, ischanged, nomeEntry);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        void FinalizaSeExisteKey(long buffer, string bufferdigitado, IDictionary<long,bool> ischanged, Entry nomeEntry)
        {
            if (string.IsNullOrEmpty(bufferdigitado))
            {
                ischanged.Clear();
                nomeEntry.Text = string.Empty;
            }
            else
            {
                if (buffer == 0)
                {
                    ischanged.Clear();
                    nomeEntry.Text = string.Empty;
                }
                else
                {
                    ischanged.Remove(buffer);
                }
            }
        }

        public string ClipText(string mascara)
        {
            return LimpaPattern(mascara);
        }

        private string LimpaPattern(string buffer)
        {
            return Regex.Replace(buffer, @"[^0-9]+", "");
        }

        private static string MontarMascaraDecComMilhar(byte ncasasdecimais, string buffer)
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
                    switch (ncasasdecimais)
                    {
                        case 1:
                            return @"{0:0\,0}";
                        case 2:
                            return @"{0:0\,00}";
                        case 3:
                            return @"{0:0\,000}";
                        default:
                            return @"{0:0\,0000}";
                    }
                case 6:
                case 7:
                case 8:
                    switch (ncasasdecimais)
                    {
                        case 1:
                            return @"{0:###\.##0\,0}";
                        case 2:
                            return @"{0:###\.##0\,00}";
                        case 3:
                            return @"{0:###\.##0\,000}";
                        default:
                            return @"{0:###\.##0\,0000}";
                    }
                case 9:
                case 10:
                case 11:
                    switch (ncasasdecimais)
                    {
                        case 1:
                            return @"{0:###\.###\.##0\,0}";
                        case 2:
                            return @"{0:###\.###\.##0\,00}";
                        case 3:
                            return @"{0:###\.###\.##0\,000}";
                        default:
                            return @"{0:###\.###\.##0\,0000}";
                    }
                case 12:
                case 13:
                case 14:
                    switch (ncasasdecimais)
                    {
                        case 1:
                            return @"{0:###\.###\.###\.##0\,0}";
                        case 2:
                            return @"{0:###\.###\.###\.##0\,00}";
                        case 3:
                            return @"{0:###\.###\.###\.##0\,000}";
                        default:
                            return @"{0:###\.###\.###\.##0\,0000}";
                    }
                case 15:
                case 16:
                case 17:
                    switch (ncasasdecimais)
                    {
                        case 1:
                            return @"{0:###\.###\.###\.###\.##0\,0}";
                        case 2:
                            return @"{0:###\.###\.###\.###\.##0\,00}";
                        case 3:
                            return @"{0:###\.###\.###\.###\.##0\,000}";
                        default:
                            return @"{0:###\.###\.###\.###\.##0\,0000}";
                    }
                default:
                    switch (ncasasdecimais)
                    {
                        case 1:
                            return @"{0:###\.###\.###\.###\.###\.##0\,0}";
                        case 2:
                            return @"{0:###\.###\.###\.###\.###\.##0\,00}";
                        case 3:
                            return @"{0:###\.###\.###\.###\.###\.##0\,000}";
                        default:
                            return @"{0:###\.###\.###\.###\.###\.##0\,0000}";
                    }
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
