//using Azure;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System;
using System.Text;
using Proyecto_ProgramacionWeb_1131119.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Threading.Tasks;

namespace Proyecto_ProgramacionWeb_1131119.Functions
{
    public class APIServices
    {
        public static int timeout = 30;
        public static string baseurl = "https://localhost:7229/";

        public static async System.Threading.Tasks.Task<IEnumerable<Usuario>> UsuariosGetList()
        {
            //var json_ = Newtonsoft.Json.JsonConvert.SerializeObject(object_to_serialize);
            //var content = new StringContent(json_, Encoding.UTF8, "application/json");

            HttpClientHandler clientHandler = new HttpClientHandler();

            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            // Pass the handler to httpclient(from you are calling api)

            HttpClient httpClient = new HttpClient(clientHandler);

            httpClient.Timeout = TimeSpan.FromSeconds(timeout);

            //var response = await httpClient.PostAsync(baseurl + "Movies/GetList", content);
            var response = await httpClient.PostAsync(baseurl + "Home/GetListUsuario", null);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)

            {
                return JsonConvert.DeserializeObject<IEnumerable<Usuario>>(await response.Content.ReadAsStringAsync());
            }

            else

            {
                throw new Exception(response.StatusCode.ToString());
            }
        }

        public static async System.Threading.Tasks.Task<IEnumerable<Usuario>> GetUsuarioE(string Nombre, string Contraseña)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            // Pass the handler to httpclient(from you are calling api)
            HttpClient httpClient = new HttpClient(clientHandler);
            httpClient.Timeout = TimeSpan.FromSeconds(timeout);
            var response = await httpClient.PostAsync(baseurl + "Home/GetUsuarioE?Nombre=" + Nombre + "&Contraseña=" + Contraseña, null);


            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var usuario = JsonConvert.DeserializeObject<Usuario>(responseContent);
                return new List<Usuario> { usuario };
            }
            else
            {
                Usuario usuario = new Usuario()
                {
                    IdUsuario = 0
                };
                return new List<Usuario> { usuario };
            }
        }

        public static async System.Threading.Tasks.Task<IEnumerable<Usuario>> UsuarioGet(int id)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            // Pass the handler to httpclient(from you are calling api)
            HttpClient httpClient = new HttpClient(clientHandler);
            httpClient.Timeout = TimeSpan.FromSeconds(timeout);
            var response = await httpClient.PostAsync(baseurl + "Home/GetUsuario?Id=" + id, null);
            // var response = await httpClient.PostAsync(baseurl + "Movies/Get/"+id, null);


            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var usuario = JsonConvert.DeserializeObject<Usuario>(responseContent);
                return new List<Usuario> { usuario };
            }
            else
            {
                Usuario usuario = new Usuario()
                {
                    IdUsuario = 0
                };
                return new List<Usuario> { usuario };
            }
        }

        public static async System.Threading.Tasks.Task<IEnumerable<Usuario>> UsuarioGetP(int id)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            // Pass the handler to httpclient(from you are calling api)
            HttpClient httpClient = new HttpClient(clientHandler);
            httpClient.Timeout = TimeSpan.FromSeconds(timeout);
            var response = await httpClient.PostAsync(baseurl + "Home/GetUsuarioP?Id=" + id, null);
            // var response = await httpClient.PostAsync(baseurl + "Movies/Get/"+id, null);


            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var usuario = JsonConvert.DeserializeObject<Usuario>(responseContent);
                return new List<Usuario> { usuario };
            }
            else
            {
                Usuario usuario = new Usuario()
                {
                    IdUsuario = 0
                };
                return new List<Usuario> { usuario };
            }
        }
        public static async System.Threading.Tasks.Task<IEnumerable<Personal>> PersonalGet(int id)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            // Pass the handler to httpclient(from you are calling api)
            HttpClient httpClient = new HttpClient(clientHandler);
            httpClient.Timeout = TimeSpan.FromSeconds(timeout);
            var response = await httpClient.PostAsync(baseurl + "Home/GetPersonal?Id=" + id, null);
            // var response = await httpClient.PostAsync(baseurl + "Movies/Get/"+id, null);


            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var personal = JsonConvert.DeserializeObject<Personal>(responseContent);
                return new List<Personal> { personal };
            }
            else
            {
                Personal personal = new Personal()
                {
                    IdPersonal = 0
                };
                return new List<Personal> { personal };
            }
        }
        public static async System.Threading.Tasks.Task<IEnumerable<Paciente>> PacienteGet(int id)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            // Pass the handler to httpclient(from you are calling api)
            HttpClient httpClient = new HttpClient(clientHandler);
            httpClient.Timeout = TimeSpan.FromSeconds(timeout);
            var response = await httpClient.PostAsync(baseurl + "Home/GetPaciente?Id=" + id, null);
            // var response = await httpClient.PostAsync(baseurl + "Movies/Get/"+id, null);


            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var paciente = JsonConvert.DeserializeObject<Paciente>(responseContent);
                return new List<Paciente> { paciente };
            }
            else
            {
                Paciente paciente = new Paciente()
                {
                    IdPaciente = 0
                };
                return new List<Paciente> { paciente };
            }
        }

        public static async System.Threading.Tasks.Task<IEnumerable<Persona>> PersonaGet(int id)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            // Pass the handler to httpclient(from you are calling api)
            HttpClient httpClient = new HttpClient(clientHandler);
            httpClient.Timeout = TimeSpan.FromSeconds(timeout);
            var response = await httpClient.PostAsync(baseurl + "Home/GetPersona?Id=" + id, null);
            // var response = await httpClient.PostAsync(baseurl + "Movies/Get/"+id, null);


            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var persona = JsonConvert.DeserializeObject<Persona>(responseContent);
                return new List<Persona> { persona };
            }
            else
            {
                Persona persona = new Persona()
                {
                    IdPersona = 0
                };
                return new List<Persona> { persona };
            }
        }

        public static async System.Threading.Tasks.Task<IEnumerable<GeneralResult>> PersonaSet(Persona object_to_serialize)
        {
            var json_ = Newtonsoft.Json.JsonConvert.SerializeObject(object_to_serialize);
            var content = new StringContent(json_, Encoding.UTF8, "application/json");

            HttpClientHandler clientHandler = new HttpClientHandler();

            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            // Pass the handler to httpclient(from you are calling api)

            HttpClient httpClient = new HttpClient(clientHandler);

            httpClient.Timeout = TimeSpan.FromSeconds(timeout);

            var response = await httpClient.PostAsync(baseurl + "Home/PostPersona", content);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                //var responseContent = await response.Content.ReadAsStringAsync();
                //var result2 = JsonConvert.DeserializeObject<GeneralResult>(responseContent);
                var responseContent = await response.Content.ReadAsStringAsync();
                var general = JsonConvert.DeserializeObject<GeneralResult>(responseContent);
                GeneralResult result = new GeneralResult { Result = true, ErrorMessage = general.ErrorMessage};
                return new List<GeneralResult> { result };
            }

            else
            {
                GeneralResult result = new GeneralResult { Result = false };
                return new List<GeneralResult> { result };
            }
        }

        public static async System.Threading.Tasks.Task PostPersonal(Personal object_to_serialize)
        {
            var json_ = Newtonsoft.Json.JsonConvert.SerializeObject(object_to_serialize);
            var content = new StringContent(json_, Encoding.UTF8, "application/json");

            HttpClientHandler clientHandler = new HttpClientHandler();

            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            // Pass the handler to httpclient(from you are calling api)

            HttpClient httpClient = new HttpClient(clientHandler);

            httpClient.Timeout = TimeSpan.FromSeconds(timeout);

            var response = await httpClient.PostAsync(baseurl + "Home/PostPersonal", content);

            //if (response.StatusCode == System.Net.HttpStatusCode.OK)

            //{
            //    return JsonConvert.DeserializeObject<IEnumerable<GeneralResult>>(await response.Content.ReadAsStringAsync());
            //}

            //else

            //{
            //    throw new Exception(response.StatusCode.ToString());
            //}
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new Exception(response.StatusCode.ToString());
            }
        }

        public static async Task PostPaciente(Paciente object_to_serialize)
        {
            var json_ = Newtonsoft.Json.JsonConvert.SerializeObject(object_to_serialize);
            var content = new StringContent(json_, Encoding.UTF8, "application/json");

            HttpClientHandler clientHandler = new HttpClientHandler();

            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            // Pass the handler to httpclient(from you are calling api)

            HttpClient httpClient = new HttpClient(clientHandler);

            httpClient.Timeout = TimeSpan.FromSeconds(timeout);

            var response = await httpClient.PostAsync(baseurl + "Home/PostPaciente", content);

            //if (response.StatusCode == System.Net.HttpStatusCode.OK)

            //{
            //    return JsonConvert.DeserializeObject<IEnumerable<GeneralResult>>(await response.Content.ReadAsStringAsync());
            //}

            //else

            //{
            //    throw new Exception(response.StatusCode.ToString());
            //}

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new Exception(response.StatusCode.ToString());
            }
        }

        public static async Task PostUsuario(Usuario object_to_serialize)
        {
            var json_ = Newtonsoft.Json.JsonConvert.SerializeObject(object_to_serialize);
            var content = new StringContent(json_, Encoding.UTF8, "application/json");

            HttpClientHandler clientHandler = new HttpClientHandler();

            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            // Pass the handler to httpclient(from you are calling api)

            HttpClient httpClient = new HttpClient(clientHandler);

            httpClient.Timeout = TimeSpan.FromSeconds(timeout);

            var response = await httpClient.PostAsync(baseurl + "Home/PostUsuario", content);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new Exception(response.StatusCode.ToString());
            }
        }

        public static async Task EditPersona(Persona object_to_serialize)
        {
            var json_ = Newtonsoft.Json.JsonConvert.SerializeObject(object_to_serialize);
            var content = new StringContent(json_, Encoding.UTF8, "application/json");

            HttpClientHandler clientHandler = new HttpClientHandler();

            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            // Pass the handler to httpclient(from you are calling api)

            HttpClient httpClient = new HttpClient(clientHandler);

            httpClient.Timeout = TimeSpan.FromSeconds(timeout);

            var response = await httpClient.PutAsync(baseurl + "Home/EditPersona", content);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new Exception(response.StatusCode.ToString());
            }
        }

        public static async Task EditUsuario(Usuario object_to_serialize)
        {
            var json_ = Newtonsoft.Json.JsonConvert.SerializeObject(object_to_serialize);
            var content = new StringContent(json_, Encoding.UTF8, "application/json");

            HttpClientHandler clientHandler = new HttpClientHandler();

            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            // Pass the handler to httpclient(from you are calling api)

            HttpClient httpClient = new HttpClient(clientHandler);

            httpClient.Timeout = TimeSpan.FromSeconds(timeout);

            var response = await httpClient.PutAsync(baseurl + "Home/EditUsuario", content);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new Exception(response.StatusCode.ToString());
            }
        }

        public static async Task EditPaciente(Paciente object_to_serialize)
        {
            var json_ = Newtonsoft.Json.JsonConvert.SerializeObject(object_to_serialize);
            var content = new StringContent(json_, Encoding.UTF8, "application/json");

            HttpClientHandler clientHandler = new HttpClientHandler();

            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            // Pass the handler to httpclient(from you are calling api)

            HttpClient httpClient = new HttpClient(clientHandler);

            httpClient.Timeout = TimeSpan.FromSeconds(timeout);

            var response = await httpClient.PutAsync(baseurl + "Home/EditPaciente", content);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new Exception(response.StatusCode.ToString());
            }
        }

        public static async Task EditPersonal(Personal object_to_serialize)
        {
            var json_ = Newtonsoft.Json.JsonConvert.SerializeObject(object_to_serialize);
            var content = new StringContent(json_, Encoding.UTF8, "application/json");

            HttpClientHandler clientHandler = new HttpClientHandler();

            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            // Pass the handler to httpclient(from you are calling api)

            HttpClient httpClient = new HttpClient(clientHandler);

            httpClient.Timeout = TimeSpan.FromSeconds(timeout);

            var response = await httpClient.PutAsync(baseurl + "Home/EditPersonal", content);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new Exception(response.StatusCode.ToString());
            }
        }

        public static async Task DeletePersona(int id)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            // Pass the handler to httpclient(from you are calling api)
            HttpClient httpClient = new HttpClient(clientHandler);
            httpClient.Timeout = TimeSpan.FromSeconds(timeout);
            var response = await httpClient.DeleteAsync(baseurl + "Home/DeletePersona?Id=" + id);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new Exception(response.StatusCode.ToString());
            }
        }
    }
}
