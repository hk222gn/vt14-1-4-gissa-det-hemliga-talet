using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace GissaDetHemligaTalet.Model
{
    public enum Outcome { Indefinite, Low, High, Correct, NoMoreGuesses, PreviousGuess };

    public class SecretNumber
    {
        private int _number;
        private List<int> _previousGuesses;
        public const int MaxNumberOfGuesses = 7;

        public bool CanMakeGuess { get; set; }
        public int Count { get; set; }
        public int? Number { get { return _number; } }
        public Outcome Outcome { get; set; }
        public IEnumerable<int> PreviousGuesses { get { return _previousGuesses.AsReadOnly(); } }

        public void Initialize()
        {
            _number = new Random().Next(1, 100);
            if (_previousGuesses.Count >= 1)
            {
                _previousGuesses.Clear();
            }
            Outcome = Outcome.Indefinite;
            CanMakeGuess = true;
        }

        public Outcome MakeGuess(int guess)
        {
            if (guess < 1 || guess > 100)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (PreviousGuesses.Contains(guess))
            {
                CanMakeGuess = true;
                return Outcome.PreviousGuess;
            }

            _previousGuesses.Add(guess);
            Count = _previousGuesses.Count;

            if (guess == Number)
            {
                CanMakeGuess = false;
                return Outcome.Correct;
            }

            if (Count >= MaxNumberOfGuesses)
            {
                CanMakeGuess = false;
                return Outcome.NoMoreGuesses;
            }

            if (guess < Number)
            {
                CanMakeGuess = true;
                return Outcome.Low;
            }
            
            if (guess > Number)
            {
                CanMakeGuess = true;
                return Outcome.High;
            }

            return Outcome.Indefinite;
        }

        public SecretNumber()
        {
            _previousGuesses = new List<int>(); // med plats för 7 element?
            Initialize();
        }
    }
}