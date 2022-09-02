using Flashcard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashcardTest
{
    [TestClass]
    public class ProposalTest
    {
        private bool CompareCards(Card card1, Card card2)
        {
            if (card1 != null && card2 != null)
            {
                if (card1.WordToTranslate == card2.WordToTranslate && card1.Translation == card2.Translation && card1.Difficulty == card2.Difficulty && card1.PrimaryLanguage == card2.PrimaryLanguage && card1.ID == card2.ID && card1.Slot == card2.Slot)
                {
                    return true;
                }
            }
            else if (card1 == null && card2 != null)
            {
                return false;
            }
            return false;

        }

        private Card CreateCard(string wordToTranslate, string translation, CardBox.Difficulties difficulty, string key = "")
        {
            return new Card(wordToTranslate, translation, CardBox.Slots.FirstSlot, difficulty, key);
        }

        private CardBox InitCardBox(object[] saveState = null)
        {
            List<Card> sampleCardList = new List<Card>();
            sampleCardList.Add(CreateCard("Tisch", "table", CardBox.Difficulties.Basic, "rBjSo7Cp3C3TtISnYc"));
            sampleCardList.Add(CreateCard("Sonne", "sun", CardBox.Difficulties.Basic, "dkjUDlm6oa658k3mnC"));
            sampleCardList.Add(CreateCard("Stuhl", "chair", CardBox.Difficulties.Basic, "r0uj2RIS2NUQpgGXO4"));
            sampleCardList.Add(CreateCard("Schrecken", "dread", CardBox.Difficulties.Advanced, "1Uxk723tr0FzNucsO1"));
            sampleCardList.Add(CreateCard("Zorn", "wrath", CardBox.Difficulties.Advanced, "F6L8JgL70qpLFu8WlR"));
            sampleCardList.Add(CreateCard("zögern", "hesitate", CardBox.Difficulties.Advanced, "K0B9I6wEASbQX6bcOx"));
            if (saveState == null)
            {
                return new CardBox(CardBox.Slots.FirstSlot, CardBox.Languages.German, CardBox.Difficulties.Basic, sampleCardList);
            }
            return new CardBox((CardBox.Slots)saveState[0], (CardBox.Languages)saveState[1], (CardBox.Difficulties)saveState[2], sampleCardList);
        }

        [TestMethod]
        public void CompareObjectsByInstance()
        {
            var sampleBox = InitCardBox();

            var FirstCard = CreateCard("deutsch", "german", CardBox.Difficulties.Advanced);
            var SecondCard = CreateCard("deutsch", "german", CardBox.Difficulties.Advanced);

            Assert.AreEqual(FirstCard, SecondCard, "Not the same Cards");
        }

        [TestMethod]
        public void CompareObjectsByValues()
        {
            var sampleBox = InitCardBox();
            List<Card> tempList = new List<Card>();

            var FirstCard = CreateCard("deutsch", "german", CardBox.Difficulties.Advanced);
            var SecondCard = CreateCard("deutsch", "german", CardBox.Difficulties.Advanced);
            
            Assert.AreEqual(true, CompareCards(FirstCard, SecondCard), "Not the same Cards");
        }

        [TestMethod]
        public void CompareObjectsByEquals()
        {
            var FirstCard = CreateCard("deutsch", "german", CardBox.Difficulties.Advanced);
            var SecondCard = CreateCard("deutsch", "german", CardBox.Difficulties.Advanced);

            Assert.AreEqual(true, FirstCard.Equals(SecondCard), "Not the same Cards");
        }
    }
}
