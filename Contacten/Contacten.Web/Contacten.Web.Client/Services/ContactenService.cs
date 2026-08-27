using Contacten.Models;
using System.Net;
using System.Net.Http.Json;

namespace Contacten.Web.Client.Services
{
    public class ContactenService
    {
        private readonly HttpClient httpClient;
        public ContactenService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<Contact>> GetContacten()
        {
            var response = await httpClient.GetAsync("api/contacten");
            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    return await response.Content.ReadFromJsonAsync<List<Contact>>();
                default:
                    return null;
            }
        }

        public async Task<Contact> GetContact(int id)
        {
            var response = await httpClient.GetAsync($"api/contacten/{id}");
            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    return await response.Content.ReadFromJsonAsync<Contact>();
                default:
                    return null;
            }
        }

        public async Task<Contact> UpdateContact(Contact contact)
        {
            HttpResponseMessage message = await httpClient.PutAsJsonAsync<Contact>(
            $"api/contacten/{contact.ContactId}", contact);
            if (message.IsSuccessStatusCode)
                return contact;
            else
                return null;
        }

        public async Task DeleteContact(int id)
        {
            await httpClient.DeleteAsync($"api/contacten/{id}");
        }

        public async Task<Contact> AddContact(Contact contact)
        {
            HttpResponseMessage message = await httpClient.PostAsJsonAsync<Contact>(
            $"api/contacten", contact);
            if (message.IsSuccessStatusCode)
                return contact;
            else
                return null;
        }
    }
}
