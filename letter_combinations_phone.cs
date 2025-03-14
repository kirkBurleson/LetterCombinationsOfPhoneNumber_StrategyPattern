public class Solution {
    // Each strategy (algorithm) class must implement this method
    // specific to it's use case
    public interface ILetterCombinationStrategy
    {
        public IList<string> Process();
    }

    // wrapper class
    public class LetterCombinationSolver
    {
        // This holds the strategy (2, 3, or 4 numbers) we will pass in later
        private readonly ILetterCombinationStrategy strategy;

        // Accepts a strategy class that implements the ILetterCombinationStrategy interface
        public LetterCombinationSolver(ILetterCombinationStrategy strategy)
        {
            this.strategy = strategy;
        }

        // Call this method after instantiating the class
        public IList<string> Process()
        {
            // This fires off the algorithm specific to the strategy
            // class we passed into our class when we created it
            return strategy.Process();
        }
    }

    // Algorithm implementations (Change these to what you want)
    public class TwoDigits(string firstGroup, string secondGroup) : ILetterCombinationStrategy
    {
        private IList<string> result = new List<string>();

        // iterate each group of letters
        // concatenate the characters into a string
        // add string to result list
        public IList<string> Process()
        {
            foreach (char c in firstGroup)
            {
                foreach (char d in secondGroup)
                {
                    result.Add(c.ToString() + d.ToString());
                }
            }

            return result;
        }
    }

    public class ThreeDigits(string firstGroup, string secondGroup, string thirdGroup) : ILetterCombinationStrategy
    {
        private IList<string> result = new List<string>();

        // iterate each group of letters
        // concatenate the characters into a string
        // add string to result list
        public IList<string> Process()
        {
            foreach (char c in firstGroup)
            {
                foreach (char d in secondGroup)
                {
                    foreach (char e in thirdGroup)
                    {
                        result.Add(c.ToString() + d.ToString() + e.ToString());
                    }
                }
            }

            return result;
        }
    }

    public class FourDigits(string firstGroup, string secondGroup, string thirdGroup, string fourthGroup) : ILetterCombinationStrategy
    {
        private IList<string> result = new List<string>();

        // iterate each group of letters
        // concatenate the characters into a string
        // add string to result list
        public IList<string> Process()
        {
            foreach (char c in firstGroup)
            {
                foreach (char d in secondGroup)
                {
                    foreach (char e in thirdGroup)
                    {
                        foreach (char f in fourthGroup)
                        {
                            result.Add(c.ToString() + d.ToString() + e.ToString() + f.ToString());
                        }
                    }
                }
            }

            return result;
        }
    }

    public IList<string> LetterCombinations(string digits) {
        var result = new List<string>();

        // check for null and empty input
        if (string.IsNullOrEmpty(digits)) { return result; }

        // map our digits to their letters
        Dictionary<char, string> letters = new Dictionary<char, string>() {
            {'2', "abc"}, {'3', "def"}, { '4', "ghi" }, { '5', "jkl" },
            { '6', "mno" }, {'7',"pqrs" }, {'8',"tuv" }, {'9',"wxyz" }
        };

        // Only 1 digit, return every letter as an individual string ("a", "b", "c", etc...)
        if (digits.Length == 1)
        {
            string letterGroup = letters[digits[0]];
            foreach (char s in letterGroup) { result.Add(s.ToString()); }
            return result;
        }

        // which strategy do we use?

        // use strategy classes directly
        // if (digits.Length == 2) { return new TwoDigits(letters[digits[0]], letters[digits[1]]).Process(); }
        // if (digits.Length == 3) { return new ThreeDigits(letters[digits[0]], letters[digits[1]], letters[digits[2]]).Process(); }
        // if (digits.Length == 4) { return new FourDigits(letters[digits[0]], letters[digits[1]], letters[digits[2]], letters[digits[3]]).Process(); }

        // use a wrapper class
        if (digits.Length == 2) { return new LetterCombinationSolver(new TwoDigits(letters[digits[0]], letters[digits[1]])).Process(); }
        else if (digits.Length == 3) { return new LetterCombinationSolver(new ThreeDigits(letters[digits[0]], letters[digits[1]], letters[digits[2]])).Process(); }
        else if (digits.Length == 4) { return new LetterCombinationSolver(new FourDigits(letters[digits[0]], letters[digits[1]], letters[digits[2]], letters[digits[3]])).Process(); }

        return result;
    }
}