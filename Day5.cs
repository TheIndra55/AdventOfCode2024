namespace AdventOfCode2024
{
    internal class Day5 : IDay
    {
        private List<string[]> GetPages(string[] input, bool correct)
        {
            var theRules = input.Where(x => x.Contains('|')).Select(x => x.Split("|"));
            var updates = input.Where(x => x.Contains(','));

            var matches = new List<string[]>();

            foreach (var update in updates)
            {
                var pages = update.Split(',');
                var done = new List<string>();

                foreach (var page in pages)
                {
                    var rules = theRules.Where(x => x[1] == page);

                    if (rules.Any(
                        // Check if the page from the rule appeared before
                        rule => pages.Contains(rule[0]) && !done.Contains(rule[0])))
                    {
                        break;
                    }

                    done.Add(page);
                }

                if (done.Count == pages.Length == correct)
                {
                    matches.Add(pages);
                }
            }

            return matches;
        }

        public object Part1(string[] input)
        {
            var correct = GetPages(input, true);

            return correct.Sum(pages => int.Parse(pages[pages.Length / 2]));
        }

        public object Part2(string[] input)
        {
            var theRules = input.Where(x => x.Contains('|')).Select(x => x.Split("|"));
            var incorrect = GetPages(input, false);

            var correct = new List<string[]>();

            foreach (var pages in incorrect.Select(x => x.ToList()))
            {
                for (var i = 0; i < pages.Count; i++)
                {
                    var page = pages[i];
                    var rules = theRules.Where(x => x[1] == page);

                    foreach (var rule in rules)
                    {
                        var before = pages.Take(i);

                        if (pages.Contains(rule[0]) && !before.Contains(rule[0]))
                        {
                            // Remove the page and add it back in front
                            pages.Remove(rule[0]);
                            pages.Insert(i, rule[0]);

                            // Sort again
                            i--;
                            break;
                        }
                    }
                }

                correct.Add(pages.ToArray());
            }

            return correct.Sum(pages => int.Parse(pages[pages.Length / 2]));
        }
    }
}
