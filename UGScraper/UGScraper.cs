﻿using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TabFinder
{
    public class UGScraper
    {
        private static string baseURL = "https://www.ultimate-guitar.com/search.php?search_type=title&value=";
        private ChromeDriver browser;
        public UGScraper()
        {
            var options = new ChromeOptions()
            {
                BinaryLocation = "C:\\Program Files (x86)\\Google\\Chrome\\Application\\chrome.exe"
            };
            options.AddArguments(new List<string>() { "headless", "disable-gpu" });
            options.AddArgument("--log-level=2");
            options.SetLoggingPreference(LogType.Browser, LogLevel.Severe); // Not sure if these are helping?
            options.SetLoggingPreference(LogType.Client, LogLevel.Severe);
            options.SetLoggingPreference(LogType.Driver, LogLevel.Severe);
            options.SetLoggingPreference(LogType.Profiler, LogLevel.Severe);
            options.SetLoggingPreference(LogType.Server, LogLevel.Severe);
            this.browser = new ChromeDriver(options);

        }
        public List<UGTab> GetAllTabs(List<BasicSong> allTracks, UGType type)
        {
            Console.WriteLine($"Getting {allTracks.Count} tabs");
            List<UGTab> tabs = new List<UGTab>();
            try
            {
                foreach (BasicSong track in allTracks)
                {
                    string fullTrack = $"{track.artist} - {track.title}";
                    Console.WriteLine($"Searching for tabs for {fullTrack}");
                    UGSearch searchResults = this.GetSearchResult(track, type);
                    UGSearchResult bestCandidate = searchResults.GetBestResult();
                    Console.WriteLine($"Getting tab for {fullTrack}");
                    if (bestCandidate == null)
                    {
                        Console.WriteLine($"No tab found for {fullTrack}");
                    }
                    else
                    {
                        tabs.Add(this.GetTab(bestCandidate));
                    }
                }
                browser.Quit();
                return tabs;
            }
            catch
            {
                browser.Quit();
                throw;
            }

        }

        public UGSearch GetSearchResult(BasicSong track, UGType type)
        {
            // TODO multi-page support
            string fullUrl = $"{baseURL}{track.searchString}&type={(int)type}";
            this.browser.Navigate().GoToUrl(fullUrl);
            var mainList = browser.FindElementsByCssSelector("article > div > div");
            return new UGSearch(mainList);
        }

        public UGTab GetTab(UGSearchResult searchResult)
        {
            string tab;
            if (!searchResult.canStoreContent)
            {
                tab = "Cannot store in text format, see: " + searchResult.href;
            } 
            else
            {
                this.browser.Navigate().GoToUrl(searchResult.href);
                tab = browser.FindElementByTagName("code").Text;
            }
            return new UGTab(searchResult.artist,
                    searchResult.songAndVer,
                    searchResult.rating,
                    searchResult.numRatings,
                    tab);
        }
    }
}
