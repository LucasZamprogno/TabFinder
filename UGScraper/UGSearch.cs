using System.Collections.Generic;
using OpenQA.Selenium;

namespace TabFinder
{
    public class UGSearch
    {
        private List<UGSearchResult> allResults;
        public int Count { get { return allResults.Count; } }
        public UGSearch(IReadOnlyCollection<IWebElement> divList)
        {
            List<IWebElement> asList = new List<IWebElement>(divList);
            List<UGSearchResult> all = new List<UGSearchResult>();
            asList.RemoveAt(0); // Remove header
            string currentArtist = "";
            foreach (IWebElement div in asList)
            {
                string artistMaybe = div.FindElements(By.XPath("./*"))[0].Text.Trim();
                if (artistMaybe.Length > 0)
                {
                    currentArtist = artistMaybe;
                }
                if (!UGSearchResult.PaidOnly(div))
                {
                    all.Add(new UGSearchResult(currentArtist, div));
                }
            }
            all.Sort(HumanRankReviews);
            this.allResults = all;
        }

        public UGSearchResult? GetBestResult()
        {
            return this.allResults.Count > 0 ? this.allResults[0] : null;
        }

        private int HumanRankReviews(UGSearchResult first, UGSearchResult second)
        {
            // Special human bayesian judgment call case
            if (first.rating == 4 && second.rating == 5 &&
                second.numRatings < 5 && first.numRatings > 30)
            {
                return -1; // Give precedence to lots of reviews over a few 5s
            }
            if (first.rating == second.rating)
            {
                return first.numRatings > second.numRatings ? -1 : 1; // Same stars, take with more reviews
            }
            return first.rating > second.rating ? -1 : 1; // Just go by number of stars
        }
    }
}
