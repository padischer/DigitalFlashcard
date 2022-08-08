using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flashcard
{
    internal class CardBox
    {
        public List<Slot> SlotList { get; set; }
        private int CurrentSlotIndex;
        public Card CurrentCard { get; private set; }



        public CardBox(List<Slot> slotList, string dataSource)
        {
            SlotList = slotList;

            string[] fileInputData = System.IO.File.ReadAllLines(dataSource);

            for (int i = 0; i < fileInputData.Length; i++)
            {
                string[] dataLine = fileInputData[i].Split(",");
                slotList[0].CardList.Add(new Card(dataLine[0], dataLine[1]));
            }
            CurrentSlotIndex = 0;
        }

        public string[] ShowPossibleTranslations()
        {
            List<Card> currentCardList = SlotList[CurrentSlotIndex].CardList;
            string[] translationList = new string[currentCardList.Count];
            for(int i = 0; i < currentCardList.Count;i++)
            {
                translationList[i] = currentCardList[i].EnglishWord;
            }
            return translationList;
        }

        public string SelectRandomWordToTranslate()
        {
            Random rnd = new Random();
            CurrentCard = SlotList[CurrentSlotIndex].CardList[rnd.Next(0, SlotList[CurrentSlotIndex].CardList.Count)];
            return CurrentCard.GermanWord;
        }

        public string Validate(string input)
        {
            string returnMessage;
            if(CurrentCard.EnglishWord == input)
            {
                if(CurrentSlotIndex != 2)
                {
                    SlotList[CurrentSlotIndex].CardList.Remove(CurrentCard);
                    CurrentSlotIndex++;
                    SlotList[CurrentSlotIndex].CardList.Add(CurrentCard);
                    CurrentSlotIndex--;
                }
                returnMessage = "Korrekt";
            }
            else
            {
                if(CurrentSlotIndex != 0)
                {
                    SlotList[CurrentSlotIndex].CardList.Remove(CurrentCard);
                    CurrentSlotIndex--;
                    SlotList[CurrentSlotIndex].CardList.Add(CurrentCard);
                }
                returnMessage = "Falsch!" + CurrentCard.EnglishWord + " wäre richtig gewesen";
            }

            return returnMessage;

        }

        public void switchSlot(int slotNumber)
        {
            CurrentSlotIndex = slotNumber-1;
        }

    }
}
