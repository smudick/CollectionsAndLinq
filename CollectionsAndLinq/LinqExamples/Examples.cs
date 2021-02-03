using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CollectionsAndLinq.LinqExamples
{
    class Examples
    {
        public void Run()
        {
            //new List of whole numbers
            var numbers = new List<int> { 12, 15, 400, 1, 3208, 19, 12, 16, 400, 23, 100 };
            var badNumbers = new List<int> { 19, 13, 666 };

            //where is like Array.filter, returns a new collection of IEnumerable<T>
            //Filtering data
            var bigNumbers = numbers.Where(number => number > 27);

            //Select is like Array.map, returns a new collection of IEnumerable<T>
            //transforming data
            var biggerNumbers = numbers.Select(number => number + 27);

            //the max item in a collection
            var biggestNumber = numbers.Max();

            //the first item of a collection  
            var firstNumber = numbers.First();

            //first matching item
            var firstMatchingNumber = numbers.First(number => number > 12);

            //contains but cooler, returns bool
            var hasReallyBigNumbers = numbers.Any(number => number > 1000000);

            //Complex/Reference types and Linq
            var animals = new List<Animal>
            {//collection initializer
                new Animal {Type = "Giraffe", HeightInInches =204, WeightInPounds = 1800 }, //object initializers
                new Animal {Type = "Tiger", HeightInInches = 40, WeightInPounds = 500},
                new Animal {Type = "Frog", HeightInInches = 3, WeightInPounds = 0},
                new Animal {Type = "Gorilla", HeightInInches = 63, WeightInPounds = 3500}
            };

            //filter data
            //materializing an IEnumerable
            //Linq by default used a concept called deferred execution to only filter/transform data just in time
            var animalsThatStartWithG = animals.Where(animal => animal.Type.StartsWith('G')).ToList();

            //transform data
            var animalDescriptions = animals.Select(animal => $"A {animal.Type} is {animal.HeightInInches} inches tall and weighs {animal.WeightInPounds}lbs");

            foreach (var description in animalDescriptions)
            {
                Console.WriteLine(description);
            }
                
            //group a selection by a given key (based on a function)
            var groupAnimals = animals.GroupBy(animal => animal.Type.First());

            foreach (var animalGroup in groupAnimals)
            {
                Console.WriteLine($"animals that start with {animalGroup.Key}");

                foreach (var animal in animalGroup)
                {
                    Console.WriteLine(animal.Type);
                }
            }

            //group and transform at the same time
            var groupAnimalNames = animals.GroupBy(animal => animal.Type.First(), animal => animal.Type);

            foreach (var animalGroup in groupAnimalNames)
            {
                Console.WriteLine($"animals that start with {animalGroup.Key}");

                foreach (var name in animalGroup)
                {
                    Console.WriteLine(name);
                }
            }


            var filteredAndTransformedAnimals = animals
                .Where(animal => animal.HeightInInches > 20)
                .Select(animal => animal.Type);

            var firstThreeNumbersAndTheSixth = numbers.Take(3).Concat(numbers.Skip(5).Take(1));

            var onlyGoodNumbers = numbers.Except(badNumbers);

            //no duplicates
            var uniqueNumbers = numbers.Distinct();


        }
    }
}
