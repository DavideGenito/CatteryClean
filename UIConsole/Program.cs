using System;
using Application.UseCases;
using Infrastructure.Repositories;
using Infrastructure;
using Application.Dto;

namespace UIConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Setup manuale delle dipendenze
            var catRepository = new JsonCatRepository();
            var catteryUseCase = new Cattery(catRepository);

            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("🐱  GESTIONE GATTILE");
                Console.WriteLine("=======================");
                Console.WriteLine("1. Registra nuovo gatto");
                Console.WriteLine("2. Visualizza gatti presenti");
                Console.WriteLine("3. Esci");
                Console.Write("\nScelta: ");
                var scelta = Console.ReadLine();

                switch (scelta)
                {
                    case "1":
                        RegistraGatto(catteryUseCase);
                        break;
                    case "2":
                        VisualizzaGatti(catteryUseCase);
                        break;
                    case "3":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("❌ Scelta non valida!");
                        break;
                }

                if (!exit)
                {
                    Console.WriteLine("\nPremi un tasto per continuare...");
                    Console.ReadKey();
                }
            }
        }

        static void RegistraGatto(Cattery cattery)
        {
            Console.Clear();
            Console.WriteLine("🐾 Nuovo Gatto\n");

            Console.Write("Nome: ");
            string nome = Console.ReadLine() ?? "";

            Console.Write("Razza: ");
            string razza = Console.ReadLine() ?? "";

            Console.Write("Sesso (M/F): ");
            string sesso = Console.ReadLine() ?? "";

            Console.Write("Data di arrivo (yyyy-MM-dd): ");
            DateTime dataArrivo = DateTime.Parse(Console.ReadLine() ?? "");

            Console.Write("Data di nascita (vuoto se sconosciuta): ");
            string inputNascita = Console.ReadLine() ?? "";
            DateTime? dataNascita = null;
            int? annoPresunto = null;
            if (!string.IsNullOrWhiteSpace(inputNascita))
                dataNascita = DateTime.Parse(inputNascita);
            else
            {
                Console.Write("Anno presunto: ");
                annoPresunto = int.Parse(Console.ReadLine() ?? "0");
            }

            Console.Write("Descrizione: ");
            string descrizione = Console.ReadLine() ?? "";

            try
            {
                CatDto cat = new CatDto
                {
                    Name = nome,
                    Breed = razza,
                    IsMale = sesso,
                    DataArrivo = dataArrivo,
                    DataNascita = dataNascita,
                    AnnoPresunto = annoPresunto,
                    Descrizione = descrizione
                };
                cattery.AddCat(nome, razza, sesso, dataArrivo, dataNascita, annoPresunto, descrizione);
                Console.WriteLine("\n✅ Gatto registrato correttamente!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n⚠️ Errore: {ex.Message}");
            }
        }

        static void VisualizzaGatti(Cattery cattery)
        {
            Console.Clear();
            Console.WriteLine("📋 Elenco Gatti presenti\n");

            try
            {
                var gatti = cattery.VisualizzaGatti();

                if (gatti.Count == 0)
                {
                    Console.WriteLine("Nessun gatto presente nel gattile.");
                    return;
                }

                foreach (var cat in gatti)
                {
                    Console.WriteLine($"Codice: {cat.Codice}");
                    Console.WriteLine($"Nome: {cat.Nome}");
                    Console.WriteLine($"Razza: {cat.Razza}");
                    Console.WriteLine($"Sesso: {cat.Sesso}");
                    Console.WriteLine($"Arrivo: {cat.DataArrivo:dd/MM/yyyy}");
                    Console.WriteLine($"Descrizione: {cat.Descrizione}");
                    Console.WriteLine("--------------------------");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"⚠️ Errore durante la visualizzazione: {ex.Message}");
            }
        }
    }
}
