using GeneticSharp.Domain;
using GeneticSharp.Domain.Crossovers;
using GeneticSharp.Domain.Mutations;
using GeneticSharp.Domain.Populations;
using GeneticSharp.Domain.Selections;
using GeneticSharp.Domain.Terminations;
using System;

namespace ProblemPlecakowy
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = new Data();
            
            var selection = new EliteSelection();
            var crossover = new UniformCrossover(0.5f);
            var mutation = new FlipBitMutation();
            var fitness = new FitnessFunction(data);
            var chromosome = new Chromosome(data.ItemsCount);
            var population = new Population(50, 70, chromosome);

            var ga = new GeneticAlgorithm(population, fitness, selection, crossover, mutation);
            ga.Termination = new GenerationNumberTermination(100);

            Console.WriteLine("Rozpoczęcie wykonania algorytmu...");
            var watch = System.Diagnostics.Stopwatch.StartNew();
            ga.Start();
            watch.Stop();
            var executionTime = watch.ElapsedMilliseconds;           

            Console.WriteLine("---------Wynik---------");
            var result = new Result(ga.BestChromosome, executionTime, data.ListOfItems);
            result.DisplayResult();

            Console.ReadLine();
        }
    }
}
