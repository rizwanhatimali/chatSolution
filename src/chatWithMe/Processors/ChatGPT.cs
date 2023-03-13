using chatWithMe.Models;
using Microsoft.ML;
using OpenAI_API.Completions;
using OpenAI_API;

namespace chatWithMe.Processors
{
    public static class ChatGPT
    {
        public static string GetMyAnswer(ChatInput chatInput)
        {
            string answer = string.Empty;
            var openai = new OpenAIAPI(chatInput.OpenAIApiKey);
            CompletionRequest completion = new CompletionRequest();
            completion.Prompt = chatInput.Question;
            completion.MaxTokens = 4000;
            var result = openai.Completions.CreateCompletionAsync(completion);
            if (result != null)
            {
                foreach (var item in result.Result.Completions)
                {
                    answer = item.Text;
                }
                return answer;
            }
            else
            {
                return "Explain more about your Query";
            }
        }
    }
}
