using Newtonsoft.Json;
using Questao2;

public class Program
{
    public static async Task Main()
    {
        string teamName = "Paris Saint-Germain";
        int year = 2013;
        int totalGoals = await getTotalScoredGoals(teamName, year);

        Console.WriteLine($"Team {teamName} scored {totalGoals} goals in {year}");

        teamName = "Chelsea";
        year = 2014;
        totalGoals = await getTotalScoredGoals(teamName, year);

        Console.WriteLine($"Team {teamName} scored {totalGoals} goals in {year}");

        // Output expected:
        // Team Paris Saint - Germain scored 109 goals in 2013
        // Team Chelsea scored 92 goals in 2014
    }

    public static async Task<int> getTotalScoredGoals(string team, int year)
    {

        int totalGoals = 0;

        string url = $"https://jsonmock.hackerrank.com/api/football_matches?year={year}&team1={team}";
        totalGoals += await GetTotalFromAPI(url, isTeam1: true);

        url = $"https://jsonmock.hackerrank.com/api/football_matches?year={year}&team2={team}";
        totalGoals += await GetTotalFromAPI(url, isTeam1: false);

        return totalGoals;
    }

    public static async Task<int> GetTotalFromAPI(string url, bool isTeam1)
    {
        int totalGoals = 0;
        int currentPage = 1;
        int totalPages = 1;
        using (HttpClient client = new HttpClient())
        {
            do
            {
                string paginatedUrl = $"{url}&page={currentPage}";
                var response = await client.GetStringAsync(paginatedUrl);

                ApiResponse apiResponse = JsonConvert.DeserializeObject<ApiResponse>(response);

                totalPages = apiResponse.TotalPages;

                foreach (var match in apiResponse.Data)
                {
                    totalGoals += isTeam1 ? match.Team1GoalsInt : match.Team2GoalsInt;
                }

                currentPage++;

            } while (currentPage <= totalPages);
        }
        return totalGoals;
    }
}