using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenAI_API;
using OpenAI_API.Completions;

namespace OpenAIChatGPT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpenAI : ControllerBase
    {
        private readonly IConfigProvider _iconfigprovider;
        public OpenAI(IConfigProvider iconfigprovider)
        {
            _iconfigprovider = iconfigprovider;
        }

        [HttpGet]
        public async Task<IActionResult> GetData(string input)
        {
            string apiKey = _iconfigprovider.GetAPIKey;
            string response = "";
            OpenAIAPI openai = new OpenAIAPI(apiKey);
            CompletionRequest completion = new CompletionRequest();
            completion.Prompt = input;
            completion.Model = "gpt-3.5-turbo-1106";
            completion.MaxTokens = 4000;
            var output = await openai.Completions.CreateCompletionAsync(completion);
            if (output != null)
            {
                foreach (var item in output.Completions)
                {
                    response = item.Text;
                }
                return Ok(response);
            }
            else
            {
                return BadRequest($"Dat not found");
            }
        }
    }
}
