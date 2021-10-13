using Safar.UIService.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Safar.UIService
{
    public class SafarService
    {
        public GenericUiService gnericUiService;
        public SafarService()
        {
            gnericUiService = new GenericUiService();
        }
        public VerifiedUserDto GetUserById(int userId)
        {
            var task = Task.Run(async () => await gnericUiService.GenericGetResult<VerifiedUserDto>("getuserbyid/", userId));
            return task.Result;
        }

        public int AddUser(VerifiedUserDto entity)
        {
            try
            {
                var task = Task.Run(async () => await gnericUiService.GenericPostResult<VerifiedUserDto, Dictionary<string, object>>("save", entity));
                var addResponse = task.Result;
                return Convert.ToInt32(addResponse["Id"]);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<string> GenricPostURI(HttpContent c)
        {
            var response = string.Empty;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:19450/save");
                HttpResponseMessage result = await client.PostAsync(client.BaseAddress, c);
                if (result.IsSuccessStatusCode)
                {
                    response = result.StatusCode.ToString();
                }
            }
            return response;
        }
    }
}
