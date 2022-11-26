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
        private static int _reszta;
            private static int _nwd;
        public Ułamek(int licznik, int mianownik)
        {
            _licznik = licznik;
            _mianownik = mianownik;
        }

        public void skroc ()
        {
            int nwd = Narzędzia.NWD(_licznik, _mianownik);
            _nwd = nwd;
       //     if (nwd != 1) // jak jest inne niz 1, bo bez sensu dzielić przez 1
        //    {
                if (_licznik/_mianownik == 1) // brak reszty
                {
                    _reszta = 0;
                }
                else
                {
                    _reszta = 1;
                }
                _calosci = _licznik / _mianownik;
                _licznik /= nwd;
                _mianownik /= nwd;
         //   }
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
                    
                    Console.WriteLine($"Odczytałem wpisany ułamek to {_licznik} / {_mianownik}.");
                    
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
            skroc();

          //  return $"nwd= {_nwd} calosci: {_calosci}   ulamek: {_licznik}/{_mianownik}";

            if (_calosci > 0)
            {
                if (_reszta == 1)
                {
                    int tmp= _licznik - (_calosci * _mianownik);
                    return $"{_calosci}  {tmp}/{_mianownik}";
                } else
                    return $"{_calosci}";
            } else
            return $"{_licznik}/{_mianownik}";
        }
    }
}
