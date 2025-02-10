using Newtonsoft.Json;

namespace Questao2
{
    public class Match
    {
        [JsonProperty("competition")]
        public string Competition { get; set; }

        [JsonProperty("year")]
        public int Year { get; set; }

        [JsonProperty("round")]
        public string Round { get; set; }

        [JsonProperty("team1")]
        public string Team1 { get; set; }

        [JsonProperty("team2")]
        public string Team2 { get; set; }

        [JsonProperty("team1goals")]
        public string Team1Goals { get; set; }  

        [JsonProperty("team2goals")]
        public string Team2Goals { get; set; }  

        public int Team1GoalsInt => int.TryParse(Team1Goals, out int goals) ? goals : 0;
        public int Team2GoalsInt => int.TryParse(Team2Goals, out int goals) ? goals : 0;

    }
}
