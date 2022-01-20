using System;
using System.Collections.Generic;

// Fonte: https://balta.io/blog/csharp-delegates

namespace DelegatesSample
{
    class Program
    {
        // Ponteiros
        private delegate void OnSuccessDelegate(IEnumerable<Models.ArticleModel> data);
        private delegate void OnErrorDelegate(Models.ErrorModel data);

        static void Main(string[] args)
        {
            /*
                Delegate é como se fosse um callback em javascript. Ou seja, uma rotina que é passada como parâmetro para outro método.
            */
            
            OnSuccessDelegate onSuccessHandler = OnSuccess;
            OnErrorDelegate onErrorHandler = OnError;

            GetArticles(onSuccessHandler, onErrorHandler);

            Console.ReadKey();
        }

        private static void OnSuccess(IEnumerable<Models.ArticleModel> data)
        {
            foreach (var item in data)
            {
                Console.WriteLine(item.Title);
            }
        }

        private static void OnError(Models.ErrorModel data)
        {
            Console.WriteLine($"ERRO: {data.Message}");
        }

        private static void GetArticles(OnSuccessDelegate onSuccess, OnErrorDelegate onError)
        {
            try
            {
                var data = new List<Models.ArticleModel>();
                data.Add(new Models.ArticleModel(1, "Orientação a objetos"));
                data.Add(new Models.ArticleModel(2, "Fundamentos do C#"));
                //throw new Exception("Deu ruim");
                onSuccess(data);
            }
            catch (Exception ex)
            {
                onError(new Models.ErrorModel($"Ocorreu um erro: {ex.Message}"));
            }
        }
    }
}
