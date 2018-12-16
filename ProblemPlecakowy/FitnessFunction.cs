using GeneticSharp.Domain.Chromosomes;
using GeneticSharp.Domain.Fitnesses;
using System;
using System.Collections.Generic;

namespace ProblemPlecakowy
{
    public class FitnessFunction : IFitness
    {
        private readonly List<object[]> _listOfItems;
        private double _sumOfValues = 0;
        private double _sumOfVolume = 0;
        private readonly double _knapsackVolume;
        private readonly int _itemsCount;
        public FitnessFunction(Data data)
        {
            _listOfItems = data.ListOfItems;
            _knapsackVolume = data.KnapsackVolume;
            _itemsCount = data.ItemsCount;
        }
        public double Evaluate(IChromosome chromosome)
        {
            do
            {
                Calculate(chromosome);
                if (_sumOfVolume > _knapsackVolume)
                    ChangeChromosomeGene(chromosome);
            }
            while (_sumOfVolume > _knapsackVolume);
            return _sumOfValues;
        }

        private void Calculate(IChromosome chromosome)
        {
            _sumOfValues = 0;
            _sumOfVolume = 0;
            var genes = chromosome.GetGenes();
            for(int i =0; i< genes.Length; i++)
            {
                if (genes[i].Value.ToString() == "0")
                    continue;

                var item = _listOfItems[i];
                _sumOfVolume += Double.Parse(item[1].ToString());
                _sumOfValues += Double.Parse(item[2].ToString());
            }
        }
        private void ChangeChromosomeGene(IChromosome chromosome)
        {
            var random = new Random();
            int index;
            var genes = chromosome.GetGenes();

            do
            {
                index = random.Next(0, _itemsCount);
            }
            while (genes[index].Value.ToString() == "0");

            chromosome.ReplaceGene(index, new Gene(0));
        }
    }
}
