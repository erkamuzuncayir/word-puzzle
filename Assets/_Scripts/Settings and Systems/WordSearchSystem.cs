using System.Collections.Generic;
using UnityEngine;

public class WordSearchSystem : MonoBehaviour
{
    public VoidEvent endLevel;
    public BoolEvent wordFound;
    public TextAsset dictionaryAsset;
    public SharedListString wordDictionary;
    public SharedListString submittedWords;
    public SharedListChar guessLetters;
    public SharedListString foundInDict;
    public TrieNode root = new TrieNode();
    private bool _anyPossibleWord;
    static readonly int SIZE = 26;

    private void OnEnable()
    {
        LetterManager.CheckIfPossibleWordsFromRemaining += PossibleWordSearcherDriver;
    }

    private void OnDisable()
    {
        LetterManager.CheckIfPossibleWordsFromRemaining -= PossibleWordSearcherDriver;
    }

    private void Awake()
    {
        string dictStr = dictionaryAsset.text;
        var splittedDict = dictStr.Split("\n");
        wordDictionary.sharedList = new List<string>(splittedDict);
        // insert all words of dictionary into trie
        int n = wordDictionary.sharedList.Count;
        for (int i = 0; i < n; i++)
            insert(root, wordDictionary.sharedList[i]);
    }

    public void CheckWord()
    {
        string guess = new string(guessLetters.sharedList.ToArray());
        if (guess.Length > 1 && !submittedWords.sharedList.Contains(guess))
        {
            int guessIndex = wordDictionary.sharedList.BinarySearch(guess);
            wordFound.Raise(guessIndex > -1);
        }
    }

    // Driver code
    public void PossibleWordSearcherDriver(char[] remainingLetters)
    {
        FindAllPossibleWordsInDict(remainingLetters, root, remainingLetters.Length);
        if (!_anyPossibleWord)
        {
            Debug.Log("i raised too.");
            endLevel.Raise();
        }
        else
        {
            _anyPossibleWord = false;
            foundInDict.sharedList.Clear();
        }
    }

    // trie Node
    public class TrieNode
    {
        public TrieNode[] Child = new TrieNode[SIZE];

        // isLeaf is true if the node represents
        // end of a word
        public bool leaf;

        // Constructor
        public TrieNode()
        {
            leaf = false;
            for (int i = 0; i < SIZE; i++)
                Child[i] = null;
        }
    }

    // If not present, inserts key into trie
    // If the key is prefix of trie node, just
    // marks leaf node
    void insert(TrieNode root, string Key)
    {
        int n = Key.Length;
        TrieNode pChild = root;

        for (int i = 0; i < n; i++)
        {
            int index = Key[i] - 'a';

            if (pChild.Child[index] == null)
                pChild.Child[index] = new TrieNode();

            pChild = pChild.Child[index];
        }

        // make last node as leaf node
        pChild.leaf = true;
    }

    // A recursive function to print all possible valid
    // words present in array
    void searchWord(TrieNode root, bool[] Hash,
        string str)
    {
        // if we found word in trie / dictionary
        if (root.leaf == true)
        {
            _anyPossibleWord = true;
            foundInDict.sharedList.Add(str);
        }

        // traverse all child's of current root
        for (int K = 0; K < SIZE; K++)
        {
            if (Hash[K] == true && root.Child[K] != null)
            {
                // add current character
                char c = (char)(K + 'a');

                // Recursively search reaming character
                // of word in trie
                searchWord(root.Child[K], Hash, str + c);
            }
        }
    }

    // Prints all words present in dictionary.
    void FindAllPossibleWordsInDict(char[] Arr, TrieNode root,
        int n)
    {
        // create a 'has' array that will store all
        // present character in Arr[]
        bool[] Hash = new bool[SIZE];

        for (int i = 0; i < n; i++)
            Hash[Arr[i] - 'a'] = true;

        // temporary node
        TrieNode pChild = root;

        // string to hold output words
        string str = "";

        // Traverse all matrix elements. There are only
        // 26 character possible in char array
        for (int i = 0; i < SIZE; i++)
        {
            // we start searching for word in dictionary
            // if we found a character which is child
            // of Trie root
            if (Hash[i] == true && pChild.Child[i] != null)
            {
                str = str + (char)(i + 'a');
                searchWord(pChild.Child[i], Hash, str);
                str = "";
            }
        }
    }
}
