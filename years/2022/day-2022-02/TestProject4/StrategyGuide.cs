using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TestProject4
{
    internal class StrategyGuide
    {
        public dynamic Day02 { get; }
        public Dictionary<String, dynamic> SignsByOpCode { get; }
        public Dictionary<string, dynamic> SignsBySuggestionCode { get; }
        public Dictionary<string, dynamic> SignsByName { get; }

        private List<string> RawData;

        public StrategyGuide(string data)
        {
            var json = File.ReadAllText("../../../../SSoT/Day02.json");
            this.Day02 = ((dynamic)JsonConvert.DeserializeObject(json)).AdventOfCode.Year2022.Day02;
            this.SignsByOpCode = new Dictionary<String, dynamic>();
            this.SignsBySuggestionCode = new Dictionary<String, dynamic>();
            this.SignsByName = new Dictionary<String, dynamic>();
            foreach (var sign in this.Day02.Signs.Sign)
            {
                this.SignsByOpCode[$"{sign.OpponentCode}"] = sign;
                this.SignsBySuggestionCode[$"{sign.SuggestionCode}"] = sign;
                this.SignsByName[$"{sign.Name}"] = sign;
            }
            this.RawData = data.Split(Environment.NewLine).ToList();
        }

        internal DateTime CalculateSomeDate()
        {
            throw new NotImplementedException();
        }

        internal Int32 GetExpecteGameScore()
        {
            return Int32.Parse($"{this.Day02.SampleGames.SampleGame.GameScore}");
        }

        internal int GetTotal()
        {
            return this.RawData.Sum(line => CalculateLineScore(line));
        }

        internal int GetTotal2()
        {
            return this.RawData.Sum(line => CalculateLineSCore2(line));
        }

        private int CalculateLineScore(string line)
        {
            var parts = line.Split(" ".ToCharArray()).ToList();
            var opponentSign = this.SignsByOpCode[parts[0]];
            var suggestedSign = this.SignsBySuggestionCode[parts[1]];
            var status = suggestedSign.WinsAgainstName == opponentSign.Name ? "Win" :
                        (suggestedSign.LosesToName == opponentSign.Name ? "Loss" : "Draw");
            if (status == "Win") return Int32.Parse($"{suggestedSign.WinScore}");
            else if (status == "Loss") return Int32.Parse($"{suggestedSign.LossScore}");
            else return Int32.Parse($"{suggestedSign.DrawScore}");
        }

        private int CalculateLineSCore2(string line)
        {
            var parts = line.Split(" ".ToCharArray()).ToList();
            var opponentSign = this.SignsByOpCode[parts[0]];
            dynamic suggestedSign = JsonConvert.DeserializeObject("{}");
            switch (parts[1])
            {
                case "X":
                    suggestedSign = this.SignsByName[$"{opponentSign.WinsAgainstName}"];
                    break;

                case "Y":
                    suggestedSign = this.SignsByName[$"{opponentSign.Name}"];
                    break;

                case "Z":
                    suggestedSign = this.SignsByName[$"{opponentSign.LosesToName}"];
                    break;

                default:
                    throw new Exception("Unexpected");
            }
            var status = suggestedSign.WinsAgainstName == opponentSign.Name ? "Win" :
                        (suggestedSign.LosesToName == opponentSign.Name ? "Loss" : "Draw");
            if (status == "Win") return Int32.Parse($"{suggestedSign.WinScore}");
            else if (status == "Loss") return Int32.Parse($"{suggestedSign.LossScore}");
            else return Int32.Parse($"{suggestedSign.DrawScore}");
        }

    }
}