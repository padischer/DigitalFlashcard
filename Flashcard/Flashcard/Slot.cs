using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flashcard
{
    internal class Slot
    {
        public int SlotID { get; private set; }
        public List<Card> CardList { get; private set; }



        public Slot(int slotID)
        {
            CardList = new List<Card>();
            SlotID = slotID;
        }
        public void AddCard(string wordToTranslate, string translation)
        {
            CardList.Add(new Card(wordToTranslate, translation));
        }

    }
}
