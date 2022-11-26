using System;
using System.Collections.Generic;
using System.Text;

namespace PPO_1
{
    internal struct Ułamek
    {
        private int _licznik;
        private int _mianownik;
        private static int _calosci;

        public Ułamek(int licznik, int mianownik)
        {
            _licznik = licznik;
            _mianownik = mianownik;
            
        }

        public void skroc ()
        {
            int nwd = Narzędzia.NWD(_licznik, _mianownik);
            _calosci = _licznik / _mianownik;
            
            _mianownik /= nwd;
            _licznik /= nwd;
            if (_mianownik < 0)
            {
                _mianownik *= -1;
                _licznik *= -1;
            }

        }

        public Ułamek(string licznik_i_mianownik)
        {
            
            int gdzie_slash = licznik_i_mianownik.IndexOf("/");
            if (gdzie_slash == -1)
            {
                Console.WriteLine("Coś się nie udało, nie mogłem znaleźć slasha");
                throw new InvalidOperationException("Coś się nie udało, nie mogłem znaleźć slasha");
            }
            else
            {
                string pierwsze = licznik_i_mianownik.Substring(0, gdzie_slash);
                string drugie = licznik_i_mianownik.Substring(gdzie_slash + 1);

                int temp1, temp2;
                bool parse_pierwszy = int.TryParse(pierwsze, out temp1);
                bool parse_drugi = int.TryParse(drugie, out temp2);
                if (parse_pierwszy && parse_drugi)
                { // udało się przekonwertować string na dwa inty
                    _licznik = temp1;
                    _mianownik = temp2;
                }
                else
                { // nie udało się
                    Console.WriteLine("Nie udało się przekonwertować stringu na inty");
                    throw new InvalidOperationException("Nie udało się przekonwertować stringu na inty");
                }

            }
        }
        public int GetLicznik()
        {
            return _licznik;
        }
        public int GetMianownik()
        {
            return _licznik;
        }

        public static Ułamek operator +(Ułamek a) => a; // znak dodatni
        public static Ułamek operator -(Ułamek a) => new Ułamek(-a._licznik, a._mianownik); // znak ujemny

        public static Ułamek operator -(Ułamek a, Ułamek b) => a + (-b); // odejmowanie
        public static Ułamek operator +(Ułamek a, Ułamek b) // dodawanie
        => new Ułamek(a._licznik * b._mianownik + b._licznik * a._mianownik, a._mianownik * b._mianownik);

        public static Ułamek operator *(Ułamek a, Ułamek b) => new Ułamek(a._licznik * b._licznik, a._mianownik * b._mianownik); // mnożenie
        public static Ułamek operator /(Ułamek a, Ułamek b) // dzielenie
        {
            if (b._licznik == 0)
            {
                throw new DivideByZeroException();
            }
            return new Ułamek(a._licznik * b._mianownik, a._mianownik * b._licznik);
        }


        public double ToDouble()
        {
            return (double)_licznik/(double)_mianownik;
        }


        public override string ToString()
        {
            // return $"nwd= {_nwd} calosci: {_calosci}   ulamek: {_licznik}/{_mianownik}";
            skroc();
            if (_calosci > 0)
            { 
               
                if ((_licznik - (_calosci * _mianownik)) != 0)
                {
                    return $"{_calosci} [{_licznik - (_calosci * _mianownik)} / {_mianownik}]";
                }
                else
                {
                    return $"{_calosci}";
                }
            }
            else if (_calosci < 0)
            {
                if ((-1 * (_licznik - (_calosci * _mianownik))) != 0)
                {
                    return $"{_calosci} [{-1 * (_licznik - (_calosci * _mianownik))} / {_mianownik}]";
                } 
                else
                {
                    return $"{_calosci}";
                }
            }
            else
                return $"{_licznik} / {_mianownik}";
        }
    }
}
