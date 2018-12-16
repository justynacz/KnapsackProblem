using GeneticSharp.Domain.Chromosomes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProblemPlecakowy
{
    public class Result
    {
        private readonly double? _fitness;
        private readonly long _time;
        private readonly IChromosome _chromosome;
        private List<int> _itemsToTake;
        private readonly List<object[]> _listOfItems;
        public Result(IChromosome chromosome, long time, List<object[]> listOfItems)
        {
            _itemsToTake = new List<int>();
            _listOfItems = listOfItems;
            _fitness = chromosome.Fitness;
            _time = time;
            _chromosome = chromosome;
            PrepareItemsToTake();
        }

        public void DisplayResult()
        {
            Console.WriteLine("Czas wykonania: " + _time.ToString()+"[ms]");
            Console.WriteLine("Wartość przedmiotów: " + _fitness.ToString());
            Console.WriteLine("Przedmioty do wzięcia: ");
            foreach (var item in _itemsToTake)
                Console.WriteLine(item.ToString());
        }
        private void PrepareItemsToTake()
        {
            var genes = _chromosome.GetGenes();
            var itemsCount = genes.Count(gene => gene.Value.ToString() == "1");
            for (int i = 0; i < _chromosome.Length; i++)
            {
                if (genes[i].Value.ToString() == "0")
                    continue;
                _itemsToTake.Add(i+1);
            }
        }
    }
}