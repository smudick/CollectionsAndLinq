using System;
using System.Collections.Generic;

namespace CollectionsAndLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            /////////////List<T> generic list//////////////////
            //Pronounced "list of T"
            //anything with angle brackets after the type name is called a generic type
            //T is a Generic Type Parameter
            //string in this case closes the generic type -- open generic type: List<>, this will not compile

            var teachers = new List<string> { "Jameka", "Dylan", "Nathan" };
            var e13 = new List<string>();
            e13.Add("Sam");
            e13.Add("Ryan");
            e13.Add("Hunter");
            e13.Add("Bailey");
            e13.Add("Wanda");

            //Common error 
            ////foreach works based on an enumerator for a type
            //foreach (var student in e13) // invalid operation exception
            //{
            //    //changes to the underlying collection are not allowed
            //    if (student == "Hunter")
            //    {
            //        e13.Remove("Hunter"); 
            //    }
            //}

            e13.AddRange(teachers);

            e13.ForEach(name => { Console.WriteLine(name); });

            e13.Remove("Wanda");

            //////////////Dictionary<TKey, TValue>/////////////
            
            //Arity (`2) -- how many generic type parameters a type has. Dictionary`2
            //Very fast information retrieval 
            //Slower information storage speeds
            //good for: infrequently updated but often read data
            //good for: loading information at startup or in the background and fast retrieval on demand (caching)

            //first parameter is type for the key, second is the type for the value
            var words = new Dictionary<string, string>
            { //collection initializer
                {"soup", "a thing i don't have right now but want." }, //key value pair
                {"cake", "a thing i don't have right now but would make me fatter." }
            };
            words.Add("Arity","how many generic type parameters a type has");

            words["Arity"] = "A thing nathan made up"; // look up an item by key using the indexer

            //cannot add multiple values with the same key

            //try add will check if a key is already in the dictionary, if there is no matching key, it will return true and add the value
            //if the key is already there, it will return false and you can specify something else

            if (!words.TryAdd("Arity", "anther definition"))
            {
                words["Arity"] = "another definition";
            }


            //Contains key checks if a value exists but doesn't do anything else
            words.ContainsKey("soup"); //true

            //Remove only takes key value as an argument
            words.Remove("cake");

            foreach (var word in words)
            {
                Console.WriteLine($"{word.Key} means {word.Value}");
            }

            //destructured
            foreach (var (word,definition) in words)
            {
                Console.WriteLine($"{word} means {definition}");
            }

            var complicatedDictionary = new Dictionary<string, List<string>>();

            complicatedDictionary.Add("Soup", new List<string>());
            var soupDefinitions = complicatedDictionary["Soup"];
            soupDefinitions.Add("This is the definition of soup");

            complicatedDictionary.Add("Arity", new List<string> { "a definition of arity" });

            foreach (var (word, definitions) in complicatedDictionary)
            {
                Console.WriteLine(word);
                foreach (var definition in definitions)
                {
                    Console.WriteLine($"\t{definition}");
                }
            }

            /////////////////Hashset<T>///////////////////
            ///Really fast retrieval, no keys
            ///enforces uniqueness, but causes no errors for things that aren't unique
            ///good for: looping
            ///good for: when you only want at most one copy of a thing, deduplication
            ///Slow information storage
            ///not super common
            ///

            var unique = new HashSet<string>(e13); //most collection constuctors take in collections and convert them

            unique.Add("Nathan"); //this gets added
            unique.Add("Nathan"); //these four get ignored
            unique.Add("Nathan");
            unique.Add("Nathan");

            unique.Remove("Nathan");


            ///////////////////Stack<T>///////////////////////
            ///LIFO - Last in first out
            ///
            var stack = new Stack<int>();
            stack.Push(5);
            stack.Push(8);
            stack.Push(1);
            stack.Push(14);
            stack.Push(2);
            stack.Push(4);

            while (stack.Count > 0)
            {
                Console.WriteLine($"currently destacking: stack : {stack.Pop()}");
            }

            ///////////////////Queue<T>///////////////////////
            ///FIFO - First in first out
            var queue = new Queue<int>();
            queue.Enqueue(5);
            queue.Enqueue(8);
            queue.Enqueue(1);
            queue.Enqueue(14);
            queue.Enqueue(2);
            queue.Enqueue(4);

            while (queue.Count > 0)
            {
                Console.WriteLine($"currently dequeueing: queue : {queue.Dequeue()}");
            }




            var a1 = new A<int>();
            var a2 = new A<string>();

            a1.DoStuff(123);
            a2.DoStuff("Other stuff");

        }
    }
    class A<T>
    {
        public void DoStuff(T thingToDo)
        {
            Console.WriteLine($"Stuff {thingToDo}");
        }
    }
}
