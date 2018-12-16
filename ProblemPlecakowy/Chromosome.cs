using GeneticSharp.Domain.Chromosomes;

namespace ProblemPlecakowy
{
    public class Chromosome : BinaryChromosomeBase
    {
        private readonly int _length;
        public Chromosome(int length) : base(length)
        {
            _length = length;
            CreateGenes();
        }
        public override IChromosome CreateNew()
        {
            return new Chromosome(_length);
        }
    }
}
