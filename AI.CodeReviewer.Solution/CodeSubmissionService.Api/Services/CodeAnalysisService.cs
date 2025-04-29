using CodeSubmissionService.Api.IServices;
using CodeSubmissionService.Api.Models;
using System.Text.Json;
using System.Text;
using System.Net.Http;

namespace CodeSubmissionService.Api.Services
{
    public class CodeAnalysisService : ICodeAnalysisService
    {

        private readonly HttpClient _httpClient;

        // Inject HttpClient via constructor (used to send requests to Ollama API)
        public CodeAnalysisService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        /// <summary>
        /// This method sends the submitted code to the local Ollama model and returns the AI's response
        /// </summary>
        /// <param name="code"></param>
        /// <param name="language"></param>
        /// <returns></returns>
        public async Task<CodeAnalysisResponse> AnalyzeCodeAsync(CodeRequest codeRequest)
        {
            // Creating the prompt message to instruct the model what to do
            var prompt = $"Analyze the following {codeRequest.Language} code for improvements, bugs, and best practices:\n\n{codeRequest.Code}";

            // Creating the request body expected by Ollama API
            var requestBody = new
            {
                model = "codellama",
                prompt = prompt,
                stream = false
            };

            // Serialize the request into JSON and set it as the request content

            var content = new StringContent(JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json");

            // Sending POST request to local Ollama server running on port 11434
            var response = await _httpClient.PostAsync("http://localhost:11434/api/generate", content);
            response.EnsureSuccessStatusCode(); // throws error if response is not 200 OK
                                    
            var result = await response.Content.ReadAsStringAsync();
            var json = JsonDocument.Parse(result);
            var feedback = json.RootElement.GetProperty("response").GetString();

            return new CodeAnalysisResponse
            {
                Feedback = feedback,
                IsSuccess = true
            };
        }
    }
    
}
